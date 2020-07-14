using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Util;
using GyL.DDD.DotNet.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Update
{
	public class UpdateSampleHandler : IRequestHandler<UpdateSampleRequest, ResponseBase>
	{
		private readonly ISampleRepository _sampleRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateSampleHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
		{
			_sampleRepository = sampleRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ResponseBase> Handle(UpdateSampleRequest request, CancellationToken cancellationToken)
		{
			if (request.Valid)
			{
				var updated = _sampleRepository.Update(Mapper.Map<UpdateSampleRequest, Domain.Model.Sample>(request));
				int recordsAffected = await _unitOfWork.SaveChangesAsync();
				return new ResponseBase(StatusCode.NoContent);
			}
			return new ResponseBase(request.Notifications);
		}
	}
}
