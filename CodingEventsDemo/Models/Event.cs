using System;
namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumberOfAttendees { get; set; }
        public string ContactEmail { get; set; }
        public bool NeedToRegister { get; set; }
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }

        public int Id { get; set; }

        public Event()
        {
        }

        public Event(string name, string description, string location, int numberOfAttendees, string contactEmail, bool needToRegister)
        {
            Name = name;
            Description = description;
            Location = location;
            NumberOfAttendees = numberOfAttendees;
            ContactEmail = contactEmail;
            NeedToRegister = needToRegister;
            
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
