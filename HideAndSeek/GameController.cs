using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    internal class GameController
    {
        public Location CurrentLocation { get; private set; }
        public string Status => $"You are in the {CurrentLocation}. You see the following exits:" +
        Environment.NewLine +
        $" - {string.Join(Environment.NewLine + " - ", CurrentLocation.ExitList)}";

        public string? Prompt => "Which direction do you want to go: ";

        public GameController()
        {
            CurrentLocation = House.Entry;
        }

        public bool Move(Direction direction)
        {
            if (!CurrentLocation.Exits.ContainsKey(direction))
                return false;
            CurrentLocation = CurrentLocation.Exits[direction];
            return true;
        }

        internal string ParseInput(string? input)
        {
            if (Enum.TryParse(input, out Direction direction))
            {
                if (CurrentLocation.Exits.ContainsKey(direction))
                {
                    return $"Moving {direction}";
                }
                else return $"There's no exit in that direction";
            }
            else return "That's not a valid direction";
        }
    }
}
