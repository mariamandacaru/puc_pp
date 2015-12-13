using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_3_Composite
{
    class Calc_Composite
    {
        static void Main(string[] args)
        {

        }

    }

    //Composite
    interface Operador {
        void calcularValor(Stack<Double> values);
    }

    class Calculo_Facade
    {
        string rpn;

        public Calculo_Facade(string _rpn)
        {
            this.rpn = _rpn;
        }

        public decimal CalcularRPN()
        {
            string[] rpnTokens = rpn.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal number = decimal.Zero;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                        default:
                            Console.WriteLine("Erro no método CalcularRPN()");
                            break;
                    }
                }

            }

            return stack.Pop();
        }

    }

}
