namespace Manga.WebApi.Filters
{
    using System;
    using System.Collections.Generic;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Linq;

    public class SwaggerDocumentFilter : IDocumentFilter
    {
        private readonly List<Tag> _tags = new List<Tag>
        {
            new Tag { 
            	Name = "RoutingApi", 
            	Description = "This is a description for the api routes" 
            }
        };

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc == null)
            {
                throw new ArgumentNullException(nameof(swaggerDoc));
            }

            swaggerDoc.Tags = GetFilteredTagDefinitions(context);
            swaggerDoc.Paths = GetSortedPaths(swaggerDoc);
        }

        private List<Tag> GetFilteredTagDefinitions(DocumentFilterContext context)
        {
            //Filtering ensures route for tag is present
            var currentGroupNames = context.ApiDescriptions
            	.Select(description => description.GroupName);
            return _tags.Where(tag => currentGroupNames.Contains(tag.Name)).ToList();
        }

        private IDictionary<string, PathItem> GetSortedPaths(
        	SwaggerDocument swaggerDoc)
        {
            return swaggerDoc.Paths.OrderBy(pair => pair.Key)
            	.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}