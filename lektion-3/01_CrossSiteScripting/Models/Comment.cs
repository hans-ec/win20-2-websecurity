using System.ComponentModel.DataAnnotations;

namespace _01_CrossSiteScripting.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; }
    }
}
