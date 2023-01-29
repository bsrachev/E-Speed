namespace E_Speed.Infrastructure
{
    using System.Security.Claims;

    using static E_Speed.Data.DataConstants.Roles;

    public static class ClaimsPrincipalExtensions
    {
        public static int Id(this ClaimsPrincipal user)
        {
            int userId = 0;
            if (user.HasClaim(claim => claim.Type == ClaimTypes.NameIdentifier))
            {
                userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return userId;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);

        public static bool IsOfficeEmployee(this ClaimsPrincipal user)
            => user.IsInRole(OfficeEmployeeRoleName);

        public static bool IsDeliveryEmployee(this ClaimsPrincipal user)
            => user.IsInRole(DeliveryEmployeeRoleName);
    }
}
