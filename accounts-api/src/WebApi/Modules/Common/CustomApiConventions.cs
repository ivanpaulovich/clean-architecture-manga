namespace WebApi.Modules.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

/// <summary>
/// </summary>
public static class CustomApiConventions
{
    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public static void Create([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public static void Delete([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public static void Edit([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id, [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public static void Find([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    public static void List([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public static void Post([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public static void Patch([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id, [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public static void Update([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id, [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
    {
        // Convention
    }
}
