using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Get
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, EntityResult<List<SampleDto>>>
    {
        private readonly ITestQuery _testQuery;
        public GetAllHandler(ITestQuery testQuery)
        {
            _testQuery = testQuery;
        }
        public async Task<EntityResult<List<SampleDto>>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _testQuery.GetAllSample();

            return new EntityResult<List<SampleDto>>(request.Notifications, retorno);
        }
    }
}
