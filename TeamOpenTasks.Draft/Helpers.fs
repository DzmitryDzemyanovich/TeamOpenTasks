namespace TeamOpenTasks

open TeamOpenTasks.Data.Types
open TeamOpenTasks.Data.Models

module Helpers =

    let getTeamId (tm: TeamMembership) : TeamId =
        match tm with
        | TeamMembership(tid, _) -> tid

    let getRole (tm: TeamMembership) : Role =
        match tm with
        | TeamMembership(_, r) -> r

    let createTeamRole (t:Team) (r:Role) : TeamMembership =
        TeamMembership(t.Id, r)

    let createAdmin  (t:Team) : TeamMembership =
        createTeamRole t Role.Admin

    let createSM  (t:Team) : TeamMembership =
        createTeamRole t Role.ScrumMaster

    let createMember  (t:Team) : TeamMembership =
        createTeamRole t Role.TeamMember