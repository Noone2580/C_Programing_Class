
using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

StartGame:

string HelpInfo = "\n\nUse \"Look\" And than an objects name to inspect it\n-Around to get a list of all interactable objects.\n\nType\"Use\" Then the name of the object to Interact with it.\n";

string Name = "Unknown";

string Acttion;

int Spot = 0;

bool Inspot = false;

bool Water = false;

bool Notebook = false;

Console.WriteLine("Use Help! To see a list of Actions.");
Console.WriteLine("\n");

YourName:
Console.WriteLine("It's dark... And cold \nYour Head hurts....");
Console.WriteLine("Do You Remenber Your Name?");
Name = Console.ReadLine();
Console.WriteLine();



if (Name.Contains("Help!"))
{
    Console.WriteLine("\nWrite Your Name\n");
    goto YourName;
}
else

Console.Clear();
Console.WriteLine("It's " + Name + "? You think to Yourself unsure if it's Your name or not");
Console.WriteLine("\n\n");


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
if (Spot == 0)
Console.WriteLine("You get off the bed You where Laying on and move to the center of the room.");

Spot = 1;
Console.WriteLine("To You're right is some kind of Terminal and what looks like a needle is attached to the right of the it. \nTo You're left theres a window and a chair with someone slumped over.To the right of the Chair theres a Valve with a Label on it.\nIn front of You theres what looks to be a Vendding Machine and a Door.");

Console.WriteLine("What do You Do? ");
Acttion = Console.ReadLine();
Console.WriteLine();



if (Acttion.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" And Then a direction to move\n-Left\n-Right\n-Forword\n-Back \n" + HelpInfo);
    goto Room;
}
else
 
Acttion = Acttion.ToLower();


if (Acttion.Contains("go"))
{
    if (Acttion.Contains("right"))
        goto Right;
    if (Acttion.Contains("left"))
    {
        Console.Clear();
        goto Left;
    }
        
    if (Acttion.Contains("forword"))
        goto Forword;
    if (Acttion.Contains("back"))
        goto Back;
    else goto Room;
}
else goto Room;


Bed:
Spot = 0;
Console.WriteLine("What now? ");
Acttion = Console.ReadLine();
Console.WriteLine();

if (Acttion.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" And Then a direction to move\n-Back \n" + HelpInfo);
    goto Bed;
}
else

Acttion = Acttion.ToLower();


if (Acttion.Contains("go"))
{
    if (Acttion.Contains("back"))
    goto Back;
    else goto Bed;
}
else

if (Acttion.Contains("look"))
{
    if (Acttion.Contains("around")) 
    {
        Console.WriteLine("Youre laying on a Gray bed. At Youre feet theres a Box\n");
        goto Bed; 
    }
    if (Acttion.Contains("box"))
    {
        Console.WriteLine("It's a small wooden Box with a Finger Print Lock on it\n");
        goto Bed;
    }
    else goto Bed;
}
else 

if (Acttion.Contains("use"))
{
    if (Acttion.Contains("box"))
    {
        Console.WriteLine("Youre Finger Does't work");
        goto Bed;
    }
    if (Acttion.Contains("bed"))
    {
        Console.WriteLine("You close Your Eyes... You are not Tird.");
        goto OpenEyes;
    }
    else goto Bed;
}






Right:

Left:
Console.WriteLine("You turn left to face and move to the window.");

Spot = 2;
Console.WriteLine("What now? ");
Acttion = Console.ReadLine();
Console.WriteLine();

if (Acttion.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" And Then a direction to move\n-Back \n" + HelpInfo);
    goto Left;
}
else

Acttion = Acttion.ToLower();


if (Acttion.Contains("go"))
{
    if (Acttion.Contains("back"))
        goto Back;
    else goto Left;
}
else

if (Acttion.Contains("look"))
{
    if (Acttion.Contains("around"))
    {
        Console.WriteLine("Youre standing in front of a round Window theres a Valve next to it and to the left there is a Blue chair with a Body slumped over.\n");
        goto Left;
    }
    if (Acttion.Contains("window"))
    {
        Console.WriteLine("You look out the Window... Theres a snow storm and it's dark\n");
        goto Left;
    }
    if (Acttion.Contains("valve"))
    {
        Console.WriteLine("It's Red and theres a label that reads hot water\n");
        goto Left;
    }
    if (Acttion.Contains("body"))
    {
        Console.WriteLine("They are wearing a Orange winter jacket with a name tag that reads " + Name + "\nResearch and Developnent\n");
        goto Left;
    }
    else goto Left;
}

else

if (Acttion.Contains("use"))
{
    if (Acttion.Contains("window"))
{
        Console.WriteLine("it Does't open");
        goto Left;
    }

    if (Acttion.Contains("body"))
    {
        Console.WriteLine("You grab the body\nWhat now?");
        Acttion = Console.ReadLine();
        Acttion = Acttion.ToLower();

        if (Acttion.Contains("box"))
        {
            Console.WriteLine("You drag the body to the box and use theyre finger on the lock... it unlocks\nYou open the box to find a note book and a pin. You grab it and drag the body back to the chair");
            Notebook = true;
            Console.WriteLine("You can the note book to draw what you see! Type Draw");
            goto Left;
        }
        else goto Left;
    }

    if (Acttion.Contains("valve"))
    {

        Console.WriteLine("Turn?");

        Acttion = Console.ReadLine();
        Console.WriteLine();
        Acttion = Acttion.ToLower();

        if (Acttion.Contains("left"))
        {
            if (Water == false)
            {
                Console.WriteLine("It does't move\n");
                goto Left;
            }

            else
            {
                Console.WriteLine("It moves you hear the water stop flowing and aloud shutter door close");
                Water = false;
                goto Left;
            }
        }
        if (Acttion.Contains("right"))
        {
            if (Water == true)
            {
                Console.WriteLine("It does't move\n");
                goto Left;
            }
            else
            {
                Console.WriteLine("It moves you hear the sound of flowing water and aloud shutter door open");
                Water = true;
                goto Left;
            }
        }


        else goto Left;
    }
}

Forword:

Back:
if (Spot == 1)
{
    Console.Clear();
    Console.WriteLine("You turn around and lay on the bed\n");
    goto Bed;
}
else
{
    Console.Clear();
    goto Room;
}



