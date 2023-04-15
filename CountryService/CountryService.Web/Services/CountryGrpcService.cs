using CountryService.Web.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CountryService.Web.Protos.CountryService;

namespace CountryService.Web.Services;

public class CountryGrpcService : CountryServiceBase
{
    public override async Task GetAll(Empty request, IServerStreamWriter
<CountryReply> responseStream, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
    public override async Task<CountryReply> Get(CountryIdRequest request,
   ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
    public override async Task<Empty> Delete(IAsyncStreamReader<CountryId
   Request> requestStream, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
    public override async Task<Empty> Update(CountryUpdateRequest request,
   ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
    public override async Task Create(IAsyncStreamReader<CountryCreation
Request> requestStream, IServerStreamWriter<CountryCreationReply>
responseStream, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
}
