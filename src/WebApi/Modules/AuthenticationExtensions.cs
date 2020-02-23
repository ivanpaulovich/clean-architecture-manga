namespace WebApi.Modules
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text.Json;
    using Domain.Security.Services;
    using Infrastructure.GitHubAuthentication;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    // https://www.jerriepelser.com/blog/authenticate-oauth-aspnet-core-2/
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("AuthenticationModule:UseFake");
            if (useFake)
            {
                services.AddSingleton<IUserService, TestUserService>();
            }
            else
            {
                services.AddScoped<IUserService, GitHubUserService>();

                services.AddAuthorization(options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                });

                services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = "GitHub";
                    })
                    .AddCookie()
                    .AddOAuth("GitHub", options =>
                    {
                        options.ClientId = configuration["GitHub:ClientId"];
                        options.ClientSecret = configuration["GitHub:ClientSecret"];
                        options.CallbackPath = new PathString("/signin-github");

                        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                        options.UserInformationEndpoint = "https://api.github.com/user";

                        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                        options.ClaimActions.MapJsonKey("urn:github:login", "login");
                        options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
                        options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");

                        options.Events = new OAuthEvents
                        {
                            OnCreatingTicket = async context =>
                            {
                                var request =
                                    new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                request.Headers.Authorization =
                                    new AuthenticationHeaderValue("Bearer", context.AccessToken);

                                var response = await context.Backchannel.SendAsync(request,
                                    HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted)
                                    .ConfigureAwait(false);
                                response.EnsureSuccessStatusCode();

                                var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync()
                                    .ConfigureAwait(false));

                                context.RunClaimActions(user.RootElement);
                            }
                        };
                    });
            }


            return services;
        }
    }
}
