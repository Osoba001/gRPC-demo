using Grpc.Core;

namespace DistanceGrpc.Services
{
    public class CustomerServic:CustomerService.CustomerServiceBase
    {
        private readonly ILogger<CustomerServic> logger;

        public CustomerServic(ILogger<CustomerServic> logger)
        {
            this.logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var custer =  new CustomerModel();

            if (request.UserId==1)
            {
                custer.Name = "Joy";
                custer.IsAlive= true;
                custer.Email = "Joy@gmail.com";
                custer.Age = 30;
            }else
            {
                custer.Name = "Peter";
                custer.IsAlive = false;
                custer.Email = "Peter11@gmail.com";
                custer.Age = 100;
            }
            return Task.FromResult(custer);
            
        }

        public override async Task GetAllCustomerInfo(AllCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {

            var customers = new List<CustomerModel>();

            customers.Add(new CustomerModel() { Age=23,Email="Peter@gmail.com", Name="Peter", IsAlive=true});
            customers.Add(new CustomerModel() { Age=20,Email="Joy@gmail.com", Name="Joy", IsAlive=true});
            customers.Add(new CustomerModel() { Age=28,Email="Jame@gmail.com", Name="Jame", IsAlive=true});

            foreach (var cust in customers)
            {
               await responseStream.WriteAsync(cust);
            }
        }
    }
}
