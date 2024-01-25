using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public static class House
    {
        public static readonly Location Entry;
        static House()
        {
            Entry = new Location("Entry");
            var garage = new Location("Garage");

            var hallway = new Location("Hallway");
            var kitchen = new Location("Kitchen");
            var bathRoom = new Location("Bathroom");
            var livingRoom = new Location("Living Room");

            var landing = new Location("Landing");
            var attic = new Location("Attic");
            var kidsRoom = new Location("Kids Room");
            var pantry = new Location("Pantry");
            var nursery = new Location("Nursery");
            var secondBathroom = new Location("Second Bathroom");

            var masterBedroom = new Location("Master Bedroom");
            var masterBath = new Location("Master Bath");

            Entry.AddExit(Direction.East, hallway);
            Entry.AddExit(Direction.Out, garage);

            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.North, bathRoom);
            hallway.AddExit(Direction.South, livingRoom);
            hallway.AddExit(Direction.Up, landing);

            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.West, secondBathroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Up, attic);

            masterBedroom.AddExit(Direction.East, masterBath);
        }
    }
}
