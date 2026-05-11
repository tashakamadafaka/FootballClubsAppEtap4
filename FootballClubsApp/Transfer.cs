using System;

namespace FootballClubsApp
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int? FromClubId { get; set; }
        public string FromClubName { get; set; }
        public int ToClubId { get; set; }
        public string ToClubName { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal Fee { get; set; }
        public string Note { get; set; }
    }
}
