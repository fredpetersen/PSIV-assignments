namespace SimpleExpr
{
  abstract class AExpr
  {
    public abstract int eval(Dictionary<string, int> env);
    public abstract AExpr simplify();
    public abstract bool Equals(object obj);
    public abstract string toString();
  };

  class Var : AExpr
  {
    public string name;

    public Var(string name)
    {
      this.name = name;
    }

    public override int eval(Dictionary<string, int> env)
    {
      return env[name];
    }

    public override string toString()
    {
      return name;
    }

    public override AExpr simplify()
    {
      return this;
    }

    public override bool Equals(object obj)
    {
      return obj is Var var &&
             name == var.name;
    }
  }



  class CstI : AExpr
  {
    public int i;

    public CstI(int i)
    {
      this.i = i;
    }

    public override int eval(Dictionary<string, int> env)
    {
      return i;
    }

    public override string toString()
    {
      return i.ToString();
    }

    public override AExpr simplify()
    {
      return this;
    }

    public override bool Equals(object obj)
    {
      return obj is CstI i &&
             this.i == i.i;
    }
  }

  abstract class Binop : AExpr
  {
    public AExpr e1, e2;
    public Binop(AExpr e1, AExpr e2)
    {
      this.e1 = e1;
      this.e2 = e2;
    }
  }

  class Add : Binop
  {
    public Add(AExpr e1, AExpr e2) : base(e1,e2)
    {
      // base(e1,e2);
    }

    public override int eval(Dictionary<string, int> env)
    {
      return e1.eval(env) + e2.eval(env);
    }

    public override string toString()
    {
      return $"({e1.toString()} + {e2.toString()})";
    }

    public override bool Equals(object obj)
    {
      return obj is Add add &&
             e1.Equals(add.e1) && e2.Equals(add.e2);
    }

    public override AExpr simplify()
    {
      var simple1 = e1.simplify();
      var simple2 = e2.simplify();
      if (simple1.Equals(new CstI(0))) return simple2;
      if (simple2.Equals(new CstI(0))) return simple1;
      return new Add(simple1, simple2);
    }
  }

  class Sub : Binop
  {
    public Sub(AExpr e1, AExpr e2) : base(e1,e2)
    {
      // base(e1,e2);
    }

    public override int eval(Dictionary<string, int> env)
    {
      return e1.eval(env) - e2.eval(env);
    }

    public override string toString()
    {
      return $"({e1.toString()} - {e2.toString()})";
    }

    public override bool Equals(object obj)
    {
      return obj is Sub sub &&
             e1.Equals(sub.e1) && e2.Equals(sub.e2);
    }

    public override AExpr simplify()
    {
      var simple1 = e1.simplify();
      var simple2 = e2.simplify();
      if (simple1.Equals(simple2)) return new CstI(0);
      if (simple2.Equals(new CstI(0))) return simple1;
      return new Sub(simple1, simple2);
    }
  }

  class Mul : Binop
  {
    public Mul(AExpr e1, AExpr e2) : base(e1,e2)
    {
      // base(e1,e2);
    }

    public override int eval(Dictionary<string, int> env)
    {
      return e1.eval(env) * e2.eval(env);
    }

    public override bool Equals(object obj)
    {
      return obj is Mul mul &&
             e1.Equals(mul.e1) && e2.Equals(mul.e2);
    }

    public override AExpr simplify()
    {
      var simple1 = e1.simplify();
      var simple2 = e2.simplify();
      if (new CstI(0).Equals(simple1) || new CstI(0).Equals(simple2)) return new CstI(0);
      if (new CstI(1).Equals(simple1)) return simple2;
      if (new CstI(1).Equals(simple2)) return simple1;
      return new Mul(simple1, simple2);
    }

    public override string toString()
    {
      return $"({e1.toString()} * {e2.toString()})";
    }
  }
}