using System.Text;
public partial class Program
{    
    public static double Calculate(string expression)
    {
        bool isBracketEquation = false;
        char lastCharacter = '0';
        int openBracketCount = 0;
        int closeBracketCount = 0;        
        StringBuilder innerExpressionBuilder = new();
        StringBuilder stringBuilder = new();
        Stack<string> stack = new();

        foreach (char character in expression)
        {            
            if (char.IsWhiteSpace(character))
            {
                continue;
            }
                 
            if (Equals(character, '(') || isBracketEquation)
            {                
                openBracketCount += Equals(character, '(') ? 1 : 0;
                closeBracketCount += Equals(character, ')') ? 1 : 0;
                isBracketEquation = true;

                if (isBracketEquation)
                {
                    if (lastCharacter == ')' && character == '(')
                    {
                        stack.Push(stringBuilder.ToString());
                        stack.Push("*");                        
                        stringBuilder.Clear();
                        innerExpressionBuilder.Clear();
                        innerExpressionBuilder.Append(character);
                        continue;
                    }
                    innerExpressionBuilder.Append(character);
                    lastCharacter = character;
                }

                if (Equals(character, ')') && openBracketCount == closeBracketCount)
                {
                    isBracketEquation = false;
                    string innerExpression = innerExpressionBuilder.ToString();
                    innerExpression = innerExpression[1..(innerExpression.Length - 1)];                    
                    stringBuilder.Append($"{Calculate(innerExpression)}");
                }
            }
            else if (char.IsDigit(character) || Equals(character, '.'))
            {
                stringBuilder.Append(character);
            }
            else
            {                
                Calculate(stack, stringBuilder.ToString());                
                stringBuilder = new StringBuilder();                
                stack.Push($"{character}");
            }
        }
        Calculate(stack, stringBuilder.ToString());
        AddSubtractCalculate(stack);
        double result = double.TryParse(stack.Pop(), out result) ? result : double.NaN;
        return Math.Round(result, 2);
    }

    private static void Calculate(Stack<string> stack, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        if (stack.Any() && (stack.Peek() == "*" || stack.Peek() == "/"))
        {
            MultiplyDivideCalculate(stack, value);           
        }
        else
        {
            stack.Push(value);
        }
    }

    private static void AddSubtractCalculate(Stack<string> stack)
    {
        double result = 0;
        while(stack.Any())
        {
            string operand = stack.Pop();
            if(stack.Any())
            {
                string operation = stack.Pop();
                if (operation == "+")
                {
                    result += double.Parse(operand);
                }
                else
                {
                    result += -double.Parse(operand);
                }
            }
            else
            {
                result += double.Parse(operand);
            }
        }
        stack.Push($"{result}");
    }

    private static void MultiplyDivideCalculate(Stack<string> stack, string secondValue)
    {
        string operation = stack.Pop();
        double firstOperand = Convert.ToDouble(stack.Pop());
        double secondOperand = Convert.ToDouble(secondValue);
        double result;        
        if (operation == "*")
        {
            result = firstOperand * secondOperand;
        }
        else
        {
            result = firstOperand / secondOperand;
        }
        stack.Push($"{result}");
    }    
}