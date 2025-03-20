using HelpLibrary.DTOs.Library;
using HelpLibrary.Entities;

namespace ServerLibrary.Helpers.Converters
{
    public static class ConvertToBookmarkDTO
    {
        public static BookmarkDTO Convert(Bookmark bookmark)
        {
            if (bookmark == null)
                return null!;

            return new BookmarkDTO
            {
                Id = bookmark.Id,
                IdLibrary = bookmark.IdLibrary,
                Page = bookmark.Page,
                Comment = bookmark.Comment,
                CreatedAt = bookmark.CreatedAt
            };
        }
    }
}
