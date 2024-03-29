namespace TeamOpenTasks.Draft

open System
open TeamOpenTasks.Infrastructure.Data.Types
open TeamOpenTasks.Infrastructure.Data.Models

module Teams =

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

    let changeTeam (t:Team) (nt:Team) : Team =
        t
        |> changeTeamTitle nt.Title
        |> changeTeamSprintStart nt.SprintStart
        |> changeTeamInitialDate nt.SprintZeroStartDate
        |> changeTeamSprintLength nt.SprintLength

    let createTeam (title: TeamTitle) (startDay: DayOfWeek) (startDate: DateTime) (sprintLength: int) : Team =
        createTeamWithTitle title
        |> changeTeamSprintStart startDay
        |> changeTeamInitialDate startDate
        |> changeTeamSprintLength sprintLength

    let addTeamTask (t:Task) (tm:Team): Team =
        {tm with Tasks=(t::tm.Tasks)}

    let removeTeamTask (task:Task) (tm:Team): Team =
        {tm with Tasks=(tm.Tasks |> List.filter (fun t -> t.Id <> task.Id))}
