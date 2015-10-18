using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetBay.Core;
using DotNetBay.Data.EF;
using DotNetBay.Model;

namespace DotNetBay.WebApp.Controllers
{
    public class AuctionsController : Controller
    {
        private EFMainRepository mainRepository;
        private AuctionService service;

        public AuctionsController()
        {
            this.mainRepository = new EFMainRepository();
            this.service = new AuctionService(this.mainRepository, new SimpleMemberService(this.mainRepository));
        }

        // GET: Auctions
        public ActionResult Index()
        {
            return View(this.service.GetAll().ToList());
        }

        // GET: Auctions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auctions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auction auction)
        {
            var members = new SimpleMemberService(this.mainRepository);
            auction.Seller = members.GetCurrentMember();

            var newAuction = new Auction()
            {
                Title = auction.Title,
                Description = auction.Description,
                StartDateTimeUtc = auction.StartDateTimeUtc,
                EndDateTimeUtc = auction.EndDateTimeUtc,
                StartPrice = auction.StartPrice,
                Seller = members.GetCurrentMember()
            };

            this.service.Save(newAuction);

            return RedirectToAction("Index");
        }

    }
}
