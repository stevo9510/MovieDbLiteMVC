using System.Collections.Generic;

namespace MovieDbLite.Models
{
    public partial class AwardShow
    {
        public AwardShow()
        {
            Award = new HashSet<Award>();
        }

        public int Id { get; set; }
        public string ShowName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Award> Award { get; set; }
    }
}
