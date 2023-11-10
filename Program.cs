/*
    This program randomly matches people together for a game of secret santa.
    The result is printed to the console.
*/


// Variables

string[] names = new string[] { "Summaya", "Tabitha", "Luke", "Emily", "Saba", "Simon" }; // List of people that participate
string[] shuffledNames = new string[names.Length];
bool secret = false; // Switch for displaying results recretly (true) or openly (flase).


// Top level statements

Array.Sort(names);

shuffledNames = (string[])names.Clone();

do
{
    shuffledNames = Shuffle(shuffledNames);
} while (IsSamePersonMatched(names, shuffledNames));

Console.Clear();

if (secret)
{
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{names[i]} step forward to receive your match.");
        Console.WriteLine("Press enter to display your match...");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"{names[i]} you get a gift for: {shuffledNames[i]}");
        Console.WriteLine("Press enter to when you've memorised your match...");
        Console.ReadLine();
        Console.Clear();
    }
}
else
{
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{names[i]}\t get a gift for\t{shuffledNames[i]}");
    }
}


// Methods

string[] Shuffle(string[] array)
{
    var random = new Random();
    for (int i = array.Length - 1; i > 0; i--)
    {
        int j = random.Next(i + 1);
        string temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    return array;
}

bool IsSamePersonMatched(string[] names, string[] shuffledNames)
{
    for (int i = 0; i < names.Length; i++)
    {
        if (names[i] == shuffledNames[i])
        {
            return true;
        }
    }
    return false;
}