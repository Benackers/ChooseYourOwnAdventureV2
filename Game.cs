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
            EntryHall.roomName = "The Entry Hall";
            EntryHall.description = "The entrance to the Manor";

            navigate.currentRoom = EntryHall;
            //navigate.currentRoom.enteredBefore = false;

            Room DiningHall = new Room();
            DiningHall.roomName = "The Dining Hall";
            DiningHall.description = "A place for fine dining";

            Room Lounge = new Room();
            Lounge.roomName = "The Lounge";
            Lounge.description = "An area for lounging around";

            Lounge.Exits.Add(new Exits(Exits.Directions.s, DiningHall));
            DiningHall.Exits.Add(new Exits(Exits.Directions.w, EntryHall));
            DiningHall.Exits.Add(new Exits(Exits.Directions.n, Lounge));
            EntryHall.Exits.Add(new Exits(Exits.Directions.e, DiningHall));

            MapRooms.Add(EntryHall);
            MapRooms.Add(DiningHall);
            MapRooms.Add(Lounge);
        }

        public void Update()
        {
            if (!JustLaunched)
            {
                Console.WriteLine("Welcome to the game. To move locations, type the direction into the console(ie n).");
                Console.WriteLine("You are in the Entry Hall, To the E (East) is the Dining Hall");
                Console.WriteLine("Please enter a direction to move to.");
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