namespace Manga.WebApi.Filters
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.OpenApi.Models;

    public class SwaggerDocumentFilter : IDocumentFilter
    {
        private readonly List<OpenApiTag> _tags = new List<OpenApiTag>
        {
            new OpenApiTag
            {
                Name = "RoutingApi",
                Description = "This is a description for the api routes"
            }
        };

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc == null)
            {
                throw new ArgumentNullException(nameof(swaggerDoc));
            }

            swaggerDoc.Tags = GetFilteredTagDefinitions(context);
        }

        private List<OpenApiTag> GetFilteredTagDefinitions(DocumentFilterContext context)
        {
            //Filtering ensures route for tag is present
            var currentGroupNames = context.ApiDescriptions
                .Select(description => description.GroupName);
            return _tags.Where(tag => currentGroupNames.Contains(tag.Name))
                .ToList();
        }
    }
}