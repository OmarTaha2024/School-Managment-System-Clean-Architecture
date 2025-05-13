namespace SchoolManagment.Data.Results
{
    public class ManageUserclaimsResult
    {
        public string UserId { get; set; }
        public List<UserClaims> userClaims { get; set; }
    }
    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}

