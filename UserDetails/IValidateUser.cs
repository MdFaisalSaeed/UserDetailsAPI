using UserDetails.Controllers;

namespace UserDetails
{
    public interface IValidateUser
    {
        public bool ValidateUserDetails(UserModel userModel);
    }
}
