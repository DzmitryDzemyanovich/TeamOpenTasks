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

    let createTeam t = {
        Id = Guid.NewGuid()
        Title = t
        SprintZeroStartDate = globalTeam.SprintZeroStartDate
        SprintStart = globalTeam.SprintStart
        SprintLength = globalTeam.SprintLength
        Tasks = globalTeam.Tasks
        }
