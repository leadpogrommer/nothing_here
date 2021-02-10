using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using EngineIO;

namespace NtiPain
{
    
        public class ForkLoader
        {
            private MemoryInt Pos;
            private MemoryBit ForkLeft;
            private MemoryBit ForkRight;
            private MemoryBit Lift;
            private MemoryBit MovingX;
            private MemoryBit MovingZ;
            private MemoryBit AtLeft;
            private MemoryBit AtRight;
            private MemoryBit AtMiddle;

            public Side WhoAmI;

            public ConcurrentQueue<UnloadRequest> UnloadRequests = new ConcurrentQueue<UnloadRequest>();
            
            
            private MemoryBit[] AtSide;
            private MemoryBit[] ForkSide;

            public Road InputLine;
            public Road OutputLine;

            private Task Worker;

            
            public ForkLoader(MemoryInt pos, MemoryBit fl, MemoryBit fr, MemoryBit l, MemoryBit x, MemoryBit z, MemoryBit al, MemoryBit ar, MemoryBit am, Road inputLine, Road outputLine, Side mySide)
            {
                pos.Value = 55;
                
                Pos = pos;
                ForkLeft = fl;
                ForkRight = fr;
                Lift = l;
                MovingX = x;
                MovingZ = z;
                AtLeft = al;
                AtMiddle = am;
                AtRight = ar;

                AtSide = new MemoryBit[2] {AtRight, AtLeft};
                ForkSide = new MemoryBit[2] {ForkRight, ForkLeft};

                InputLine = inputLine;
                OutputLine = outputLine;

                WhoAmI = mySide;
            }

            public void TakeFrom(Side s)
            {
                MemoryBit fork = ForkSide[(int) s];
                MemoryBit at = AtSide[(int) s];
                fork.Value = true;
                while (!at.Value) Thread.Sleep(32);
                Lift.Value = true;
                Thread.Sleep(300);
                while (MovingZ.Value) Thread.Sleep(32);

                fork.Value = false;
                while (!AtMiddle.Value) Thread.Sleep(32);
                
            }

            public void MoveTo(int pos)
            {
                Pos.Value = pos;
                Thread.Sleep(100);
                while (MovingX.Value || MovingZ.Value) Thread.Sleep(32);
            }

            public void PutTo(Side s)
            {
                MemoryBit fork = ForkSide[(int) s];
                MemoryBit at = AtSide[(int) s];

                fork.Value = true;
                while(!at.Value)Thread.Sleep(32);
                Lift.Value = false;
                Thread.Sleep(300);
                while (MovingZ.Value) Thread.Sleep(32);
                fork.Value = false;
                while(!AtMiddle.Value)Thread.Sleep(32);
            }

            public void Start()
            {
                Worker = new Task(Logic);
                Worker.Start();
            }

            public void Logic()
            {
                while (true)
                {
                    if (!InputLine.Enabled) Load();
                    if (!UnloadRequests.IsEmpty) Unload();
                    Thread.Sleep(16);
                }
            }

            public void Load()
            {
                Item currentItem;
                InputLine.Items.TryDequeue(out currentItem);
                MoveTo(55);
                TakeFrom(Side.Left);
                MoveTo(currentItem.Place.CellPosition);
                PutTo(currentItem.Place.CellSide);
                currentItem.Moving = false;
            }

            public void Unload()
            {
                // TODO: Add unloading safeguard
                UnloadRequests.TryDequeue(out UnloadRequest request);
                var item = ItemDatabase.Instance().GetItem(request.Id);
                item.Moving = true;
                
                MoveTo(item.Place.CellPosition);
                TakeFrom(item.Place.CellSide);
                item.Dest = request.NewDestination;
                item.Place = request.NewCellLocation;
                if (request.NewDestination != Item.Destination.Out && WhoAmI == request.NewCellLocation.Rack)
                {
                    MoveTo(item.Place.CellPosition);
                    PutTo(item.Place.CellSide);
                    item.Moving = false;
                }
                else
                {
                    
                    MoveTo(55);
                    PutTo(Side.Right);
                    OutputLine.Items.Enqueue(item);
                }
                
            }
        }
}