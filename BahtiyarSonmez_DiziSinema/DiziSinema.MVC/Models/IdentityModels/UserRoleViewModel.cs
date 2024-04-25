namespace DiziSinema.MVC.Models.IdentityModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public List<AssignRoleViewModel> Roles { get; set; }
    }
}
