using System;
using System.Data.Common;

namespace NtiPain
{
    public class Item
    {
        public enum Destination
        {
            Left, Right, Out
        }

        public int Id;
        public Destination Dest;
        public int Cell;

        public Item(int id, Destination dest, int cell = 0)
        {
            Id = id;
            Dest = dest;
            Cell = cell;
        }
    }
}