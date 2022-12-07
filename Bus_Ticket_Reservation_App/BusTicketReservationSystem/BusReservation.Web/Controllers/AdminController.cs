using BusReservation.Business.Abstract;
using BusReservation.Core;
using BusReservation.Entity;
using BusReservation.Web.Identity;
using BusReservation.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusReservation.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IBusService _busService;
        private readonly ICityService _cityService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ITripService tripService, IBusService busService, ICityService cityService, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _tripService = tripService;
            _busService = busService;
            _cityService = cityService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #region User
        public async Task<IActionResult> UserList()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public async Task<IActionResult> UserCreate()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            List<string> roles = null!;
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Fname = userModel.FirstName,
                    Lname = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email,

                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                    TempData["Message"] = Jobs.CreateMessage("Congratulations!", "The user has been successfully created.", "success");
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("UserList");
            }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.Fname,
                LastName = user.Lname,
                Email = user.Email,
                UserName = user.UserName,
                SelectedRoles = await _userManager.GetRolesAsync(user)

            };
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user != null)
                {
                    user.Fname = userModel.FirstName;
                    user.Lname = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        //Hata verme durumuna önceden tedbir alırız. "null'se boş bırakır".
                        userModel.SelectedRoles = userModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, userModel.SelectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userModel.SelectedRoles).ToArray<string>());
                        TempData["Message"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarılıdır.", "success");
                        return RedirectToAction("UserList");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                    return View(userModel);
                }
                TempData["Message"] = Jobs.CreateMessage("Hata!", "Böyle bir kullanıcı bulunamadı.", "danger");
            }
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> PasswordEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            PasswordEditModel passwordEditModel = new() { UserId = user.Id };
            return View(passwordEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> PasswordEdit(PasswordEditModel passwordEdit)
        {
            var user = await _userManager.FindByIdAsync(passwordEdit.UserId);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, passwordEdit.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Successful!", "Password has been changed successfully..", "success");
                return RedirectToAction("UserList");
            }
            return View(passwordEdit);
        }
        public async Task<IActionResult> UserDelete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Successful!", "The user has been successfully deleted.", "primary");

            }
            return RedirectToAction("UserList");
        }

        #endregion

        #region Role
        public async Task<IActionResult> RoleList()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleModel.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Successfull!", "Role is successfully created.", "success");
                    return RedirectToAction("RoleList");

                }
            }

            return View(roleModel);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var users = await _userManager.Users.ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            var members = new List<User>();
            var nonMembers = new List<User>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    members.Add(user);
                }
                else
                {
                    nonMembers.Add(user);
                }
            }
            RoleDetails roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect($"/Admin/RoleEdit/{roleEditModel.RoleId}");
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    TempData["Message"] = Jobs.CreateMessage("Delete failed!", "There are users in this role, you must first delete the users.", "danger");
                    return RedirectToAction("RoleList");
                }
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Delete successful!", "The role has been successfully deleted.", "success");
            }
            return RedirectToAction("RoleList");
        }

        #endregion

        #region Trip

        public async Task<IActionResult> TripList()
        {
            var trips = await _tripService.GetAllAsync();
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View(trips);
        }

        public async Task<IActionResult> TripCreate()
        {
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.Buses = await _busService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TripCreate(TripModel tripModel, int bus, int departureCity, int arrivalCity)
        {
            if (ModelState.IsValid)
            {
                Trip trip = new Trip()
                {
                    DepartureTime = tripModel.DepartureTime,
                    ReservationDate = tripModel.ReservationDate,
                    TicketPrice = tripModel.TicketPrice,
                    DepartureCityId = departureCity,
                    ArrivalCityId = arrivalCity,
                    EstimatedTime = tripModel.EstimatedTime,
                    BusId = bus,
                };
                await _tripService.CreateAsync(trip);
                TempData["Message"] = Jobs.CreateMessage("Congratulations!", "Trip has been successfully created.", "success");
                return RedirectToAction("TripList");
            }
            if (tripModel.BusId == null)
            {
                ViewBag.BusErrorMessage = "Please Choose a Bus!";
            }
            return View(tripModel);
        }
        [HttpGet]
        public async Task<IActionResult> TripEdit(int id)
        {
            Trip trip = await _tripService.GetByIdAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            TripModel tripModel = new TripModel()
            {
                TripId = trip.TripId,
                DepartureTime = trip.DepartureTime,
                ReservationDate = trip.ReservationDate,
                TicketPrice = trip.TicketPrice,
                EstimatedTime = trip.EstimatedTime,
                BusId = trip.BusId,
                ArrivalCityId = trip.ArrivalCityId,
                DepartureCityId = trip.DepartureCityId,
            };
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.Buses = await _busService.GetAllAsync();
            return View(tripModel);
        }
        [HttpPost]
        public async Task<IActionResult> TripEdit(TripModel tripModel, int bus, int departureCity, int arrivalCity, int id)
        {
            if (ModelState.IsValid)
            {
                Trip trip = await _tripService.GetByIdAsync(id);
                if (trip == null) { return NotFound(); }
                trip.DepartureTime = tripModel.DepartureTime;
                trip.ReservationDate = tripModel.ReservationDate;
                trip.TicketPrice = tripModel.TicketPrice;
                trip.EstimatedTime = tripModel.EstimatedTime;
                trip.DepartureCityId = departureCity;
                trip.ArrivalCityId = arrivalCity;
                trip.BusId = bus;
                await _tripService.UpdateAsync(trip);
                return RedirectToAction("TripList");
            }
            return RedirectToAction("TripEdit");
        }
        public async Task<IActionResult> TripDelete(int id)
        {
            Trip trip = await _tripService.GetByIdAsync(id);
            if (trip == null) { return NotFound(); }
            _tripService.Delete(trip);
            return RedirectToAction("TripList");
        }

        #endregion

        #region City

        public async Task<IActionResult> CityList()
        {
            return View(await _cityService.GetAllAsync());
        }
        public IActionResult CityCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CityCreate(CityModel cityModel)
        {
            
            if (ModelState.IsValid)
            {
                City city = new City()
                {
                    CityName = cityModel.CityName,
                };
                await _cityService.CreateCityAsync(city);
                return RedirectToAction("CityList");
            }
            return View(cityModel);
        }
        public async Task<IActionResult> CityEdit(int id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city == null) { return NotFound(); }
            CityModel cityModel = new CityModel()
            {
                CityId = city.CityId,
                CityName = city.CityName,
            };
            return View(cityModel);
        }
        [HttpPost]
        public async Task<IActionResult> CityEdit(CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                City city = await _cityService.GetByIdAsync(cityModel.CityId);
                if (city == null) { return NotFound(); }
                city.CityId = cityModel.CityId;
                city.CityName = cityModel.CityName;
                _cityService.Update(city);
                return RedirectToAction("CityList");
            }
            return RedirectToAction("CityEdit");

        }
        public async Task<IActionResult> CityDelete(int id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city == null) { return NotFound(); }
            _cityService.Delete(city);
            return RedirectToAction("CityList");
        }

        #endregion

        #region Bus
        public async Task<IActionResult> BusList()
        {
            return View(await _busService.GetAllAsync());
        }
        public IActionResult BusCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BusCreate(BusModel busModel)
        {
            if (ModelState.IsValid)
            {
                Bus bus = new()
                {
                    BusName = busModel.BusName,
                    TotalSeats = busModel.Capacity,
                };
                await _busService.CreateAsync(bus);
                return RedirectToAction("BusList");

            }
            return View(busModel);
        }
        public async Task<IActionResult> BusEdit(int id)
        {
            Bus bus = await _busService.GetByIdAsync(id);
            if (bus == null) { return NotFound(); }
            BusModel busModel = new()
            {
                BusId = bus.BusId,
                BusName = bus.BusName,
                Capacity = bus.TotalSeats,

            };
            return View(busModel);
        }
        [HttpPost]
        public async Task<IActionResult> BusEdit(BusModel busModel)
        {
            if (ModelState.IsValid)
            {
                Bus bus = await _busService.GetByIdAsync(busModel.BusId);
                if (bus == null) { return NotFound(); }
                bus.BusId = busModel.BusId;
                bus.BusName = busModel.BusName;
                bus.TotalSeats = busModel.Capacity;
                _busService.Update(bus);
                return RedirectToAction("BusList");
            }
            return RedirectToAction("BusEdit");
        }
        public async Task<IActionResult> BusDelete(int id)
        {
            Bus bus = await _busService.GetByIdAsync(id);
            if (bus == null) { return NotFound(); }
            _busService.Delete(bus);
            return RedirectToAction("BusList");
        }
        #endregion

    }
}
