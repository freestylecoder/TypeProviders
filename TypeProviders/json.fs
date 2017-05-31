namespace TypeProviders

// API should be available at : http://localhost:12026/api/values

module Json =
    open FSharp.Data

    type JsonData = JsonProvider<"""
[
	{
		"Key1" : "string",
		"Key2" : 1.2,
		"Key3" : 3
	},
	{
		"Key1" : "string"
	}
]
	""">

    let printJsonObject (o:JsonData.Root) =
        printfn "Key1 : %s" o.Key1

        match o.Key2 with
        | Some d -> d
        | None -> 0m
        |> printfn "Key2 : %f"
        
        match o.Key3 with
        | Some i -> i
        | None -> 0
        |> printfn "Key3 : %i"

    let rec printJson j =
        match j with
        | [] -> ()
        | h::t ->
            printJsonObject h
            printJson t