(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr =
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4 = Prim("==", Prim("max", CstI 1, CstI 5), Prim("min", CstI 5,  CstI 12))
let e5 = Prim("+", Prim("*", Prim("max", CstI(3), CstI(4)), Prim("min", CstI(1), CstI(5))), (Prim("==", (Prim("max", CstI(3), CstI(4))), Prim("min", CstI(4), CstI(8)))))

// "max (3, 4) * min (1, 5) + (max(3, 4) == min(4, 8))" = 5



(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i              -> i
    | Var x               -> lookup env x
    | Prim("+", e1, e2)   -> eval e1 env + eval e2 env
    | Prim("*", e1, e2)   -> eval e1 env * eval e2 env
    | Prim("-", e1, e2)   -> eval e1 env - eval e2 env
    | Prim("min", e1, e2) -> List.min [eval e1 env; eval e2 env]
    | Prim("max", e1, e2) -> List.max [eval e1 env; eval e2 env]
    | Prim("==", e1, e2)  ->
      match eval e1 env = eval e2 env with
        | true -> 1
        | _ -> 0
    | Prim _ -> failwith "Unknown primitive";;

let rec earlyEval e (env : (string * int) list) : int =
    match e with
    | CstI i              -> i
    | Var x               -> lookup env x
    | If (e1, e2, e3) -> if earlyEval e1 env <> 0 then earlyEval e2 env else earlyEval e3 env
    | Prim(ope, e1, e2)   ->
      let i1 = earlyEval e1 env
      let i2 = earlyEval e2 env
      match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "min" -> List.min [i1; i2]
        | "max" -> List.max [i1; i2]
        | "==" -> match i1 = i2 with | true -> 1 | _ -> 0
        | _ -> failwith "Unknown primitive"


let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

