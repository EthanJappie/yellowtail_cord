using Yellowtail.Cord.Application.Common.Interfaces;

namespace Yellowtail.Cord.Infrastructure.Services;

public class CurrentUserProvider : ICurrentUserProvider
{
    private Guid? _currentUserId;

    public Guid? CurrentUserId => _currentUserId ?? new Guid("00000000-0000-0000-0000-000000000001");

    public void SetCurrentUserId(Guid userId)
    {
        _currentUserId = userId;
    }
}
