using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryIdeaModule2Lessons15_17
{
    public class Book
    {
        private readonly string? _title;
        private readonly string? _author;
        private readonly string? _genre;

        public Book(string? title, string? author, string? genre)
        {
            _title = title;
            _author = author;
            _genre = genre;
        }

        public string? GetTitle() => _title;
        public string? GetAuthor() => _author;
        public string? GetGenre() => _genre;
    }
}
