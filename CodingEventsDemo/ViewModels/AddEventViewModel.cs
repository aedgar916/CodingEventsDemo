using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description can be no longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event location is required.")]
        public string Location { get; set; }

        [Range(0, 100000, ErrorMessage = "Cannot be more than 100,000 attendees.")]
        public int NumberOfAttendees { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public bool IsTrue { get { return true; } }

        [Compare("IsTrue", ErrorMessage = "Attendees must register.")]
        public bool NeedToRegister { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    });
            }
        }

        public AddEventViewModel()
        {
        }
    }
}
