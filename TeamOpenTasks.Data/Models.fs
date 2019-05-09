namespace TeamOpenTasks.Data

open Types
open System

module Models =

    type Task = {
        Id: TaskId
        Title: TaskTitle
        CreationDate: DateTime
        Description: TaskDescription
        IsDone: bool
        }

    type TaskAssignment = {
        TaskId: TaskId
        UserId: UserId
        AssignedAt: DateTime
        Expires: DateTime option
        RespawnOnExpiration: bool
        }

    type Team = {
        Id: TeamId
        Title: TeamTitle
        SprintZeroStartDate: DateTime
        SprintStart: DayOfWeek
        SprintLength: int
        Tasks: Task list
        }

    type TeamMembership = { 
        TeamId: TeamId
        Role: Role
        }

    type User = {
        Id: UserId
        Name: UserName
        TeamsMembership: TeamMembership list
        }