namespace TeamOpenTasks.Data

open Microsoft.EntityFrameworkCore
open Models

module DataContext =

    type TeamOpenTasksContext(options: DbContextOptions<TeamOpenTasksContext>) =
        inherit DbContext(options)

        override __.OnModelCreating modelBuilder = 
            modelBuilder
                .Entity<Task>()
                .HasKey(fun t -> (t.Id) :> obj)
            |> ignore
            
            modelBuilder
                .Entity<TaskAssignment>()
                .HasKey(fun ta -> (ta.TaskId, ta.UserId) :> obj)
            |> ignore
            
            modelBuilder
                .Entity<Team>()
                .HasKey(fun t -> (t.Id) :> obj)
            |> ignore
            //modelBuilder.Entity<Task>().Property(fun task -> task.Id).ValueGeneratedOnAdd() |> ignore

        [<DefaultValue>]
        val mutable tasks:DbSet<Task>
        member x.Tasks 
            with get() = x.tasks 
            and set v = x.tasks <- v