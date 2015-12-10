using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public class Calculadora {

//    public static void main(String[] args) {
//        FachadaCaulculo fachada = new FachadaCaulculo();
//        String expresao = "4 3 6 1 + - / ";
//        System.out.print(fachada.calcula(expresao));
//    }
//}

//// Composite
//interface Operador {
//    void calculaValor(Stack<Double> values);
//}

//class Avalia implements Operador {
//    List<Operador> operadores = new LinkedList<Operador>();

//    public void calculaValor(Stack<Double> values) {

//        for (Operador operador : operadores) {
//            operador.calculaValor(values);
//        }
//    }
//}

//class Adicao implements Operador {

//    public void calculaValor(Stack<Double> values) {
//        double result = values.pop() + values.pop();
//        values.push(result);
//    }
//}

//class Subtracao implements Operador {

//    public void calculaValor(Stack<Double> values) {

//        double result = values.pop() - values.pop();
//        values.push(result);
//    }
//}

//class Multiplicacao implements Operador {

//    public void calculaValor(Stack<Double> values) {

//        double result = values.pop() * values.pop();
//        values.push(result);
//    }
//}

//class Divisao implements Operador {

//    public void calculaValor(Stack<Double> values) {
//        double result = values.pop() / values.pop();
//        values.push(result);
//    }
//}

//// Fachada
//class FachadaCaulculo {

//    private static String cleanExpr(String expr) {
//        // remove all non-operators, non-whitespace, and non digit chars
//        return expr.replaceAll("[^\\*\\+\\-\\d/\\s]", "");
//    }

//    double calcula(String expressao) {
//        String cleanExpr = cleanExpr(expressao);

//        Stack<Double> values = new Stack<Double>();
       
//        Avalia a = new Avalia();

//        for (String token : cleanExpr.split("\\s")) {
//            Double tokenNum = null;
//            try {                
//                tokenNum = Double.parseDouble(token);

//            } catch (NumberFormatException e) {
//                e.getMessage();
//            }
//            if (tokenNum != null) {
//                values.push(tokenNum);
//            } else if (token.equals("*")) {
//                a.operadores.add(new Multiplicacao());
//            } else if (token.equals("/")) {
//                a.operadores.add(new Divisao());
//            } else if (token.equals("-")) {
//                a.operadores.add(new Subtracao());
//            } else if (token.equals("+")) {
//                a.operadores.add(new Adicao());
//            } else {// just in case
//                System.out.println("Error");
//            }
//        }

//        a.calculaValor(values);

//        return values.peek();
//    }
//}
namespace ED_3
{
    class Calc_Composite
    {
    }

    //Composite
    interface Operador {
        void calcularValor(Stack<Double> values);
    }

}
