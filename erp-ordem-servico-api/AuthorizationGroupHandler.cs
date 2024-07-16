using Microsoft.AspNetCore.Authorization;

namespace erp_ordem_servico_api
{
    public class AuthorizationGroupHandler : AuthorizationHandler<AuthorizationBusinessGroupRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationBusinessGroupRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "groups" && c.Value == requirement.GroupName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
