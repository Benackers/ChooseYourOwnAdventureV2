using System;
using ChooseYourOwnAdventureV2;
using System.Collections.Generic;

namespace ChooseYourOwnAdventureV2
{
    public class Room

    {
        private List<Exits> _exits = new List<Exits>();
        public List<Exits> Exits { get { return _exits; } }
        public string roomName;
        public string description;
        public bool enteredBefore = false;
    }

}