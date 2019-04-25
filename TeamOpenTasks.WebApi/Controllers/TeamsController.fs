namespace TeamOpenTasks.WebApi.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open TeamOpenTasks.TestData
open TeamOpenTasks.Teams
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc

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
        let value = Teams.find id
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
