using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Insert
{
    class InsertSampleHandler : IRequestHandler<InsertSampleRequest, Result>
    {
        private readonly ISampleRepository _sampleRepository;
        public InsertSampleHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<Result> Handle(InsertSampleRequest request, CancellationToken cancellationToken)
        {
            await _sampleRepository.InsertAsync(request.Value);
            return new Result(request.Notifications) { StatusCode = StatusCode.Ok };
        }
    }
}
