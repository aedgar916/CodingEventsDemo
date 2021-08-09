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

namespace CodingEventsDemo.Controllers
{
    public class TagController : Controller
    {
        private EventDbContext _context;

        public TagController(EventDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Tag> tags = _context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }

        public IActionResult AddEvent(int id)
        {
            Event theEvent = _context.Events.Find(id);
            List<Tag> possibleTags = _context.Tags.ToList();

            AddEventTagViewModel addEventTagViewModel = new AddEventTagViewModel(theEvent, possibleTags);

            return View(addEventTagViewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel addEventTagViewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = addEventTagViewModel.EventId;
                int tagId = addEventTagViewModel.TagId;

                List<EventTag> existingTags = _context.EventTags
                    .Where(et => et.EventId == eventId)
                    .Where(et => et.TagId == tagId)
                    .ToList();

                if (existingTags.Count == 0)
                {
                    EventTag eventTag = new EventTag
                    {
                        EventId = eventId,
                        TagId = tagId
                    };

                    _context.EventTags.Add(eventTag);
                    _context.SaveChanges();

                }

                return Redirect("/Events/Detail/" + eventId);
            }

            return View(addEventTagViewModel);
        }

        public IActionResult Detail(int id)
        {
            List<EventTag> eventTags = _context.EventTags
                .Where(et => et.TagId == id)
                .Include(et => et.Event)
                .Include(et => et.Tag)
                .ToList();

            return View(eventTags);
        }
    }
}
