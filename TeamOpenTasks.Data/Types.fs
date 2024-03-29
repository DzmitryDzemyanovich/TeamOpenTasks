namespace TeamOpenTasks.Infrastructure.Data

open System

module Types =

    type Role =
        | Admin = 1
        | ScrumMaster = 2
        | TeamMember = 3     

    type TaskId = TaskId of Guid
    type TaskTitle = TaskTitle of string
    type TaskDescription = string

    type TeamId = Guid
    type TeamTitle = string

    type UserId = Guid
    type UserName = string   

    type TeamMembership = 
        | TeamMembership of TeamId *  Role
