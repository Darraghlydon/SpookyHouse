// See https://aka.ms/new-console-template for more information
//This is the code for our class exercise in C#
//We will be building onto this every week, Week 1's content will cover necessary variables for SpookyHouse.
//Changing the console Title adds a little bit to our game
Console.Title = "Spooky House!";

//Black and Red are objectively the spookiest colours
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Red;


// While we could just have the numbers put in one by one, this would be quite boring to play. A random number generator 
// allows us to add some variety to the game without much extra effort. I like to provide a minimum and maximum value
// to the number generator to put constraints on what numbers I can get back. 

Random randomIntegerGenerator = new Random();

//Regions are an optional element to your code, some people like them as they make things look tidy, but it's up to you whether you implement them or not.

#region Variables
//A spooky house with less than 4 rooms isn't very spooky, while more than 9 is simply terrifying. 
int numberOfRoomsInHouse = randomIntegerGenerator.Next(4, 9);
//There should be less ghosts than rooms in the house, which is why we set numberOfRooms as our maximum value here. 
int numberOfGhosts = randomIntegerGenerator.Next(1, numberOfRoomsInHouse);
//But to retain our spookiness, there should be more ghosts than torch battery, which will be used to scare them away
int batteryCapacity = randomIntegerGenerator.Next(1, numberOfGhosts);
//Everyone is a little bit crazy, but we'll assume you've got some level of confidence so your sanity won't start below 3. 
int playerSanity = randomIntegerGenerator.Next(3,7);
int roomNumber = 1;


//For the game itself, if you see a ghost in a room and choose not to scare it away before you leave, your sanity will drop by 1.
//If your sanity drops too low, bad things happen! 


bool hasTorch = false;
bool hasKey = false;
bool isTheKeyInThisRoom = false;
bool isThereAGhostInThisRoom = false;

string playerName = "";
#endregion


//So far, all we can do is take the player's name and tell them some information about Spooky House. 
Console.WriteLine("Welcome to Spooky House!");
Console.Write("What is your name? ");
playerName = Console.ReadLine();
Console.WriteLine("Welcome "+ playerName+". You are feeling as sane as the number " + playerSanity + ".");

Console.WriteLine("You have a battery capacity on your torch of "+batteryCapacity);
Console.WriteLine("Which is unfortunate, as there are "+numberOfGhosts + " spooky ghosts in the house.");
Console.WriteLine("You are in Room " + roomNumber);
int nextValue = randomIntegerGenerator.Next(0, 1);
if (nextValue==1)
{
    Console.WriteLine("There is a ghost in this room")
    isThereAGhostInThisRoom = true;
}

if (isThereAGhostInThisRoom)
{
    Console.WriteLine("Do you want to scare the ghost with your torch?");
    string answer = Console.ReadLine();
    if (answer == 'Yes')
    {
        if (batteryCapacity > 0)
        {
            Console.WriteLine("You scared away the ghost!");
            numberOfGhosts = numberOfGhosts - 1;
        }
        else
        {
            Console.WriteLine("You have no battery left!");
            playerSanity = playerSanity - 1;
        }
        
    }
    else
    {
        Console.WriteLine("Ghosts are scurry");
        playerSanity = playerSanity - 1; 
    }

}


