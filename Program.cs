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
//We want a way to keep track of which rooms we have gone in to. 
int unCheckedRooms = numberOfRoomsInHouse;
//There should be less ghosts than rooms in the house, which is why we set numberOfRooms as our maximum value here. 
int numberOfGhosts = randomIntegerGenerator.Next(1, numberOfRoomsInHouse);
//But to retain our spookiness, there should be more ghosts than torch battery, which will be used to scare them away
int batteryCapacity = randomIntegerGenerator.Next(1, numberOfGhosts);
//Everyone is a little bit crazy, but we'll assume you've got some level of confidence so your sanity won't start below 3. 
int playerSanity = randomIntegerGenerator.Next(3,7);
int roomNumber = 1;
//Every ghost has a level, which we must overcome through a random dice roll to defeat
int ghostLevel = randomIntegerGenerator.Next(1, 5);
//this value will be used everytime we face a ghost
int scareAwayValue;


//To make our code a bit more readable, and to allow us to change these messages later we can define them as a string
string ghostInRoom = "There's a ghost in this room! Spppooookkkkyyyy!!!";
string noGhostInRoom = "There are no ghosts here!";
string willYouScareGhost = "Do you want to try to scare it?";
string attemptToScareGhost = "You shakily point your torch at the ghost.";
string scareAwayFailed = "Your torch wobbles over the ghost, but it has no effect! You run in terror!";
string scareAwaySuccess = "Your torch beam smashes into the ghost, making it disappear! You stride into the next room confidently.";
string runAwayText = "You shriek and run from the ghost into the next room, slamming the door behind you.";
//String formats allow us to make code a bit more readable. The number in the curly brackets should be replaced by the variable at the end
string batteryCapacityText = string.Format("You have a battery capacity of {0}", batteryCapacity);
string batteryEmptyText = "You have no battery left!";
string gameSuccess = "You scared away all the ghosts! A clear light shines through Spooky House, with a new day of hope!";
string gameFailure =
    " You have gone totally, utterly mad. You are doomed to wander spooky house until you join the ghosts.";



//For the game itself, if you see a ghost in a room and choose not to scare it away before you leave, your sanity will drop by 1.
//If your sanity drops too low, bad things happen! 


bool hasTorch = false;
bool hasKey = false;
bool isTheKeyInThisRoom = false;
bool isThereAGhostInThisRoom = false;

string playerName = "";
#endregion


//Take the player's name and tell them some information about Spooky House. 
Console.WriteLine("Welcome to Spooky House!");
Console.Write("What is your name? ");
playerName = Console.ReadLine();
Console.WriteLine("Welcome "+ playerName+". You are feeling as sane as the number " + playerSanity + ".");

Console.WriteLine("You have a battery capacity on your torch of "+batteryCapacity);
Console.WriteLine("Which is unfortunate, as there are "+numberOfGhosts + " spooky ghosts in the house.");





//If there are still ghosts in the house, check if there's one in this room
while (numberOfGhosts > 0)
{
    Console.WriteLine("You are in Room " + roomNumber);

//There is a 50/50 chance there's a ghost in the room

    int ghostInRoomCheck = randomIntegerGenerator.Next(0, 2);

    if (ghostInRoomCheck == 1)
    {
        Console.WriteLine(ghostInRoom);
        isThereAGhostInThisRoom = true;
    }

    if (isThereAGhostInThisRoom)
    {
        Console.WriteLine(batteryCapacityText);
        Console.WriteLine(willYouScareGhost);
        string answer = Console.ReadLine();
        if (answer == "Yes")
        {
            if (batteryCapacity > 0)
            {
                Console.WriteLine(attemptToScareGhost);
                //Find the ghost's level, and check if we can scare it away
                ghostInRoomCheck = randomIntegerGenerator.Next(1, 5);
                scareAwayValue = randomIntegerGenerator.Next(1, 6);
                if (scareAwayValue >= ghostInRoomCheck)
                {
                    Console.WriteLine(scareAwaySuccess);
                    numberOfGhosts = numberOfGhosts - 1;
                    playerSanity = playerSanity + 1;
                }
                else
                {
                    Console.WriteLine(scareAwayFailed);
                    //trying to scare away a ghost and failing is worse than just running from one.
                    playerSanity = playerSanity - 2;
                }

                batteryCapacity = batteryCapacity - 1;


            }
            else
            {
                Console.WriteLine(batteryEmptyText);
                playerSanity = playerSanity - 1;
            }

        }
        else
        {
            Console.WriteLine(runAwayText);
            playerSanity = playerSanity - 1;
        }

    }
    else
    {
        Console.WriteLine(noGhostInRoom);
    }


    ++roomNumber;


    if (numberOfGhosts == 0)
    {
        Console.WriteLine(gameSuccess);
    }
    else if (playerSanity <= 0)
    {
        Console.WriteLine(gameFailure);
    }
}
        
        
        
    




