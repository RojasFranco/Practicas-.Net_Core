using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Util;
using GyL.DDD.DotNet.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Create
{
	public class CreateSampleHandler : IRequestHandler<CreateSampleRequest, Response<SampleDto>>
	{
		private readonly ISampleRepository _sampleRepository;
		private readonly IUnitOfWork _unitOfWork;
		public CreateSampleHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
		{
			_sampleRepository = sampleRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Response<SampleDto>> Handle(CreateSampleRequest request, CancellationToken cancellationToken)
		{
			if (request.Valid)
			{
				var created = await _sampleRepository.AddAsync(Mapper.Map<CreateSampleRequest, Domain.Model.Sample>(request));
				int recordsAffected = await _unitOfWork.SaveChangesAsync();
				return new Response<SampleDto>(request.Notifications, Mapper.Map<Domain.Model.Sample, SampleDto>(created.Entity)) { StatusCode = StatusCode.Created };
			}
			return new Response<SampleDto>(request.Notifications, null) { StatusCode = StatusCode.BadRequest }; 
		}
	}
}
