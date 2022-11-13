using System;

namespace Skylight.Models
{
    public class StormTracker
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Biography { get; set; }
        public DateTime StartDate { get; set; }
        public string? PicturePath { get; set; }

        public StormTracker(string firstName, string? middleName, string lastName, string? biography, DateTime startDate, string? picturePath)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Biography = biography;
            StartDate = startDate;
            PicturePath = picturePath;
        }
    }
}