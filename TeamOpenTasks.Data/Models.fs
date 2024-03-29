namespace TeamOpenTasks.Infrastructure.Data

open Types
open System

module Models =

    [<CLIMutable>]
    type Task = {
        Id: TaskId
        Title: TaskTitle
        CreationDate: DateTime
        Description: TaskDescription
        IsDone: bool
        }

    [<CLIMutable>]
    type TaskAssignment = {
        TaskId: TaskId
        UserId: UserId
        AssignedAt: DateTime
        Expires: DateTime option
        RespawnOnExpiration: bool
        }

    [<CLIMutable>]
    type Team = {
        Id: TeamId
        Title: TeamTitle
        SprintZeroStartDate: DateTime
        SprintStart: DayOfWeek
        SprintLength: int
        Tasks: Task list
        }

    [<CLIMutable>]
    type User = {
        Id: UserId
        Name: UserName
        TeamsMembership: TeamMembership list
        }