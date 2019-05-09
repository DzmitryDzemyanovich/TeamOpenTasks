namespace TeamOpenTasks.WebApi.Controllers

open System
open Microsoft.AspNetCore.Mvc
open TeamOpenTasks.TestData
open TeamOpenTasks.Data.Models

[<Route("api/[controller]")>]
[<ApiController>]
type TeamsController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let teams = Teams.allTeams
        ActionResult<Team[]>(teams |> List.toArray)

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
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
