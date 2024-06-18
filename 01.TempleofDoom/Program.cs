/*
2 4 6 8
11 3 5 7 9
24 28 18 30

13 7 4 22 11 15 20
3 2 1
12 10 5

*/

Queue<int> tools = new Queue<int> (Console.ReadLine()
    .Split()
    .Select(int.Parse));

Stack<int> substances = new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

List<int> challenges = new List<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

while (tools.Count > 0 && substances.Count > 0)
{
    int currentTool = tools.Dequeue();
    int currentSubstance = substances.Pop();
    int result = currentTool * currentSubstance;
    var resultIsEqual = challenges.FirstOrDefault(x => x.Equals(result));

    if (resultIsEqual != default)
    {
        challenges.Remove(resultIsEqual);
    }
    else
    {
        tools.Enqueue(++currentTool);
        currentSubstance--;
        if (currentSubstance == 0)
        {
            continue;
        }
        substances.Push(currentSubstance);
    }

    if (challenges.Count == 0)
    {
        break;
    }
}

if (challenges.Count == 0)
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");    
}
else if (tools.Count == 0 || substances.Count == 0)
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");

}

PrintSequences();
void PrintSequences()
{
    if (tools.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
    }
    if (substances.Any())
    {
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }
    if (challenges.Any())
    {
        Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
    }
}