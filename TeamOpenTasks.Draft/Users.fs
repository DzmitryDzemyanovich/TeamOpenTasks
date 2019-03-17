namespace TeamOpenTasks

open System
open UserRoles
open Teams

module Users =
    type TeamMembership = { TeamId: Guid; Role: Role }

    type User = { 
        Id: Guid
        Name: string
        TeamsMembership: TeamMembership list
        }

    let filterMembership (m:TeamMembership) (ms:TeamMembership list):TeamMembership list =
        ms |> List.filter (fun x -> (x.TeamId <> m.TeamId) && (x.Role <> m.Role))

    let setMembership (u:User) (tm:TeamMembership list) : User =
        { Name=u.Name; Id=u.Id; TeamsMembership=tm }

    let createUser (n:string) : User =
        { Name = n; Id = Guid.NewGuid(); TeamsMembership = [] }

    let addMembership (u:User) (tm:TeamMembership) : User =
        let newTM = tm::u.TeamsMembership
        setMembership u newTM

    let removeMembership (u:User) (tm:TeamMembership) : User =
        let filteredTM = u.TeamsMembership |> filterMembership tm
        setMembership u filteredTM

    let cleanTeamMembership (u:User) (t:Team) : User =
        {u with TeamsMembership=(u.TeamsMembership |> List.filter(fun tm -> tm.TeamId <> t.Id))}