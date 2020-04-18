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
        public short AwardShowId { get; set; }
        public string AwardName { get; set; }
        public string Description { get; set; }

        public string FriendlyName
        {
            get
            {
                string awardShowDetail = AwardShow != null ? $"({AwardShow.ShowName})" : "";
                return $"{AwardName} {awardShowDetail}";
            }
        }

        public virtual AwardShow AwardShow { get; set; }
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
