using System;

namespace MovieDbLite.Models
{
    public partial class FilmMemberAward
    {
        public long FilmMemberId { get; set; }
        public int AwardId { get; set; }
        public long MovieId { get; set; }
        public string Year { get; set; }
        public DateTime DateReceived { get; set; }

        public virtual Award Award { get; set; }
        public virtual FilmMember FilmMember { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
