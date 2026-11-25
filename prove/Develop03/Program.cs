using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture[] scriptures =
        {

            /// I rerused the starting code (like 'while(true)') from the journal assignment.
            /// I learned was that collection initializers allow you 
            /// to create a list in a condensed way.
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
                Console.WriteLine("You got it all right!");
                break;
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            ///This hides three random words in the scripture.
            scripture.HideRandomWords(3);
        }
    }
}