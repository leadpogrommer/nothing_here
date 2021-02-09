using EngineIO;

namespace NtiPain
{
    public class Memories
    {
        public MemoryBit loadrcA4 = MemoryMap.Instance.GetBit("Load RC A4", MemoryType.Output);
        public MemoryBit unloadrcA5 = MemoryMap.Instance.GetBit("Unload RC A5", MemoryType.Output);
        public MemoryInt targetPositionA = MemoryMap.Instance.GetInt("Target Position A", MemoryType.Output);
        public MemoryBit forksLeftA = MemoryMap.Instance.GetBit("Forks Left A", MemoryType.Output);
        public MemoryBit liftA = MemoryMap.Instance.GetBit("Lift A", MemoryType.Output);
        public MemoryBit forksRightA = MemoryMap.Instance.GetBit("Forks Right A", MemoryType.Output);

        public MemoryBit loadrcB3 = MemoryMap.Instance.GetBit("Load RC B3", MemoryType.Output);
        public MemoryBit unloadrcB4 = MemoryMap.Instance.GetBit("Unload RC B4", MemoryType.Output);
        public MemoryInt targetPositionB = MemoryMap.Instance.GetInt("Target Position B", MemoryType.Output);
        public MemoryBit forksLeftB = MemoryMap.Instance.GetBit("Forks Left B", MemoryType.Output);
        public MemoryBit liftB = MemoryMap.Instance.GetBit("Lift B", MemoryType.Output);
        public MemoryBit forksRightB = MemoryMap.Instance.GetBit("Forks Right B", MemoryType.Output);

        public MemoryBit rc11 = MemoryMap.Instance.GetBit("RC (4m) 1.1", MemoryType.Output);
        public MemoryBit rc12 = MemoryMap.Instance.GetBit("RC (6m) 1.2", MemoryType.Output);
        public MemoryBit rc13 = MemoryMap.Instance.GetBit("RC (2m) 1.3", MemoryType.Output);
        public MemoryBit rc14 = MemoryMap.Instance.GetBit("RC (2m) 1.4", MemoryType.Output);
        public MemoryBit rc15 = MemoryMap.Instance.GetBit("RC (6m) 1.5", MemoryType.Output);
        public MemoryBit rc16 = MemoryMap.Instance.GetBit("RC (2m) 1.6", MemoryType.Output);
        public MemoryBit rc17 = MemoryMap.Instance.GetBit("RC (4m) 1.7", MemoryType.Output);

        public MemoryBit rcA1 = MemoryMap.Instance.GetBit("RC A1", MemoryType.Output);
        public MemoryBit rcA2 = MemoryMap.Instance.GetBit("Curved RC A2", MemoryType.Output);
        public MemoryBit rcA3 = MemoryMap.Instance.GetBit("RC A3", MemoryType.Output); 
        public MemoryBit rcA6 = MemoryMap.Instance.GetBit("RC A6", MemoryType.Output);
        public MemoryBit rcA7 = MemoryMap.Instance.GetBit("RC A7", MemoryType.Output);
        public MemoryBit rcA8 = MemoryMap.Instance.GetBit("RC A8", MemoryType.Output);
        public MemoryBit rcA9 = MemoryMap.Instance.GetBit("RC A9", MemoryType.Output);
        public MemoryBit rcA10 = MemoryMap.Instance.GetBit("RC A10", MemoryType.Output);

        public MemoryBit rcB1 = MemoryMap.Instance.GetBit("RC B1", MemoryType.Output);
        public MemoryBit rcB2 = MemoryMap.Instance.GetBit("RC B2", MemoryType.Output);
        public MemoryBit rcB5 = MemoryMap.Instance.GetBit("RC B5", MemoryType.Output);
        public MemoryBit rcB6 = MemoryMap.Instance.GetBit("Curved RC B6", MemoryType.Output);
        public MemoryBit rcB7 = MemoryMap.Instance.GetBit("RC B7", MemoryType.Output);
        public MemoryBit rcB8 = MemoryMap.Instance.GetBit("RC B8", MemoryType.Output);
        public MemoryBit rcB9 = MemoryMap.Instance.GetBit("RC B9", MemoryType.Output);
        public MemoryBit rcB10 = MemoryMap.Instance.GetBit("RC B10", MemoryType.Output);

        public MemoryBit ct1p = MemoryMap.Instance.GetBit("CT 1 (+)", MemoryType.Output);
        public MemoryBit ct1n = MemoryMap.Instance.GetBit("CT 1 (-)", MemoryType.Output);
        public MemoryBit ct2p = MemoryMap.Instance.GetBit("CT 2 (+)", MemoryType.Output);
        public MemoryBit ct2n = MemoryMap.Instance.GetBit("CT 2 (-)", MemoryType.Output);
        public MemoryBit ct3p = MemoryMap.Instance.GetBit("CT 3 (+)", MemoryType.Output);
        public MemoryBit ct3n = MemoryMap.Instance.GetBit("CT 3 (-)", MemoryType.Output);
        public MemoryBit ct4p = MemoryMap.Instance.GetBit("CT 4 (+)", MemoryType.Output);
        public MemoryBit ct4n = MemoryMap.Instance.GetBit("CT 4 (-)", MemoryType.Output);
        public MemoryBit ct1Ap = MemoryMap.Instance.GetBit("CT 1A (+)", MemoryType.Output);
        public MemoryBit ct1An = MemoryMap.Instance.GetBit("CT 1A (-)", MemoryType.Output);
        public MemoryBit ct2Ap = MemoryMap.Instance.GetBit("CT 2A (+)", MemoryType.Output);
        public MemoryBit ct2An = MemoryMap.Instance.GetBit("CT 2A (-)", MemoryType.Output);
        public MemoryBit ct3Bp = MemoryMap.Instance.GetBit("CT 3B (+)", MemoryType.Output);
        public MemoryBit ct3Bn = MemoryMap.Instance.GetBit("CT 3B (-)", MemoryType.Output);
        public MemoryBit ct4Bp = MemoryMap.Instance.GetBit("CT 4B (+)", MemoryType.Output);
        public MemoryBit ct4Bn = MemoryMap.Instance.GetBit("CT 4B (-)", MemoryType.Output);
        public MemoryBit ctAp = MemoryMap.Instance.GetBit("CT A (+)", MemoryType.Output);
        public MemoryBit ctAn = MemoryMap.Instance.GetBit("CT A (-)", MemoryType.Output);
        public MemoryBit ctBp = MemoryMap.Instance.GetBit("CT B (+)", MemoryType.Output);
        public MemoryBit ctBn = MemoryMap.Instance.GetBit("CT B (-)", MemoryType.Output);

        public MemoryBit ct1L = MemoryMap.Instance.GetBit("CT 1 Left", MemoryType.Output);
        public MemoryBit ct1R = MemoryMap.Instance.GetBit("CT 1 Right", MemoryType.Output);
        public MemoryBit ct2L = MemoryMap.Instance.GetBit("CT 2 Left", MemoryType.Output);
        public MemoryBit ct2R = MemoryMap.Instance.GetBit("CT 2 Right", MemoryType.Output);
        public MemoryBit ct3L = MemoryMap.Instance.GetBit("CT 3 Left", MemoryType.Output);
        public MemoryBit ct3R = MemoryMap.Instance.GetBit("CT 3 Right", MemoryType.Output);
        public MemoryBit ct4L = MemoryMap.Instance.GetBit("CT 4 Left", MemoryType.Output);
        public MemoryBit ct4R = MemoryMap.Instance.GetBit("CT 4 Right", MemoryType.Output);
        public MemoryBit ct1AL = MemoryMap.Instance.GetBit("CT 1A Left", MemoryType.Output);
        public MemoryBit ct1AR = MemoryMap.Instance.GetBit("CT 1A Right", MemoryType.Output);
        public MemoryBit ct2AL = MemoryMap.Instance.GetBit("CT 2A Left", MemoryType.Output);
        public MemoryBit ct2AR = MemoryMap.Instance.GetBit("CT 2A Right", MemoryType.Output);
        public MemoryBit ct3BL = MemoryMap.Instance.GetBit("CT 3B Left", MemoryType.Output);
        public MemoryBit ct3BR = MemoryMap.Instance.GetBit("CT 3B Right", MemoryType.Output);
        public MemoryBit ct4BL = MemoryMap.Instance.GetBit("CT 4B Left", MemoryType.Output);
        public MemoryBit ct4BR = MemoryMap.Instance.GetBit("CT 4B Right", MemoryType.Output);
        public MemoryBit ctAL = MemoryMap.Instance.GetBit("CT A Left", MemoryType.Output);
        public MemoryBit ctAR = MemoryMap.Instance.GetBit("CT A Right", MemoryType.Output);
        public MemoryBit ctBL = MemoryMap.Instance.GetBit("CT B Left", MemoryType.Output);
        public MemoryBit ctBR = MemoryMap.Instance.GetBit("CT B Right", MemoryType.Output);

        public MemoryBit rStop1 = MemoryMap.Instance.GetBit("StopR 1 Out", MemoryType.Input);
        public MemoryBit rStop1A = MemoryMap.Instance.GetBit("StopR 1A In", MemoryType.Input);
        public MemoryBit rStop2 = MemoryMap.Instance.GetBit("StopR 2 In", MemoryType.Input);
        public MemoryBit rStop2Aout = MemoryMap.Instance.GetBit("StopR 2A Out", MemoryType.Input);
        public MemoryBit rStop2AfromB = MemoryMap.Instance.GetBit("StopR 2A In from B", MemoryType.Input);
        public MemoryBit rStop2AfromA = MemoryMap.Instance.GetBit("StopR 2A In from A", MemoryType.Input);
        public MemoryBit rStopA = MemoryMap.Instance.GetBit("StopR A", MemoryType.Input);
        public MemoryBit rStopB = MemoryMap.Instance.GetBit("StopR B", MemoryType.Input);
        public MemoryBit rStop3in = MemoryMap.Instance.GetBit("StopR 3 In", MemoryType.Input);
        public MemoryBit rStop3out = MemoryMap.Instance.GetBit("StopR 3 Out", MemoryType.Input);
        public MemoryBit rStop3Bin = MemoryMap.Instance.GetBit("StopR 3B In", MemoryType.Input);
        public MemoryBit rStop3BtoB = MemoryMap.Instance.GetBit("StopR 3B Out to B", MemoryType.Input);
        public MemoryBit rStop3BtoA = MemoryMap.Instance.GetBit("StopR 3B Out to A", MemoryType.Input);
        public MemoryBit rStop4B = MemoryMap.Instance.GetBit("StopR 4B", MemoryType.Input);

        public MemoryBit movingXA = MemoryMap.Instance.GetBit("Moving X A", MemoryType.Input);
        public MemoryBit movingZA = MemoryMap.Instance.GetBit("Moving Z A", MemoryType.Input);
        public MemoryBit atLoadA = MemoryMap.Instance.GetBit("At Load A", MemoryType.Input);
        public MemoryBit atLeftA = MemoryMap.Instance.GetBit("At Left A", MemoryType.Input);
        public MemoryBit atMiddleA = MemoryMap.Instance.GetBit("At Middle A", MemoryType.Input);
        public MemoryBit atRightA = MemoryMap.Instance.GetBit("At Right A", MemoryType.Input);

        public MemoryBit movingXB = MemoryMap.Instance.GetBit("Moving X B", MemoryType.Input);
        public MemoryBit movingZB = MemoryMap.Instance.GetBit("Moving Z B", MemoryType.Input);
        public MemoryBit atLoadB = MemoryMap.Instance.GetBit("At Load B", MemoryType.Input);
        public MemoryBit atLeftB = MemoryMap.Instance.GetBit("At Left B", MemoryType.Input);
        public MemoryBit atMiddleB = MemoryMap.Instance.GetBit("At Middle B", MemoryType.Input);
        public MemoryBit atRightB = MemoryMap.Instance.GetBit("At Right B", MemoryType.Input);

        public MemoryBit cs1 = MemoryMap.Instance.GetBit("CS 1", MemoryType.Input);
        public MemoryBit cs2 = MemoryMap.Instance.GetBit("CS 2", MemoryType.Input);
        public MemoryBit cs3 = MemoryMap.Instance.GetBit("CS 3", MemoryType.Input);
        public MemoryBit cs4 = MemoryMap.Instance.GetBit("CS 4", MemoryType.Input);
        public MemoryBit cs1A = MemoryMap.Instance.GetBit("CS 1A", MemoryType.Input);
        public MemoryBit cs2A = MemoryMap.Instance.GetBit("CS 2A", MemoryType.Input);
        public MemoryBit cs3B = MemoryMap.Instance.GetBit("CS 3B", MemoryType.Input);
        public MemoryBit cs4B = MemoryMap.Instance.GetBit("CS 4B", MemoryType.Input);
        public MemoryBit csA = MemoryMap.Instance.GetBit("CS A", MemoryType.Input);
        public MemoryBit csB = MemoryMap.Instance.GetBit("CS B", MemoryType.Input);

        public MemoryBit rs1In = MemoryMap.Instance.GetBit("RS 1 In", MemoryType.Input);
        public MemoryBit rs1Out = MemoryMap.Instance.GetBit("RS 1 Out", MemoryType.Input);
        public MemoryBit rs1AIn = MemoryMap.Instance.GetBit("RS 1A In", MemoryType.Input);
        public MemoryBit rs1AOut = MemoryMap.Instance.GetBit("RS 1A Out", MemoryType.Input);

        public MemoryBit rs2In = MemoryMap.Instance.GetBit("RS 2 In", MemoryType.Input);
        public MemoryBit rs2Out = MemoryMap.Instance.GetBit("RS 2 Out", MemoryType.Input);
        public MemoryBit rs2AfromA = MemoryMap.Instance.GetBit("RS 2A In From A", MemoryType.Input);
        public MemoryBit rs2AfromB = MemoryMap.Instance.GetBit("RS 2A In From B", MemoryType.Input);
        public MemoryBit rs2AOut = MemoryMap.Instance.GetBit("RS 2A Out", MemoryType.Input);

        public MemoryBit rs3In = MemoryMap.Instance.GetBit("RS 3 In", MemoryType.Input);
        public MemoryBit rs3Out = MemoryMap.Instance.GetBit("RS 3 Out", MemoryType.Input);
        public MemoryBit rs3AtoA = MemoryMap.Instance.GetBit("RS 3B Out to A", MemoryType.Input);
        public MemoryBit rs3AtoB = MemoryMap.Instance.GetBit("RS 3B Out to B", MemoryType.Input);
        public MemoryBit rs3BIn = MemoryMap.Instance.GetBit("RS 3B In", MemoryType.Input);

        public MemoryBit rs4In = MemoryMap.Instance.GetBit("RS 4 In", MemoryType.Input);
        public MemoryBit rs4Out = MemoryMap.Instance.GetBit("RS 4 Out", MemoryType.Input);
        public MemoryBit rs4BIn = MemoryMap.Instance.GetBit("RS 4B In", MemoryType.Input);
        public MemoryBit rs4BOut = MemoryMap.Instance.GetBit("RS 4B Out", MemoryType.Input);

        public MemoryBit rsAIn = MemoryMap.Instance.GetBit("RS A In", MemoryType.Input);
        public MemoryBit rsAOut = MemoryMap.Instance.GetBit("RS A Out", MemoryType.Input);
        public MemoryBit rsAtoB = MemoryMap.Instance.GetBit("RS A Out to B", MemoryType.Input);
        public MemoryBit rsBIn = MemoryMap.Instance.GetBit("RS B In", MemoryType.Input);
        public MemoryBit rsBfromA = MemoryMap.Instance.GetBit("RS B In from A", MemoryType.Input);
        public MemoryBit rsBOut = MemoryMap.Instance.GetBit("RS B Out", MemoryType.Input);

        public MemoryInt rfidInCommand = MemoryMap.Instance.GetInt("RFID In Command", MemoryType.Output);
        public MemoryBit rfidInExecuteCommand = MemoryMap.Instance.GetBit("RFID In Execute Command", MemoryType.Output);
        public MemoryInt rfidInMemoryIndex = MemoryMap.Instance.GetInt("RFID In Memory Index", MemoryType.Output);
        public MemoryInt rfidInWriteData = MemoryMap.Instance.GetInt("RFID In Write Data", MemoryType.Output);
        public MemoryInt rfidInCommandID = MemoryMap.Instance.GetInt("RFID In Command ID", MemoryType.Input);
        public MemoryInt rfidInStatus = MemoryMap.Instance.GetInt("RFID In Status", MemoryType.Input);
        public MemoryInt rfidInReadData = MemoryMap.Instance.GetInt("RFID In Read Data", MemoryType.Input);

        public MemoryInt rfid2Command = MemoryMap.Instance.GetInt("RFID 2 Command", MemoryType.Output);
        public MemoryBit rfid2ExecuteCommand = MemoryMap.Instance.GetBit("RFID 2 Execute Command", MemoryType.Output);
        public MemoryInt rfid2MemoryIndex = MemoryMap.Instance.GetInt("RFID 2 Memory Index", MemoryType.Output);
        public MemoryInt rfid2WriteData = MemoryMap.Instance.GetInt("RFID 2 Write Data", MemoryType.Output);
        public MemoryInt rfid2CommandID = MemoryMap.Instance.GetInt("RFID 2 Command ID", MemoryType.Input);
        public MemoryInt rfid2Status = MemoryMap.Instance.GetInt("RFID 2 Status", MemoryType.Input);
        public MemoryInt rfid2ReadData = MemoryMap.Instance.GetInt("RFID 2 Read Data", MemoryType.Input);

        public MemoryInt rfidOutCommand = MemoryMap.Instance.GetInt("RFID Out Command", MemoryType.Output);
        public MemoryBit rfidOutExecuteCommand = MemoryMap.Instance.GetBit("RFID Out Execute Command", MemoryType.Output);
        public MemoryInt rfidOutMemoryIndex = MemoryMap.Instance.GetInt("RFID Out Memory Index", MemoryType.Output);
        public MemoryInt rfidOutWriteData = MemoryMap.Instance.GetInt("RFID Out Write Data", MemoryType.Output);
        public MemoryInt rfidOutCommandID = MemoryMap.Instance.GetInt("RFID Out Command ID", MemoryType.Input);
        public MemoryInt rfidOutStatus = MemoryMap.Instance.GetInt("RFID Out Status", MemoryType.Input);
        public MemoryInt rfidOutReadData = MemoryMap.Instance.GetInt("RFID Out Read Data", MemoryType.Input);

        public MemoryInt rfidA1Command = MemoryMap.Instance.GetInt("RFID A1 Command", MemoryType.Output);
        public MemoryBit rfidA1ExecuteCommand = MemoryMap.Instance.GetBit("RFID A1 Execute Command", MemoryType.Output);
        public MemoryInt rfidA1MemoryIndex = MemoryMap.Instance.GetInt("RFID A1 Memory Index", MemoryType.Output);
        public MemoryInt rfidA1WriteData = MemoryMap.Instance.GetInt("RFID A1 Write Data", MemoryType.Output);
        public MemoryInt rfidA1CommandID = MemoryMap.Instance.GetInt("RFID A1 Command ID", MemoryType.Input);
        public MemoryInt rfidA1Status = MemoryMap.Instance.GetInt("RFID A1 Status", MemoryType.Input);
        public MemoryInt rfidA1ReadData = MemoryMap.Instance.GetInt("RFID A1 Read Data", MemoryType.Input);

        public MemoryInt rfidA2Command = MemoryMap.Instance.GetInt("RFID A2 Command", MemoryType.Output);
        public MemoryBit rfidA2ExecuteCommand = MemoryMap.Instance.GetBit("RFID A2 Execute Command", MemoryType.Output);
        public MemoryInt rfidA2MemoryIndex = MemoryMap.Instance.GetInt("RFID A2 Memory Index", MemoryType.Output);
        public MemoryInt rfidA2WriteData = MemoryMap.Instance.GetInt("RFID A2 Write Data", MemoryType.Output);
        public MemoryInt rfidA2CommandID = MemoryMap.Instance.GetInt("RFID A2 Command ID", MemoryType.Input);
        public MemoryInt rfidA2Status = MemoryMap.Instance.GetInt("RFID A2 Status", MemoryType.Input);
        public MemoryInt rfidA2ReadData = MemoryMap.Instance.GetInt("RFID A2 Read Data", MemoryType.Input);

        public MemoryInt rfidA3Command = MemoryMap.Instance.GetInt("RFID A3 Command", MemoryType.Output);
        public MemoryBit rfidA3ExecuteCommand = MemoryMap.Instance.GetBit("RFID A3 Execute Command", MemoryType.Output);
        public MemoryInt rfidA3MemoryIndex = MemoryMap.Instance.GetInt("RFID A3 Memory Index", MemoryType.Output);
        public MemoryInt rfidA3WriteData = MemoryMap.Instance.GetInt("RFID A3 Write Data", MemoryType.Output);
        public MemoryInt rfidA3CommandID = MemoryMap.Instance.GetInt("RFID A3 Command ID", MemoryType.Input);
        public MemoryInt rfidA3Status = MemoryMap.Instance.GetInt("RFID A3 Status", MemoryType.Input);
        public MemoryInt rfidA3ReadData = MemoryMap.Instance.GetInt("RFID A3 Read Data", MemoryType.Input);

        public MemoryInt rfidA4Command = MemoryMap.Instance.GetInt("RFID A4 Command", MemoryType.Output);
        public MemoryBit rfidA4ExecuteCommand = MemoryMap.Instance.GetBit("RFID A4 Execute Command", MemoryType.Output);
        public MemoryInt rfidA4MemoryIndex = MemoryMap.Instance.GetInt("RFID A4 Memory Index", MemoryType.Output);
        public MemoryInt rfidA4WriteData = MemoryMap.Instance.GetInt("RFID A4 Write Data", MemoryType.Output);
        public MemoryInt rfidA4CommandID = MemoryMap.Instance.GetInt("RFID A4 Command ID", MemoryType.Input);
        public MemoryInt rfidA4Status = MemoryMap.Instance.GetInt("RFID A4 Status", MemoryType.Input);
        public MemoryInt rfidA4ReadData = MemoryMap.Instance.GetInt("RFID A4 Read Data", MemoryType.Input);

        public MemoryInt rfidB1Command = MemoryMap.Instance.GetInt("RFID B1 Command", MemoryType.Output);
        public MemoryBit rfidB1ExecuteCommand = MemoryMap.Instance.GetBit("RFID B1 Execute Command", MemoryType.Output);
        public MemoryInt rfidB1MemoryIndex = MemoryMap.Instance.GetInt("RFID B1 Memory Index", MemoryType.Output);
        public MemoryInt rfidB1WriteData = MemoryMap.Instance.GetInt("RFID B1 Write Data", MemoryType.Output);
        public MemoryInt rfidB1CommandID = MemoryMap.Instance.GetInt("RFID B1 Command ID", MemoryType.Input);
        public MemoryInt rfidB1Status = MemoryMap.Instance.GetInt("RFID B1 Status", MemoryType.Input);
        public MemoryInt rfidB1ReadData = MemoryMap.Instance.GetInt("RFID B1 Read Data", MemoryType.Input);

        public MemoryInt rfidB2Command = MemoryMap.Instance.GetInt("RFID B2 Command", MemoryType.Output);
        public MemoryBit rfidB2ExecuteCommand = MemoryMap.Instance.GetBit("RFID B2 Execute Command", MemoryType.Output);
        public MemoryInt rfidB2MemoryIndex = MemoryMap.Instance.GetInt("RFID B2 Memory Index", MemoryType.Output);
        public MemoryInt rfidB2WriteData = MemoryMap.Instance.GetInt("RFID B2 Write Data", MemoryType.Output);
        public MemoryInt rfidB2CommandID = MemoryMap.Instance.GetInt("RFID B2 Command ID", MemoryType.Input);
        public MemoryInt rfidB2Status = MemoryMap.Instance.GetInt("RFID B2 Status", MemoryType.Input);
        public MemoryInt rfidB2ReadData = MemoryMap.Instance.GetInt("RFID B2 Read Data", MemoryType.Input);

        public MemoryInt rfidB3Command = MemoryMap.Instance.GetInt("RFID B3 Command", MemoryType.Output);
        public MemoryBit rfidB3ExecuteCommand = MemoryMap.Instance.GetBit("RFID B3 Execute Command", MemoryType.Output);
        public MemoryInt rfidB3MemoryIndex = MemoryMap.Instance.GetInt("RFID B3 Memory Index", MemoryType.Output);
        public MemoryInt rfidB3WriteData = MemoryMap.Instance.GetInt("RFID B3 Write Data", MemoryType.Output);
        public MemoryInt rfidB3CommandID = MemoryMap.Instance.GetInt("RFID B3 Command ID", MemoryType.Input);
        public MemoryInt rfidB3Status = MemoryMap.Instance.GetInt("RFID B3 Status", MemoryType.Input);
        public MemoryInt rfidB3ReadData = MemoryMap.Instance.GetInt("RFID B3 Read Data", MemoryType.Input);

        public MemoryBit emitterEmit = MemoryMap.Instance.GetBit("Emitter 1 (Emit)", MemoryType.Output);
        public MemoryInt emitterBase = MemoryMap.Instance.GetInt("Emitter 1 (Base)", MemoryType.Output);
        public MemoryInt emitterPart = MemoryMap.Instance.GetInt("Emitter 1 (Part)", MemoryType.Output);

        public Memories()
        {
            rcA1.Value = true;
            rcA2.Value = true;
            rcA3.Value = true;
            rcA6.Value = true;
            rcA7.Value = true;
            rcA8.Value = true;
            rcA9.Value = true;
            rcA10.Value = true;
            rcB1.Value = true;
            rcB2.Value = true;
            rcB5.Value = true;
            rcB6.Value = true;
            rcB7.Value = true;
            rcB8.Value = true;
            rcB9.Value = true;
            rcB10.Value = true;
            rc11.Value = true;
            rc12.Value = true;
            rc13.Value = true;
            rc14.Value = true;
            rc15.Value = true;
            rc16.Value = true;
            rc17.Value = true;

            targetPositionA.Value = 55;
            targetPositionB.Value = 55;
        }
    }
}