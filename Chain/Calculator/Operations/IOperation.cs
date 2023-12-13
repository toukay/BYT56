namespace Calculator;

interface IOperation
{
    void SetNext(IOperation nextOperation);
    double Calculate(Request request);
}