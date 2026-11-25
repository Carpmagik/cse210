using System;

/// extra effort was used through the collection initializers 
/// to allow more verses to be used.
class Program
{
    static void Main(string[] args)
    {
        Scripture[] scriptures =
        {
            // I tried to reuse the starting code (like 'while(true)') from the journal assignment.
            // I learned about collection initializers because I wanted to add a random verses
            // each time the programe starts
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "And it shall come to pass that whosoever will believe in the Lord shall be saved."
            ),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."
            ),
            new Scripture(
                new Reference("Moses", 1, 39),
                "For behold, this is the work and the glory of God, to bring to pass the immortality and eternal life of man."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Length)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Program complete, all words hidden.");
                break;
            }

            Console.WriteLine("Press Enter to hide words or type 'quit' to end the program.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            // This hides three random words in the scripture.
            scripture.HideRandomWords(3);
        }
    }
}