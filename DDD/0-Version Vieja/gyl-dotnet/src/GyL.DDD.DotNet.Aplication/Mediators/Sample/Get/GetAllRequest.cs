using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Get
{
    public class GetAllRequest : Notifiable, IRequest<EntityResult<List<SampleDto>>>
    {
        public GetAllRequest()
        {

        }
    }
}
