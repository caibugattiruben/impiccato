



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
    bool uscire = false,indovinato=false;
    string lettere="";
    while(vita>0 && uscire==false && indovinato == false)
    {
        Console.WriteLine("cosa vuoi fare questo turno\n1. Dire una lettera\n2. Indizio\n3. Lettera jolly\n4.Indovinare la parola\n5. Chiudere");
        Console.Write("Dimmi il numero della tua azione: ");
        int azione=int.Parse(Console.ReadLine());
        switch (azione)
        {
            case 1:
                Console.Write("Dimmi la lettera che stavi pensando ");
                string lettera = Console.ReadLine();
                Console.WriteLine();
                string pos = "";
                for(int i = 0; i < parola.Length; i++)
                {
                    if (lettera[0] == parola[i])
                    {
                        pos += i;
                    }
                }
                if (pos.Length > 0)
                {
                    if (pos.Length > 1)
                    {
                        for(int i = 0;i < pos.Length; i++)
                        {
                            int o =int.Parse(pos[i].ToString()); ;
                            parolaT[o] = parola[o];
                        }
                    }
                    else
                    {
                        parolaT[pos[0]-1] = parola[pos[0]-1];
                    }
                    Console.Write("HAI INDOVINATO LA LETTERA. LA TUA PAROLA ORA E' ");
                    for(int i = 0; i < parolaT.Length; i++)
                    {
                        Console.Write(parolaT[i]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("la lettera non è presente nella parola misteriosa");
                }

                        
                break;
        }
            
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
Console.WriteLine(parola);
char[] parolaT=trasformo(parola);

for (int i = 0; i < 2; i++)
{
    pos = rnd.Next(0, parola.Length);
    parolaT[pos] = parola[pos];
}
Console.WriteLine(parolaT);
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
gioco(parola, parolaT,vita);