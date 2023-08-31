module Intro3

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr;;

// v - (w + z)
// 2 * (v - (w + z))
// x + y + z + v

let e1 = Sub(Var "v", Add(Var "w", Var "z"))

let e2 = Mul(CstI 2, (Sub( Var "v", Add(Var "w", Var "z"))))

let e3 = Add(Add(Add(Var "x", Var "y"), Var("z")), Var "v")

let rec fmt (e: aexpr) : string =
  match e with
  | CstI x -> sprintf "%i" x
  | Var x -> x
  | Add(e1, e2) -> sprintf "(%s + %s)" (fmt e1) (fmt e2)
  | Sub(e1, e2) -> sprintf "(%s - %s)" (fmt e1) (fmt e2)
  | Mul(e1, e2) -> sprintf "(%s * %s)" (fmt e1) (fmt e2)

let rec simplify (e: aexpr) : aexpr =
  match e with
  | CstI x -> CstI x
  | Var x -> Var x
  | Add(e1,e2) ->
    match (e1,e2) with
    | (CstI 0, x) | (x, CstI 0) -> x
    | (e1, e2) when e1 = e2 -> Mul(CstI 2, e1)
    | _ -> simplify (Add (simplify e1, simplify e2))
  | Sub(e1, e2) ->
    match (e1,e2) with
    | (x, CstI 0) -> x
    | (x,y) when x = y -> CstI 0
    | _ -> simplify (Sub (simplify e1, simplify e2))
  | Mul(e1, e2) ->
    match (e1,e2) with
    | (CstI 1, x) | (x, CstI 1) -> x
    | (CstI 0, _) | (_, CstI 0) -> CstI 0
    | _ ->simplify (Mul (simplify e1, simplify e2))


let wacke0 = Mul(CstI(1), CstI(5))
let wacke1 = Add(CstI 1, CstI 0)

let wacke2 = Sub(CstI 42, CstI 42)

let wackSamlet = Mul(wacke2, wacke0)
let wacke3 = Add(CstI(5), CstI(5))

let wackExample = Mul(Add(CstI 1, CstI 0), (Add(Var "x", CstI 0)))


let rec diff (Var(diffVariable) : aexpr) (e: aexpr) : aexpr =
  match e with
  | CstI _ -> CstI 0
  | Var x when x = diffVariable  -> CstI 1
  | Var _ -> CstI 0
  | Add(e1,e2) -> Add(diff (Var diffVariable) e1, diff (Var diffVariable) e2)
  | Sub(e1, e2) -> Sub(diff (Var diffVariable) e1, diff (Var diffVariable) e2)
  | Mul(e1, e2) -> Add(Mul(diff (Var diffVariable) e1, e2), Mul(diff (Var diffVariable) e2, e1))

