namespace TeamOpenTasks

open System

module Tasks =
    type Task = {
        Id: Guid
        Title: string
        CreationDate: DateTime
        Description: string
        IsDone: bool
        }

    type TaskAssignment = {
        TaskId: Guid
        UserId: Guid
        AssignedAt: DateTime
        CanExpire: bool
        CanUnassign: bool
        }
