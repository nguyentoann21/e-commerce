namespace e_commerce_server.Services.Interfaces
{
    public interface IStorage
    {
        Task<string> StaticFileStorage(IFormFile file, string folder);
    }
}
