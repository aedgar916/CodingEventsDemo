using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage ="Please enter a category name.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Name must be 3 - 20 characters long.")]
        public string Name { get; set; }
    }
}
