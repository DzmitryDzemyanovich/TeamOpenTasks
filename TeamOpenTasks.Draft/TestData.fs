namespace TeamOpenTasks
open System.Collections.Generic

module TestData =
    open System
    open Users
    open Teams
    open Helpers
    open UserRoles
    open Tasks

    module Teams =
        let team1: Team = createTeamWithTitle "Team 1"
        let team2: Team = createTeamWithTitle "Team 2"
        let adminTeam: Team = createTeamWithTitle "Admins"

        let mutable allTeams = [team1; team2; adminTeam]

        let find (id: Guid) : Team option=
            let result =
                allTeams 
                |> List.tryFind (fun t -> t.Id = id)
            result

        let addTeam  (title: string) (startDay: DayOfWeek) (startDate: DateTime) (sprintLength: int) :Team =
            let team = Teams.createTeam title startDay startDate sprintLength
            allTeams <- team::allTeams
            team

    module Users =
//#region Test Users
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
//#endregion

        let mutable allUsers = [admin; sm1; sm2; member11; member12; member21; member22; na1; na2]

        let addUser (u:User) (us:User list): User list =
            //TODO: add user to DB
            u::us

        let removeUser (u:User) (us:User list): User list =
            //TODO: remove user from DB
            us |> List.filter (fun x -> x.Id <> u.Id)

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
            isAdmin u || isSM t u || isSimpleMember t u

        let addTeam (t:Team) (ts:Team list) : Team list =
            //add to DB
            t::ts

        let removeTeam (t:Team) (ts:Team list) : Team list =
            //removefromDB
            ts |> List.filter (fun x -> x.Id <> t.Id)

        let getUserTeamRole (u:User) (t:Team): Role option =
            if isAdmin u then Some Role.Admin
            elif isSM t u then Some Role.ScrumMaster
            elif isSimpleMember t u then Some Role.TeamMember
            else None

        let getTeamUsers (t: Team) (users: User list) : (Guid * string * Role) list =
            users 
            |> List.filter (fun u -> isAnyMember t u) // (fun {TeamsMembership=tm} -> tm |> List.exists (fun membership -> membership.TeamId = t.Id))
            |> List.map (fun u -> (u.Id, u.Name, (getUserTeamRole u t )))
            |> List.filter (fun (_,_,x) -> x.IsSome)
            |> List.map (fun (id, name, x) -> (id, name, x.Value))

        let getUsersPerTeam (teams: Team list) : (Guid * string * (Guid * string * Role) list) list =
            teams |> List.map (fun t -> (t.Id, t.Title, getTeamUsers t allUsers))

            // Teams.allTeams 
            // |> List.map (fun t -> t.Id) 
            // |> List.map (fun teamId -> (teamId, getTeamUsers teamId allUsers))

        let getTeams (u:User) : (Guid * string * (Guid * string * Role) list) list =
            let targetTeams =
                if (isAdmin u) then Teams.allTeams
                else (Teams.allTeams |> List.filter(fun t -> isSM t u || isSimpleMember t u))
            getUsersPerTeam targetTeams


    module Tasks =
        let allTasks = []

        
        let addTask (t:Task) (ts: Task list): Task list =
            //TODO: add task to DB
            t::ts

        let removeTask (t:Task) (ts: Task list): Task list =
            //TODO: add task to DB
            ts |> List.filter (fun task -> task.Id <> t.Id)
        (*
            type Task = {
        Id: Guid
        Title: string
        CreationDate: DateTime
        Description: string
        IsDone: bool
        }
        *)