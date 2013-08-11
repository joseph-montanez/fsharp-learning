module main

type Person(Id : int, First : string, Last  : string) =
    member this.Id = Id
    member this.First = First
    member this.Last = Last
    member this.GetName = this.First + " " + this.Last

[<AbstractClass>]
type Employee(Id : Person) =
    abstract member CountReports : int
    member this.Id = Id

type Engineer(Id : Person) =
    inherit Employee(Id)
    override this.CountReports = 1

type Manager(Id : Person, Emps : list<Employee>) =
    inherit Engineer(Id)
    member this.Reports : list<Employee> = Emps
    override this.CountReports = 1 + (this.Reports |> List.sumBy(fun emp -> emp.CountReports))

type Executive(Id : Person, Emps : list<Employee>, Assistant : Engineer) =
    inherit Manager(Id, Emps)
    member this.Assistant = Assistant
    override this.CountReports = 1 + (this.Reports |> List.sumBy(fun emp -> emp.CountReports)) + this.Assistant.CountReports
    
let sb = new Person(1, "Sam", "Bulter")
let jw = new Person(2, "John", "William")
let bs = new Person(3, "Bob", "Suk")
let hh = new Person(4, "Henry", "Hicks")

let employee_1 = new Engineer(sb)
let assitant = new Engineer(hh)
let manager_1 = new Manager(jw, [employee_1])
let executive_1 = new Executive(bs, [manager_1], assitant)

let workers : list<Employee> = [ employee_1; assitant; manager_1; executive_1 ]

workers |> List.iter (fun emp -> printfn "%A has %A employees reporting" emp.Id.GetName emp.CountReports)

printfn "Press any key to continue..."
System.Console.ReadKey() |> ignore
