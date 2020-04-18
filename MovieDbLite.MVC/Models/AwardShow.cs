using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardShow
    {
        public AwardShow()
        {
            Award = new HashSet<Award>();
            AwardShowInstance = new HashSet<AwardShowInstance>();
        }

        public short Id { get; set; }
        [Display(Name = "Show")]
        public string ShowName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Award> Award { get; set; }
        public virtual ICollection<AwardShowInstance> AwardShowInstance { get; set; }
    }
}
