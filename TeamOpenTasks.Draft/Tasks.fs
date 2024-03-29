namespace TeamOpenTasks.Draft

open System
open TeamOpenTasks.Infrastructure.Data.Types
open TeamOpenTasks.Infrastructure.Data.Models

module Tasks =

    let createTask (tid: TaskId) (t:TaskTitle) (d:TaskDescription) : Task =
        { Id= tid; Title=t; CreationDate=DateTime.Now; Description=d; IsDone=false }

    let editTitle (t:TaskTitle) (task:Task) : Task =
        { task with Title = t}

    let editDescription (d:TaskDescription) (task:Task) : Task =
        { task with Description = d }

    let editIsDone (isdone:bool) (task:Task) : Task =
        { task with IsDone = isdone }
/////////////////////////////////////////////////////////////////////////////////////////////

    let mutable allTaskAssignments:TaskAssignment list = []

    let assignTask (tid: TaskId) (uid: UserId) (e: DateTime option) (r:bool) : TaskAssignment =
        { TaskId=tid; UserId=uid; AssignedAt=DateTime.Now; Expires=e; RespawnOnExpiration=r}

    let addTaskAssignment (ta:TaskAssignment) : TaskAssignment list =
        allTaskAssignments <- ta::allTaskAssignments
        allTaskAssignments

    let removeTaskAssignment (ta:TaskAssignment) (tas:TaskAssignment list):TaskAssignment list =
        allTaskAssignments <- tas |> List.filter (fun t -> t.TaskId <> ta.TaskId || t.UserId <> ta.UserId)
        allTaskAssignments

    let checkForExpiration (ta:TaskAssignment): bool =
        match ta.Expires with
        | Some date -> date.Date <= DateTime.Today
        | None -> false
