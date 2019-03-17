namespace TeamOpenTasks

(*
module Person =
    type T = { FirstName: string; LastName: string } with

        member this.FullName =
            this.FirstName + " " + this.LastName
        
    let create first last =
        { FirstName = first; LastName = last }

    type T with

        member this.SortableName =
            this.LastName + ", " + this.FirstName
*)

module Main =
    open System
    open Users
    open Teams
    open UserRoles
    open TestData
    open Helpers

    
    
    (*
    +Admin can add user
    +Admin can remove user
    +Admin can see all teams (with users)
    +Admin can see all users (as a list)
    +Admin can create teams
    +Admin can remove teams
    +Admin can assign roles
    +Admin can unassign roles
    +Admin can modify team rules (group of teams also)
    +Admin can change user team-role //(unassign-assign)
    +Admin can edit tasks

    +SM can assign user to team //(addMembership)
    +SM can remove user from team //(removeMembership)
    SM can create tasks
    +SM can add tasks
    +SM can remove tasks
    SM can assign tasks to user (option: user should accept)
    SM can unassign task from user (option: user should accept)
    +SM can see all his teams (with users)
    +SM can modify team rules (group of teams also)
    SM can change user team-role
    SM can edit tasks

    +User can see his team members
    User can assign task to himself
    User can unassign task from himself

    Task can expire (optional)
    Task can unassign on expiration (optional)
    *)

// type Order (amount:int, price:decimal) =
//     let isFree = price=0M
//     let total = price*((decimal)amount)
//     let isMoreThan(cost:decimal) = total > cost
//     new () = Order(0, 0M)
//     member this.Amount = amount
//     member this.Price = price
//     member this.IsFree = isFree
//     member this.Total = total
//     member this.IsMoreThan(cost:decimal) = isMoreThan(cost)

// let x = new Order(2, 3M)
// printfn "%f %b" x.Total (x.IsMoreThan(2M))

    [<EntryPoint>]
    let main argv =
        // let person = Person.create "John" "Doe"
        // printfn "%s" person.FullName
        // printfn "%s" person.SortableName
        0 // return an integer exit code
