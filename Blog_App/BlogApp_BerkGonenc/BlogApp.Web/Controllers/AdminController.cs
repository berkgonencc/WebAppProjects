using BlogApp.Business.Abstract;
using BlogApp.Core;
using BlogApp.Entity;
using BlogApp.Web.Identity;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IPostService postService, ICategoryService categoryService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _postService = postService;
            _categoryService = categoryService;
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
            List<string> roles = null;
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
                    TempData["Message"] = Jobs.CreateMessage("Congrats!", "The user has been created!", "success");
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

        #region Post
        public async Task<IActionResult> PostList()
        {
            List<Post> posts = await _postService.GetAll();
            return View(posts);
        }
        public async Task<IActionResult> PostWrite()
        {
            ViewBag.Categories = await _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostWrite(PostWithCategoriesModel postModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                var url = Jobs.MakeUrl(postModel.Title);
                var summary = postModel.PostContent.Substring(0, 100);
                Post post = new Post()
                {
                    Title = postModel.Title,
                    PostContent = postModel.PostContent,
                    Slug = url,
                    ImageUrl = Jobs.UploadImage(file, url),
                    IsPublished = postModel.IsPublished,
                    Summary = summary
                };
                await _postService.CreateAsync(post, categoryIds);
                TempData["Message"] = Jobs.CreateMessage("Congrats!", "Post is successfully created.", "info");
                return RedirectToAction("Index", "Home");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            if (file == null)
            {
                ViewBag.ImageErrorMessage = "Please choose an image!";
            }
            ViewBag.Categories = await _categoryService.GetAll();
            return View(postModel);
        }
        public async Task<IActionResult> PostEdit(int id)
        {
            Post post = await _postService.GetPostWithCategoriesAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            PostWithCategoriesModel postModel = new()
            {
                Id = post.Id,
                Title = post.Title,
                PostContent = post.PostContent,
                ImageUrl = post.ImageUrl,
                IsPublished = post.IsPublished,
                SelectedCategories = post.PostCategories.Select(pc => pc.Category).ToList()
            };
            ViewBag.Categories = await _categoryService.GetAll();
            return View(postModel);
        }
        [HttpPost]
        public async Task<IActionResult> PostEdit(PostWithCategoriesModel postModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                var url = Jobs.MakeUrl(postModel.Title);
                if (file != null)
                {
                    postModel.ImageUrl = Jobs.UploadImage(file, url);
                }
                Post post = await _postService.GetById(postModel.Id);
                if (post == null)
                {
                    return NotFound();
                }

                post.Title = postModel.Title;
                post.PostContent = postModel.PostContent;
                post.Slug = url;
                post.IsPublished = postModel.IsPublished;
                if (file != null)
                {
                    post.ImageUrl = postModel.ImageUrl;
                }
                await _postService.UpdateAsync(post, categoryIds);
                TempData["Message"] = Jobs.CreateMessage("Congrats!", "Post is updated!", "success");
                return RedirectToAction("PostList");
            }
            if (file == null)
            {
                Post post = await _postService.GetById(postModel.Id);
                if (post == null)
                {
                    return NotFound();
                }
                postModel.ImageUrl = post.ImageUrl;
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            }
            else
            {
                postModel.SelectedCategories = categoryIds.Select(c => new Category() { Id = c }).ToList();
            }
          
            ViewBag.Categories = await _categoryService.GetAll();
            return View(postModel);

        }
        public async Task<IActionResult> UpdateIsPublished(int id)
        {
            Post post = await _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            await _postService.UpdateIsPublishedAsync(post);
            return RedirectToAction("PostList");
        }
        public async Task<IActionResult> PostDelete(int id)
        {
            Post post = await _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            _postService.Delete(post);
            return RedirectToAction("PostList");
        }
        #endregion

        #region Category
        public async Task<IActionResult> CategoryList()
        {
            List<Category> categories = await _categoryService.GetAll();
            return View(categories);

        }
        public async Task<IActionResult> CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                Category category = new Category()
                {
                    Name = categoryModel.Name,
                    Description = categoryModel.Description,
                    Slug = url
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);
        }
        public async Task<IActionResult> CategoryDelete(int id)
        {
            Category category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var category = await _categoryService.GetById(id);
            CategoryModel categoryModel = new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            return View(categoryModel);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                string url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                var category = await _categoryService.GetById(categoryModel.Id);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = categoryModel.Name;
                category.Description = categoryModel.Description;
                category.Slug = url;
                await _categoryService.UpdateAsync(category);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);
        }

        #endregion
    }

}
