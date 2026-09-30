
/*
 * Explanations:
 * 
 * 1. .csproj:
 *    The C# project file. It contains project settings, targeted .NET framework version,
 *    dependencies, package references, and compiler configurations.
 * 
 * 2. Program.cs:
 *    The main entry point file of the C# application where the code execution starts.
 * 
 * 3. obj/ (Object folder):
 *    Stores temporary intermediate files and metadata created during compilation 
 *    before the final executable is built.
 * 
 * 4. bin/ (Binary folder):
 *    Contains the final compiled output binaries (like .exe and .dll files) 
 *    ready for execution or deployment.
 * 
 * File-scoped Namespace Note:
 * Using a file-scoped namespace (e.g., 'namespace CSharpBasicsAssignment;') declares 
 * that all code in this file belongs to this namespace. 
 * 
* Solution Format Note:
 * This project uses the newer '.slnx' format.
 * '.slnx' is readable, well-organized, and based on XML.
 * The old '.sln' format is unreadable, messy, and uses old tools.
 */
using CSharpBasicsAssignment;
using System.Drawing;
using System.Xml.Linq;
int globalCounter = 100;
RunTypesDemo();
RunValueVsReferenceDemo();
RunScopeAndOperatorsDemo();


int[] testArray1 = { 4, 1, 2, 1, 2 };
Console.WriteLine($"Single Number Test 1: {FindSingleNumber(testArray1)}");

int[] testArray2 = { 7, 3, 5, 3, 7 };
Console.WriteLine($"Single Number Test 2: {FindSingleNumber(testArray2)}");

//Declare a variable of every type: int, long, double, decimal, bool, char, string, and one inferred with var — print each
//value and its runtime type using .GetType().

void RunTypesDemo()
{
    int x = 5;
    long y = 1234567890;
    double z = 4508.88;
    decimal a = 6545899.2345m;
    bool b = true;
    char c = 'c';
    string d = "asmaa";
    var e = 10;

    Console.WriteLine($"value is {x} and its runtime type {x.GetType()}  ");
    Console.WriteLine($"value is {y} and its runtime type {y.GetType()}  ");
    Console.WriteLine($"value is {z} and its runtime type {z.GetType()}  ");
    Console.WriteLine($"value is {a} and its runtime type {a.GetType()}  ");
    Console.WriteLine($"value is {b} and its runtime type {b.GetType()}  ");
    Console.WriteLine($"value is {c} and its runtime type {c.GetType()}  ");
    Console.WriteLine($"value is {d} and its runtime type {d.GetType()}  ");
    Console.WriteLine($"value is {e} and its runtime type {e.GetType()}  ");


    //Implicit conversion: assign an int into a long and a char into an int; print both and
    //explain in a comment why no cast was required.


    int f = 4;
    long g = f;

    Console.WriteLine($"value is {f} and {g}  ");

    Char r = 'a';
    int t = r;

    Console.WriteLine($"value is {r} and {t}  ");

    /* 
     * Why no cast was required:
     * Implicit conversion happens automatically because there is NO risk of data loss.
     * 1. 'long' (64-bit) is larger than 'int' (32-bit), so any 'int' fits comfortably inside 'long'.
     * 2. 'char' is a 16-bit unsigned integer representing a UTF-16 code point, 
     *    which easily fits into a 32-bit signed 'int'.
     */



    //Explicit conversion: cast a double to an int with(int), then convert the same double with Convert.ToInt32 —
    //print both results and explain the difference in a comment(truncation vs. rounding).

    double m = 34.55;
    int n = (int)m;

    Console.WriteLine($"value is {m} and {n}  ");

    int v = Convert.ToInt32(m);
    Console.WriteLine($"value is {v} ");

    /*
     * Difference Explanation:
     * 1. (int) casting: Performs TRUNCATION. It drops the decimal part completely without rounding.
     * 2. Convert.ToInt32(): Performs ROUNDING. It rounds the number to the nearest integer.
     */


    // The integer division trap: compute 5 / 2 as int and 5.0 / 2 as double; print both and explain the difference in a one-line
    //comment.

    int trapint = 5 / 2;
    Console.WriteLine($"value is {trapint} ");

    double trapdouble = 5.0 / 2;
    Console.WriteLine($"value is {trapdouble} ");

    // 5 / 2 discards the remainder, while 5.0 / 2 performs floating-point division.

    //Boxing / unboxing: box an int into an object, then unbox it back into an int; print the value after each step.

    int box = 5;
    object obj = box;
    int unbox = (int)obj;

    Console.WriteLine($"value is {obj} and {unbox}  ");

    /*Parsing: read a string "42" with int.Parse, and a bad string "abc" with int.TryParse — print whether TryParse succeeded
    and handle the failure without throwing.*/

    string st = "42";
    int stint = int.Parse(st);
    string badst = "abc";
    bool sucsses = int.TryParse(badst, out int result);
    if (!sucsses)
        Console.WriteLine("cannot parse");
    else
        Console.WriteLine($"can parse and value is {result}");

    /* float → decimal: attempt the implicit assignment(commented out, since it won't compile), then do it correctly with an
      explicit (decimal)cast — comment explaining why the compiler refuses the implicit version.*/

    float flo = 55.7f;
    //decimal dec = flo;

    decimal dec = (decimal)flo;
    // The compiler refuses implicit conversion because float is floating-point (binary)
    // and decimal is fixed-point (base 10), which can cause precision loss.

}
//part c
void RunValueVsReferenceDemo()
{


    Point p1 = new Point { X = 1, Y = 2 };
    Point p2 = p1;

    p2.X = 99;

    Console.WriteLine($"p1.X = {p1.X}"); // Output: 1
    Console.WriteLine($"p2.X = {p2.X}"); // Output: 99

    /*
     * Explanation:
     * 'Point' is a struct (Value Type), which means it is stored directly on the Stack.
     * When assigning 'p2 = p1', C# creates a complete value-by-value copy of 'p1'.
     * Therefore, 'p1' and 'p2' occupy separate memory locations, and modifying 'p2.X' does not affect 'p1.X'.
     */


    Order o1 = new Order
    {
        OrderId = 101,
        CustomerName = "Asmaa",
        Quantity = 3,
        UnitPrice = 250.00m,
        IsPaid = false,
        DiscountPercent = 10.0,
        ShippingCity = "Cairo",
        Priority = 'H',
        ItemCode = 9876543210L
    };

    o1.CalculateTotal();

    Order o2 = o1;
    o2.IsPaid = true;

    Console.WriteLine($"o1.IsPaid = {o1.IsPaid} | o2.IsPaid = {o2.IsPaid}");
    /*
     * Explanation:
     * Order is a class (Reference Type). The object itself lives on the Heap,
     * while o1 and o2 are variables on the Stack holding references.
     * Assigning 'o2 = o1' copies the address, so both point to the exact same instance.
     */


    object boxedOrder = o1;
    Order o3 = (Order)boxedOrder;

    bool isSameInstance = object.ReferenceEquals(o1, o3);
    Console.WriteLine($"object.ReferenceEquals(o1, o3): {isSameInstance}");

    Console.Write("o2 Summary: ");
    o2.PrintSummary();


    /*"1. Value types live on the Stack, while Reference types have their object data stored on the Heap with a reference on the Stack.\n" +
      "2. Assignment '=' for a value type copies the data value, whereas for a reference type, it copies the memory address.\n" +
      "3. Storing a reference type inside an 'object' variable does not create a new object or trigger boxing; it simply stores the same Heap address."*/


}




// Part D 




void MethodA()
{
    Console.WriteLine($"MethodA reading globalCounter: {globalCounter}");
}


void MethodB()
{
    Console.WriteLine($"MethodB reading globalCounter: {globalCounter}");
}



void RunScopeAndOperatorsDemo()
{
    MethodA();
    MethodB();

    // 2. Method Scope: Local variable visible only within this method
    int methodLocalVar = 50;
    Console.WriteLine($"Method Scope Local Var: {methodLocalVar}");

    // 3. Block Scope: for-loop variables
    for (int i = 0; i < 3; i++)
    {
        int blockLocalVar = i * 10;
        Console.WriteLine($"Inside loop  {i}, blockLocalVar: {blockLocalVar}");
    }

    // Attempting to use block-scoped variables outside the loop causes a compile error:
    // Console.WriteLine(i);
    // Console.WriteLine(blockLocalVar);
    /*
     * Compile Error: CS0103: The name 'i' (or 'blockLocalVar') does not exist in the current context.
     * Explanation: Both 'i' and 'blockLocalVar' are bound to the block scope of the for-loop
     * and are destroyed as soon as the loop finishes execution.
     */

    int total = 100;
    Console.WriteLine($"Initial total: {total}");

    total += 20;
    Console.WriteLine($"{total}");

    total -= 15;
    Console.WriteLine($"{total}");

    total *= 2;
    Console.WriteLine($"{total}");

    total /= 5;
    Console.WriteLine($"{total}");

    total %= 9;
    Console.WriteLine($"{total}");


    // 'total += 20;' is compound assignment shorthand, exactly equivalent to writing 'total = total + 20;'.



    int a = 12; // Binary: 1100
    int b = 10; // Binary: 1010

    int bitwiseAnd = a & b; // Binary: 1000 -> Decimal: 8
    int bitwiseOr = a | b; // Binary: 1110 -> Decimal: 14
    int bitwiseXor = a ^ b; // Binary: 0110 -> Decimal: 6

    Console.WriteLine($"a & b (AND) = {bitwiseAnd}");
    Console.WriteLine($"a | b (OR)  = {bitwiseOr}");
    Console.WriteLine($"a ^ b (XOR) = {bitwiseXor}");

    /*
     * Bit-by-bit calculation breakdown:
     * a     = 1 1 0 0  (12)
     * b     = 1 0 1 0  (10)
     * --------------------
     * a & b = 1 0 0 0  (8)  -> 1 only if both bits are 1
     * a | b = 1 1 1 0  (14) -> 1 if at least one bit is 1
     * a ^ b = 0 1 1 0  (6)  -> 1 if bits are different
     */

    // Difference between & (bitwise) and && (logical) in an if-condition:
    // When the left operand is false, the logical '&&' short-circuits and skips evaluating the right operand entirely, whereas the bitwise '&' always evaluates both operands regardless.
}


// Method to find the single number using XOR operator
// Explanation: XOR-ing a number with itself results in 0 (A ^ A = 0), and XOR-ing with 0 keeps the number (A ^ 0 = A).
// Since all elements appear twice except one, duplicate pairs cancel each other out, leaving only the single element.

int FindSingleNumber(int[] nums)
{
    int result = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        result ^= nums[i];
    }

    return result;
}
struct Point
{
    public int X;
    public int Y;
};