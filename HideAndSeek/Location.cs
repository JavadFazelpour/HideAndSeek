using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class Location
    {

        public string Name { get; private set; }
        public override string ToString() => Name;
        public IDictionary<Direction, Location> Exits { get; private set; }
                                                  = new Dictionary<Direction, Location>();
        public Location(string name) => Name = name;
        public IEnumerable<string> ExitList =>
            /*from keyValuePair in Exits
            orderby keyValuePair.Key
            orderby Math.Abs((int)keyValuePair.Key)
            select $"The {keyValuePair.Value} is {DescribeDirection(keyValuePair.Key)}";
            */
        Exits
        .OrderBy(keyValuePair => (int)keyValuePair.Key)
        .OrderBy(keyValuePair => Math.Abs((int)keyValuePair.Key))
        .Select(keyValuePair => $"The {keyValuePair.Value} is {DescribeDirection(keyValuePair.Key)}");
        

        public void AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add(direction, connectingLocation);
            connectingLocation.AddReturnExit(direction, this);
        }
        private void AddReturnExit(Direction direction, Location connectingLocation)
        {
            Exits.Add((Direction)(-(int)direction), connectingLocation);
        }

        public Location GetExit(Direction direction)
        {
            if (Exits.ContainsKey(direction)) return Exits[direction];
            else return this;
        }
        private string DescribeDirection(Direction d) => d switch
        {
            Direction.Up => "Up",
            Direction.Down => "Down",
            Direction.In => "In",
            Direction.Out => "Out",
            _ => $"to the {d}",
        };
    }
}
