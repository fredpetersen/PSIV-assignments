void main(int n) {
  int arr[20];
  squaresforloop(n, arr);
  int sump;
  sump = 0;
  arrsumforloop(n, arr, &sump);
  print sump;
  println;
}

void squares(int n, int arr[]) {
  int i;
  i = 0;
  while (i < n) {
    arr[i] = i*i;
    i = i + 1;
  }
}

void arrsum(int n, int arr[], int *sump) {
  int i;
  i = 0;
  while (i < n) {
    *sump = *sump + arr[i];
    i = i + 1;
  }
}

void squaresforloop(int n, int arr[]) {
  int i;
  for(i=0; i<n; i = i+1) {
    arr[i] = i*i;
  }
}

void arrsumforloop(int n, int arr[], int *sump) {
  int i;
  for(i = 0; i<n; i = i+1) {
    *sump = *sump + arr[i];
  }
}