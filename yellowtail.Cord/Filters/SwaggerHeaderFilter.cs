using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Yellowtail.Cord.Filters;

public class SwaggerHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Tenant-Id",
            In = ParameterLocation.Header,
            Description = "The tenant ID for scoping requests",
            Required = false,
            Schema = new OpenApiSchema { Type = "string", Format = "uuid" }
        });

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-User-Id",
            In = ParameterLocation.Header,
            Description = "The user ID for audit tracking",
            Required = false,
            Schema = new OpenApiSchema { Type = "string", Format = "uuid" }
        });
    }
}
