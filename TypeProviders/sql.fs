namespace TypeProviders

// SQL Connection String : Data Source=localhost;Initial Catalog=TypeProviders;Integrated Security=SSPI

module Sql =
    open FSharp.Data.TypeProviders

    type SqlData = SqlDataConnection<"Data Source=localhost;Initial Catalog=TypeProviders;Integrated Security=SSPI">

    let printSqlRow (r:SqlData.ServiceTypes.TopTable) =
        printfn "%i" r.Id
        printfn "\t%s" r.TopTableData
        printfn "\t%s" r.LookupTable.LookupTableData
        
        for j in r.JoinTable do
            printfn "\t%s" j.OtherTable.OtherTableData
        
        printfn ""

    let rec printSql s =
        match s with
        | [] -> ()
        | h::t ->
            printSqlRow h
            printSql t
