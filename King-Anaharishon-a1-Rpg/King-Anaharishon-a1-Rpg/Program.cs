
StartGame:

string Name = "Unknown";

string Acttion;

int Day;

int Hp;

int Food;

float Temp;

Console.WriteLine("Use Help! To see a list of Actions. And Use Stats! To see all your Stats");
Console.WriteLine("\n");

YourName:
Console.WriteLine("It's dark... And cold \nYour Head hurts....");
Console.WriteLine("Do you Remenber your Name?");
Name = Console.ReadLine();


if (Name.Contains("Help!"))
{
    Console.WriteLine("\nWrite your Name\n");
    goto YourName;
}
else

Console.Clear();
Console.WriteLine("It's " + Name + "? You think to yourself unsure if it's your name or not");
Console.WriteLine("\n\n");
Console.WriteLine("\"Do you need medical assistants?\" \nYou hear to you're right");

OpenEyes:
Console.WriteLine("Open Your Eyes?");

Acttion = Console.ReadLine();
Acttion = Acttion.ToLower();

Console.WriteLine();

if (Acttion.Contains("y") ^ Acttion.Contains("open"))
    Console.Clear();
    Console.WriteLine("All you see is white for a few seconds... You see a small red room...\n");
else
    goto OpenEyes;


Room:
Console.WriteLine("To you're right is some kind of Terminal and what looks like a needle is attached to the right of the it. \nTo you're left theres a window andd a chair with someone slumped over. To the right of the person theres a Valve with a label on it\nIn front of you theres what looks to be a vendding machine and a Door");

Console.WriteLine();

Console.Write("What do you Do? ");
Acttion = Console.ReadLine();


if (Name.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" An Then a direction to move\n-Left\n-Right\n-Forword\n-Back \n\nUse \"Look\" And an object to inspect it Or Use \"Around\" to get a list of all interactable objects");
    goto Room;
}
