namespace TeamOpenTasks

open System
open Tasks
open Types

module Teams =
    type Team = {
        Id: TeamId
        Title: TeamTitle
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

    let createTeamWithTitle t = { globalTeam with Id = Guid.NewGuid(); Title = t }

    let changeTeamTitle (t:TeamTitle) (team:Team): Team =
        {team with Title=t}

    let changeTeamSprintStart (s:DayOfWeek) (team:Team): Team =
        {team with SprintStart=s}

    let changeTeamInitialDate (d:DateTime) (team:Team): Team =
        {team with SprintZeroStartDate=d}

    let changeTeamSprintLength (l:int) (team:Team): Team =
        {team with SprintLength=l}

    let createTeam (title: TeamTitle) (startDay: DayOfWeek) (startDate: DateTime) (sprintLength: int) : Team =
        createTeamWithTitle title
        |> changeTeamSprintStart startDay
        |> changeTeamInitialDate startDate
        |> changeTeamSprintLength sprintLength

    let addTeamTask (t:Task) (tm:Team): Team =
        {tm with Tasks=(t::tm.Tasks)}

    let removeTeamTask (task:Task) (tm:Team): Team =
        {tm with Tasks=(tm.Tasks |> List.filter (fun t -> t.Id <> task.Id))}
