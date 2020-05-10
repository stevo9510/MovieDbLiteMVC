using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardShowInstance
    {
        public AwardShowInstance()
        {
            AwardWinner = new HashSet<AwardWinner>();
        }

        [Key]
        public int Id { get; set; }
        public short AwardShowId { get; set; }
        public short Year { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateHosted { get; set; }
        public string FriendlyName { get { return $"{AwardShow?.ShowName} - {Year}"; } }

        [ForeignKey(nameof(AwardShowId))]
        [InverseProperty("AwardShowInstance")]
        public AwardShow? AwardShow { get; set; }
        [InverseProperty("AwardShowInstance")]
        public ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
