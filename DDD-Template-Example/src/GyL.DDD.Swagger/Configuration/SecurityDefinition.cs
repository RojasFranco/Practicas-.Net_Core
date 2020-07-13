namespace GyL.DDD.DotNet.Swagger.Configuration
{
    public class SecurityDefinition
    {
        public string Type { get; set; }
        public string Flow { get; set; }
        public string Description { get; set; }
        public string TokenUrl { get; set; }
        public string AuthorizationUrl { get; set; }
        public string In { get; set; }
        public string Name { get; set; }
    }
}
