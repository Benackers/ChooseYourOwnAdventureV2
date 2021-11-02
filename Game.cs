using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventureV2
{
    class Game
    {

        public bool isRunning = true;
        bool JustLaunched = false;
        //Room CurrentRoom;
        List<Room> MapRooms = new List<Room>();
        RoomNavigation navigate = new RoomNavigation();
        public Game()
        {
            //Create the map
            Room EntryHall = new Room();
            EntryHall.roomName += "The Entry Hall";
            EntryHall.description += "The entrance to the Manor";

            navigate.currentRoom = EntryHall;
            //navigate.currentRoom.enteredBefore = false;

            Room DiningHall = new Room();
            DiningHall.roomName += "The Dining Hall";
            DiningHall.description += "A place for fine dining";

            Room Lounge = new Room();
            Lounge.roomName += "The Lounge";
            Lounge.description += "An area for lounging around";

            Lounge.addExit(new Exits(Exits.Directions.s, DiningHall));
            DiningHall.addExit(new Exits(Exits.Directions.w, EntryHall));
            DiningHall.addExit(new Exits(Exits.Directions.n, Lounge));
            EntryHall.addExit(new Exits(Exits.Directions.e, DiningHall));

            MapRooms.Add(EntryHall);
            MapRooms.Add(DiningHall);
            MapRooms.Add(Lounge);


            //Console.WriteLine("Welcome to that game. To move locations, type the direction into the console (ie n). Press Enter to start the game.");

            // var response = " ";

            // while (response != "quit")
            // {

            //     Console.WriteLine($"You Are in {CurrentRoom.roomName}, {CurrentRoom.description}.");
            //     for (int i = 0; i < CurrentRoom.exits.Count; i++)
            //     {
            //         Console.WriteLine("To the {0} is {1}.", CurrentRoom.exits[i].direction, CurrentRoom.exits[i].leadsTo.roomName.ToString());
            //         CurrentRoom.enteredBefore = true;
            //     }

            //     Console.WriteLine("Please enter a command.");
            //     response = Console.ReadLine().ToLower();

            //     for (int i = 0; i < CurrentRoom.exits.Count; i++)
            //     {
            //         if (response != CurrentRoom.exits[i].direction.ToString())
            //         {
            //             Console.WriteLine("That is not somewhere you can go");
            //             break;
            //         }
            //         else if (response == CurrentRoom.exits[i].direction.ToString())
            //         {
            //             Console.WriteLine($"You move off to the {response}");
            //             CurrentRoom = CurrentRoom.exits[i].leadsTo;
            //             break;
            //             //Console.WriteLine("To the {0} is {1}.", CurrentRoom.exits[i].direction, CurrentRoom.exits[i].leadsTo.roomName.ToString());
            //         }
            //     }
            // }
        }

        public void Update()
        {
            if (!JustLaunched)
            {
                Console.WriteLine("Welcome to that game. To move locations, type the direction into the console(ie n).Press Enter to start the game.");
                JustLaunched = true;
            }
            string currentCommand = Console.ReadLine().ToLower();
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }
            navigate.UnpackExitsInRoom();
            navigate.AttemptToChangeRooms(currentCommand);
        }
    }
}