namespace TeamOpenTasks

module TestData =
    open System
    open Users
    open Teams
    open Helpers
    open UserRoles

    module Teams =
        let team1: Team = createTeam "Team 1"
        let team2: Team = createTeam "Team 2"
        let adminTeam: Team = createTeam "Admins"

        let allTeams = [team1; team2; adminTeam]

    module Users =
        let admin: User = { 
            Id = Guid.NewGuid()
            Name = "Test Admin"
            TeamsMembership = [createAdmin Teams.adminTeam]
            }

        let sm1: User = { 
            Id = Guid.NewGuid()
            Name = "SM team 1"
            TeamsMembership = [createSM Teams.team1]
            }

        let sm2: User = { 
            Id = Guid.NewGuid()
            Name = "SM team 2"
            TeamsMembership = [createSM Teams.team2]
            }

        let member11: User = { 
            Id = Guid.NewGuid()
            Name = "Member 1 team 1"
            TeamsMembership = [createMember Teams.team1]
            }

        let member12: User = { 
            Id = Guid.NewGuid()
            Name = "Member 2 team 1"
            TeamsMembership = [createMember Teams.team1]
            }

        let member21: User = { 
            Id = Guid.NewGuid()
            Name = "Member 1 team 2"
            TeamsMembership = [createMember Teams.team2]
            }

        let member22: User = { 
            Id = Guid.NewGuid()
            Name = "Member 2 team 2"
            TeamsMembership = [createMember Teams.team2]
            }

        let na1: User = { 
            Id = Guid.NewGuid()
            Name = "N/A 1"
            TeamsMembership = []
            }

        let na2: User = { 
            Id = Guid.NewGuid()
            Name = "N/A 2"
            TeamsMembership = []
            }

        let allUsers = [admin; sm1; sm2; member11; member12; member21; member22; na1; na2]

        let addUser (u:User) : User list =
            //TODO: add user to DB
            u::allUsers

        let removeUser (u:User) : User list =
            //TODO: remove user from DB
            allUsers |> List.filter (fun x -> x.Id <> u.Id)

        let isInRole (t:Team) (r:Role) (u:User) : bool =
            u.TeamsMembership 
            |> List.filter (fun tm -> (tm.TeamId=t.Id) && (tm.Role=r))
            |> List.length
            |> (=) 1

        let isAdmin (u:User) : bool =
            u |> isInRole Teams.adminTeam Role.Admin

        let isSM (t:Team) (u:User) : bool =
            u |> isInRole t Role.ScrumMaster

        let isSimpleMember (t:Team) (u:User) : bool =
            u |> isInRole t Role.TeamMember

        let isAnyMember (t:Team) (u:User) : bool =
            isSM t u || isSimpleMember t u

        let addTeam (t:Team) (ts:Team list) : Team list =
            t::ts

        let removeTeam (t:Team) (ts:Team list) : Team list =
            ts |> List.filter (fun x -> x.Id <> t.Id)
