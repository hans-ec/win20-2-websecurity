using System.ComponentModel.DataAnnotations;

namespace _02_FileUploading.Models
{
    public class FileItem
    {
        [Key]
        public Guid Id { get; set; }
        public string UntrustedName { get; set; }
        public DateTime Created { get; set; }
        public long Size { get; set; }
        public byte[] Content { get; set; }
    }
}
