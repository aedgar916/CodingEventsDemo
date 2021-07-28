using System;
using System.ComponentModel.DataAnnotations;

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

        [Compare("NeedToRegister", ErrorMessage = "Attendees must register.")]
        public bool NeedToRegister { get; set; }
    }
}
