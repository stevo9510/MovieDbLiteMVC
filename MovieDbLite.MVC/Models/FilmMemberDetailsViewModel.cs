using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public class FilmMemberDetailsViewModel
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string PreferredFullName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
        public string Biography { get; set; }
        public List<FilmMemberCredits> Credits { get; set; }
        public List<FilmMemberAwardInfo> Awards { get; set; }

        public string ActualFullName 
        { 
            get
            {
                return $"{FirstName + " "}{MiddleName + " "}{LastName + " "}{Suffix}";
            }
        }
    }

    public class FilmMemberCredits
    {
        public long MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string CharacterName { get; set; }
        public short FilmRoleId { get; set; }
        public string RoleName { get; set; }
        public short? Year { get; set; }
    }

    public class FilmMemberAwardInfo
    {
        public string MovieTitle { get; set; }
        public string AwardName { get; set; }
        public string ShowName { get; set; }
        public short Year { get; set; }
    }
}
