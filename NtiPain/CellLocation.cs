using System;

namespace NtiPain
{
    public class CellLocation
    {
        public Side Rack;
        public Side CellSide;
        public int CellPosition;

        public CellLocation(Side r, Side s, int p)
        {
            Rack = r;
            CellSide = s;
            CellPosition = p;
        }

        public CellLocation(string str)
        {
            var splitted = str.Split(':');
            Rack = (Side)Enum.Parse(typeof(Side), splitted[0], true);
            CellSide = (Side)Enum.Parse(typeof(Side), splitted[1], true);
            CellPosition = Int32.Parse(splitted[2]);
        }
    }
}