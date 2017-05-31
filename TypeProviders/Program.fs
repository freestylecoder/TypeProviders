// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open TypeProviders.Config
open TypeProviders.Json

[<EntryPoint>]
let main argv = 
    
    // app.config
    printAppSettings ()
    printfn ""
    
    // json
    let myJson = JsonData.Load( "http://localhost:12026/api/values" )
    Array.toList myJson
    |> printJson
    printfn ""

    // sql
    printfn ""
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
