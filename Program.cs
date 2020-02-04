using System;
using System.Collections.Generic;

namespace Calc
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input; string newInput = null; int length;
            var numbers = new Stack<double>();
            var operators = new Stack<char>();
            while (true)
            {
                int error = 0;
                input = Console.ReadLine(); length = input.Length;

                for (int k = 0; k < length; k++)
                {
                    if (input[k] == '0' || input[k] == '1' || input[k] == '2' || input[k] == '3' || input[k] == '4' || input[k] == '5' || input[k] == '6' || input[k] == '7' || input[k] == '8' || input[k] == '9' || input[k] == ',' || input[k] == '+' || input[k] == '-' || input[k] == '*' || input[k] == '/' || input[k] == '(' || input[k] == ')')
                    {
                        continue;
                    }
                    else
                    {
                        error = 1; ErrorConsol(error); break;
                    }
                }

                for (int k = 0; k < length; k++)
                {
                    if (k == 0 || k == length - 1)
                    {
                        if (input[k] == ',')
                        {
                            error = 2; ErrorConsol(error); break;
                        }
                        if (input[k] == '+' || input[k] == '-' || input[k] == '*' || input[k] == '/')
                        {
                            error = 5; ErrorConsol(error); break;
                        }
                    }
                    else
                    {
                        if (input[k] == ',')
                        {
                            if ((input[k - 1] == '+' || input[k - 1] == '-' || input[k - 1] == '*' || input[k - 1] == '/' || input[k - 1] == '(' || input[k - 1] == ')' || input[k - 1] == ',') || (input[k + 1] == '+' || input[k + 1] == '-' || input[k + 1] == '*' || input[k + 1] == '/' || input[k + 1] == '(' || input[k + 1] == ')' || input[k + 1] == ','))
                            {
                                error = 3; ErrorConsol(error); break;
                            }
                        }
                        if (input[k] == '+' || input[k] == '-' || input[k] == '*' || input[k] == '/')
                        {
                            if ((input[k - 1] == '+' || input[k - 1] == '-' || input[k - 1] == '*' || input[k - 1] == '/' || input[k - 1] == ',') || (input[k + 1] == '+' || input[k + 1] == '-' || input[k + 1] == '*' || input[k + 1] == '/' || input[k + 1] == ','))
                            {
                                error = 6; ErrorConsol(error); break;
                            }
                        }
                    }
                }

                for (int k = 0; k < length; k++)
                {
                    int e = 0;
                    if (input[k] == '0' || input[k] == '1' || input[k] == '2' || input[k] == '3' || input[k] == '4' || input[k] == '5' || input[k] == '6' || input[k] == '7' || input[k] == '8' || input[k] == '9')
                    {
                        for (int j = k; j < length; j++)
                        {
                            if (input[j] == '0' || input[j] == '1' || input[j] == '2' || input[j] == '3' || input[j] == '4' || input[j] == '5' || input[j] == '6' || input[j] == '7' || input[j] == '8' || input[j] == '9' || input[j] == ',')
                            {
                                if (input[j] == ',')
                                    e++;
                            }
                            else
                            {
                                k = j;
                                break;
                            }
                        }
                        if (e > 1) { error = 4; ErrorConsol(error); break; }
                    }
                }

                int o = 0, z = 0;
                for (int k = 0; k < length; k++)
                {
                    if (input[k] == '(')
                        o++;

                    if (input[k] == ')')
                        z++;
                }
                if (o != z)
                    error = 7; ErrorConsol(error);

                if (error > 0) { continue; }

                for (int i = 0; i < length; i++)
                {
                    if (input[i] == '0' || input[i] == '1' || input[i] == '2' || input[i] == '3' || input[i] == '4' || input[i] == '5' || input[i] == '6' || input[i] == '7' || input[i] == '8' || input[i] == '9')
                    {
                        for (int j = i; j < length; j++)
                        {
                            if (input[j] == '0' || input[j] == '1' || input[j] == '2' || input[j] == '3' || input[j] == '4' || input[j] == '5' || input[j] == '6' || input[j] == '7' || input[j] == '8' || input[j] == '9' || input[j] == ',' )
                            {
                                newInput += input[j];
                                if (j + 1 == length)
                                {
                                    double d = Convert.ToDouble(newInput);
                                    numbers.Push(d);
                                    i = j; newInput = null;
                                    if (numbers.Count > 1)
                                    {
                                        while (operators.Count != 0)
                                        {
                                            switch (operators.Peek())
                                            {
                                                case '+':
                                                    double m11 = numbers.Pop(); double m12 = numbers.Pop();
                                                    numbers.Push(m12 + m11); operators.Pop();
                                                    break;
                                                case '-':
                                                    double m21 = numbers.Pop(); double m22 = numbers.Pop();
                                                    numbers.Push(m22 - m21); operators.Pop();
                                                    break;
                                                case '*':
                                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                                    numbers.Push(m32 * m31); operators.Pop();
                                                    break;
                                                case '/':
                                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                                    numbers.Push(m42 / m41); operators.Pop();
                                                    break;
                                                case '(':
                                                    operators.Pop();
                                                    break;
                                                default:
                                                    //ошбика
                                                    break;
                                            }
                                        }
                                    }   
                                    break;
                                }
                            }
                            else
                            {
                                double d = Convert.ToDouble(newInput);
                                numbers.Push(d);
                                i = j; newInput = null;
                                break;
                            }
                        }
                    }
                    int l = i;
                    if (input[i] == '+')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push('+');
                        }
                        else
                        {
                            switch (operators.Peek())
                            {
                                case '+':
                                    double m11 = numbers.Pop(); double m12 = numbers.Pop();
                                    numbers.Push(m12 + m11); operators.Pop(); l = i - 1;
                                    break;
                                case '-':
                                    double m21 = numbers.Pop(); double m22 = numbers.Pop();
                                    numbers.Push(m22 - m21); operators.Pop(); l = i - 1;
                                    break;
                                case '*':
                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                    numbers.Push(m32 * m31); operators.Pop(); l = i - 1;
                                    break;
                                case '/':
                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                    numbers.Push(m42 / m41); operators.Pop(); l = i - 1;
                                    break;
                                case '(':
                                    operators.Push('+');
                                    break;
                                default:
                                    //ошибка;
                                    break;
                            }
                        }
                    }
                    if (input[i] == '-')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push('-');
                        }
                        else
                        {
                            switch (operators.Peek())
                            {
                                case '+':
                                    double m11 = numbers.Pop(); double m12 = numbers.Pop();
                                    numbers.Push(m12 + m11); operators.Pop(); l = i - 1;
                                    break;
                                case '-':
                                    double m21 = numbers.Pop(); double m22 = numbers.Pop();
                                    numbers.Push(m22 - m21); operators.Pop(); l = i - 1;
                                    break;
                                case '*':
                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                    numbers.Push(m32 * m31); operators.Pop(); l = i - 1;
                                    break;
                                case '/':
                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                    numbers.Push(m42 / m41); operators.Pop(); l = i - 1;
                                    break;
                                case '(':
                                    operators.Push('-');
                                    break;
                                default:
                                    //ошибка;
                                    break;
                            }
                        }
                    }
                    if (input[i] == '*')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push('*');
                        }
                        else
                        {
                            switch (operators.Peek())
                            {
                                case '+':
                                    operators.Push('*');
                                    break;
                                case '-':
                                    operators.Push('*');
                                    break;
                                case '*':
                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                    numbers.Push(m32 * m31); operators.Pop(); l = i - 1;
                                    break;
                                case '/':
                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                    numbers.Push(m42 / m41); operators.Pop(); l = i - 1;
                                    break;
                                case '(':
                                    operators.Push('*');
                                    break;
                                default:
                                    //ошибка;
                                    break;
                            }
                        }
                    }
                    if (input[i] == '/')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push('/');
                        }
                        else
                        {
                            switch (operators.Peek())
                            {
                                case '+':
                                    operators.Push('/');
                                    break;
                                case '-':
                                    operators.Push('/');
                                    break;
                                case '*':
                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                    numbers.Push(m32 * m31); operators.Pop(); l = i - 1;
                                    break;
                                case '/':
                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                    numbers.Push(m42 / m41); operators.Pop(); l = i - 1;
                                    break;
                                case '(':
                                    operators.Push('/');
                                    break;
                                default:
                                    //ошибка;
                                    break;
                            }
                        }
                    }
                    if (input[i] == '(') { operators.Push('('); }
                    if (input[i] == ')')
                    {
                        while (operators.Peek() != '(')
                        {
                            switch (operators.Peek())
                            {
                                case '+':
                                    double m11 = numbers.Pop(); double m12 = numbers.Pop();
                                    numbers.Push(m12 + m11); operators.Pop();
                                    break;
                                case '-':
                                    double m21 = numbers.Pop(); double m22 = numbers.Pop();
                                    numbers.Push(m22 - m21); operators.Pop();
                                    break;
                                case '*':
                                    double m31 = numbers.Pop(); double m32 = numbers.Pop();
                                    numbers.Push(m32 * m31); operators.Pop();
                                    break;
                                case '/':
                                    double m41 = numbers.Pop(); double m42 = numbers.Pop();
                                    numbers.Push(m42 / m41); operators.Pop();
                                    break;
                                case '(':
                                    operators.Pop();
                                    break;
                                default:
                                    //ошбика
                                    break;
                            }
                        }
                        operators.Pop();
                        if (i + 1 == length)
                        {
                            while (operators.Count != 0)
                            {
                                switch (operators.Peek())
                                {
                                    case '+':
                                        double m51 = numbers.Pop(); double m52 = numbers.Pop();
                                        numbers.Push(m52 + m51); operators.Pop();
                                        break;
                                    case '-':
                                        double m61 = numbers.Pop(); double m62 = numbers.Pop();
                                        numbers.Push(m62 - m61); operators.Pop();
                                        break;
                                    case '*':
                                        double m71 = numbers.Pop(); double m72 = numbers.Pop();
                                        numbers.Push(m72 * m71); operators.Pop();
                                        break;
                                    case '/':
                                        double m81 = numbers.Pop(); double m82 = numbers.Pop();
                                        numbers.Push(m82 / m81); operators.Pop();
                                        break;
                                    case '(':
                                        operators.Pop();
                                        break;
                                    default:
                                        //ошбика
                                        break;
                                }
                            }
                        }
                    }
                    i = l;
                }

                Console.WriteLine("Кол-во чисел в стеке: " + numbers.Count + ". Последние число стека: " + numbers.Peek());
                if (operators.Count != 0)
                {
                    Console.WriteLine("Кол-во операторов в стеке: " + operators.Count + ". Последняя операция в стеке: " + operators.Peek());
                    operators.Clear();
                }
                numbers.Clear();
            }
        }

        static public void ErrorConsol(int errors)
        {
            if (errors == 1)
                Console.WriteLine("Ошибка: Перечень допустимых символов: 0123456789+-*/,()");

            if (errors == 2)
                Console.WriteLine("Выражение не может начинаться или заканчиваться запятой.");

            if (errors == 3)
                Console.WriteLine("Где-то неправильно стоит запятая.");

            if (errors == 4)
                Console.WriteLine("В одном числе не может быть больше одной запятой.");

            if (errors == 5)
                Console.WriteLine("Выражене не может начинаться или заканчиваться оператором.");

            if (errors == 6)
                Console.WriteLine("Операторы расставлены неверно.");

            if (errors == 7)
                Console.WriteLine("Количество открывающших и закрывающих скобок разное");
        }

    }
}
