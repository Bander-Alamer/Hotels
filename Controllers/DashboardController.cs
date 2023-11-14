using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hotels.Controllers
{
    public class DashboardController : Controller
    {

        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {

            _context = context;

        }

		public IActionResult room()
		{

			var hotel = _context.hotel.ToList();
             ViewBag.hotel = hotel;

            var rooms = _context.rooms.ToList();
			return View(rooms);
		}

		public IActionResult Roomdetaile()
		{

			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;

			var rooom = _context.rooms.ToList();
			ViewBag.rooms = rooom;


			var roomsD = _context.roomDetailes.ToList();

			return View(roomsD);

		

		}

		public IActionResult Update(Hotel hotel)
		{

			_context.hotel.Update(hotel);
			_context.SaveChanges();


			return RedirectToAction("Index");

		}

		public IActionResult Edit(int id)
		{

			var hoteledit = _context.hotel.SingleOrDefault(x => x.Id == id);

			return View(hoteledit);



		}



		[HttpPost]
		public IActionResult Index(string city)
		{
			var hotel = _context.hotel.Where(x=> x.City.Equals(city));
			return View(hotel);
		}

		public IActionResult CreatNewRoom(Rooms rooms)
		{

			_context.rooms.Add(rooms);
            _context.SaveChanges();


			return RedirectToAction("room");
		}

		public IActionResult CreatNewDetaileRoom(RoomDetailes roomsD)
		{

			_context.roomDetailes.Add(roomsD);
			_context.SaveChanges();


			return RedirectToAction("Roomdetaile");
		}


		[Authorize]
		public IActionResult Index()
        {
			var hotel = _context.hotel.ToList();
			return View(hotel);

        }




		public IActionResult SearchHotel(string city)
		{

			var chickhotel = _context.hotel.FirstOrDefault(item => item.City.Contains(city));
		

			if (chickhotel == null)
			
				TempData["found"] = "no";
			
				
			else

				TempData["found"] = "ok";


			
			return RedirectToAction("Index" , chickhotel);
		}




		public IActionResult Delete(int id)
        {
			var hoteldelete = _context.hotel.SingleOrDefault(x => x.Id == id);

            if(hoteldelete != null) {

			_context.hotel.Remove(hoteldelete);
			_context.SaveChanges();
                TempData["del"] = "ok";

			}
			return RedirectToAction("Index");

		}


		public IActionResult CreatNewHotel(Hotel hotels)
        {
            _context.hotel.Add(hotels);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

