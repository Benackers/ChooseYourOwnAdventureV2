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
            for (int i = 0; i < currentRoom.exits.Count; i++)
            {
                exitDictionary.Add(currentRoom.exits[i].direction.ToString(), currentRoom.exits[i].leadsTo);
                //We just entered a room. We are going to unpack the exits. add them to our list of descriptions and get ready to show them on the screen.
            }
        }

        public void AttemptToChangeRooms(string directionBearing)
        {
            if (exitDictionary.ContainsValue(directionBearing))
            {
                currentRoom = exitDictionary[currentRoom.exits.leadsTo.directionBearing];
                Console.WriteLine("You head off to the " + directionBearing);
            }
            else
            {
                Console.WriteLine("there is no path to the " + directionBearing);
            }
        }
    }
}
