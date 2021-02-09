using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EngineIO;

namespace NtiPain
{
    public class StorageController
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

            private MemoryBit[] AtSide;
            private MemoryBit[] ForkSide;

            public enum Side: int
            {
                Right,
                Left
            }
            public ForkLoader(MemoryInt pos, MemoryBit fl, MemoryBit fr, MemoryBit l, MemoryBit x, MemoryBit z, MemoryBit al, MemoryBit ar, MemoryBit am)
            {
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
        }
        
        public class BunchOf
        {
            private MemoryBit[] Bits;
            public BunchOf(params MemoryBit[] bits)
            {
                foreach (var bit in bits)
                {
                    bit.Value = true;
                    Bits = bits;
                }
            }

            public void Disable()
            {
                foreach (var bit in Bits)
                {
                    bit.Value = false;
                }
            }
        }
        
        public ForkLoader LeftForkLoader;
        public ForkLoader RightForkLoader;

        public Memories m;

        private Task Updater;

        // public AutoResetEvent UpdateEvent;

        public void Wait()
        {
            Thread.Sleep(32);
        }

        public StorageController()
        {
            m = new Memories();
            LeftForkLoader = new ForkLoader(m.targetPositionA, m.forksLeftA, m.forksRightA, m.liftA, m.movingXA, m.movingZA,
                m.atLeftA, m.atRightA, m.atMiddleA);
            RightForkLoader = new ForkLoader(m.targetPositionB, m.forksLeftB, m.forksRightB, m.liftB, m.movingXB, m.movingZB,
                m.atLeftB, m.atRightB, m.atMiddleB);

            Updater = new Task(() =>
            {
                Console.WriteLine("Updater Started");
                while (true)
                {
                    Thread.Sleep(8);
                    MemoryMap.Instance.Update();    
                }
            });
            Updater.Start();
            Console.WriteLine("After Updater");
            
        }
        
        public void Emit()
        {
            m.emitterEmit.Value = false;
            
            // emitterBase.Value = 6;
            // emitterPart.Value = 2;
            m.emitterEmit.Value = true;
            
            Wait();
            
            m.emitterEmit.Value = false;

        }

        public void FromStartToLeftStorage()
        {
            // Input Conveyor
            m.ct1p.Value = true;
            while (!m.cs1.Value)Thread.Sleep(16);

            m.ct1p.Value = false;


            // Load conveyor
            m.loadrcA4.Value = true;
            // Weird Ip Machine
            m.ct1L.Value = true;
            m.ct1AR.Value = true;
            while (m.rs1AOut.Value)Thread.Sleep(32);
            while (!m.rs1AOut.Value)Thread.Sleep(32);
            m.ct1L.Value = false;
            m.ct1AR.Value = false;
            while (m.atLoadA.Value)Thread.Sleep(16);
            m.loadrcA4.Value = false;
        }

        public void FromRightToLeft()
        {
            m.unloadrcB4.Value = true;
            m.ct4BL.Value = true;
            while (!m.cs4B.Value)Thread.Sleep(32);
            m.unloadrcB4.Value = false;
            m.ct4BL.Value = false;
            
            m.ct4Bp.Value = true;
            m.ct3Bp.Value = true;
            m.ct2Ap.Value = true;
            m.ct1Ap.Value = true;
            while (!m.cs1A.Value) Thread.Sleep(32);
            m.ct4Bp.Value = false;
            m.ct3Bp.Value = false;
            m.ct2Ap.Value = false;
            m.ct1Ap.Value = false;

            m.ct1AR.Value = true;
            m.loadrcA4.Value = true;
            while (m.atLoadA.Value)Thread.Sleep(16);
            m.loadrcA4.Value = false;
            m.ct1AR.Value = false;


        }

        public void FromLeftToRight()
        {
            m.unloadrcA5.Value = true;
            m.ctAp.Value = true;
            m.ctBp.Value = true;
            m.loadrcB3.Value = true;
            while (m.atLoadB.Value)Thread.Sleep(16);
            m.unloadrcA5.Value = false;
            m.ctAp.Value = false;
            m.ctBp.Value = false;
            m.loadrcB3.Value = false;
        }

        public void FromRightToOut()
        {
            m.unloadrcB4.Value = true;
            m.ct4BL.Value = true;
            m.ct4R.Value = true;
            while (!m.cs4.Value) Thread.Sleep(32);
            m.unloadrcB4.Value = false;
            m.ct4BL.Value = false;
            m.ct4R.Value = false;
            m.ct4p.Value = true;
            while (m.rs4Out.Value) Thread.Sleep(32);
            while (!m.rs4Out.Value) Thread.Sleep(32);
            m.ct4p.Value = false;
        }

        public void FromLeftToOut()
        {
            BunchOf bunch;

            bunch = new BunchOf(m.unloadrcA5, m.ctAp);
            while (!m.csA.Value) Thread.Sleep(32);
            bunch.Disable();
            
            bunch = new BunchOf(m.ctAR, m.ct2AL, m.ct2R);
            while (!m.cs2.Value) Thread.Sleep(32);
            bunch.Disable();
            
            bunch = new BunchOf(m.ct2p, m.ct3p, m.ct4p);
            while (m.rs4Out.Value) Thread.Sleep(32);
            while (!m.rs4Out.Value) Thread.Sleep(32);
            bunch.Disable();
            
        }

        public void BatchLoad(params Location[] targetLocations){}
        
    }

    public class Location
    {
        public StorageController.ForkLoader.Side Side;
        public int Place;

        public Location(StorageController.ForkLoader.Side s, int p)
        {
            Side = s;
            Place = p;
        }
    }
    
    // public abstract class AbstractJunction: Thre
}