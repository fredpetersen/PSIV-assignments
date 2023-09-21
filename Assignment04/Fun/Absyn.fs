(* Fun/Absyn.fs * Abstract syntax for micro-ML, a functional language *)

module Absyn

type expr =
  | CstI of int
  | CstB of bool
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
  | If of expr * expr * expr
  | Letfun of string * string list * expr * expr    (* CHANGED FOR ASSIGNMENT 4 *)
  | Call of expr * expr list (* CHANGED FOR ASSIGNMENT 4 *)
