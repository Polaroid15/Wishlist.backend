using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WL.Application.Common.Extensions;

namespace WL.PublicApi.DiExtensions;

public static class UsingHealthChecksExtensions
{
    public static void UseCustomHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health",
            new HealthCheckOptions {
                ResponseWriter = async (context, report) =>
                {
                    var result = new {
                        status = report.Status.ToString(),
                        errors = report.Entries.Select(e => new {
                            key = e.Key,
                            value = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                        })
                    }.ToJson();
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });
    }
}