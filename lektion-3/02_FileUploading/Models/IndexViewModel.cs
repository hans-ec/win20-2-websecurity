using Azure.Storage.Blobs.Models;

namespace _02_FileUploading.Models
{
    public class IndexViewModel
    {
        public FileModel FileItem { get; set; }
        public List<BlobItem> Items { get; set; } = new List<BlobItem>();
    }
}
