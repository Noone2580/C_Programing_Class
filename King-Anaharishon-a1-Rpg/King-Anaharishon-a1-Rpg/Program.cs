
StartGame:

string Name = "Unknown";

string Acttion;

int Day;

int Hp;

int Food;

float Temp;

Console.WriteLine("Use Help! To see a list of Actions. And Use Stats! To see all Your Stats");
Console.WriteLine("\n");

YourName:
Console.WriteLine("It's dark... And cold \nYour Head hurts....");
Console.WriteLine("Do You Remenber Your Name?");
Name = Console.ReadLine();


if (Name.Contains("Help!"))
{
    Console.WriteLine("\nWrite Your Name\n");
    goto YourName;
}
else

Console.Clear();
Console.WriteLine("It's " + Name + "? You think to Yourself unsure if it's Your name or not");
Console.WriteLine("\n\n");
Console.WriteLine("\"Do You need medical assistants?\" \nYou hear to You're right");

OpenEyes:
Console.WriteLine("Open Your Eyes?");

Acttion = Console.ReadLine();
Acttion = Acttion.ToLower();

Console.WriteLine();

if (Acttion.Contains("y") ^ Acttion.Contains("open"))
{
    Console.Clear();
    Console.WriteLine("All You see is white for a few seconds... Then You see a small red room...\n");
}
else
    goto OpenEyes;


Room:
Console.WriteLine("To You're right is some kind of Terminal and what looks like a needle is attached to the right of the it. \nTo You're left theres a window and a chair with someone slumped over. To the right of the Chair theres a Valve with a Label on it\nIn front of You theres what looks to be a Vendding Machine and a Door");

Console.WriteLine();

Console.Write("What do You Do? ");
Acttion = Console.ReadLine();


if (Name.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" An Then a direction to move\n-Left\n-Right\n-Forword\n-Back \n\nUse \"Look\" And an object to inspect it Or Use \"Around\" to get a list of all interactable objects");
    goto Room;
}
