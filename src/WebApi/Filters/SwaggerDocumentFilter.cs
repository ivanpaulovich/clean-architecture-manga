namespace WebApi.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class SwaggerDocumentFilter : IDocumentFilter
    {
        private readonly List<OpenApiTag> _tags = new List<OpenApiTag>
        {
            new OpenApiTag {Name = "RoutingApi", Description = "This is a description for the api routes"}
        };

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc is null)
            {
                throw new ArgumentNullException(nameof(swaggerDoc));
            }

            swaggerDoc.Tags = this.GetFilteredTagDefinitions(context);
            swaggerDoc.Paths = this.GetSortedPaths(swaggerDoc);
        }

        private List<OpenApiTag> GetFilteredTagDefinitions(DocumentFilterContext context)
        {
            // Filtering ensures route for tag is present
            var currentGroupNames = context.ApiDescriptions
                .Select(description => description.GroupName);

            return this._tags
                .Where(tag => currentGroupNames.Contains(tag.Name))
                .ToList();
        }

        private OpenApiPaths GetSortedPaths(
            OpenApiDocument swaggerDoc)
        {
            IDictionary<string, OpenApiPathItem> dic = swaggerDoc.Paths
                .OrderBy(pair => pair.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return null;
        }
    }
}
