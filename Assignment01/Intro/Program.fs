module ProgramSomIkVirker

open Intro2

// For more information see https://aka.ms/fsharp-console-apps

let e5 = Prim("+", Prim("*", Prim("max", CstI(3), CstI(4)), Prim("min", CstI(1), CstI(5))), (Prim("==", (Prim("max", CstI(3), CstI(4))), Prim("min", CstI(4), CstI(8)))))
let e6 = If(Var "a", CstI 11, CstI 22)

printfn "%A" (earlyEval e6 env)
