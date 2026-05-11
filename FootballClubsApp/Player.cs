using System;

namespace FootballClubsApp
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }   // отделно
        public string LastName { get; set; }    // отделно
        public string FullName => $"{FirstName} {LastName}"; // read-only, за DataGridView
        public DateTime BirthDate { get; set; }
        public int ClubId { get; set; }
        public string Position { get; set; }
        public int? ShirtNumber { get; set; }
        public string Status { get; set; }
    }
}