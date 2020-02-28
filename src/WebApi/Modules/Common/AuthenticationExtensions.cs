namespace WebApi.Modules.Common
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text.Json;
    using Domain.Security.Services;
    using Infrastructure.GitHubAuthentication;
    using Microsoft.AspNetCore.Authentication;
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
                    }).AddAuthentication(o =>
                    {
                        o.DefaultScheme = "Application";
                        o.DefaultSignInScheme = "External";
                    })
                    .AddCookie("Application")
                    .AddCookie("External")
                    .AddGoogle(o =>
                    {
                        o.ClientId = configuration["AuthenticationModule:Google:ClientId"];
                        o.ClientSecret = configuration["AuthenticationModule:Google:ClientSecret"];
                        o.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                        o.ClaimActions.Clear();
                        o.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                        o.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                        o.ClaimActions.MapJsonKey("urn:google:profile", "link");
                        o.ClaimActions.MapJsonKey("image", "picture");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                    })
                    .AddOAuth("GitHub", options =>
                    {
                        options.ClientId = configuration["AuthenticationModule:GitHub:ClientId"];
                        options.ClientSecret = configuration["AuthenticationModule:GitHub:ClientSecret"];
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
