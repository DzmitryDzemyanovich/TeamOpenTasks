namespace TeamOpenTasks

module Helpers =
    open System
    open Users
    open Teams
    open UserRoles

    let createTeamRole (t:Team) (r:Role) : TeamMembership =
        { TeamId = t.Id; Role = r }

    let createAdmin  (t:Team) : TeamMembership =
        createTeamRole t Role.Admin

    let createSM  (t:Team) : TeamMembership =
        createTeamRole t Role.ScrumMaster

    let createMember  (t:Team) : TeamMembership =
        createTeamRole t Role.TeamMember