using System;
using ChooseYourOwnAdventureV2;

namespace ChooseYourOwnAdventureV2
{
    public class Exits
    {
        // public string keyString;
        // public string exitDescription;
        // public Room valueRoom;
        public enum Directions
        {
            Undefined, north, south, east, west
        };

        public Room leadsTo;
        public Directions direction;

        public Exits(Directions _direction, Room newLeadsTo)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
        }

    }
}