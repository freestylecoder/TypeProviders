// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open TypeProviders.Config
open TypeProviders.Json
open TypeProviders.Sql

[<EntryPoint>]
let main argv = 
    
    // app.config
    printAppSettings ()
    printfn ""
    
    // json
    JsonData.Load( "http://localhost:12026/api/values" )
    |> Array.toList
    |> printJson
    printfn ""

    // sql
    SqlData.GetDataContext().TopTable
    |> Seq.toList
    |> printSql
    printfn ""

    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
