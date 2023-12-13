namespace Calculator;

class Calculator
{
    private AddOperation _addOperation;
    private SubtractOperation _subtractOperation;
    private MultiplyOperation _multiplyOperation;
    private DivideOperation _divideOperation;

    public Calculator()
    {
    _addOperation = new AddOperation();
    _subtractOperation = new SubtractOperation();
    _divideOperation = new DivideOperation();
    _multiplyOperation = new MultiplyOperation();
    
    _addOperation.SetNext(_subtractOperation);
    _subtractOperation.SetNext(_multiplyOperation);
    _multiplyOperation.SetNext(_divideOperation);
    }

    public double Calculate(Request request)
    {
        return _addOperation.Calculate(request);
    }
}