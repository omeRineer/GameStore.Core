namespace Models.Identity.User
{
    public class SetUserRolesRequest
    {
        public Guid UserId { get; set; }
        public Guid[]? Roles { get; set; }
    }
}
