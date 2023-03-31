namespace Task3;

internal class Program
{
    private static void Main()
    {
        var clerk3 = new Clerk { Name = "3" };
        var clerk4 = new Clerk { Name = "4" };
        var clerk2 = new Clerk { Name = "2", DependsOn = new List<Clerk> { clerk3, clerk4 } };
        var clerk1 = new Clerk { Name = "1", DependsOn = new List<Clerk> { clerk2 } };

        var clerks = new List<Clerk> { clerk1, clerk2, clerk3, clerk4 };

        var result = new Dictionary<string, Clerk>();

        foreach (var clerk in clerks)
        {
            _processClerks(clerk, ref result);
        }
    }

    private static void _processClerks(Clerk clerk, ref Dictionary<string, Clerk> result)
    {
        foreach (var dClerk in clerk.DependsOn)
        {
            _processClerks(dClerk, ref result);
        }

        if (!result.ContainsKey(clerk.Name))
        {
            result.Add(clerk.Name, clerk);
        }
    }
}

internal class Clerk
{
    public IList<Clerk> DependsOn = new List<Clerk>();

    public string Name;
}