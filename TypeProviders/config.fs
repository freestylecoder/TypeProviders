namespace TypeProviders

module Config =
    open FSharp.Configuration

    type AppConfig = AppSettings<"app.config">

    let printAppSettings () =
        printfn "%s" AppConfig.ConfigFileName

        printfn "StringKey:  %s" AppConfig.StringKey
        printfn "IntegerKey: %i" AppConfig.IntegerKey
        printfn "FloatKey:   %f" AppConfig.FloatKey
        printfn "BooleanKey: %b" AppConfig.BooleanKey