using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Extensions
{
    public static class HymnExtensions
    {
        // from https://cdn.statically.io/gh/pseudosavant/LDSHymns/c3a00214e2f879a855f5894b345596dd6c547b70/hymns.json
        public static void AddHymns(this IServiceCollection services)
        {
            var library = new HymnLibrary();
            services.AddSingleton(library);
        }
    }
}