using BusReservation.Business.Abstract;
using BusReservation.Core;
using BusReservation.Entity;
using BusReservation.Web.Models;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Iyzipay;
using System.Threading.Tasks;

namespace BusReservation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IBusService _busService;
        private readonly ICityService _cityService;
        private readonly ITicketService _ticketService;
        private readonly IPassengerService _passengerService;

        public HomeController(ITripService tripService, IBusService busService, ICityService cityService, ITicketService ticketService, IPassengerService passengerService)
        {
            _tripService = tripService;
            _busService = busService;
            _cityService = cityService;
            _ticketService = ticketService;
            _passengerService = passengerService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View();
        }
        public IActionResult Help()
        {

            return View();
        }

        public async Task<IActionResult> Explore()
        {
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View();
        }
        public async Task<IActionResult> FindBusTicket(string departureCity, string arrivalCity, string tripDate)
        {
            List<Trip> trips = await _tripService.GetReservationListAsync(departureCity, arrivalCity, tripDate);
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View(trips);
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int id)
        {
            Trip trip = await _tripService.GetByIdAsync(id);
            List<Ticket> seats = await _ticketService.GetSelectedSeatsByResId(id);
            PurchaseModel purchaseModel = new PurchaseModel()
            {
                Trip = trip,
                SelectedSeats = seats

            };
            ViewBag.Buses = await _busService.GetAllAsync();
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View(purchaseModel);
        }
        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseModel purchaseModel, int seatNumber, int id)
        {
            var trip = await _tripService.GetByIdAsync(id);
            purchaseModel.Trip = new Trip()
            {
                DepartureCity = trip.DepartureCity,
                ArrivalCity = trip.ArrivalCity,
                ReservationDate = trip.ReservationDate,
                DepartureTime = trip.DepartureTime,
                TicketPrice = trip.TicketPrice,
                
            };
            TicketModel ticket = new() { 
                Id = purchaseModel.Id,
                Fname = purchaseModel.Fname,
                Lname = purchaseModel.Lname,
                SeatNo = seatNumber,
            };
            if (ModelState.IsValid && seatNumber != 0)
            {
                Passenger passenger = new Passenger()
                {
                    Fname = purchaseModel.Fname,
                    Lname = purchaseModel.Lname,
                    Email = purchaseModel.Email,
                    PhoneNumber = purchaseModel.PhoneNumber,
                };
                await _passengerService.CreateAsync(passenger, seatNumber, id);
            }
            if (ModelState.IsValid && seatNumber != 0)
            {
                var payment = PaymentProcess(purchaseModel);
                if (payment.Status == "success")
                {
                    TempData["Message"] = Jobs.CreateMessage("Payment successfully completed!", "Thank you for your payment. Your transaction has been completed, and a receipt for your purchase has been emailed to you. You can download the ticket from the link below.", "success");
                    return RedirectToAction("CompletedReservation", ticket);
                }
                else
                {
                    TempData["Message"] = Jobs.CreateMessage("Payment faild!", payment.ErrorMessage, "danger");
                }
            }
            TempData["Message"] = Jobs.CreateMessage("Failed", "Please fill in the information below!", "warning");
            return RedirectToAction("Purchase");
        }
        public async Task<IActionResult> DestinationList()
        {
            return View(await _cityService.GetAllAsync());
        }
        public async Task<IActionResult> CompletedReservation(TicketModel ticket)
        {
            var trip = await _tripService.GetByIdAsync(ticket.Id);
            var newt = new TicketModel
            {
                Fname = ticket.Fname,
                Lname = ticket.Lname,
                Trip = trip,
                SeatNo = ticket.SeatNo
            };
            ViewBag.Cities = await _cityService.GetAllAsync();
            return View(newt);
        }
        private Payment PaymentProcess(PurchaseModel purchaseModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-qUDnJ0UQi9WgAi6mLDI2FIs8gXIYgBnB";
            options.SecretKey = "sandbox-tNjBQtjsMGxFPCQu4vdTNzFIgSiJkGSW";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = purchaseModel.Trip.TicketPrice.ToString();
            request.PaidPrice = purchaseModel.Trip.TicketPrice.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = purchaseModel.CardHolderName;
            paymentCard.CardNumber = purchaseModel.CardNumber;
            paymentCard.ExpireMonth = purchaseModel.ExpirationMonth;
            paymentCard.ExpireYear = purchaseModel.ExpirationYear;
            paymentCard.Cvc = purchaseModel.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = purchaseModel.Fname;
            buyer.Surname = purchaseModel.Lname;
            buyer.GsmNumber = purchaseModel.PhoneNumber;
            buyer.Email = purchaseModel.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul";
            buyer.Ip = "85.34.78.112";
            buyer.City = "İstanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = purchaseModel.Trip.TicketPrice.ToString();
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            return Payment.Create(request, options);
        }



    }
}