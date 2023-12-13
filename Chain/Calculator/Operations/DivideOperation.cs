namespace Calculator;

class DivideOperation : BaseOperation
{
    public override double Calculate(Request request)
    {
        if (request.Oper == "/")
        {
            if (request.Number2 == 0)
            {
                throw new InvalidOperationException("Division by zero is not allowed.");
            }
            return request.Number1 / request.Number2;
        }
        
        return NextOperation?.Calculate(request) ?? Double.NaN;
    }
}