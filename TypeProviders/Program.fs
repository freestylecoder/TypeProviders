// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open TypeProviders.Config

[<EntryPoint>]
let main argv = 
    
    printAppSettings ()
    
    printfn ""
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
