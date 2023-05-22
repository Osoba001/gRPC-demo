// See https://aka.ms/new-console-template for more information

using DistanceGrpc;
using Grpc.Core;
using Grpc.Net.Client;


var channel = GrpcChannel.ForAddress("https://localhost:7295");
//var client=new Greeter.GreeterClient(channel);
//var reply= await client.SayHelloAsync(new HelloRequest() { Name="Mr Kelly"});
//Console.WriteLine(reply.Message);

var client=new CustomerService.CustomerServiceClient(channel);
var customer=await client.GetCustomerInfoAsync(new CustomerLookupModel() { UserId=1});
Console.WriteLine(customer);

using(var call=client.GetAllCustomerInfo(new AllCustomerRequest()))
{
    while(await call.ResponseStream.MoveNext())
    {
        Console.WriteLine(call.ResponseStream.Current);
    }
}
Console.ReadLine();
