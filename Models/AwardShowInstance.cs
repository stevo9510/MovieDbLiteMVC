using System;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardShowInstance
    {
        public int Id { get; set; }
        public int AwardShowId { get; set; }
        public string Year { get; set; }
        public DateTime DateHosted { get; set; }

        public virtual AwardShow AwardShow { get; set; }
    }
}
