using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CleanArchit.Presantation.MVC.Models
{
    public class TeacherIdentity: IdentityUser
    {
/*        public int UserID
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]*/

        [Required(ErrorMessage = "Please enter correct date", AllowEmptyStrings = false)]
        public string DateOfBirth { get; set; }



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
    }
}
