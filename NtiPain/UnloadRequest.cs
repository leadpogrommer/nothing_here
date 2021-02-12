namespace NtiPain
{
    public class UnloadRequest
    {
        public Item.Destination NewDestination;
        public CellLocation NewCellLocation;
        public int Id;
        public CellLocation OldLocation;

        public UnloadRequest(int id, Item.Destination dest, CellLocation loc = null)
        {
            Id = id;
            NewDestination = dest;
            NewCellLocation = loc;
        }
    }
}