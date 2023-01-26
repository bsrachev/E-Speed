namespace E_Speed.Infrastructure
{
    using System.Security.Claims;

    using static E_Speed.Data.DataConstants.Roles;

    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);

        public static bool IsOfficeEmployee(this ClaimsPrincipal user)
            => user.IsInRole(OfficeEmployeeRoleName);

        public static bool IsDeliveryEmployee(this ClaimsPrincipal user)
            => user.IsInRole(DeliveryEmployeeRoleName);
    }
}
