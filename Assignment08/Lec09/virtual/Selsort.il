  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3)
    IL_0000:  ldc.i4.0            // push constant 0 on stack
    IL_0001:  stloc.0             // store local variable from stack (0) to first local variabel (i = 0)
    IL_0002:  br.s       IL_0032  // unconditional jump (to outer for-loop condition check)

    // OUTER LOOP BODY BEGIN
    IL_0004:  ldloc.0             // Load int i
    IL_0005:  stloc.1             // Store value of i on variable index 1 (int least = i)
    IL_0006:  ldloc.0             // Load int i again
    IL_0007:  ldc.i4.1            // Push constant 1 on stack
    IL_0008:  add                 // add 1 to i
    IL_0009:  stloc.3             // Store value of i+1 to third local variabel (int j = i+1)
    IL_000a:  br.s       IL_001a  // unconditional jump (to inner for-loop condition check)

    // INNER LOOP BODY
    IL_000c:  ldarg.0             // load array argument (arr)
    IL_000d:  ldloc.3             // load int j
    IL_000e:  ldelem.i4           // load j-th element of arr
    IL_000f:  ldarg.0             // load array argument again (arr)
    IL_0010:  ldloc.1             // load int least (The index of the smallest element so far in arr)
    IL_0011:  ldelem.i4           // load smallest element of arr
    IL_0012:  bge.s      IL_0016  // Jump to IL_0016 if arr[j] >= arr[least]

    IL_0014:  ldloc.3             // load int j
    IL_0015:  stloc.1             // store value of j in variable least

    // INNER LOOP INCREMENT
    IL_0016:  ldloc.3             // load int j
    IL_0017:  ldc.i4.1            // push constant 1 to stack
    IL_0018:  add                 // add 1 to j
    IL_0019:  stloc.3             // store value of j+1 to variable j (j++)

    // INNER LOOP CONDITION
    IL_001a:  ldloc.3             // Load int j
    IL_001b:  ldarg.0             // load array argument (arr)
    IL_001c:  ldlen               // get length of arr
    IL_001d:  conv.i4             // convert length to int
    IL_001e:  blt.s      IL_000c  // jump to inner loop body if j less than length (at IL_000c)

    // SWITCH TWO VARIABLES         (int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;)
    IL_0020:  ldarg.0             // Loads array from arguments (arr)
    IL_0021:  ldloc.0             // Loads int i
    IL_0022:  ldelem.i4           // Gets i-th element of arr (arr[i])
    IL_0023:  stloc.2             // Store on second variabel index (int tmp)
    IL_0024:  ldarg.0             // Loads array from arguments (arr)
    IL_0025:  ldloc.0             // Loads int i
    IL_0026:  ldarg.0             // Loads array from arguments again (arr)
    IL_0027:  ldloc.1             // Loads int least
    IL_0028:  ldelem.i4           // Gets smallest element of arr (arr[least])
    IL_0029:  stelem.i4           // Store value of arr[least] on arr[i]
    IL_002a:  ldarg.0             // Loads array from arguments again again (arr)
    IL_002b:  ldloc.1             // Loads variable least
    IL_002c:  ldloc.2             // Loads variable tmp
    IL_002d:  stelem.i4           // Store value of tmp in arr[least]

    // OUTER LOOP INCREMENT
    IL_002e:  ldloc.0             // Loads int i
    IL_002f:  ldc.i4.1            // Push constant 1 to stack
    IL_0030:  add                 // Add 1 to i (i+1)
    IL_0031:  stloc.0             // Store value i+1 on int i (i++)

    // OUTER LOOP CONDITION
    IL_0032:  ldloc.0               // load local variable (i)
    IL_0033:  ldarg.0               // load array argument (arr)
    IL_0034:  ldlen                 // get length of array
    IL_0035:  conv.i4               // convert length to int
    IL_0036:  blt.s      IL_0004    // jump to loop body, if i less than array length (at IL_0004)

    IL_0038:  ret                   // Return when i >= arr.length
  } // end of method Selsort::SelectionSort
