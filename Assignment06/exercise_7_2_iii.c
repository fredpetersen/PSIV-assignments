void main(int n) {
  int arr[7];
  arr[0] = 1; 
  arr[1] = 2;
  arr[2] = 1; 
  arr[3] = 1;
  arr[4] = 1; 
  arr[5] = 2;
  arr[6] = 0;
  
  int max;
  max = 3;
  
  int freq[4];
  histogram(7, arr, max, freq);
  int i;
  i = 0;
  while (i < max+1){
    print freq[i];
    i = i+1;
  }
  println;
}

void histogram(int n, int ns[], int max, int freq[]) {
  int i;
  i = 0;
  while(i<max+1) {
    freq[i] = 0;
    i = i + 1;
  }

  i = 0;
  while(i < n) {
    int c;
    c = ns[i];
    freq[c] = freq[c] + 1;
    i = i + 1;
  }
}
