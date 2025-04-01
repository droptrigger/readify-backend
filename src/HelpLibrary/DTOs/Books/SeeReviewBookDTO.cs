using HelpLibrary.DTOs.Reviews;
using HelpLibrary.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpLibrary.DTOs.Books
{
    public class SeeReviewBookDTO
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Автор отзыва
        /// </summary>
        public AuthorDTO? Author { get; set; }

        /// <summary>
        /// Id книги, на которую сделан отзыв
        /// </summary>
        public int IdBook { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? Comment { get; set; } = null!;

        /// <summary>
        /// Поставленная оценка книге
        /// </summary>
        public byte? Rating { get; set; }

        /// <summary>
        /// Дата написания отзыва
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Список лайков отзыва
        /// </summary>
        public List<LikeDTO>? Likes { get; set; }
    }
}
