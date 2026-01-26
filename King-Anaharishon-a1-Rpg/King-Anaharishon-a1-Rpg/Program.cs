
using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

GameStart:

string HelpInfo = "\n\nUse \"Look\" And than an objects name to inspect it\n-Around to get a list of all interactable objects.\n\nType\"Use\" Then the name of the object to Interact with it.\n";

string Name = "Unknown";

string Acttion;

string PasswordCode = "RGBO";

int Spot = 0;

int Row = 0;

int Col = 0;

bool Water = false;

bool Notebook = false;

bool Password = true;

bool Locked = true;

bool Gear = false;

bool Box = false;

bool RC = true;


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

if (Acttion.Contains("y") || Acttion.Contains("open"))
{
    Console.Clear();
    Console.WriteLine("All You see is white for a few seconds... Then You see a small red room...\n");
}
else
    goto OpenEyes;


//This the main room you will be coming back to this eveytime you need to move around

Room:
if (Spot == 0)
    Console.WriteLine("You get off the bed You where Laying on and move to the center of the room.");

Spot = 1;

if (Notebook)
    Console.WriteLine(
        "--------------------------------------------------\n" +
        "|           |            |           |______|    |\n" +
        "|           |____________|                       |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|-|                                              |\n" +
        "| |                                              |\n" +
        "|-|                                        |-----|\n" +
        "|                                          |     |\n" +
        "|()+                                       |     |\n" +
        "|                                          |     |\n" +
        "|=======|                                  |-----|\n" +
        "|==|   |                                         |\n" +
        "|==|   |                                         |\n" +
        "|=======|                                        |\n" +
        "|                       |============|======|    |\n" +
        "|                |----| |============|      |    |\n" +
        "|                |    | |============|      |    |\n" +
        "|                |----| |============|======|    |\n" +
        "--------------------------------------------------");
Console.WriteLine("To You're right is some kind of Terminal. \nTo You're left theres a window and a chair with someone slumped over.To the right of the Chair theres a Valve with a Label on it.\nIn front of You theres what looks to be a Vendding Machine and a Door.");

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
    {
        Console.Clear();
        goto Right;

    }
    if (Acttion.Contains("left"))
    {
        Console.Clear();
        goto Left;
    }

    if (Acttion.Contains("forword"))
    {
        Console.Clear();
        goto Forword;

    }
    if (Acttion.Contains("back"))
        goto Back;
    else goto Room;
}
else goto Room;


//This is your bed. Sleep
Bed:
Spot = 0;
if (Notebook)
    Console.WriteLine(
        "--------------------------------------------------\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|            ____________                        |\n" +
        "|            | T   __   |                        |\n" +
        "|            | E  (())  |                        |\n" +
        "|            | A | *| | |                        |\n" +
        "|            | M |__|_| |                        |\n" +
        "|            | 4 EVER   |                        |\n" +
        "|            ------------                        |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|      _______________________                   |\n" +
        "|      | -_       -_          -_                 |\n" +
        "|      |-_  -_ _____-_____________  ________     |\n" +
        "|      |_ -_  |      |           |  | -______-   |\n" +
        "--------||  -_|______|       ____|--|-_|_____|----\n" +
        "              ||     |______/   ||   - |_____|    \n");


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





//This is the Terminal you need to open the door
Right:
if (Spot != 3)
    Console.WriteLine("You turn right and walk to the Terminal");
Spot = 3;


if(Notebook)
    Console.WriteLine(
        "--------------------------------------------------\n" +
        "|             | |        ____________________    |\n" +
        "|           [-| |-]      |*         /      *|    |\n" +
        "|           | | | |      | Station / 1432   |    |\n" +
        "|           [-| |-]      |*       /        *|    |\n" +
        "|              \\\\        --------------------    |\n" +
        "|              | |                               |\n" +
        "|              | |      ________________         |\n" +
        "|              | |      |-______________-_       |\n" +
        "|              | |      | | c:|          |       |\n" +
        "|              | |      | |              |       |\n" +
        "|               | |     | |              |       |\n" +
        "|                | |    | |              |       |\n" +
        "|                 | |   | |______________|_      |\n" +
        "|                 | |   | -_  ===========++ -_   |\n" +
        "|                 | \\_____\\ -________________|   |\n" +
        "|                  \\=-----/  |               |   |\n" +
        "|      (=_              |    |               |   |\n" +
        "|        =================)  |               |   |\n" +
        "------------------------|-_ _|_______________|----\n" +
        "                           -|______________|      \n");

Console.WriteLine("\nWhat Now?");
Acttion = Console.ReadLine();
Console.WriteLine();

if (Acttion.Contains("Help!"))
{
    Console.WriteLine("\nUse \"Go\" And Then a direction to move\n-Back \n" + HelpInfo);
    goto Right;
}
else

    Acttion = Acttion.ToLower();

if (Acttion.Contains("go"))
{
    if (Acttion.Contains("back"))
        goto Back;
    else goto Right;
}
if (Acttion.Contains("look"))
{
    if (Acttion.Contains("around"))
    {
        Console.WriteLine("In front You there is a large box Terminal that looks older then anything in the room and nothing else");
        goto Right;
    }
    if (Acttion.Contains("terminal"))
    {
        if (Water)
        {
            Console.WriteLine("It's a large Terminal that has a low tone huming and a few lights. The screen glows green.");
            goto Right;
        }
        else
        {
            Console.WriteLine("It's a large Terminal that those not have Power.");
            goto Right;

        }
    }
}

if (Acttion.Contains("use"))
{
    if (Acttion.Contains("terminal"))
    {
        if (Water)
        {
            Console.WriteLine("The glows green as you get close.\nYou put Your hands on the keyboard.");
        }
        else
        {
            Console.WriteLine("It has no Power");
            goto Right;
        }
    }
}

//This is the Terminal it has it's own code because it will break other wase.
Terminal:
if (Password)
{
    Console.Clear();
    Console.WriteLine("Please login");
    Console.Write("Name: ");
    Acttion = Console.ReadLine();
    if (Acttion == Name)
    {
        Console.Write("Password: ");
        Acttion = Console.ReadLine();
        if (Acttion == PasswordCode)
        {
            Console.WriteLine("Access granted");
            Password = false;
        }
        else
        {
            Console.Clear();
            goto Terminal;
        }
    }
    else
    {
        Console.Clear();
        goto Terminal;

    }
}
else
    Console.WriteLine();

Console.WriteLine($"Wecome {Name}. What would you like to do?");
Acttion = Console.ReadLine();

if (Acttion.Contains("Help!"))
{
    Console.Clear();
    Console.WriteLine($"\nUse \"Go Back \nTo leave the Terminal\nList of acttions\n-Unlock Door\n-error\n-error\n-{Name}");
    goto Terminal;
}

if (Acttion.Contains(Name))
{
    Console.Clear();
    Console.WriteLine($"Employee Number: 77731143\nName: {Name}\nSex: Error data not found\nAge: Error data not found\nCurrent Station: 1432");
    goto Terminal;
}

Acttion = Acttion.ToLower();

if (Acttion.Contains("go"))
{
    if (Acttion.Contains("back"))
    {
        Console.Clear();
        Console.WriteLine("You step back from the Terminal");
        goto Right;
    }
}

if (Acttion.Contains("unlock") || Acttion.Contains("door"))
{
    if (Locked)
    {
        if (Gear)
        {
            Console.Clear();
            Console.WriteLine("You hear the Door unlock.");
            Locked = false;
            goto Terminal;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Error 5332210 Door lock not responding");
            goto Terminal;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("The Door is already unlocked");
        goto Terminal;
    }
}

else goto Terminal;


//This is the window your frind is here.
Left:
if (Spot != 2)
    Console.WriteLine("You turn left to face and move to the window.");

Spot = 2;
if (Notebook)
    Console.WriteLine(
        "--------------------------------------------------\n" +
        "|________________________________________________|\n" +
        "|_________________________/ \\____________________|\n" +
        "|                         | |                    |\n" +
        "|                         | |                    |\n" +
        "|                         | |                    |\n" +
        "|                         | |                    |\n" +
        "|                         | |         __-=-__    |\n" +
        "|                         | |        /  == = \\   |\n" +
        "|                         |_|       | == ===  |  |\n" +
        "|                       [-| |-]     | = == == |  |\n" +
        "|                       | (=) |      \\__= =__/   |\n" +
        "|                       [-|_|-]         -=-      |\n" +
        "|        _________        | |                    |\n" +
        "|      _/         \\ ___   | |                    |\n" +
        "|     (_ -_       _(( ))_ | |                    |\n" +
        "|     | -_ -_    /2/  __ || |                    |\n" +
        "|     |   -_()  / /   () || |                    |\n" +
        "|     | 3C  || |_| |__||_|| |                    |\n" +
        "------|__   ||___-|  |||  |_|---------------------\n" +
        "         ---|_____|= |=|                          \n");


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
            Console.WriteLine("You can use the note book to draw what you see!");
            goto Left;
        }
        else
        {
            Console.WriteLine("You put the body back");

            goto Left;
        }
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
if (Spot != 4)
    Console.WriteLine("You walk forword to the Door");
Spot = 4;

if (Notebook)
    Console.WriteLine(
        "--------------------------------------------------\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                                                |\n" +
        "|                              ________________  |\n" +
        "|                              |              |  |\n" +
        "|      ______________          |     _____    |  |\n" +
        "|      | -____________-_       |     | ^ |    |  |\n" +
        "|      |  |_________  _ |      |     | 1 |    |  |\n" +
        "|      |  || * * * | [_]|      |     -----    |  |\n" +
        "|      |  || * * * |()[]|     ___________________|\n" +
        "|      |  ||  [*]  | __ |    |___________________|\n" +
        "|      |  || * * * ||##||      |      (0)     |  |\n" +
        "|      |  || * * * ||##||     -------------------|\n" +
        "|      |  || * * * | -- |    |___________________|\n" +
        "|      |  ||_______|    |      |              |  |\n" +
        "|      |  | ________    |      |              |  |\n" +
        "-------|_ | |_Push_|    |------|______________|---\n" +
        "         -|_____________|                          \n");

Console.WriteLine("What now?");
Acttion = Console.ReadLine();

if (Acttion.Contains("Help!"))
{
    Console.Clear();
    Console.WriteLine("\nUse \"Go\" And Then a direction to move\n-Back \n" + HelpInfo);
    goto Forword;
}
Acttion = Acttion.ToLower();

if (Acttion.Contains("go"))
{
    Console.Clear();
    Console.WriteLine("You turn around and go back to the center of the room.");
    goto Back;
}

if (Acttion.Contains("look"))
{
    if (Acttion.Contains("around"))
    {
        Console.Clear();
        Console.WriteLine("In front of You see the only Door in the room to the left there is a Vendding Machine");
        goto Forword;
    }
    if (Acttion.Contains("door"))
    {
        if (Water)
        {
            Console.Clear();
            Console.WriteLine("It's a big Red Door with a mechanical lock and some lights");
            goto Forword;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("It's a big Red Door with a mechanical lock");
            goto Forword;
        }
    }
    if (Acttion.Contains("vendding") || Acttion.Contains("machine"))
    {
        if (Water)
        {
            Console.Clear();
            Console.WriteLine("You look into the Vendding Machine and see a Gear on the hook row 2 col 4");
            goto Forword;
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("You can't see into the Vendding Machine there is a shutter door in the way. There is text on the door that reads \"All buttons don't work except for 3, 5, 9\nTo get someing type in - or + then the number\"");
            goto Forword;
        }
            
        
    }
}

if (Acttion.Contains("use"))
{
    if (Acttion.Contains("door"))
    {
        if (Gear)
        {
            if (Locked)
            {
                Console.Clear();
                Console.WriteLine("It's Locked");
                goto Forword;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You open the Door and get hit by a large gust of freezing wind and snow.\nIt's dark outside and you can't see far\nYou look back into the room. seeing that You have nothing else to do then to move forword");
                Console.WriteLine("You step outside and start walking when you hear the door close behide You\nYou walk for a while... You see nothing but darkness and snow...");
                Console.WriteLine("As You are walking a large gust hits You and You hear someing metal breaking in the distance\nAll of a suddon You get hit in the back of the head by something You can's see. You fall to the ground...");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("A Part is missing in the lock");
            goto Forword;
        }
    }
    if (Acttion.Contains("vendding") || Acttion.Contains("machine") )
    {
        goto Vendding;
    }
}


Vendding:
string rcs = "Row";
Console.WriteLine($"Row: {Row}, Col: {Col}");
if (RC)
{
    rcs = "Row";
}
else
{
    rcs = "Col";
}
Console.WriteLine("Currunt: " + rcs);
Acttion = Console.ReadLine();

if (Acttion.Contains("Help!"))
{
    Console.Clear();
    Console.WriteLine("Type \"Go Back\" to leave the vendding machine. Type \"Row\" or \"Col\" so change the number");
    goto Vendding;
}

Acttion = Acttion.ToLower();

if (Acttion.Contains("row") || Acttion.Contains("col"))
{
    if (Acttion.Contains("row")) 
    {
        RC = true;
        Console.Clear();
        goto Vendding;
    }
    else
    {
        RC = false;
        Console.Clear();
        goto Vendding;
    }
}
if (Acttion.Contains("3") || Acttion.Contains("5") || Acttion.Contains("9"))
{

}
else 
{
    Console.Clear();
    goto Vendding; 
}



//This is used to go back to the main room.
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



