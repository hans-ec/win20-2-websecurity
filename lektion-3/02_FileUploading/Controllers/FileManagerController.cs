using _02_FileUploading.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_FileUploading.Controllers
{
    public class FileManagerController : Controller
    {
        private BlobServiceClient _serviceClient;
        private BlobContainerClient _containerClient;
        private BlobClient _blobClient;

        public FileManagerController(IConfiguration configuration)
        {
            _serviceClient = new BlobServiceClient(configuration.GetConnectionString("StorageAccount"));
            _containerClient = GetBlobContainerClient("files");
        }

        private BlobContainerClient GetBlobContainerClient(string name)
        {
            try { return _serviceClient.CreateBlobContainer(name); }
            catch { return _serviceClient.GetBlobContainerClient(name); }
        }




        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            
            await foreach(BlobItem blobItem in _containerClient.GetBlobsAsync())
                viewModel.Items.Add(blobItem);
            
            return View(viewModel);
        }

        public async Task<IActionResult> Upload(IndexViewModel model)
        {
            using (var ms = new MemoryStream())
            {
                model.FileItem.File.CopyTo(ms);
                _blobClient = _containerClient.GetBlobClient(model.FileItem.File.FileName);
                ms.Position = 0;
                await _blobClient.UploadAsync(ms, true);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Download(string name)
        {
            string localPath = Path.Combine($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\files\download", name);
            _blobClient = _containerClient.GetBlobClient(name);
            await _blobClient.DownloadToAsync(localPath);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string name)
        {
            await _containerClient.DeleteBlobIfExistsAsync(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
