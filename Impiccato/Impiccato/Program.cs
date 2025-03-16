




void creoMatrice(string[,] NomiCompleti,string path)
{
    string[] nomi1;
    StreamReader r = new StreamReader(path);
    string nomi = r.ReadLine();
    int cont = 0;
    while (nomi != null && nomi!="")
    {
        nomi1 = nomi.Split(',');
        for (int i = 0; i < NomiCompleti.GetLength(1)-1; i++)
        {
            NomiCompleti[cont, i] = nomi1[i];
        }
        cont++;
        nomi = "";
        nomi = r.ReadLine();
    }
}
string scelgoParola(string[,] m)
{
    string parola;
    Random rnd=new Random();   
    Console.WriteLine("Vuoi scegliere il tema della tua parola? (s o n) (se sbagli a digitare il computer sceglierà no per te)");
    string risposta = Console.ReadLine();
    risposta=risposta.Trim().ToLower();
    int riga = 0,colonna=0;
    if (risposta =="s")
    {
        Console.WriteLine("dimmi il tema della tua parola (calcio, verbi, frutta e verdura, animali, nazioni, lavori oppure città) (se sbagli verrà scelto calcio)");
        string Tema=Console.ReadLine();
        Tema = Tema.Trim().ToLower();
        for(int i = 0; i < m.GetLength(0); i++)
        {
            if (Tema == m[i, 0])
            {
                riga = i;
            }
        }

                
    }
    else
    {
        riga=rnd.Next(0,7);
    }
    colonna=rnd.Next(1,52);
    parola = m[riga, colonna];
    return parola;
}
string scelgoParolaEN(string[,] m)
{
    string parola;
    Random rnd = new Random();
    Console.WriteLine("Do you want to choose the theme of your word? (y or n) (if you type incorrectly, the computer will choose no for you)");
    string risposta = Console.ReadLine();
    risposta = risposta.Trim().ToLower();
    int riga = 0, colonna = 0;
    if (risposta == "y")
    {
        Console.WriteLine("Tell me the theme of your word (football, verbs, fruits and vegetables, animals, countries, jobs, or cities) (if you make a mistake, football will be chosen).");
        string Tema = Console.ReadLine();
        Tema = Tema.Trim().ToLower();
        for (int i = 0; i < m.GetLength(0); i++)
        {
            if (Tema == m[i, 0])
            {
                riga = i;
            }
        }


    }
    else
    {
        riga = rnd.Next(0, 7);
    }
    colonna = rnd.Next(1, 52);
    parola = m[riga, colonna];
    return parola;
}
char[] trasformo(string parola)
{
    char[] parolafatta=new char[parola.Length];
    for (int i = 0; i < parola.Length; i++)
    {
        parolafatta[i] = '_';
    }
    return parolafatta;
        
}
void gioco(string parola,char[] parolaT,int vita)
{
    Random rnd = new Random();
    bool uscire = false,indovinato=false;
    string lettere="";
    int jolly = 1;
    int n=0;
    while(vita>0 && uscire==false && indovinato == false)
    {
        Console.WriteLine("Le tue vite rimaste sono: " + vita);
        Console.WriteLine("Le tue lettere jolly rimaste sono: " + jolly);
        Console.Write("la tua parola è: ");
        for (int i = 0; i < parola.Length; i++)
        {
            Console.Write(parolaT[i]);
        }
        Console.WriteLine();
        Console.WriteLine("Le lettere già inserite sono " + lettere);
        Console.WriteLine("cosa vuoi fare questo turno\n1. Dire una lettera\n2. Indizio\n3. Lettera jolly\n4.Indovinare la parola\n5. Chiudere");
        Console.Write("Dimmi il numero della tua azione: ");
        int azione=int.Parse(Console.ReadLine());
        
        switch (azione)
        {
            case 1:
                bool contiene = false,contienel=false;
                int contienetrat = 0;
                string pos = "";
                int cont = 0;
                contiene = false;
                cont = 0;
                contienel = false;
                contiene = false;
                contienetrat = 0;
                Console.Write("Dimmi la lettera che stavi pensando ");
                string lettera = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < parola.Length; i++)
                {
                    if (lettera[0] == parola[i])
                    {
                        contiene = true;
                    }
                }
                if (contiene == true)
                {
                    for(int i = 0; i < parola.Length; i++)
                    {
                        if (lettera[0] == parola[i])
                        {
                            if (pos.Length == 0)
                            {
                                pos += i;
                            }
                            else
                            {
                                pos += "," + i;
                            }

                        }
                    }
                    string[] posArray = pos.Split(','); 
                    for (int i = 0; i < posArray.Length; i++)
                    {
                        int pos1 = int.Parse(posArray[i]); 
                        parolaT[pos1] = parola[pos1]; 
                    }
                    Console.Write("HAI INDOVINATO LA TUA PAROLA ADESSO E': ");
                    for (int i = 0; i < parola.Length; i++)
                    {
                        Console.Write (parolaT[i]);
                    }
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("la lettera da te inserita non è presente nella parola");
                    if (lettere.Length == 0)
                    {
                        lettere += lettera;
                    }
                    else
                    {
                        for (int i = 0;i < lettere.Length; i++)
                        {
                            if (lettera[0] == lettere[i])
                            {
                                contienel=true;
                            }
                        }
                        if (contienel == true)
                        {
                            Console.WriteLine("HAI GIA' INSERITO QUESTA LETTERA");
                        }
                        else
                        {
                            lettere += ", " + lettera;
                        }
                        
                    }
                    vita--;
                    
                }
                
                for (int i = 0; i < parolaT.Length; i++)
                {
                    if (parolaT[i] != '_')
                    {
                        contienetrat++;
                    }
                }
                if (contienetrat == parolaT.Length)
                {
                    indovinato = true;
                }
                break;
            case 2:
                break;
            case 3:
                if (jolly > 0)
                {
                    Console.WriteLine("Hai deciso di usare la lettera jolly");
                    bool ok = false;
                    while (ok == false)
                    {
                        int posizione = rnd.Next(0, parola.Length);
                        for(int i=0; i < parola.Length; i++)
                        {
                            if (parolaT[posizione] == '_')
                            {
                                parolaT[posizione] = parola[posizione];
                                ok = true;
                                jolly -= 1;
                                i = parola.Length;
                            }
                            else
                            {
                                posizione = rnd.Next(0, parola.Length);
                            }
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Non hai lettere jolly a disposizione");
                }
                break;
            case 4:
                Console.Write("Dimmi questa parola ");
                string p = Console.ReadLine();
                Console.WriteLine();
                if (p == parola)
                {
                    Console.WriteLine("HAI INDOVINATO");
                    indovinato = true;
                }
                else
                {
                    Console.WriteLine("non ci hai preso");
                    vita--;
                }
                break;
            case 5:
                Console.WriteLine("hai deciso di uscire dal gioco... scarso");
                uscire = true;
                break;
            
        }
        Console.WriteLine();

    }
    if (indovinato == true)
    {
        Console.WriteLine("Complimenti hai indovinato la parola");
    }
    else if (vita <= 0)
    {
        Console.WriteLine("Mi dispiace hai perso finendo le vite");
    }

}
Random rnd = new Random();
string[,] nomi=new string[7,51];
string path,parola;
int pos = 0,vita=0;
Console.WriteLine("il gioco lo vuoi in italiano o in ingles (i o e) (se sbagli verrà scelto inglese)");
string risposta = Console.ReadLine();
risposta = risposta.Trim().ToLower();
if (risposta == "i")
{
    path = "nomi.txt";
}
else
{
   path = "nomiEN.txt";
}
creoMatrice(nomi, path);
if (risposta == "i")
{
    parola = scelgoParola(nomi);
}
else
{
    parola = scelgoParolaEN(nomi);
}
char[] parolaT=trasformo(parola);
if (risposta == "i")
{
    Console.WriteLine("dimmi la difficoltà \n 1. Facile (10 tentativi)\n 2. Medio (5 tentativi)\n 3.Difficile (3 tentativi)\n 4. Impossibile (1 tentativo)\n digita il numero corrispondente se sbagli verrà scelto facile");
    int risposta1 = int.Parse(Console.ReadLine());
    if (risposta1 == 2)
    {
        vita=5;
        Console.WriteLine("hai scelto Medio la tua vita è 5");
    }
    else if (risposta1 == 3)
    {
        vita=3;
        Console.WriteLine("hai scelto Difficile la tua vita è 3");
    }
    else if (risposta1 == 4)
    {
        vita=1;
        Console.WriteLine("hai scelto Impossibile la tua vita è 1");

    }
    else
    {
        vita=10;
        Console.WriteLine("hai scelto Facile la tua vita è 10");
    }
}
else
{
    Console.WriteLine("Choose the difficulty:\n1. Easy (10 attempts)\n2. Medium (5 attempts)\n3.Hard (3 attempts)\n4. Impossible (1 attempt)\nType the corresponding number, if you make a mistake, easy will be chosen.");
    int risposta1 = int.Parse(Console.ReadLine());
    if (risposta1 == 2)
    {
       vita= 5;
        Console.WriteLine("You chose Medium, your life is 5");
    }
    else if (risposta1 == 3)
    {
        vita= 3;
        Console.WriteLine("You chose Medium, your life is 3");
    }
    else if (risposta1 == 4)
    {
        vita = 1;
        Console.WriteLine("You chose Medium, your life is 1");
    }
    else
    {
        vita = 10;
        Console.WriteLine("You chose Medium, your life is 10");
    }
}
for (int i = 0; i < 2; i++)
{
    pos = rnd.Next(0, parola.Length);
    parolaT[pos] = parola[pos];
}
gioco(parola, parolaT,vita);