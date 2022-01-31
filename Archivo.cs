using System;
using System.IO;

namespace Archivos{
    public class Archivo{
        StreamReader archivo = new StreamReader("C:\\archivos\\prueba.txt");
        public void desplegar(){
            while(!archivo.EndOfStream){
                Console.Write((char)archivo.Read());
            }
        }
    }
}