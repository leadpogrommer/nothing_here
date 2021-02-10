using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EngineIO;

namespace NtiPain
{
    public class StorageController
    {

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

        // public Memories m;

        private Task Updater;

        // public AutoResetEvent UpdateEvent;

        public void Wait()
        {
            Thread.Sleep(32);
        }



        public void Emit()
        {
            M.emitterEmit.Value = false;

            // emitterBase.Value = 6;
            // emitterPart.Value = 2;
            M.emitterEmit.Value = true;

            Wait();

            M.emitterEmit.Value = false;

        }

        public void FromStartToLeftStorage()
        {
            // Input Conveyor
            M.ct1p.Value = true;
            while (!M.cs1.Value) Thread.Sleep(16);

            M.ct1p.Value = false;


            // Load conveyor
            M.loadrcA4.Value = true;
            // Weird Ip Machine
            M.ct1L.Value = true;
            M.ct1AR.Value = true;
            while (M.rs1AOut.Value) Thread.Sleep(32);
            while (!M.rs1AOut.Value) Thread.Sleep(32);
            M.ct1L.Value = false;
            M.ct1AR.Value = false;
            while (M.atLoadA.Value) Thread.Sleep(16);
            M.loadrcA4.Value = false;
        }

        public void FromRightToLeft()
        {
            M.unloadrcB4.Value = true;
            M.ct4BL.Value = true;
            while (!M.cs4B.Value) Thread.Sleep(32);
            M.unloadrcB4.Value = false;
            M.ct4BL.Value = false;

            M.ct4Bp.Value = true;
            M.ct3Bp.Value = true;
            M.ct2Ap.Value = true;
            M.ct1Ap.Value = true;
            while (!M.cs1A.Value) Thread.Sleep(32);
            M.ct4Bp.Value = false;
            M.ct3Bp.Value = false;
            M.ct2Ap.Value = false;
            M.ct1Ap.Value = false;

            M.ct1AR.Value = true;
            M.loadrcA4.Value = true;
            while (M.atLoadA.Value) Thread.Sleep(16);
            M.loadrcA4.Value = false;
            M.ct1AR.Value = false;


        }

        public void FromLeftToRight()
        {
            M.unloadrcA5.Value = true;
            M.ctAp.Value = true;
            M.ctBp.Value = true;
            M.loadrcB3.Value = true;
            while (M.atLoadB.Value) Thread.Sleep(16);
            M.unloadrcA5.Value = false;
            M.ctAp.Value = false;
            M.ctBp.Value = false;
            M.loadrcB3.Value = false;
        }

        public void FromRightToOut()
        {
            M.unloadrcB4.Value = true;
            M.ct4BL.Value = true;
            M.ct4R.Value = true;
            while (!M.cs4.Value) Thread.Sleep(32);
            M.unloadrcB4.Value = false;
            M.ct4BL.Value = false;
            M.ct4R.Value = false;
            M.ct4p.Value = true;
            while (M.rs4Out.Value) Thread.Sleep(32);
            while (!M.rs4Out.Value) Thread.Sleep(32);
            M.ct4p.Value = false;
        }

        public void FromLeftToOut()
        {
            BunchOf bunch;

            bunch = new BunchOf(M.unloadrcA5, M.ctAp);
            while (!M.csA.Value) Thread.Sleep(32);
            bunch.Disable();

            bunch = new BunchOf(M.ctAR, M.ct2AL, M.ct2R);
            while (!M.cs2.Value) Thread.Sleep(32);
            bunch.Disable();

            bunch = new BunchOf(M.ct2p, M.ct3p, M.ct4p);
            while (M.rs4Out.Value) Thread.Sleep(32);
            while (!M.rs4Out.Value) Thread.Sleep(32);
            bunch.Disable();

        }

        private Road RLeftToRight = new Road(M.rsAtoB, M.rsBfromA, M.rcA7);
        private Road RDown = new Road(M.rsAOut, M.rs2AfromA, M.rcA8);
        private Road RLeftUnload = new Road(null, M.rsAIn, M.rcA6, M.unloadrcA5);
        private Road RRightLoad = new Road(M.rsBOut, M.atLoadB, M.loadrcB3, M.rcB2);
        private Road RUp = new Road(M.rs3AtoB, M.rsBIn, M.rcB1);
        private Road RLeftLoad = new Road(M.rs1AOut, M.atLoadA, M.rcA1, M.rcA2, M.rcA3, M.loadrcA4);
        private Road RRightUnload = new Road(null, M.rs4BIn, M.unloadrcB4, M.rcB5, M.rcB6, M.rcB7);
        private Road RInput = new Road(null, M.rs1In, M.rc11);
        private Road ROutput = new Road(M.rs4Out, null, M.rc17);
        private Road RLeftForward = new Road(M.rs1Out, M.rs2In, M.rc13, M.rc12);
        private Road RMiddleForward = new Road(M.rs2Out, M.rs3In, M.rc14);
        private Road RRightForward = new Road(M.rs3Out, M.rs4In, M.rc16, M.rc15);
        private Road RRightBackward = new Road(M.rs4BOut, M.rs3BIn, M.rcB9, M.rcB8);

        private Road RMiddleBackward = new Road(M.rs3AtoA, M.rs2AfromB, M.rcB10);

        private Road RLeftBackward = new Road(M.rs2AOut, M.rs1AIn, M.rcA10, M.rcA9);




        private Junction JTopLeft;
        private Junction JTopRight;
        private DoubleJunction JLeft;
        private DoubleJunction JMiddleLeft;
        private DoubleJunction JMiddleRight;
        private DoubleJunction JRight;

        public StorageController()
        {
            LeftForkLoader = new ForkLoader(M.targetPositionA, M.forksLeftA, M.forksRightA, M.liftA, M.movingXA,
                M.movingZA,
                M.atLeftA, M.atRightA, M.atMiddleA, RLeftLoad, RLeftUnload, Side.Left);
            RightForkLoader = new ForkLoader(M.targetPositionB, M.forksLeftB, M.forksRightB, M.liftB, M.movingXB,
                M.movingZB,
                M.atLeftB, M.atRightB, M.atMiddleB, RRightLoad, RRightUnload, Side.Right);

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

            JTopLeft = new Junction(M.csA)
                .SetInputs(new JunctionInput(RLeftUnload, M.ctAp))
                .SetOutputs(new JunctionOutput(RLeftToRight, M.ctAp), new JunctionOutput(RDown, M.ctAR))
                .SetRoutingTable(new Dictionary<Item.Destination, int>
                    {{Item.Destination.Right, 0}, {Item.Destination.Out, 1}, {Item.Destination.Left, 1}})
                .Start();
            JTopRight = new Junction(M.csB)
                .SetInputs(new JunctionInput(RUp, M.ctBL), new JunctionInput(RLeftToRight, M.ctBp))
                .SetOutputs(new JunctionOutput(RRightLoad, M.ctBp))
                .SetRoutingTable(new Dictionary<Item.Destination, int>() {{Item.Destination.Right, 0}})
                .Start();
            JLeft = new DoubleJunction(M.cs1A, M.cs1, M.ct1AR, M.ct1L, M.ct1AL, M.ct1R)
                .SetTopInputs(new JunctionInput(RLeftBackward, M.ct1Ap))
                .SetBottomInputs(new JunctionInput(RInput, M.ct1p))
                .SetTopOutputs(new JunctionOutput(RLeftLoad, M.ct1AR))
                .SetBottomOutputs(new JunctionOutput(RLeftForward, M.ct1p))
                .SetRoutingTable(new Dictionary<Item.Destination, int>()
                {
                    {Item.Destination.Left, 0},
                    {Item.Destination.Right, 1},
                    {Item.Destination.Out, 1}
                })
                .Start();
            JMiddleLeft = new DoubleJunction(M.cs2A, M.cs2, M.ct2AR, M.ct2L, M.ct2AL, M.ct2R)
                .SetTopInputs(new JunctionInput(RDown, M.ct2AL), new JunctionInput(RMiddleBackward, M.ct2Ap))
                .SetBottomInputs(new JunctionInput(RLeftForward, M.ct2p))
                .SetTopOutputs(new JunctionOutput(RLeftBackward, M.ct2Ap))
                .SetBottomOutputs(new JunctionOutput(RMiddleForward, M.ct2p))
                .SetRoutingTable(new Dictionary<Item.Destination, int>()
                {
                    {Item.Destination.Left, 0},
                    {Item.Destination.Right, 1},
                    {Item.Destination.Out, 1}
                })
                .Start();
            JMiddleRight = new DoubleJunction(M.cs3B, M.cs3, M.ct3BR, M.ct3L, M.ct3BL, M.ct3R)
                .SetTopInputs(new JunctionInput(RRightBackward, M.ct3Bp))
                .SetBottomInputs(new JunctionInput(RMiddleForward, M.ct3p))
                .SetTopOutputs(new JunctionOutput(RUp, M.ct3BR), new JunctionOutput(RMiddleBackward, M.ct3Bp))
                .SetBottomOutputs(new JunctionOutput(RRightForward, M.ct3p))
                .SetRoutingTable(new Dictionary<Item.Destination, int>()
                {
                    {Item.Destination.Left, 1},
                    {Item.Destination.Right, 0},
                    {Item.Destination.Out, 2}
                })
                .Start();
            JRight = new DoubleJunction(M.cs4B, M.cs4, M.ct4BR, M.ct4L, M.ct4BL, M.ct4R)
                .SetTopInputs(new JunctionInput(RRightUnload, M.ct4BL))
                .SetBottomInputs(new JunctionInput(RRightForward, M.ct4p))
                .SetTopOutputs(new JunctionOutput(RRightBackward, M.ct4Bp))
                .SetBottomOutputs(new JunctionOutput(ROutput, M.ct4p))
                .SetRoutingTable(new Dictionary<Item.Destination, int>()
                {
                    {Item.Destination.Left, 0},
                    {Item.Destination.Right, 0},
                    {Item.Destination.Out, 1}
                })
                .Start();
            
            LeftForkLoader.Start();
            RightForkLoader.Start();



        }

        public void Testing()
        {
            // RLeftUnload.Items.Enqueue(new Item(1, Item.Destination.Left));
            // RLeftUnload.Items.Enqueue(new Item(1, Item.Destination.Right));
            // RLeftUnload.Items.Enqueue(new Item(1, Item.Destination.Out));
            // RLeftToRight.Items.Enqueue(new Item(1, Item.Destination.Right));
            // RUp.Items.Enqueue(new Item(1, Item.Destination.Right));


            RInput.Items.Enqueue(new Item(1, Item.Destination.Left));
            RInput.Items.Enqueue(new Item(1, Item.Destination.Right));
            RInput.Items.Enqueue(new Item(1, Item.Destination.Out));

            RRightUnload.Items.Enqueue(new Item(1, Item.Destination.Left));
            RRightUnload.Items.Enqueue(new Item(1, Item.Destination.Out));

            RLeftUnload.Items.Enqueue(new Item(1, Item.Destination.Out));
            RLeftUnload.Items.Enqueue(new Item(1, Item.Destination.Right));
            RLeftBackward.Items.Enqueue(new Item(1, Item.Destination.Left));
        }

        public void Load(int id, CellLocation place)
        {
            var toLoad = new Item(id, place.Rack == Side.Left ? Item.Destination.Left : Item.Destination.Right);
            toLoad.Place = place;
            toLoad.Moving = true;
            ItemDatabase.Instance().AddItem(toLoad);
            RInput.Items.Enqueue(toLoad);
            Emit();
        }

        public void Unload(int id)
        {
            var item = ItemDatabase.Instance().GetItem(id);
            ForkLoader current = item.Place.Rack == Side.Left ? LeftForkLoader : RightForkLoader;
            current.UnloadRequests.Enqueue(new UnloadRequest(id, Item.Destination.Out));
        }

        public void Move(int id, CellLocation dst)
        {
            var item = ItemDatabase.Instance().GetItem(id);
            ForkLoader current = item.Place.Rack == Side.Left ? LeftForkLoader : RightForkLoader;
            current.UnloadRequests.Enqueue(new UnloadRequest(id, dst.Rack == Side.Left? Item.Destination.Left : Item.Destination.Right, dst));
        }

    }
    
// public abstract class AbstractJunction: Thre
}