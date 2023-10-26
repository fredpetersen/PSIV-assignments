void main (int n) {
  int x;
  x = ++n + 3;
  print n;
  print x;
  println;
  x = --x + --n;
  print n;
  print x;
  println;
}