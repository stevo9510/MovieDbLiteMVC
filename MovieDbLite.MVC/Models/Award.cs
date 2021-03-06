﻿using MovieDbLite.MVC.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class Award : AwardBase
    {
        public Award()
        {
            AwardWinner = new HashSet<AwardWinner>();
        }

        [ForeignKey(nameof(AwardShowId))]
        [InverseProperty("Award")]
        public AwardShow? AwardShow { get; set; }
        [InverseProperty("Award")]
        public ICollection<AwardWinner> AwardWinner { get; set; }
    }
}
