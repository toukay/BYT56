namespace Calculator;

class Request
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public string Oper { get; set; }

    public Request(double number1, double number2, string reqOperator)
    {
        this.Number1 = number1;
        this.Number2 = number2;
        this.Oper = reqOperator;
    }
}