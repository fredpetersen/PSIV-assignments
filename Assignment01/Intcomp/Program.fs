module ProgramSomIkVirker

open Intcomp1
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


// let x1 = 5+7 x2 = x1*2 in x1+x2 end

let e1 = (Let([("x1", Prim("*",CstI(5),CstI(2)));("x2", Prim("+",CstI(2),Var("x1")))], Prim("+",Var("x1"),Var("x2"))))
printfn "%A" e1
printfn "%A" (eval e1 [])