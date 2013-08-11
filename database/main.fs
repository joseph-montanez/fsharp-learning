open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders

type Person = {
  Id      : int
  First   : string
  Last    : string
}

let PersonGetName(person) = person.First + " " + person.Last

type dbml = DbmlFile<"database.dbml">
let connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=FSharpDB;Integrated Security=True"
let db = new dbml.DBContext(connectionString)

query {
  for row in db.Person do
    select ({ Id = row.Id; First = row.First; Last = row.Last })
} |> Seq.iter (
  fun person -> printfn "%A" (PersonGetName person)
)
