using SimpleExpr;

// See https://aka.ms/new-console-template for more information
AExpr e = new Add(new CstI(17), new Var("z")); // 17+z = 17+3 = 20
AExpr e1 = new Mul(new Mul(new CstI(0), new Var("z")), new Add(new CstI(1), new Var("x"))); // (0 * z) * (1 + x) = (0 * 3) * (1 + 5) = 0
var env = new Dictionary<string, int>(){
    {"z", 3},
    {"x", 5},
};
AExpr e2 = new Add(new Mul(new CstI(3), new CstI(5)), new CstI(2)); // ((3*5) + 2) = 17
AExpr e3 = new Mul(new Add(new Add(new CstI(3), new CstI(0)), new CstI(2)), new CstI(1)); // (((3 + 0) + 2) * 1) = (3 + 2) = 5


// e1 = e1.simplify() = e1.eval(env);
Console.WriteLine($"{e1.toString()} = {e1.simplify().toString()} = {e1.eval(env)}");
Console.WriteLine($"{e2.toString()} = {e2.simplify().toString()} = {e2.eval(env)}");
Console.WriteLine($"{e3.toString()} = {e3.simplify().toString()} = {e3.eval(env)}");
