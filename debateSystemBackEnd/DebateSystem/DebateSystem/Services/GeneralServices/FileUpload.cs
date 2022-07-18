using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DebateSystem.Services.GeneralServices
{
    public class FileUpload
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string connectionString = @"DefaultEndpointsProtocol=https;AccountName=debatesystemaccount;AccountKey=NwsjvlGJidfhf7wG0mucWINyKYlOs8Kb4b/KTbF3ge9cZYy2M5DiAcXbXY1niKBTESdJ2g/A82kC+ASt+aIEmA==;EndpointSuffix=core.windows.net";
                string containerName = "applicationuserpp";
                BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
                var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream);
                return blobClient.Uri.AbsoluteUri;
            }
            return null;
        }
    }
}
