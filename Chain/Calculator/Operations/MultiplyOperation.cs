namespace Calculator;

class MultiplyOperation : BaseOperation
{
    public override double Calculate(Request request)
    {
        if (request.Oper == "*")
        {
            return request.Number1 * request.Number2;
        }

        return NextOperation?.Calculate(request) ?? Double.NaN;
    }
}