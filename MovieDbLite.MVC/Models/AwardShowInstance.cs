using System;
using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardShowInstance
    {
        public AwardShowInstance()
        {
            AwardWinner = new HashSet<AwardWinner>();
        }

        public int Id { get; set; }
        public short AwardShowId { get; set; }
        public short Year { get; set; }
        public DateTime DateHosted { get; set; }

        public string FriendlyName { get { return $"{AwardShow?.ShowName} - {Year}"; } }

        public virtual AwardShow AwardShow { get; set; }
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
