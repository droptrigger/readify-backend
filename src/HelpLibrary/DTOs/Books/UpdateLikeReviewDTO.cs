using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLibrary.DTOs.Books
{
    public class UpdateLikeReviewDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte ReactionType { get; set; }
    }
}
