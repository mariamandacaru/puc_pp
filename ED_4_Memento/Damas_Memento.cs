using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ED_4_Memento
{
    public class Memento
    {
        private string cor;
        private string posicao;

        public Memento(string _cor, string _posicao)
        {
            this.cor = _cor;
            this.posicao = _posicao;
        }

        public String getCor()
        {
            return cor;
        }

        public String getPosicao()
        {
            return posicao;
        }

    }

    public class Originator
    {
        private string cor;
        private string posicao;

        public void setCor(String _cor)
        {
            this.cor = _cor;
        }

        public void setPosicao(String _posicao)
        {
            this.posicao = _posicao;
        }

        public String getCor()
        {
            return cor;
        }

        public String getPosicao()
        {
            return posicao;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(cor,posicao);
        }

        public void getCorFromMemento(Memento Memento)
        {
            cor = Memento.getCor();
        }

        public void getPosicaoFromMemento(Memento Memento)
        {
            posicao = Memento.getPosicao();
        }


    }

    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }

    class Damas_Memento
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();

            originator.setCor("Vazio");
            originator.setPosicao("1,1");
            careTaker.add(originator.saveStateToMemento());

            originator.setCor("Branco");
            originator.setPosicao("1,2");
            careTaker.add(originator.saveStateToMemento());

            originator.getCorFromMemento(careTaker.get(0));
            Console.WriteLine("First cor: " + originator.getCor());

            originator.getPosicaoFromMemento(careTaker.get(0));
            Console.WriteLine("First posicao: " + originator.getPosicao());

            originator.getCorFromMemento(careTaker.get(1));
            Console.WriteLine("Second cor: " + originator.getCor());

            originator.getPosicaoFromMemento(careTaker.get(1));
            Console.WriteLine("Second posicao: " + originator.getPosicao());

            Console.ReadKey();
        }
    }
}
