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

        public bool Moving;

        public CellLocation Place;

        public Item(int id, Destination dest)
        {
            Id = id;
            Dest = dest;
        }
    }
}