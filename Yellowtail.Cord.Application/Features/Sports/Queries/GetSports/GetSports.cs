using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yellowtail.Cord.Application.Common.Interfaces.Repositories;
using Yellowtail.Cord.Application.Common.Models;

namespace Yellowtail.Cord.Application.Features.Sports.Queries.GetSports;

public record GetSportsQuery(int Page = 1, int PageSize = 20) : IRequest<PaginatedList<SportDto>>;

public class GetSportsQueryValidator : AbstractValidator<GetSportsQuery>
{
    public GetSportsQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}

public class GetSportsQueryHandler : IRequestHandler<GetSportsQuery, PaginatedList<SportDto>>
{
    private readonly ISportRepository _repository;

    public GetSportsQueryHandler(ISportRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<SportDto>> Handle(GetSportsQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll()
            .AsNoTracking()
            .Select(s => new SportDto(s.Id, s.Name, s.Description, s.ModifiedDate));

        return await PaginatedList<SportDto>.CreateAsync(query, request.Page, request.PageSize, cancellationToken);
    }
}
