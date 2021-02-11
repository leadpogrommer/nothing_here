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

        private static StorageController Controller;
        static void Main(string[] args)
        {
            var listener = new HttpListener();

            Controller = new StorageController();
            
            listener.Prefixes.Add("http://*:8228/");
            // listener.Prefixes.Add("http://172.31.224.1:8228/");
            listener.Start();
            
            
            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
            
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;
                
                // Console.WriteLine(req.RawUrl);

                Route(req, resp);

            }
            var storageController = new StorageController();
            storageController.Testing();
            Thread.Sleep(99999999);
            
        }

        public static void Route(HttpListenerRequest req, HttpListenerResponse resp)
        {
            string responseText = "Ok";
            int responseCode = 200;
            try
            {
                var splitted = req.RawUrl.ToUpper().Split('/');
                if (splitted[1] == "LOAD")
                {
                    var id = Int32.Parse(splitted[2]);
                    var dst = new CellLocation(splitted[3]);
                    Controller.Load(id, dst);
                }
                else if (splitted[1] == "UNLOAD")
                {
                    var id = Int32.Parse(splitted[2]);
                    Controller.Unload(id);
                }
                else if (splitted[1] == "MOVE")
                {
                    var id = Int32.Parse(splitted[2]);
                    var dst = new CellLocation(splitted[3]);
                    Controller.Move(id, dst);
                }
                else if (splitted[1] == "DATA")
                {
                    responseText = ItemDatabase.Instance().GetJson();
                    
                }
                else
                {
                    responseCode = 500;
                    responseText = "{\"error\": \"Unknown endpoint\"}";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                responseText = e.ToString();
                responseCode = 500;
            }

            var buffer = Encoding.UTF8.GetBytes(responseText);
            resp.ContentEncoding = Encoding.UTF8;
            resp.StatusCode = responseCode;
            resp.ContentType = "application/json";
            resp.OutputStream.Write(buffer, 0, buffer.Length);
            resp.Close();
            
        }
    }
}
