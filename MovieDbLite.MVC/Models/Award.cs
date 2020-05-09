using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class Award
    {
        public Award()
        {
            AwardWinner = new HashSet<AwardWinner>();
        }

        [Key]
        public int Id { get; set; }
        public short AwardShowId { get; set; }
        [Required]
        [StringLength(50)]
        public string AwardName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public string FriendlyName
        {
            get
            {
                string awardShowDetail = AwardShow != null ? $"({AwardShow.ShowName})" : "";
                return $"{AwardName} {awardShowDetail}";
            }
        }

        [ForeignKey(nameof(AwardShowId))]
        [InverseProperty("Award")]
        public virtual AwardShow AwardShow { get; set; }
        [InverseProperty("Award")]
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
