using Yellowtail.Cord.Application.Common.Interfaces;

namespace Yellowtail.Cord.Infrastructure.Services;

public class CurrentUserProvider : ICurrentUserProvider
{
    // For POC with no auth, return a static system user GUID.
    public Guid? CurrentUserId => new Guid("00000000-0000-0000-0000-000000000001");
}
