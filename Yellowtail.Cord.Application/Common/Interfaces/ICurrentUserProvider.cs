namespace Yellowtail.Cord.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
    Guid? CurrentUserId { get; }
    void SetCurrentUserId(Guid userId);
}
