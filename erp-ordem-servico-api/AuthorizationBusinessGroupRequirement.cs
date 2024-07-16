using Microsoft.AspNetCore.Authorization;

namespace erp_ordem_servico_api
{
    public class AuthorizationBusinessGroupRequirement : IAuthorizationRequirement
    {
        public string GroupName { get; }

        public AuthorizationBusinessGroupRequirement(string groupName)
        {
            GroupName = groupName;
        }
    }
}
