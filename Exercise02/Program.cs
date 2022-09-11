
using Exercise01;


string isNegative = "";
try
{
    IntegerToString integerToString = new IntegerToString();

    Console.WriteLine("Enter a Number to convert to currency");
    string number = "20000";
    number = Convert.ToDouble(number).ToString();

    if (number.Contains("-"))
    {
        isNegative = "Minus ";
        number = number.Substring(1, number.Length - 1);
    }
    if (number == "0")
    {
        Console.WriteLine("The number in currency fomat is \nZero Only");
    }
    else
    {
        Console.WriteLine("The number in currency format is \n{0}", isNegative + integerToString.ConvertToWords(number));
    }
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}