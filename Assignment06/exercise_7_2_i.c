void main(int n) {
  int sump;
  sump = 0;
  int arr[4];
  arr[0] = 7;
  arr[1] = 13;
  arr[2] = 9;
  arr[3] = 8;
  arrsum(n, arr, &sump);
  print sump;
  println;
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;
    while (i < n) {
      *sump = *sump + arr[i];
      i = i + 1;
    }
}
