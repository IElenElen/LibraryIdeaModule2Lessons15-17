using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryIdeaModule2Lessons15_17
{
    public class Library
    {
        private readonly List<Book> books;

        public Library()
        {
            books = [];
        }

        public void AddBook()
        {
            Console.WriteLine();
            Console.WriteLine("Podaj tytuł książki:");
            Console.WriteLine();
            string? title = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Podaj autora książki:");
            Console.WriteLine();
            string? author = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Podaj gatunek książki:");
            Console.WriteLine();
            string? genre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine();
                Console.WriteLine("Wszystkie dane muszą być wprowadzone.");
                Console.WriteLine();
                return;
            }

            Book newBook = new(title, author, genre);
            books.Add(newBook);
            Console.WriteLine();
            Console.WriteLine("Książka została dodana.");
            Console.WriteLine();
        }

        public void RemoveBook()
        {
            Console.WriteLine();
            Console.WriteLine("Podaj tytuł książki do usunięcia:");
            Console.WriteLine();
            string? title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine();
                Console.WriteLine("Tytuł książki nie może być pusty.");
                Console.WriteLine();
                return;
            }

            var bookToRemove = books.Find(book => book.GetTitle().Equals(title, StringComparison.OrdinalIgnoreCase));
            
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine();
                Console.WriteLine("Książka została usunięta.");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Nie znaleziono książki o podanym tytule.");
                Console.WriteLine();
            }
        }

        public void SearchBooksByTitleOrAuthor()
        {
            Console.WriteLine();
            string? searchTerm = Console.ReadLine();
           
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine();
                Console.WriteLine("Wyszukiwany tytuł lub autor nie może być pusty.");
                Console.WriteLine();
                return;
            }

            var foundBooks = books.FindAll(book =>
            book.GetTitle().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            book.GetAuthor().Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nie znaleziono książek.");
                Console.WriteLine();
            }

            else
            {
                foreach (var book in foundBooks)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{book.GetTitle()} - {book.GetAuthor()} ({book.GetGenre()})");
                    Console.WriteLine();
                }
            }
        }
            public string DisplayAllBooks()
            {
                if (books == null || books.Count == 0)
                {
                    return "Brak książek w bibliotece.";
                }

                StringBuilder result = new();

                foreach (var book in books)
                {
                    result.AppendLine($"{book.GetTitle()} - {book.GetAuthor()} ({book.GetGenre()})");
                    Console.WriteLine();
                }

                return result.ToString();
            }
    }
}
