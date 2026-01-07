using System.Net.Http.Headers;
using TI_Net_2026_MyBouffe.Bend.BLL.Interfaces;
using TI_Net_2026_MyBouffe.Bend.BLL.Services;
using TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces;
using TI_Net_2026_MyBouffe.Bend.DAL.Repositories;
using TI_Net_2026_MyBouffe.Bend.DAL.Services;

namespace TI_Net_2026_MyBouffe.Bend.API.DependencyInjections
{
    public static class ServicesExtensions
    {

        public static void AddOpenAI(this IServiceCollection services, string apiKey)
        {
            services.AddScoped(s => new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com/v1/"),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
                },
            });

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IOpenAIService, OpenAIServices>();
            services.AddScoped<IRecipeService, RecipeService>();
        }
    }
}
