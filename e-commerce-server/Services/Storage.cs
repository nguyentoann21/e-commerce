using e_commerce_server.Services.Interfaces;

namespace e_commerce_server.Services
{
    public class Storage : IStorage
    {
        public async Task<string> StaticFileStorage(IFormFile file, string folder)
        {
            // Check if the uploaded file is null; if so, return the default image file name
            if (file == null) return "default-image-file.png";

            // Generate a unique file name using a GUID and the original file name
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            // Combine the root folder (wwwroot) with the specified folder to create the storage path
            var storageFolder = Path.Combine("wwwroot", folder);

            // Create the storage folder if it does not already exist
            Directory.CreateDirectory(storageFolder);

            // Combine the storage folder path with the unique file name to get the full file path
            var filePath = Path.Combine(storageFolder, uniqueFileName);
            
            // Create a new FileStream to write the file to the specified path in create mode
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Asynchronously copy the uploaded file to the file stream
                await file.CopyToAsync(fileStream);
            }

            // Return the unique file name - the path is relative to the application root
            return Path.Combine(string.Empty, uniqueFileName);
        }
    }
}
