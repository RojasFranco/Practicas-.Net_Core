using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Update
{
    public class UpdateSampleRequest : Notifiable, IRequest<Result>
    {        

        public UpdateSampleRequest(int idBuscado, string descripcionNueva)
        {
            IdActualizar = idBuscado;
            NuevaDescripcion = descripcionNueva;
        }

        public int IdActualizar { get; set; }

        public string NuevaDescripcion { get; set; }
    }
}
