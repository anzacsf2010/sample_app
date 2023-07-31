using System;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace sample_app.Services
{
    public class SharedResource
    {
    }

    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;
        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
#pragma warning disable CS8604 // Possible null reference argument.
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("ShareResource", assemblyName.Name); // §REVIEW_DJE: "SharedResource" or "ShareResource"
#pragma warning restore CS8604 // Possible null reference argument.
        }
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
        }
    }
}