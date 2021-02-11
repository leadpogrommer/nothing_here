using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NtiPain
{
    public class ItemDatabase
    {
        private static ItemDatabase _inst = null;

        private ConcurrentDictionary<int, Item> Items = new ConcurrentDictionary<int, Item>();
        
        private ItemDatabase()
        {
            
        }

        public static ItemDatabase Instance()
        {
            if (_inst == null) _inst = new ItemDatabase();
            return _inst;
        }

        public void AddItem(Item i)
        {
            if (Items.ContainsKey(i.Id)) throw new ArgumentException("Repeating ID");
            Items[i.Id] = i;
        }

        public Item GetItem(int id)
        {
            return Items[id];
        }

        public void RemoveItem(int id)
        {
            Items.TryRemove(id, out _);
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(Items.Values);
        }
    }
}