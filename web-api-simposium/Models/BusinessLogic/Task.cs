using System.ComponentModel.DataAnnotations;

namespace web_api_simposium.Models.BusinessLogic
{
    public class TaskResponseGet
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public DateTime Creation { get; set; }
    }

    public class TaskRegistration
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The number of characters of the user name must be between 5 to 50")]
        public string Title { get; set; } = string.Empty;
        [StringLength(200, MinimumLength = 5, ErrorMessage = "The number of characters of the user name must be between 5 to 200")]
        public string Description { get; set; } = string.Empty;
    }

    public class TaskUpdated
    {
        [Required(ErrorMessage = "The {0} is required")]
        public string Id { get; set; } = string.Empty;
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The number of characters of the user name must be between 5 to 50")]
        public string Title { get; set; } = string.Empty;
        [StringLength(200, MinimumLength = 5, ErrorMessage = "The number of characters of the user name must be between 5 to 200")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "The {0} is required")]
        public bool Completed { get; set; }
    }
}
