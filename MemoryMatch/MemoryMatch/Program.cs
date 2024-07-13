int rows = 3;
int cols = 2;

int asciiStart = 65;
char[] grid = new char[rows * cols];

for (int i = 0; i < grid.Length; i++)
    grid[i] = Convert.ToChar(asciiStart + i / 2);

Random rand = new Random();
rand.Shuffle(grid);

string[] playingGrid = new string[rows * cols];

for (int i = 0; i < playingGrid.Length; i++)
    playingGrid[i] = (i + 1).ToString();


int matches = 0;
bool gameWon = false;

while (!gameWon)
{
    PrintPlayingGrid();
    Console.WriteLine("Please select your first card.");
    int choice1 = Convert.ToInt32(Console.ReadLine());
    playingGrid[choice1 - 1] = grid[choice1 - 1].ToString();
    Console.Clear();

    PrintPlayingGrid();
    Console.WriteLine("Please enter your second card.");
    int choice2 = Convert.ToInt32(Console.ReadLine());
    playingGrid[choice2 - 1] = grid[choice2 - 1].ToString();
    Console.Clear();

    PrintPlayingGrid();

    if (grid[choice1 - 1] == grid[choice2 - 1])
    {
        Console.WriteLine("Match!");
        matches++;

        if(matches == (rows * cols) / 2)
            gameWon = true;
    }
    else
    {
        Console.WriteLine("No match...");
        playingGrid[choice2 - 1] = choice2.ToString();
        playingGrid[choice1 - 1] = choice1.ToString();
    }

    Thread.Sleep(1000);
    Console.Clear();
}

Console.WriteLine("Congratulations, you win!");

void PrintPlayingGrid()
{
    for (int i = 0; i <rows; i++)
    {
        for (int j = 0; j < cols; j++)
            Console.Write(playingGrid[cols * i + j] + " | ");
        Console.WriteLine();
    }
}