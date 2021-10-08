using System;

namespace Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella Tombola");
            int[] a=Sceltadeinumeri();
            EstrazioneNumeri(a);
            DichiaraVittoria(EstrazioneNumeri(a));
        }
        private static int[] Sceltadeinumeri()
        {
            Console.WriteLine("inserisci cinque numeri compresi fra 1 e 90");
            int i = 0;
            int[] numeri = new int[5];
            do
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                if ((numero < 1) || (numero > 90))
                {
                    Console.WriteLine("ERRORE: il numero deve essere compreso fra 1 e 90");
                    numero = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    numeri[i] = numero;
                    i++;
                    
                    
                }
               
            }
            while (i < 5);
           
            //Il controllo del valore inserito vale solo se l'utente fa un solo errore,
            //altrimenti il programma si blocca(valore minore di 1 e maggiore di 90).
            //Il controllo della presenza di valori inseriti più volte non viene fatto.

            Console.WriteLine("I numeri inseriti sono");
            for (i=0;i<numeri.Length;i++)
            {
                
                Console.WriteLine($"{numeri[i]}");
            }
            return numeri;
        }

        private static int EstrazioneNumeri(int[] numeri)
        {
            var rnd = new Random();
            int estrazione;
            int[] estratti = new int[70];
            Console.WriteLine("\n");
            for (int i = 1; i < 70; i++) 
            {
                estrazione = rnd.Next(1, 91);
                estratti[0] = estrazione;
                if (estratti[i] == estrazione)
                {
                    estrazione = rnd.Next(1, 91);
                    continue;
                }
                else 
                {
                    estratti[i] = estrazione;
                    
                    
                }
                Console.WriteLine($"{estratti[i]}");
            }

            int conta = 0;
            int j = 0;
           
            for (int i = 0; i < 70; i++)
            {
                for ( j = 0; j < 5; j++)
                {
                    if (numeri[j]==estratti[i])
                    {
                        conta = conta + 1;
                   
                    }
                    else
                    {
                        conta = conta + 0;
                    }
                }
            }
            return conta;
            //la variabile conta viene usata nel switch successivo per definire ambo,terna etc.
            //il codice precedente ha un problema che porta la variabile conta ad assumere un
            //valore maggiore di 5, in alcuni casi;
        }

        private static void DichiaraVittoria(int conta)
        {
            switch (conta)
            {
                case 1:
                    Console.WriteLine("hai perso");
                    break;
                case 2:
                    Console.WriteLine("Hai fatto ambo");
                    break;
                case 3:
                    Console.WriteLine("Hai fatto terna");
                    break;
                case 4:
                    Console.WriteLine("Hai fatto quaterna");
                    break;
                case 5:
                    Console.WriteLine("Hai fatto cinquina");
                    break;
            }

            bool scelta = false;
            Console.WriteLine("Vuoi giocare ancora? y si n no");
            string k = Console.ReadLine();
            if (k == "y")
            {
                scelta = true;
                
                DichiaraVittoria(EstrazioneNumeri(Sceltadeinumeri()));
            }
            else
            {
                scelta = false;
                
            }

        }

        //Il codice successivo sarebbe servito per controllare la presenza di valori doppi, ma non funziona

      /*private static void ControllaDoppi(int[] numeri)
        {
            //inserisci numeri come input
            int i = 0;
            int verifica = numeri[0];
            for (i = 1; i < numeri.Length; i++)
            { 
                if (verifica!=numeri[i])
                {
                    EstrazioneNumeri(Sceltadeinumeri());
                }
                else if(verifica==numeri[i])
                {
                    Sceltadeinumeri();
                }
            }
        }*/
    }
}
