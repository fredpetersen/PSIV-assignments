module ProgramSomIkVirker

open Intcomp1
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


// let x1 = 5+7 x2 = x1*2 in x1+x2 end

let e1 = (Let([("x1", Prim("*",CstI(5),CstI(2)));("x2", Prim("+",CstI(2),Var("x1")))], Prim("+",Var("x1"),Var("x2"))))
let e2 = (Prim("+", Var("x1"),CstI(5)))
let e3 = (Let([("x1", Prim("*",CstI(5),Var("x2")));("x2", Prim("+",CstI(2),Var("x1")))], Prim("+", Var("x3"), Prim("+",Var("x1"),Var("x4")))))
printfn "%A" e3
printfn "%A" (freevars e3)



let t1 = tcomp e1 []
printfn "%A" t1

