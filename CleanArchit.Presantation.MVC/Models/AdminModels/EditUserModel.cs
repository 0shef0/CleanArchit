using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CleanArchit.Presantation.MVC.Models.AdminModels
{
    public class EditUserModel
    {
        public string Id { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string Name
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string Sirname { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
