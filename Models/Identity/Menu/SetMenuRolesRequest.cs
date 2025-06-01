namespace Models.Identity.Menu
{
    public class SetMenuRolesRequest
    {
        public Guid MenuId { get; set; }
        public Guid[]? Roles { get; set; }
    }
}
