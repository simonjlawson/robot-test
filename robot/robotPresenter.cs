using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotApp
{
    public class robotPresenter
    {
        public int GridNumber;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public direction PosFace { get; set; }
        
        public enum direction {North,South,East,West}

        bool _placed;

        public robotPresenter(int gridNumber)
        {
            PosX = 0;
            PosY = 0;
            PosFace = direction.North;
            GridNumber = gridNumber;

            _placed = false;
        }
    
        public string Command(string cmd)
        {

            if (cmd.StartsWith("PLACE "))
            {
                _placed = true;
                return placeLocation(cmd);
            }

            if (_placed)
            {
                if (cmd.StartsWith("MOVE"))
                {
                    Location newLocation;

                    //Calculate move
                    newLocation = moveLocation(new Location(PosX, PosY));

                    //Check the move
                    if (validateLocation(newLocation))
                    {
                        PosX = newLocation.X;
                        PosY = newLocation.Y;
                        return "Moved";
                    }
                    else
                    {
                        return "Invalid Move";
                    }
                }

                else if (cmd.StartsWith("LEFT"))
                {
                    //Set rotation AntiClockwise
                    if (PosFace == direction.North)
                        { PosFace = direction.West; }
                    else if (PosFace == direction.East)
                        { PosFace = direction.North; }
                    else if (PosFace == direction.South)
                        { PosFace = direction.East; }
                    else if (PosFace == direction.West)
                        { PosFace = direction.South; }

                    return "Now Facing " + PosFace.ToString();
                }

                else if (cmd.StartsWith("RIGHT"))
                {
                    //Set rotation Clockwise
                    if (PosFace == direction.North)
                        { PosFace = direction.East; }
                    else if (PosFace == direction.East)
                        { PosFace = direction.South; }
                    else if (PosFace == direction.South)
                        { PosFace = direction.West; }
                    else if (PosFace == direction.West)
                        { PosFace = direction.North; }

                    return "Now Facing " + PosFace.ToString();
                }

                else if (cmd.StartsWith("REPORT"))
                {
                    //Return Position and Facing data
                    return (PosX) + ", " + (PosY) + ", " + PosFace;
                }
                else
                {
                    //Invalid command
                    return "Command did not begin with a keyword";
                }

            } else {
                return "Robot not placed";
            }
        }

        private string placeLocation(string commandString)
        {
            Location location = new Location(0, 0);

            //Split the Command
            string[] param = commandString.Split(' ');
            if (param.Length > 1)
            {
                //Split the Parameters
                string[] cords = param[1].Split(',');
                if (cords.Length == 3)
                {

                    //Parse the XY Paramters
                    int.TryParse(cords[0], out location.X);
                    int.TryParse(cords[1], out location.Y);

                    if (validateLocation(location))
                    {
                        //Parse Facing Parameter and Set
                        if (cords[2] == "NORTH")
                            { PosFace = direction.North; }
                        else if (cords[2] == "EAST")
                            { PosFace = direction.East; }
                        else if (cords[2] == "SOUTH")
                            { PosFace = direction.South; }
                        else if (cords[2] == "WEST")
                            { PosFace = direction.West; }
                        else
                            { return "Error with Direction"; }

                        //Finalise Location
                        PosX = location.X;
                        PosY = location.Y;

                        return "Placing X" + location.X + " Y" + location.Y + " Facing " + PosFace;
                    }
                    else
                    {
                        return "Error with Location";
                    }
                }
                else
                { return "Error with number of Parameters"; }
            }
            else
            { return "Error with no Paramters"; }
        }

        private Location moveLocation(Location l)
        {
            Location newLocation = new Location(l.X,l.Y);

            if (PosFace == direction.North)
                { newLocation.Y = l.Y + 1; }
            else if (PosFace == direction.East)
                { newLocation.X = l.X + 1; }
            else if (PosFace == direction.South)
                { newLocation.Y = l.Y - 1; }
            else if (PosFace == direction.West)
                { newLocation.X = l.X - 1; }

            return newLocation;
        }

        private Boolean validateLocation(Location l)
        {
            bool valid = true;

            if (l.X >= GridNumber)
                { valid = false; }
            if (l.X < 0)
                { valid = false; }
            if (l.Y >= GridNumber)
                { valid = false; }
            if (l.Y < 0)
                { valid = false; }

            return valid;
        }

    }

    //A little class that makes moving cleaner
    public class Location
    {
        public int X;
        public int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
