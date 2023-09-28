(* CHANGED FOR ASSIGNMENT 5 *)
// Exercise 5.1
// A) Implement an F# function merge : int list * int list -> int list
// Two sorted lists of integers should be merged into one sorted list of integers

let rec merge (xs, ys) =
    match xs with
    | [] -> ys
    | x :: xs' ->
        match ys with
        | [] -> xs
        | y :: ys' when x <= y -> x :: (merge (xs', ys))
        | y :: ys' -> y :: (merge (xs, ys'));;


merge ([3;5;12], [2;3;4;7]);;
// should give [2;3;3;4;5;7;12]