namespace WebApplicationFSharp.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging


open TeamOpenTasks.Infrastructure.Data.Models
open TeamOpenTasks.Draft.TestData

[<ApiController>]
[<Route("api/[controller]")>]
type TeamsController (logger : ILogger<TeamsController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let teams = Teams.allTeams |> List.toArray
        ActionResult<Team[]>(teams)

    [<HttpGet("{id}")>]
    member this.Get(id: Guid) =
        let value = Teams.tryFind id
        match value with
        | Some team -> OkObjectResult(team) :> ObjectResult
        | None -> NotFoundObjectResult((*"none"*)) :> ObjectResult

    [<HttpPost>]
    member this.Post([<FromBody>] team:Team) =
        let createdTeam = Teams.addTeam team.Title team.SprintStart team.SprintZeroStartDate team.SprintLength
        OkObjectResult(createdTeam) :> ObjectResult

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] team:Team) =
        let updatedTeam = Teams.updateTeam team
        OkObjectResult(updatedTeam) :> ObjectResult

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
