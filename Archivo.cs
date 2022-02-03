using System;
using System.IO;

namespace Archivos{
    public class Archivo{

        StreamReader archivo;
        StreamWriter copia;
        public Archivo(){
            archivo = new StreamReader("C:\\Users\\Fernando Hernández\\Desktop\\ITQ\\4to Semestre\\Lenguajes y Autómatas 1\\archivos\\prueba.txt");
            copia = new StreamWriter("C:\\Users\\Fernando Hernández\\Desktop\\ITQ\\4to Semestre\\Lenguajes y Autómatas 1\\archivos\\copia.txt");
            copia.AutoFlush = true;
        }
        public void Cerrar(){
            archivo.Close();
            copia.Close();
        }
        public void desplegar(){
            int letras=0,numeros=0,espacios=0;
            while (!archivo.EndOfStream){
                char c = (char)archivo.Read();
                Console.Write(c);
                if (c == 'a'|| c == 'A'){
                    copia.Write('4');
                }
                else if (char.ToLower(c) == 'e' ){
                    copia.Write('3');
                }
                else if (char.ToLower(c) == 'i'){
                    copia.Write('1');
                }
                else if (char.ToLower(c) == 'o'){
                    copia.Write('0');
                }
                else if (char.ToLower(c) == 'u'){
                    copia.Write('#');
                }
                else {
                    copia.Write(c);
                }
                if(char.IsLetter(c)){
                    letras++;
                }
                else if (char.IsDigit(c)){
                    numeros++;
                }
                else if (c==32){
                    espacios++;
                }
            }
            copia.WriteLine("\nNumeros: " +numeros +"\nEspacios: " +espacios +"\nLetras: " +letras);
        Cerrar();
        }
        public void palabras(){
            string buffer= " ";
            while (!archivo.EndOfStream){
                char c = (char)archivo.Read();
                buffer = (char.IsLetterOrDigit(c) ? buffer+c : buffer);
                if(char.IsWhiteSpace(c) && buffer != ""){
                    copia.WriteLine(buffer);
                    buffer= "";
                }
            }
            Cerrar();
        }
        public void NextToken(){
            string buffer= "";
            char c = ' ';
            while(char.IsWhiteSpace(c = (char)archivo.Read()));
            if (char.IsLetter(c)){
                buffer += c;
                while(char.IsLetterOrDigit(c= (char)archivo.Read())){
                    buffer += c;
                }
                copia.WriteLine(buffer);
            }
        }
    }
}