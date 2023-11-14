using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotels.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult CreatNewRecord(Hotel hotel)
        {



            _context.hotel.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
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

        public IActionResult Delete(int id)
        {
             
            var hoteldelete= _context.hotel.SingleOrDefault(x=>x .Id==id);
            _context.hotel.Remove(hoteldelete);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }




        public IActionResult Index()

        {

            var hotel = _context.hotel.ToList();
            return View(hotel);
        }

    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}