namespace LibraryIdeaModule2Lessons15_17
{
    public class Program
    {
        static void Main(string[] _)
        {
            Book newBook = new(" ", " ", " ");
            Library library = new();

            bool exit = false;

            static bool ExecuteAction(Action action)
            {
                action();
                return false; 
            }

            while (!exit) 
            {
                Console.Clear();
                Console.WriteLine("Library.");
                Console.WriteLine();
                Console.WriteLine("Wskaż pożądaną opcję: ");
                Console.WriteLine();
                Console.WriteLine("1. Dodaj książkę: tytuł, autor, gatunek literacki.");
                Console.WriteLine();
                Console.WriteLine("2. Usuń książkę (o tytule).");
                Console.WriteLine();
                Console.WriteLine("3. Wyszukaj wg tytułu lub autora: ");
                Console.WriteLine();
                Console.WriteLine("4. Wyświetl wszystkie książki z biblioteki: ");
                Console.WriteLine();
                Console.WriteLine("5. Wyjdź z programu.");
                Console.WriteLine();

                string? userInput = Console.ReadLine();

                exit = userInput switch
                {
                    "1" => ExecuteAction(library.AddBook),
                    "2" => ExecuteAction(library.RemoveBook),
                    "3" => ExecuteAction(library.SearchBooksByTitleOrAuthor),
                    "4" => ExecuteAction(() => Console.WriteLine(library.DisplayAllBooks())),
                    "5" => true, 
                    _ => false 
                };

                if(!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij Enter, aby kontynuować...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Zamykanie programu...");
        }
    }
}
