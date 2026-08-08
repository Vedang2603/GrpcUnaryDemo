using Grpc.Net.Client;
using GrpcService;
namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var client = new Sample.SampleClient(channel);
            var productClient = new Product.ProductClient(channel);

            var response = await client.GetFullNameAsync(new SampleRequest { FirstName = "John", LastName = "Doe" });
            Console.WriteLine(response.FullName);

            var productResponse = await productClient.SaveProductAsync(new ProductModel { ProductName = "Sample Product", ProductCode = "SP001", Price = 99.99 });
            Console.WriteLine($"Product Save Status: {productResponse.StatusCode}, Successful: {productResponse.IsSuccessful}");


            var productsList = await productClient.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());
            foreach (var product in productsList.Products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Product Code: {product.ProductCode}, Price: {product.Price}, Stock Date: {product.StockDate.ToDateTime()}");
            }

            await channel.ShutdownAsync();
            Console.ReadKey();
        }
    }
}
