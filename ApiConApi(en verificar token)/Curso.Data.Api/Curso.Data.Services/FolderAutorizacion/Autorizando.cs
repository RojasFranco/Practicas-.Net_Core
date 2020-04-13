using Curso.Common.DTO;
using Curso.Model.Context;
using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curso.Data.Services.FolderAutorizacion
{
    public class Autorizando : IAutorizando
    {
        private CursoContext _cursoContext;

        public Autorizando(CursoContext cursoContext)
        {
            this._cursoContext = cursoContext;
        }

        public IRestResponse TestApi(string token)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer(); NO ES NECESARIO PORQUE VA EN URL SIN SEREALIZAR
            //var parametroEnviar = serializer.Serialize(token);



            var client = new RestClient("https://localhost:5001/api/Security/ValidarTokenTiempo/"+ token);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddParameter("application/json", "\"PPPPPPPPPP\"", ParameterType.RequestBody); EJ
            //request.AddParameter("text/plain", token, ParameterType.RequestBody); NO HAY BODY ACA
            IRestResponse response = client.Execute(request);
            return response;
        }

    }
}
