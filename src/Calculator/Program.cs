PrintExecuteResult();

void PrintExecuteResult()
{
    string expression = args[0];
    double result = Calculate(expression);
    Console.WriteLine($"{expression} = {result}");
}