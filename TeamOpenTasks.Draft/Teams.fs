namespace TeamOpenTasks

open System
open Tasks

module Teams =
    type Team = {
        Id: Guid
        Title: string
        SprintZeroStartDate: DateTime
        SprintStart: DayOfWeek
        SprintLength: int
        Tasks: Task list
        }

    let private globalTeam: Team = {
        Id = Guid.NewGuid()
        Title = "Global list"
        SprintZeroStartDate = new DateTime(2019, 03, 8)
        SprintStart = DayOfWeek.Friday
        SprintLength = 10
        Tasks = []
    }

    let createTeam t = { globalTeam with Id = Guid.NewGuid(); Title = t }

    let changeTeamTitle (t:string) (team:Team): Team =
        {team with Title=t}

    let changeTeamSprintStart (s:DayOfWeek) (team:Team): Team =
        {team with SprintStart=s}

    let changeTeamSprintLength (l:int) (team:Team): Team =
        {team with SprintLength=l}

    let addTeamTask (t:Task) (tm:Team): Team =
        {tm with Tasks=(t::tm.Tasks)}

    let removeTeamTask (task:Task) (tm:Team): Team =
        {tm with Tasks=(tm.Tasks |> List.filter (fun t -> t.Id <> task.Id))}