using GyL.DDD.DotNet.Aplication.Mediators.Sample.Get;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Domain.Model;
using GyL.DDD.DotNet.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Update
{
    public class UpdateSampleHandler : IRequestHandler<UpdateSampleRequest, Result>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly ITestQuery _testQuery;
        public UpdateSampleHandler(ISampleRepository sampleRepository, ITestQuery testQuery)
        {
            _sampleRepository = sampleRepository;
            _testQuery = testQuery;
        }

        public async Task<Result> Handle(UpdateSampleRequest request, CancellationToken cancellationToken)
        {            
            SampleDto sampleRetornado = await _testQuery.GetSample(request.IdActualizar);
            Domain.Model.Sample sampleActualizar = new Domain.Model.Sample() { Id = sampleRetornado.Id, Description = sampleRetornado.Description };
            

            await _sampleRepository.UpdateAsync(sampleActualizar, request.NuevaDescripcion);

            return new Result(request.Notifications) { StatusCode = StatusCode.Ok };
        }
    }
}
