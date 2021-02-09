using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EngineIO;
using System.Net;

namespace NtiPain
{
    class Program
    {
        static void Main(string[] args)
        {
            // var listener = new HttpListener();
            //
            // listener.Prefixes.Add("http://127.0.0.1:8080/");
            // listener.Start();
            //
            // MemoryBit turnLeft = MemoryMap.Instance.GetBit(2, MemoryType.Output);
            //
            // while (true)
            // {
            //     HttpListenerContext ctx = listener.GetContext();
            //
            //     HttpListenerRequest req = ctx.Request;
            //     HttpListenerResponse resp = ctx.Response;
            //     
            //     Console.WriteLine(req.RawUrl);
            //     
            //     turnLeft.Value = req.RawUrl.Equals("/true");
            //     MemoryMap.Instance.Update();
            //     resp.Close();
            //
            // }
            var storageController = new StorageController();
            
            // storageController.Emit();
            // storageController.FromStartToLeftStorage();
            // storageController.LeftForkLoader.TakeFrom(StorageController.ForkLoader.Side.Left);
            // storageController.LeftForkLoader.MoveTo(54);
            // storageController.LeftForkLoader.PutTo(StorageController.ForkLoader.Side.Right);
            
            storageController.LeftForkLoader.MoveTo(54);
            storageController.LeftForkLoader.TakeFrom(StorageController.ForkLoader.Side.Right);
            storageController.LeftForkLoader.MoveTo(55);
            storageController.LeftForkLoader.PutTo(StorageController.ForkLoader.Side.Right);
            storageController.FromLeftToOut();
            
            // storageController.BatchLoad(new Location(StorageController.ForkLoader.Side.Left, 54), new Location(StorageController.ForkLoader.Side.Left, 53));
            // storageController.LeftForkLoader.TakeFrom(StorageController.ForkLoader.Side.Left);
            // storageController.LeftForkLoader.MoveTo(1);
            // storageController.LeftForkLoader.PutTo(StorageController.ForkLoader.Side.Right);



        }
    }
}
