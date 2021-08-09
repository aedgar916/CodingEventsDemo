using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _context;

        public EventsController(EventDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = _context.Events
                .Include(e => e.Category)
                .ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            List<EventCategory> categories = _context.Category.ToList();

            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = _context.Category.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Location = addEventViewModel.Location,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees,
                    Category = theCategory,
                    ContactEmail = addEventViewModel.ContactEmail,
                    NeedToRegister = addEventViewModel.NeedToRegister
                };

                _context.Events.Add(newEvent);
                _context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = _context.Events.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = _context.Events.Find(eventId);
                _context.Events.Remove(theEvent);
            }

            _context.SaveChanges();

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event EditEvent = _context.Events.Find(eventId);
            ViewBag.editEvent = EditEvent;
            ViewBag.title = $"Edit Event {EditEvent.Name} (id = {EditEvent.Id})";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string location, int numberOfAttendees, string email)
        {
            Event EditEvent = _context.Events.Find(eventId);
            EditEvent.Name = name;
            EditEvent.Description = description;
            EditEvent.Location = location;
            EditEvent.NumberOfAttendees = numberOfAttendees;
            EditEvent.ContactEmail = email;
            

            _context.SaveChanges();

            return Redirect("/Events");
        }
    }
}
