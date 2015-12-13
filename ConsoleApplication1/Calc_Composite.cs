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
            string expressao = "4 3 +";
            double resultado = 0;
            Calculo_Facade calcular = new Calculo_Facade(expressao);
            resultado = calcular.CalcularRPN();
            Console.WriteLine(resultado);
            Console.ReadKey();
        }

    }

    //--------------Composite-----------------
    public interface Operador_Composite {
        void calcularValor(ref Stack<Double> values);
    }

    public class Multiplicacao : Operador_Composite
    {
        public void calcularValor(ref Stack<double> stack)
        {
            stack.Push(stack.Pop() * stack.Pop());
        }
    }

    public class Divisao : Operador_Composite
    {
        public void calcularValor(ref Stack<double> stack)
        {
            double number = 0;
            number = stack.Pop();
            stack.Push(stack.Pop() / number);
        }
    }

    public class Adicao : Operador_Composite
    {
        public void calcularValor(ref Stack<double> stack)
        {
            stack.Push(stack.Pop() + stack.Pop());
        }
    }

    public class Subtracao : Operador_Composite
    {
        public void calcularValor(ref Stack<double> stack)
        {
            double number = 0;
            number = stack.Pop();
            stack.Push(stack.Pop() - number);
        }
    }
    //----------------------------------------------

    class Calculo_Facade
    {
        string rpn;

        public Calculo_Facade(string _rpn)
        {
            this.rpn = _rpn;
        }

        public double CalcularRPN()
        {
            string[] rpnTokens = rpn.Split(' ');
            Stack<double> stack = new Stack<double>();
            double number = 0;

            Multiplicacao mult = new Multiplicacao();
            Divisao div = new Divisao();
            Adicao adicao = new Adicao();
            Subtracao sub = new Subtracao();

            foreach (string token in rpnTokens)
            {
                if (double.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "*":
                            {
                                mult.calcularValor(ref stack);
                                break;
                            }
                        case "/":
                            {
                                div.calcularValor(ref stack);
                                break;
                            }
                        case "+":
                            {
                                adicao.calcularValor(ref stack);
                                break;
                            }
                        case "-":
                            {
                                sub.calcularValor(ref stack);
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
