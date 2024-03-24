using UserDetails.Controllers;

namespace UserDetails
{
    public class ValidateUser:IValidateUser
    {
        public bool ValidateUserDetails(UserModel userModel)
        {
            var myDict = new Dictionary<string, string>
        {
            { "faisal", "123456" },
            { "Anas", "654321" }
        };
            if(myDict.ContainsKey(userModel.UserName) && myDict.ContainsValue(userModel.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
