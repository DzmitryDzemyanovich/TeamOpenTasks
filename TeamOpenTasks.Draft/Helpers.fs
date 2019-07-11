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

    let createTeamRole (tid) (r) : TeamMembership =
        TeamMembership(tid, r)

    let createAdmin  (tid) : TeamMembership =
        createTeamRole tid Role.Admin

    let createSM  (tid) : TeamMembership =
        createTeamRole tid Role.ScrumMaster

    let createMember  (tid) : TeamMembership =
        createTeamRole tid Role.TeamMember