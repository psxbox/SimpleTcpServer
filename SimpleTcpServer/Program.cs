// instantiate
using System.Text;
using SimpleUdp;
using SuperSimpleTcp;


// using SimpleTcpServer server = new("*:20091");
// set events
// server.Events.ClientConnected += ClientConnected;
// server.Events.ClientDisconnected += ClientDisconnected;
// server.Events.DataReceived += DataReceived;

UdpEndpoint udp = new("", 20091);
udp.EndpointDetected += EndpointDetected;

// only if you want to receive messages...
udp.DatagramReceived += DatagramReceived;
udp.Start();

// let's go!
// Task task = Task.Run(() =>
// {
//     System.Console.WriteLine("Starting...");
//     server.Start();
//     Thread.Sleep(1000);
//     if (server.IsListening)
//     {
//         System.Console.WriteLine("Listening...");
//     }
//     else
//     {
//         System.Console.WriteLine("Not listening...");
//     }
// });

// task.Wait();
System.Console.WriteLine("Press any key to stop...");
Console.ReadKey();

static void EndpointDetected(object? sender, EndpointMetadata md)
{
  Console.WriteLine("Endpoint detected: " + md.Ip + ":" + md.Port);
}

static void DatagramReceived(object? sender, Datagram dg)
{
  Console.WriteLine("[" + dg.Ip + ":" + dg.Port + "]: " + Encoding.UTF8.GetString(dg.Data));
} 


// static void ClientConnected(object? sender, ConnectionEventArgs e)
// {
//     Console.WriteLine($"[{e.IpPort}] client connected");
// }

// static void ClientDisconnected(object? sender, ConnectionEventArgs e)
// {
//     Console.WriteLine($"[{e.IpPort}] client disconnected: {e.Reason}");
// }

// static void DataReceived(object? sender, DataReceivedEventArgs e)
// {
//     Console.WriteLine($"[{e.IpPort}]: {Encoding.UTF8.GetString(e.Data.Array ?? Array.Empty<byte>(), 0, e.Data.Count)}");
// }