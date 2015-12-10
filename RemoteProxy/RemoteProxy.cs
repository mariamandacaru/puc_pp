using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_3
{
    class RemoteProxy
    {
        static void Main(string[] args)
        {
            ProxyStub servico = new ProxyStub();
            servico.f1();
            servico.f2();
            servico.f3();
        }

        interface ContratoServico
        {
            void f1();
            void f2();
            void f3();
        }  

        class Servico : ContratoServico 
        {				
	        public void f1(){Console.WriteLine("f1");}
	        public void f2(){Console.WriteLine("f2");}
	        public void f3(){Console.WriteLine("f3");}
        }

        class ProxySkeleton : ContratoServico
        {
	
	        Servico servico = new Servico();
	
	        public void f1(){
		        Console.WriteLine("skeleton f1");				
		        servico.f1();
	        }

	        public void f2() 
	        {
		        Console.WriteLine("skeleton f2");	
		        servico.f2();			
	        }

	        public void f3() 
	        {	
		        Console.WriteLine("skeleton f3");	
		        servico.f3();
	        }

        }
 
        class ProxyStub : ContratoServico
        {
	
	        ProxySkeleton skeleton = new ProxySkeleton();
	        public void f1()	{
	            Console.WriteLine("stub f1");			
		        skeleton.f1();
	        }

	        public void f2() 
	        {
		        Console.WriteLine("stub f2");	
		        skeleton.f2();		
	        }

	        public void f3() 
	        {	
		        Console.WriteLine("stub f3");	
		        skeleton.f3();
	        }

        } 
    }
}
