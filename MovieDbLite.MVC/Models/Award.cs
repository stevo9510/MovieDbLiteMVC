using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class Award
    {
        public Award()
        {
            AwardWinner = new HashSet<AwardWinner>();
        }

        public int Id { get; set; }
        public int AwardShowId { get; set; }
        public string AwardName { get; set; }
        public string Description { get; set; }

        public virtual AwardShow AwardShow { get; set; }
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
