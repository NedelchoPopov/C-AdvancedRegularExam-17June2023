string[] size = Console.ReadLine().Split(',');
int rows = int.Parse(size[0]);
int cols  = int.Parse(size[1]);
int mauseRow = 0;
int mauseCol = 0;
int cheeseCount = 0;
char[,] cupboard = new char[rows, cols];

for (int row = 0; row < cupboard.GetLength(0); row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < cupboard.GetLength(1); col++)
    {
        cupboard[row, col] = input[col];
        if (input[col] == 'M')
        {
            mauseRow = row;
            mauseCol = col;
        }
        if (input[col] == 'C')
        {
            cheeseCount++;
        }
    }
}
 
 string command;
while((command = Console.ReadLine()) != "danger")
{
    int nextRow = mauseRow;
    int nextCol = mauseCol;
    switch (command)
    {
        case "up":
            nextRow--;
            break;
        case "down":
            nextRow++;
            break;
        case "right":
            nextCol++;
            break;
        case "left":
            nextCol--;
            break;
    }
    if (!IsInsideBoard(cupboard, nextRow, nextCol))
    {
        Console.WriteLine("No more cheese for tonight!");
        PrintMetrix();
        return;
    }
    if (cupboard[nextRow, nextCol] == '@')
    {
        continue;
    }


    cupboard[mauseRow, mauseCol] = '*';
    mauseRow = nextRow;
    mauseCol = nextCol;
    if (cupboard[nextRow, nextCol] == '*')
    {
        cupboard[nextRow, nextCol] = 'M';
    }
    if (cupboard[nextRow,nextCol] == 'C')
    {
        cheeseCount--;
        cupboard[nextRow, nextCol] = 'M';
        if (cheeseCount == 0)
        {
            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            break;
        }
    }
    else if (cupboard[nextRow, nextCol] == 'T')
    {
        cupboard[nextRow, nextCol] = 'M';
        Console.WriteLine("Mouse is trapped!");
        PrintMetrix();
        return;
    }
}
if (cheeseCount != 0)
{
    Console.WriteLine("Mouse will come back later!");
}

PrintMetrix();
void PrintMetrix()
{
    for (int row = 0; row < cupboard.GetLength(0); row++)
    {
        for (int col = 0; col < cupboard.GetLength(1); col++)
        {
            Console.Write(cupboard[row, col]);
        }
        Console.WriteLine();
    }

}

bool IsInsideBoard(char[,] board, int row, int col)
{

    return row >= 0 && row <= board.GetLength(0) - 1
        && col >= 0 && col <= board.GetLength(1) - 1;
}
