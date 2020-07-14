using System.Net;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
    public enum StatusCode
    {
        OK = (int)HttpStatusCode.OK,
        Created = (int)HttpStatusCode.Created, //201
        NoContent = (int)HttpStatusCode.NoContent, //204
        NotFound = (int)HttpStatusCode.NotFound, //404
        BadRequest = (int)HttpStatusCode.BadRequest, //400
        UnprocessableEntity = (int)HttpStatusCode.UnprocessableEntity, //422
        Unauthorized = (int)HttpStatusCode.Unauthorized, //401
    }
}
