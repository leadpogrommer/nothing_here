using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading.Tasks;
using EngineIO;

namespace NtiPain
{
    public class Road
    {
        public MemoryBit[] Conveyors;
        public ConcurrentQueue<Item> Items = new ConcurrentQueue<Item>();
        private bool _Busy;
        public MemoryBit EndSensor;
        public MemoryBit InSensor;

        public bool ForceEnable;
        public bool Enabled;

        public Road(MemoryBit ins, MemoryBit es,params MemoryBit[] conveyors)
        {
            Conveyors = conveyors;
            InSensor = ins;
            EndSensor = es;
            RoadManager.Instance().Add(this);
        }
    }

    public class RoadManager
    {
        private Task RoadUpdater;
        private ConcurrentBag<Road> Roads;

        public void Add(Road r)
        {
            Roads.Add(r);
        }
        private RoadManager()
        {
            Roads = new ConcurrentBag<Road>();
            RoadUpdater = new Task(() =>
            {
                Console.WriteLine("RoadManager Started");
                while (true)
                {
                    foreach (var Road in Roads)
                    {
                        bool enabled = true;
                        if (Road.EndSensor != null)
                        {
                            enabled = Road.EndSensor.Value || Road.ForceEnable;    
                        }
                        foreach (var conv in Road.Conveyors)
                        {
                            conv.Value = enabled;
                        }

                        Road.Enabled = enabled;
                    }
                }
                
            });
            RoadUpdater.Start();
        }

        private static RoadManager Inst = null;
        
        public static RoadManager Instance()
        {
            if (Inst == null) Inst = new RoadManager();
            return Inst;
        }
    }
}