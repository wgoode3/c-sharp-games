using System;
using System.ComponentModel.DataAnnotations;

namespace Videogames.Models
{
    public class Videogame
    {
        [Key]
        public int VideogameId {get;set;}

        [Required(ErrorMessage="Title is required!")]
        public string title {get;set;}
        
        [Required(ErrorMessage="Year is required!")]
        [Range(1950, 2019, ErrorMessage="Year must be between 1950 and 2019!")]
        public int year {get;set;}
        
        [Required(ErrorMessage="Genre is required!")]
        public string genre {get;set;}
        
        [Required(ErrorMessage="Studio is required!")]
        [MinLength(2, ErrorMessage="Studio must be 2 characters or longer!")]
        public string studio {get;set;}

        public DateTime createdAt {get;set;} = DateTime.Now;
        public DateTime updatedAt {get;set;} = DateTime.Now;
    }
}