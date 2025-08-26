namespace Catalog.API.Config
{
    public class SwaggerOptions
    {
        public string Title { get; set; } = default!;
        public string Version { get; set; } = default!;
        public SwaggerContact Contact { get; set; } = new();
    }
    public class SwaggerContact
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Url { get; set; } = default!;
    }
}
