﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieCrewMember
    {
        [Key]
        public long MovieId { get; set; }
        [Key]
        public long FilmMemberId { get; set; }
        [Key]
        public short FilmRoleId { get; set; }

        [ForeignKey(nameof(FilmMemberId))]
        [InverseProperty("MovieCrewMember")]
        public FilmMember? FilmMember { get; set; }
        [ForeignKey(nameof(FilmRoleId))]
        [InverseProperty("MovieCrewMember")]
        public FilmRole? FilmRole { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieCrewMember")]
        public Movie? Movie { get; set; }
    }
}
