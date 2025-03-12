/** 1. Array.Clear 2. Array.Resize **/
string[] pallets =  ["B14", "A11", "B12", "A13" ];
Console.WriteLine("");

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
/*
ref 키워드를 사용하는 이유는
public static void Resize<T>(ref T[] array, int newSize)
{
    if (array == null)
    {
        array = new T[newSize];
    }
    else if (array.Length != newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(array, newArray, Math.Min(array.Length, newSize));
        array = newArray;
    }
}
기존 배열의 크기를 바꾸는 데 사용하기 위해
*/


/** 3. string.IndexOfAny 4. string.IndexOf **/
string message = "Help (find) the {opening symbols}";
Console.WriteLine($"Searching THIS Message: {message}");
char[] openSymbols = { '[', '{', '(' };
int startPosition = 5;
int openingPosition = message.IndexOfAny(openSymbols);
Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");

openingPosition = message.IndexOfAny(openSymbols, startPosition);
Console.WriteLine($"Found WITH using startPosition {startPosition}:  {message.Substring(openingPosition)}");

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

int first = input.IndexOf("<div>");
int second = input.IndexOf("</div>");
output = input.Substring(first+5, second-(first+5));

int third = input.IndexOf("<span>");
int fourth = input.IndexOf("</span>");
quantity = input.Substring(third+6, fourth-(third+6));

Console.WriteLine(quantity);
Console.WriteLine(output);


/** 5. **/