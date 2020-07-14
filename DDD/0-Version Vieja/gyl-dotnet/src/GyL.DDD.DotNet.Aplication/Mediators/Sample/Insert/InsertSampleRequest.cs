using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Insert
{
    public class InsertSampleRequest : Notifiable, IRequest<Result>
    {
        public GyL.DDD.DotNet.Domain.Model.Sample Value { get; }
        public InsertSampleRequest(GyL.DDD.DotNet.Domain.Model.Sample sample)
        {
            Value = sample;
        }
    }
}
