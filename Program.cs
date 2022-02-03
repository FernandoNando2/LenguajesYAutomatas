using System;

namespace Archivos{
    class Program{

        static void Main(string[] args){
            Archivo a = new Archivo();
            //a.palabras();
            a.NextToken();
            a.NextToken();
            a.Cerrar();
        }
    }
}