using System;
using ChooseYourOwnAdventureV2;
using System.Collections.Generic;

namespace ChooseYourOwnAdventureV2
{
    public class Room

    {
        public List<Exits> exits = new List<Exits>();
        public string roomName;
        public string description;
        public void addExit(Exits exit)
        {
            exits.Add(exit);
        }
        public bool enteredBefore = false;
        // public string description;
        // public string roomName;
        // public Exit[] exits;
    }

}