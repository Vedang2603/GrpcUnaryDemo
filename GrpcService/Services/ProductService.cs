using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService.Services
{
    public class ProductService: Product.ProductBase
    {
        public override async Task<ProductSaveResponse> SaveProduct(ProductModel request, ServerCallContext context)
        {
            //Insert the Database method to save the product here
            var response = new ProductSaveResponse
            {
                StatusCode = 200,
                IsSuccessful = true
            };
            return response;
        }

        public override async Task<ProductsList> GetProducts(Empty request, ServerCallContext context)
        {
            var product1 = new ProductModel
            {
                ProductName = "Product 1",
                ProductCode = "P001",
                Price = 10.0,
                StockDate = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            var stockDate = DateTime.SpecifyKind(new DateTime(2024, 6, 1), DateTimeKind.Utc);
            var product2 = new ProductModel
            {
                ProductName = "Product 2",
                ProductCode = "P002",
                Price = 20.0,
                StockDate = Timestamp.FromDateTime(stockDate)
            };

            ProductsList products = new ProductsList();
            products.Products.Add(product1);
            products.Products.Add(product2);

            return products;
        }
    }
}
