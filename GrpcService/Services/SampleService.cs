using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class SampleService : Sample.SampleBase
    {
        public override async Task<SampleResponse> GetFullName (SampleRequest request,ServerCallContext context)
        {
            string fullName = $"{request.FirstName} {request.LastName}";

            return new SampleResponse { FullName = fullName};
        }
    }
}
