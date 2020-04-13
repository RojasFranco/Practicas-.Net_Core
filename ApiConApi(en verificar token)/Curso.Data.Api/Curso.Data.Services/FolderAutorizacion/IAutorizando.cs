using Curso.Common.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Data.Services.FolderAutorizacion
{
    public interface IAutorizando
    {
        IRestResponse TestApi(string token);
    }
}
