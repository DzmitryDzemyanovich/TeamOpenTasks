namespace WebApplicationFSharp

#nowarn "20"

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()
        builder.Services.AddSwaggerGen()

        let app = builder.Build()

        if not (app.Environment.IsProduction()) then
            app.UseSwagger(fun options -> options.SerializeAsV2 <- true)

            app.UseSwaggerUI(fun options -> options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"))
            |> ignore

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode
