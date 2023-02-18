using System;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a person who tracks their participation in weather experiences.
    /// </summary>
    public class StormTracker : BaseIdentifiableModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Biography { get; set; }
        public DateTime StartDate { get; set; }
        public string? PicturePath { get; set; }

        /// <summary>
        /// Constructs a new <see cref="StormTracker"/> instance.
        /// </summary>
        /// <param name="firstName">The person's first name.</param>
        /// <param name="lastName">The person's last name.</param>
        /// <param name="biography">A brief description about the person.</param>
        /// <param name="startDate">The date the user joined Skylight.</param>
        /// <param name="picturePath">The file path storing the user's profile picture.</param>
        public StormTracker(string firstName, string lastName, string? biography, DateTime startDate, string? picturePath)
        {
            FirstName = firstName;
            LastName = lastName;
            Biography = biography;
            StartDate = startDate;
            PicturePath = picturePath;
        }
    }
}