using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventureV2
{
    public class RoomNavigation
    {
        public Room currentRoom;

        Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

        public void UnpackExitsInRoom()
        {
            //if (currentRoom.enteredBefore == false)
            //{
            for (int i = 0; i < currentRoom.Exits.Count; i++)
            {
                exitDictionary.Add(currentRoom.Exits[i].direction.ToString(), currentRoom.Exits[i].leadsTo);
                //currentRoom.enteredBefore = true;
            }
            //}
        }

        public void AttemptToChangeRooms(string directionBearing)
        {
            if (exitDictionary.ContainsKey(directionBearing))
            {
                currentRoom = exitDictionary[directionBearing];
                Console.WriteLine("You head off to the {0}...", directionBearing);
                Console.WriteLine($"You are now in the {currentRoom.roomName}, {currentRoom.description}.");
                for (int i = 0; i < currentRoom.Exits.Count; i++)
                {
                    Console.WriteLine("To the {0} is {1}.", currentRoom.Exits[i].direction, currentRoom.Exits[i].leadsTo.roomName.ToString());
                }
                ClearExits();
            }
            else if (directionBearing == "")
            {
                Console.WriteLine("Please enter a valid command");
                ClearExits();
            }
            else
            {
                Console.WriteLine("there is no path to the " + directionBearing);
                for (int i = 0; i < currentRoom.Exits.Count; i++)
                {
                    Console.WriteLine("To the {0} is {1}.", currentRoom.Exits[i].direction, currentRoom.Exits[i].leadsTo.roomName.ToString());
                }
                ClearExits();
            }
        }
        public void ClearExits()
        {
            exitDictionary.Clear();
        }
    }
}
