using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1WebServices.SwaggerRelated
{
    public class Header : IOperationFilter
    {
        private const string APIKey = "SE-YASER-API-KEY";

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = APIKey,
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "string" },
                Required = false
            });
        }
    }
}
