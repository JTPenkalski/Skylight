using System;

namespace Skylight.Models
{
    public class StormTracker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? About { get; set; }
        public DateTime StartDate { get; set; }
        public Uri? Picture { get; set; }

        public StormTracker(int id, string firstName, string? middleName, string lastName, string? about, DateTime startDate, Uri? picture)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            About = about;
            StartDate = startDate;
            Picture = picture;
        }
    }
}