module ProgramSomIkVirker

open Intcomp1
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


// let x1 = 5+7 x2 = x1*2 in x1+x2 end


let s1e =  assemble (scomp e1 []);;


printfn "%A" s1e
// val it : int list = [0; 17; 1; 0; 1; 1; 2; 6; 5]

intsToFile (assemble (scomp e1 [])) "is1.txt";;