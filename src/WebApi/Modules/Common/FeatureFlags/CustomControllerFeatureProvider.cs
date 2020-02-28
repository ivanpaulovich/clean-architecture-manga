namespace WebApi.Modules.Common.FeatureFlags
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.FeatureManagement;
    using Microsoft.FeatureManagement.Mvc;

    public sealed class CustomControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        private readonly IFeatureManager _featureManager;

        public CustomControllerFeatureProvider(IFeatureManager featureManager)
        {
            this._featureManager = featureManager;
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            for (int i = feature.Controllers.Count - 1; i >= 0; i--)
            {
                var controller = feature.Controllers[i].AsType();
                foreach (var customAttribute in controller.CustomAttributes)
                {
                    if (customAttribute.AttributeType.FullName == typeof(FeatureGateAttribute).FullName)
                    {
                        var constructorArgument = customAttribute.ConstructorArguments.First();
                        if (constructorArgument.Value is IEnumerable arguments)
                        {
                            foreach (var argumentValue in arguments)
                            {
                                var typedArgument = (CustomAttributeTypedArgument)argumentValue;
                                var typedArgumentValue = (CustomFeature)(int)typedArgument.Value;
                                bool isFeatureEnabled = this._featureManager
                                    .IsEnabledAsync(typedArgumentValue.ToString())
                                    .ConfigureAwait(false)
                                    .GetAwaiter()
                                    .GetResult();

                                if (!isFeatureEnabled)
                                {
                                    feature.Controllers.RemoveAt(i);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
