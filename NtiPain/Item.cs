using System;
using System.Data.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace NtiPain
{
    public class Item
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Destination
        {
            Left, Right, Out
        }

        public int Id;
        public Destination Dest;

        public bool Moving;

        public CellLocation Place;

        public bool PendingForOut = false;

        public Item(int id, Destination dest)
        {
            Id = id;
            Dest = dest;
        }
        
        
    }
}