using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_4_Strategy
{
    class IRPF_Strategy
    {
        static void Main(string[] args)
        {
            double salarioLiquido=0;
            double salario = 6000;

            ImpostoRenda_Contexto contexto2014 = new ImpostoRenda_Contexto(new Ano2014());
            salarioLiquido= contexto2014.CalcularSalario(salario);
            Console.WriteLine("Salário em 2014: " + salarioLiquido.ToString());

            ImpostoRenda_Contexto contexto2015 = new ImpostoRenda_Contexto(new Ano2015());
            salarioLiquido = contexto2015.CalcularSalario(salario);
            Console.WriteLine("Salário em 2015: " + salarioLiquido.ToString());

            Console.ReadKey();
        }

    }

    class ImpostoRenda_Contexto
    {
        private Ano_Strategy contexto;

        public ImpostoRenda_Contexto(Ano_Strategy _contexto)
        {
            this.contexto = _contexto;
        }

        public double CalcularSalario(double salario)
        {
            return contexto.CalcularSalario(salario);
        }
    }

    interface Ano_Strategy
    {
        double CalcularSalario(double salario);
    }

    class Ano2014 : Ano_Strategy
    {
        Faixas faixas = new Faixas(1787.77, 2679.29, 3572.43, 4463.81);

        double Ano_Strategy.CalcularSalario(double salario)
        {
            Calculo_Aliquotas calculo = new Calculo_Aliquotas(salario, faixas);
            return calculo.Salario_Liquido();
        }
    }

    class Ano2015 : Ano_Strategy
    {
        Faixas faixas = new Faixas(1903.98, 2826.65, 3751.05, 4664.68);

        double Ano_Strategy.CalcularSalario(double salario)
        {            
            Calculo_Aliquotas calculo = new Calculo_Aliquotas(salario,faixas);
            return calculo.Salario_Liquido();
        }
    }

    class Calculo_Aliquotas
    {
        double salario;
        double retencaoImposto = 0;
        Faixas faixas;

        public double Salario_Liquido()
        {
            if (salario <= faixas.faixaUm)
                retencaoImposto = 0;

            else if ((salario > faixas.faixaUm) && (salario <= faixas.faixaDois))
                retencaoImposto = Aliquota_Residual_Faixa_Dois();

            else if ((salario > faixas.faixaDois) && (salario <= faixas.faixaTres))

                retencaoImposto = Aliquota_Faixa_Dois() +
                                 Aliquota_Residual_Faixa_Tres();

            else if ((salario > faixas.faixaTres) && (salario <= faixas.faixaQuatro))

                retencaoImposto = Aliquota_Faixa_Dois() +
                                 Aliquota_Faixa_Tres() +
                                 Aliquota_Residual_Faixa_Quatro();

            else if (salario > faixas.faixaQuatro)

                retencaoImposto = Aliquota_Faixa_Dois() +
                                 Aliquota_Faixa_Tres() +
                                 Aliquota_Faixa_Quatro() +
                                 Aliquota_Residual_Faixa_Cinco();

            return (salario - retencaoImposto);
        }

        public Calculo_Aliquotas(double _salario, Faixas _faixas)
        {
            this.salario = _salario;
            faixas = _faixas;
        }

        public double Aliquota_Faixa_Dois()
        {
            return (((faixas.faixaDois - faixas.faixaUm) * 7.5) / 100);
        }

        public double Aliquota_Faixa_Tres()
        {
            return (((faixas.faixaTres - faixas.faixaDois) * 15) / 100);
        }

        public double Aliquota_Faixa_Quatro()
        {
            return (((faixas.faixaQuatro - faixas.faixaTres) * 22.5) / 100);
        }

        public double Aliquota_Residual_Faixa_Dois()
        {
            return (((this.salario - faixas.faixaUm) * 7.5) / 100);
        }

        public double Aliquota_Residual_Faixa_Tres()
        {
            return (((this.salario - faixas.faixaDois) * 15) / 100);
        }

        public double Aliquota_Residual_Faixa_Quatro()
        {
            return (((this.salario - faixas.faixaTres) * 22.5) / 100);
        }

        public double Aliquota_Residual_Faixa_Cinco()
        {
            return (((this.salario - faixas.faixaQuatro) * 27.5) / 100);
        }

    }

    public class Faixas
    {
        public double faixaUm;
        public double faixaDois;
        public double faixaTres;
        public double faixaQuatro;

        public Faixas(double _faixaUm, double _faixaDois, double _faixaTres, double _faixaQuatro)
        {
            faixaUm = _faixaUm;
            faixaDois = _faixaDois;
            faixaTres = _faixaTres;
            faixaQuatro = _faixaQuatro;
        }
    }


}
