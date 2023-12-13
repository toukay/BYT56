namespace Calculator;

abstract class BaseOperation : IOperation
{
    protected IOperation NextOperation;

    public void SetNext(IOperation nextOperation)
    {
        this.NextOperation = nextOperation;
    }

    public abstract double Calculate(Request request);
}