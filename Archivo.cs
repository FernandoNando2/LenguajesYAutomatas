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
                letras= (char.IsLetter(c)) ? letras+=1 : letras;
                numeros= (char.IsDigit(c)) ? numeros+=1 : numeros;
                espacios= (c==32) ? espacios+=1 : espacios;
                c = (Char.ToLower(c) == 'a' || c == 'á') ? '4' : c;
                c = (Char.ToLower(c) == 'e' || c == 'é') ? '3' : c;
                c = (Char.ToLower(c) == 'i' || c == 'í') ? '1' : c;
                c = (Char.ToLower(c) == 'o' || c == 'ó') ? '0' : c;
                c = (Char.ToLower(c) == 'u' || c == 'ú') ? '#' : c;                                                
                copia.Write(c);
            }
            copia.WriteLine("\nNumeros: " +numeros +"\nEspacios: " +espacios +"\nLetras: " +letras);
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