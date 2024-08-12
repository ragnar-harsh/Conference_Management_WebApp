namespace backend.Data
{
    public class UserModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string role { get; set; }
    }
}