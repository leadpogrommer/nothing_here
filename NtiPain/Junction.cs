using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EngineIO;

namespace NtiPain
{
    public class Junction
    {
        public JunctionInput[] Inputs;
        public JunctionOutput[] Outputs;
        public Task Worker;
        public MemoryBit AtSensor;

        public Dictionary<Item.Destination, int> RoutingTable;
        
        public void Logic()
        {
            // main loop
            while (true)
            {
                JunctionInput current = null;
                // input loop
                while (current == null)
                {
                    foreach (var input in Inputs)
                    {
                        if (!input.Line.EndSensor.Value)
                        {
                            current = input;
                            break;
                        }
                    }
                    Thread.Sleep(16);
                    
                }
                current.Load();
                Item currentItem = null; 
                current.Line.Items.TryDequeue(out currentItem);
                JunctionOutput cout = Outputs[RoutingTable[currentItem.Dest]];
                cout.Line.Items.Enqueue(currentItem);
                cout.Unload();
                
            }
        }

        public Junction(MemoryBit atSensor)
        {
            AtSensor = atSensor;
        }
        
        public Junction Start()
        {
            Worker = new Task(()=>
            {
                try
                {
                    Logic();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            Worker.Start();
            return this;
        }

        public Junction SetInputs(params JunctionInput[] ji)
        {
            Inputs = ji;
            foreach (var input in Inputs)
            {
                input.ReadySensor = AtSensor;
            }
            return this;
        }
        public Junction SetOutputs(params JunctionOutput[] jo)
        {
            Outputs = jo;
            return this;
        }

        public Junction SetRoutingTable(Dictionary<Item.Destination, int> rt)
        {
            RoutingTable = rt;
            return this;
        }
    }
    
    
    
    
    public class DoubleJunction
    {
        public JunctionInput[] TopInputs;
        public JunctionInput[] BottomInputs;
        public JunctionOutput[] TopOutputs;
        public JunctionOutput[] BottomOutputs;
        public Task Worker;
        public MemoryBit AtUpSensor;
        public MemoryBit AtDownSensor;
        public MemoryBit Top1;
        public MemoryBit Top2;
        public MemoryBit Bot1;
        public MemoryBit Bot2;
    
        public Dictionary<Item.Destination, int> RoutingTable;
        
        public void Logic()
        {
            // throw new IndexOutOfRangeException();
            // main loop
            while (true)
            {
                JunctionInput current = null;
                bool fromTop = false;
                // input loop
                while (current == null)
                {
                    foreach (var input in TopInputs)
                    {
                        if (!input.Line.EndSensor.Value)
                        {
                            current = input;
                            fromTop = true;
                            break;
                        }
                        
                    }
                    if (current != null) break;
                    foreach (var input in BottomInputs)
                    {
                        if (!input.Line.EndSensor.Value)
                        {
                            current = input;
                            break;
                        }
                        
                    }
                    Thread.Sleep(16);
                    
                }
                current.Load();
                Item currentItem = null; 
                current.Line.Items.TryDequeue(out currentItem);

                bool toTop = true;
                
                int outputIndex = RoutingTable[currentItem.Dest];

                JunctionOutput cout;
                if (outputIndex >= TopOutputs.Length)
                {
                    toTop = false;
                    cout = BottomOutputs[outputIndex - TopOutputs.Length];
                }
                else
                {
                    cout = TopOutputs[outputIndex];
                }

                if (toTop != fromTop)
                {
                    if (toTop)
                    {
                        Top1.Value = true;
                        Top2.Value = true;
                        while(!AtUpSensor.Value)Thread.Sleep(16);
                        Top1.Value = false;
                        Top2.Value = false;
                    }
                    else
                    {
                        Bot1.Value = true;
                        Bot2.Value = true;
                        while(!AtDownSensor.Value)Thread.Sleep(16);
                        Bot1.Value = false;
                        Bot2.Value = false;
                    }
                }
                
                
                cout.Line.Items.Enqueue(currentItem);
                // Console.WriteLine("Begin Unload");
                cout.Unload();
                // Console.WriteLine("End Unload");
                
            }
        }
    
        public DoubleJunction(MemoryBit topSensor, MemoryBit bottomSensor, MemoryBit t1, MemoryBit t2, MemoryBit b1, MemoryBit b2)
        {
            AtUpSensor = topSensor;
            AtDownSensor = bottomSensor;
            Top1 = t1;
            Top2 = t2;
            Bot1 = b1;
            Bot2 = b2;
        }
        
        public DoubleJunction Start()
        {
            Worker = new Task(()=>
            {
                try
                {
                    Logic();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            });
            Worker.Start();
            return this;
        }
    
        public DoubleJunction SetTopInputs(params JunctionInput[] ji)
        {
            TopInputs = ji;
            foreach (var input in ji)
            {
                input.ReadySensor = AtUpSensor;
            }
            return this;
        }
        public DoubleJunction SetBottomInputs(params JunctionInput[] ji)
        {
            BottomInputs = ji;
            foreach (var input in ji)
            {
                input.ReadySensor = AtDownSensor;
            }
            return this;
        }
        public DoubleJunction SetTopOutputs(params JunctionOutput[] jo)
        {
            TopOutputs = jo;
            return this;
        }
        public DoubleJunction SetBottomOutputs(params JunctionOutput[] jo)
        {
            BottomOutputs = jo;
            return this;
        }
    
        public DoubleJunction SetRoutingTable(Dictionary<Item.Destination, int> rt)
        {
            RoutingTable = rt;
            return this;
        }
    }

    public class JunctionOutput
    {
        public MemoryBit Sensor;
        public Road Line;
        public MemoryBit OutBit;

        public JunctionOutput(Road road, MemoryBit outBit)
        {
            Sensor = road.InSensor;
            Line = road;
            OutBit = outBit;
        }

        public void Unload()
        {
            OutBit.Value = true;
            while (Sensor.Value)
            {
                OutBit.Value = Line.Enabled;
                Thread.Sleep(32);
            }

            while (!Sensor.Value)
            {
                OutBit.Value = Line.Enabled;
                Thread.Sleep(32);
            }
            OutBit.Value = false;
        }
    }
    public class JunctionInput
    {
        public MemoryBit ReadySensor;
        public Road Line;
        public MemoryBit InBit;

        public JunctionInput(Road road, MemoryBit inBit)
        {
            Line = road;
            InBit = inBit;
            // ReadySensor = rs;
        }

        public void Load()
        {
            // Console.WriteLine("Loading");
            InBit.Value = true;
            Line.ForceEnable = true;
            // Console.WriteLine(ReadySensor.Name);
            while (!ReadySensor.Value)Thread.Sleep(32);
            Line.ForceEnable = false;
            InBit.Value = false;
            // Console.WriteLine("Loaded");


        }
    }
}