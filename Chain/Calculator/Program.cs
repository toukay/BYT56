namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        
        TestCalculation(calculator, new Request(10, 5, "+"));
        TestCalculation(calculator, new Request(10, 5, "-"));
        TestCalculation(calculator, new Request(10, 5, "*"));
        TestCalculation(calculator, new Request(10, 5, "/"));
        TestCalculation(calculator, new Request(10, 0, "/"));
        TestCalculation(calculator, new Request(10, 5, "^"));
    }

    static void TestCalculation(Calculator calculator, Request request)
    {
        try
        {
            double result = calculator.Calculate(request);
            if (!Double.IsNaN(result))
            {
                Console.WriteLine(request.Number1 + " " + request.Oper + " " + request.Number2 + " = " + (request.Number1 + request.Number2));
                Console.WriteLine("Calculation result: " + result);
            }
            else
            {
                Console.WriteLine("Operation not supported or invalid: " + request.Oper);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during calculation: " + ex.Message);
        }
    }
}