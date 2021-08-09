using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class EventDetailViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumberOfAttendees { get; set; }
        public string ContactEmail { get; set; }
        public bool NeedToRegister { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }


        public EventDetailViewModel(Event theEvent, List<EventTag> eventTags)
        {
            EventId = theEvent.Id;
            Name = theEvent.Name;
            Description = theEvent.Description;
            Location = theEvent.Location;
            NumberOfAttendees = theEvent.NumberOfAttendees;
            ContactEmail = theEvent.ContactEmail;
            NeedToRegister = theEvent.NeedToRegister;
            CategoryName = theEvent.Category.Name;

            TagText = "";

            for (int i = 0; i < eventTags.Count; i++)
            {
                TagText += "#" + eventTags[i].Tag.Name;

                if (i < eventTags.Count -1)
                {
                    TagText += ", ";
                }
            }
        }
    }
}
