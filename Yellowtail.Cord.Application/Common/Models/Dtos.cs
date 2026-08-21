namespace Yellowtail.Cord.Application.Common.Models;

public record TenantDto(Guid Id, string Name, bool IsActive, DateTime ModifiedDate);

public record MemberDto(Guid Id, Guid TenantId, string FirstName, string LastName, string? PhotoUrl, DateTime ModifiedDate, System.Collections.Generic.List<SportDto> Sports);

public record SportDto(Guid Id, string Name, string Description, DateTime ModifiedDate);
