module main

type Person = {
    Id    : int
    First : string
    Last  : string
}

let PersonGetName(id) =
    id.First + " " + id.Last

type Employee = 
    | Engineer  of Person
    | Manager   of Person * list<Employee>            // manager has list of reports
    | Executive of Person * list<Employee> * Employee // executive also has an assistant
    static member getName(emp: Employee) =
        match emp with
        | Engineer(id)                      -> PersonGetName id
        | Manager(id, reports)              -> PersonGetName id
        | Executive(id, reports, assistant) -> PersonGetName id

let rec countReports(emp : Employee) = 
    1 + match emp with
        | Engineer(id) -> 
            0
        | Manager(id, reports) -> 
            reports |> List.sumBy countReports 
        | Executive(id, reports, assistant) ->
            (reports |> List.sumBy countReports) + countReports assistant

let sb = { Id = 1; First = "Sam"; Last = "Bulter" }
let jw = { Id = 2; First = "John"; Last = "William" }
let bs = { Id = 3; First = "Bob"; Last = "Suk" }
let hh = { Id = 4; First = "Henry"; Last = "Hicks" }

let employee_1 = Engineer(sb)
let assitant = Engineer(hh)
let manager_1 = Manager(jw, [employee_1])
let executive_1 = Executive(bs, [manager_1], assitant)

let workers = [ employee_1; assitant; manager_1; executive_1 ]

workers |> List.iter (fun emp -> printfn "%A has %A employees reporting" (Employee.getName emp) (countReports emp))

printfn "Press any key to continue..."
System.Console.ReadKey() |> ignore
