using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace NIDCWA.Models
{
    public class UserBasicViewModel : ObjectViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [StringLength(128)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }

    public class UserLoginViewModel : UserBasicViewModel
    {
        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">User password</param>
        /// <returns>True if exist and password is correct</returns>
        public bool IsValid(string username, string hashedPassword)
        {
            NECCaptran_DevEntities entities = new NECCaptran_DevEntities();

            return (from u in entities.User
                    where u.Username == username &&
                    u.Password == hashedPassword
                    select u.ID).Count() == 1;
        }
    }

    public class UserSaveViewModel : UserBasicViewModel
    {
        [Required]
        [Compare("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string passwordConfirmation { get; set; }
    }

    public class UserDBContext : DbContext
    { 
        public DbSet<UserBasicViewModel> Users { get; set; }
    }
}