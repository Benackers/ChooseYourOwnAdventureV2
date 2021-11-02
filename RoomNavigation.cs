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
            for (int i = 0; i < currentRoom.exits.Count; i++)
            {
                exitDictionary.Add(currentRoom.exits[i].direction.ToString(), currentRoom.exits[i].leadsTo);
                //currentRoom.enteredBefore = true;
            }
            //}
        }

        public void AttemptToChangeRooms(string directionBearing)
        {
            Console.WriteLine($"You Are in {currentRoom.roomName}, {currentRoom.description}.");
            for (int i = 0; i < currentRoom.exits.Count; i++)
            {
                Console.WriteLine("To the {0} is {1}.", currentRoom.exits[i].direction, currentRoom.exits[i].leadsTo.roomName.ToString());
            }
            if (exitDictionary.ContainsKey(directionBearing))
            {
                currentRoom = exitDictionary[directionBearing];
                Console.WriteLine("You head off to the " + directionBearing);
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
                ClearExits();
            }
        }
        public void ClearExits()
        {
            exitDictionary.Clear();
        }
    }
}
