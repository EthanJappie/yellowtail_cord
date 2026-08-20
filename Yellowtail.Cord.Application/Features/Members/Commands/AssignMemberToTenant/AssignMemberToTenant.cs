using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;

namespace Yellowtail.Cord.Application.Features.Members.Commands.AssignMemberToTenant;

public record AssignMemberToTenantCommand(Guid MemberId, Guid TenantId) : IRequest<bool>;

public class AssignMemberToTenantCommandValidator : AbstractValidator<AssignMemberToTenantCommand>
{
    public AssignMemberToTenantCommandValidator()
    {
        RuleFor(x => x.MemberId).NotEmpty();
        RuleFor(x => x.TenantId).NotEmpty();
    }
}

public class AssignMemberToTenantCommandHandler : IRequestHandler<AssignMemberToTenantCommand, bool>
{
    private readonly IMemberRepository _memberRepository;
    private readonly ITenantRepository _tenantRepository;

    public AssignMemberToTenantCommandHandler(IMemberRepository memberRepository, ITenantRepository tenantRepository)
    {
        _memberRepository = memberRepository;
        _tenantRepository = tenantRepository;
    }

    public async Task<bool> Handle(AssignMemberToTenantCommand request, CancellationToken cancellationToken)
    {
        // Must use global repository in case moving between tenants
        var member = await _memberRepository.GetAll().FirstOrDefaultAsync(m => m.Id == request.MemberId, cancellationToken);
        if (member == null)
            return false;

        var tenant = await _tenantRepository.GetByIdAsync(request.TenantId, cancellationToken);
        if (tenant == null)
            return false;

        member.TenantId = request.TenantId;
        
        await _memberRepository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
