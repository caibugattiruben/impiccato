using System.Drawing;
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
string scelgoParola(string[,] m,ref string tema)
{
    string Tema = "";
    string parola;
    Random rnd=new Random();   
    Console.WriteLine("Vuoi scegliere il tema della tua parola? (s o n) (se sbagli a digitare il computer sceglierà no per te)");
    string risposta = Console.ReadLine();
    risposta=risposta.Trim().ToLower();
    int riga = 0,colonna=0;
    if (risposta =="s")
    {
        
        Console.WriteLine("dimmi il tema della tua parola (calcio, verbi, frutta e verdura, animali, nazioni, lavori oppure città) (se sbagli verrà scelto calcio)");
        Tema=Console.ReadLine();
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
    colonna=rnd.Next(1,51);
    tema = m[riga, 0];
    parola = m[riga, colonna];
    return parola;
}
string scelgoParolaEN(string[,] m,ref string tema)
{
    string parola;
    string Tema = "";
    Random rnd = new Random();
    Console.WriteLine("Do you want to choose the theme of your word? (y or n) (if you type incorrectly, the computer will choose no for you)");
    string risposta = Console.ReadLine();
    risposta = risposta.Trim().ToLower();
    int riga = 0, colonna = 0;
    if (risposta == "y")
    {
        Console.WriteLine("Tell me the theme of your word (football, verbs, fruits and vegetables, animals, countries, jobs, or cities) (if you make a mistake, football will be chosen).");
        Tema = Console.ReadLine();
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
    colonna = rnd.Next(1, 51);
    tema = m[riga, 0];
    parola = m[riga, colonna];
    return parola;
}
char[] trasformo(string parola)
{
    char[] parolafatta = new char[parola.Length];
    for (int i = 0; i < parola.Length; i++)
    {
        if (parola[i]==' ')
        {
            parolafatta[i] = ' ';
        }
        else
        {
            parolafatta[i] = '_';
        }
    }
    return parolafatta;
        
}
void gioco(string parola, char[] parolaT, int vita, int monete, string tema, ref bool uscire, ref string parole)
{
    Random rnd = new Random();
    bool indovinato=false;
    string lettere="";
    int jolly = 1;
    int n=0;
    string[] indizi = { "Tema della parola (costo 15 monete)", "Prima lettera della parola (costo 10 monete)", "Ultima lettera della parola (costo 5 monete)" };
    
        while (vita > 0 && uscire == false && indovinato == false)
        {
            Console.Write("la tua parola è: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < parola.Length; i++)
            {
                
                Console.Write(parolaT[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Le tue vite rimaste sono: " + vita);
            Console.WriteLine("Le tue lettere jolly rimaste sono: " + jolly);
            Console.WriteLine("Le tue monete rimaste sono: " + monete);
            Console.WriteLine("Le lettere già inserite sono: " + lettere);
            Console.WriteLine("Cosa vuoi fare questo turno\n1. Dire una lettera\n2. Indizio\n3. Lettera jolly\n4. Indovinare la parola\n5. Chiudere");
            Console.Write("Dimmi il numero della tua azione: ");
            int azione = int.Parse(Console.ReadLine());

            switch (azione)
            {
                case 1:
                    bool contiene = false, contienel = false;
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
                    if (lettere.Length == 0)
                    {
                        lettere += lettera;
                    }
                    else
                    {
                        lettere += ", " + lettera;
                    }

                    for (int i = 0; i < parola.Length; i++)
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
                        Console.Write("HAI INDOVINATO LA LETTERA LA TUA PAROLA ADESSO E': ");
                        for (int i = 0; i < parola.Length; i++)
                        {
                            Console.Write(parolaT[i]);
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
                            for (int i = 0; i < lettere.Length; i++)
                            {
                                if (lettera[0] == lettere[i])
                                {
                                    contienel = true;
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
                    int utilizzabili = 0;
                    if (monete < 5)
                    {
                        Console.WriteLine("Le tue monete sono insufficenti");
                    }
                    else
                    {
                        Console.WriteLine("Hai scelto un indizio");
                        Console.WriteLine("Gli indizi disponibili sono:");
                        for (int i = 0; i < indizi.Length; i++)
                        {
                            Console.WriteLine(i+1 + ". " + indizi[i]);
                        }
                        Console.WriteLine("Dimmi la posizione dell'indizio");
                        int posi = int.Parse(Console.ReadLine());
                        switch (posi)
                        {
                            case 1:
                                utilizzabili = 15;
                                if (monete < utilizzabili)
                                {
                                    Console.WriteLine("Non hai abbastanza monete");
                                }
                                else
                                {
                                    if (indizi[0] != "")
                                    {
                                        Console.WriteLine("Hai utilizzato tema della parola");
                                        Console.WriteLine("il tema della parola è: " + tema);
                                        indizi[0] = "";
                                        monete -= 15;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hai già utilizzato questo indizio");
                                    }
                                    
                                }
                                break;
                            case 2:
                                utilizzabili = 10;
                                if (monete < utilizzabili)
                                {
                                    Console.WriteLine("Non hai abbastanza monete");
                                }
                                else
                                {
                                    if (indizi[1] != "")
                                    {
                                        Console.WriteLine("Hai utilizzato prima lettera");
                                        parolaT[0] = parola[0];
                                        indizi[1] = "";
                                        monete -= 10;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hai già utilizzato questo indizio");
                                    }
                                    
                                }
                                break;
                            case 3:
                                utilizzabili = 5;
                                if (monete < utilizzabili)
                                {
                                    Console.WriteLine("Non hai abbastanza monete");
                                }
                                else
                                {
                                    if (indizi[2] != "")
                                    {
                                        Console.WriteLine("Hai utilizzato ultima lettera della parola");
                                        parolaT[parolaT.Length - 1] = parola[parola.Length - 1];
                                        indizi[2] = "";
                                        monete -= 5;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hai già utilizzato questo indizio");
                                    }
                                    
                                }
                                break;
                            default:
                                Console.WriteLine("hai sbagliato ad inserire");
                                break;
                        }
                    }
                    


                    break;
                case 3:
                    if (jolly > 0)
                    {
                        Console.WriteLine("Hai deciso di usare la lettera jolly");
                        bool ok = false;
                        while (ok == false)
                        {
                            int posizione = rnd.Next(1, parola.Length-1);
                            for (int i = 0; i < parola.Length; i++)
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
                     vita --;
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
            if (parole.Length == 0)
            {
                parole += parola;
            }
            else
            {
                parole += ", " + parola;
            }

        }
        else if (vita <= 0)
        {
            Console.WriteLine("Mi dispiace hai perso finendo le vite");
        }
    Console.WriteLine("La parola era " + parola);
}
void giocoEN(string parola, char[] parolaT, int vita, int monete, string tema,ref bool uscire,ref string parole)
{
    Random rnd = new Random();
    bool indovinato = false;
    string lettere = "";
    int jolly = 1;
    int n = 0;
    string[] indizi = { "Theme of the word (cost 15 coins)","First letter of the word (cost 10 coins)ù","Last letter of the word (cost 5 coins)" };
    while (vita > 0 && uscire == false && indovinato == false)
    {
        Console.Write("Your word is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < parola.Length; i++)
        {

            Console.Write(parolaT[i]);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The remaining lives: " + vita);
        Console.WriteLine("Your remaining wildcard letters: " + jolly);
        Console.WriteLine("Your remaining coins: " + monete);
        Console.WriteLine("The letters already entered are: " + lettere);
        Console.WriteLine("What would you like to do this turn?\n1. Say a letter\n2. Clue\n3. Wildcard letter\n4. Guess the word\n5. End");
        Console.Write("Tell me the number of your action: ");
        int azione = int.Parse(Console.ReadLine());

        switch (azione)
        {
            case 1:
                bool contiene = false, contienel = false;
                int contienetrat = 0;
                string pos = "";
                int cont = 0;
                contiene = false;
                cont = 0;
                contienel = false;
                contiene = false;
                contienetrat = 0;
                Console.Write("Tell me the letter you were thinking of: ");
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
                    if (lettere.Length == 0)
                    {
                        lettere += lettera;
                    }
                    else
                    {
                        lettere += ", " + lettera;
                    }
                    for (int i = 0; i < parola.Length; i++)
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
                    Console.Write("YOU GUESSED THE LETTER, YOUR WORD NOW IS: ");
                    for (int i = 0; i < parola.Length; i++)
                    {
                        Console.Write(parolaT[i]);
                    }
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("The letter you entered is not present in the word.");
                    if (lettere.Length == 0)
                    {
                        lettere += lettera;
                    }
                    else
                    {
                        for (int i = 0; i < lettere.Length; i++)
                        {
                            if (lettera[0] == lettere[i])
                            {
                                contienel = true;
                            }
                        }
                        if (contienel == true)
                        {
                            Console.WriteLine("You have already entered this letter.");
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
                int utilizzabili = 0;
                if (monete < 5)
                {
                    Console.WriteLine("Your coins are insufficient");
                }
                else
                {
                    Console.WriteLine("You have chosen a clue");
                    Console.WriteLine("The available clues are:");
                    for (int i = 0; i < indizi.Length; i++)
                    {
                        Console.WriteLine(i+1 + ". " + indizi[i]);
                    }
                    Console.WriteLine("Tell me the position of the clue");
                    int posi = int.Parse(Console.ReadLine());
                    switch (posi)
                    {
                        case 1:
                            utilizzabili = 15;
                            if (monete < utilizzabili)
                            {
                                Console.WriteLine("You don't have enough coins");
                            }
                            else
                            {
                                if (indizi[0] != "")
                                {
                                    Console.WriteLine("You have used the word's theme");
                                    Console.WriteLine("The theme of the word is: " + tema);
                                    indizi[0] = "";
                                    monete -= 15;
                                }
                                else
                                {
                                    Console.WriteLine("You have already used this clue");
                                }
                                
                            }
                            break;
                        case 2:
                            utilizzabili = 10;
                            if (monete < utilizzabili)
                            {
                                Console.WriteLine("You don't have enough coins");
                            }
                            else
                            {
                                if (indizi[1] != "")
                                {
                                    Console.WriteLine("You have used the first letter");
                                    parolaT[0] = parola[0];
                                    indizi[1] = "";
                                    monete -= 10;
                                }
                                else
                                {
                                    Console.WriteLine("You have already used this clue");
                                }

                            }
                            break;
                        case 3:
                            utilizzabili = 5;
                            if (monete < utilizzabili)
                            {
                                Console.WriteLine("You don't have enough coins");
                            }
                            else
                            {
                                if (indizi[2] != "")
                                {
                                    Console.WriteLine("You have used the last letter of the word");
                                    parolaT[parolaT.Length - 1] = parola[parola.Length - 1];
                                    indizi[2] = "";
                                    monete -= 5;
                                }
                                else
                                {
                                    Console.WriteLine("You have already used this clue");
                                }

                            }
                            break;
                        default:
                            Console.WriteLine("You have made a mistake in inserting");
                            break;
                    }
                }



                break;
            case 3:
                if (jolly > 0)
                {
                    Console.WriteLine("You have decided to use the wildcard letter");
                    bool ok = false;
                    while (ok == false)
                    {
                        int posizione = rnd.Next(1, parola.Length-1);
                        for (int i = 0; i < parola.Length; i++)
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
                    Console.WriteLine("You don't have any wildcard letters available");
                }
                break;
            case 4:
                Console.Write("Tell me this word: ");
                string p = Console.ReadLine();
                Console.WriteLine();
                if (p == parola)
                {
                    Console.WriteLine("YOU GUESSED IT");
                    indovinato = true;
                }
                else
                {
                    Console.WriteLine("You didn't get it right");
                    vita--;
                }
                break;
            case 5:
                Console.WriteLine("You decided to quit the game... poor");
                uscire = true;
                break;

        }
        Console.WriteLine();

    }
    if (indovinato == true)
    {
        Console.WriteLine("Congratulations, you guessed the word");
        if (parole.Length == 0)
        {
            parole += parola;
        }
        else
        {
            parole += ", " + parola;
        }
    }
    else if (vita<= 0)
    {
        Console.WriteLine("I'm sorry, you lost by running out of lives");
    }
    Console.WriteLine("The word was " + parola);
}
Random rnd = new Random();
string[,] nomi=new string[7,51];
string path,parola,tema="";
bool uscire = false;
int pos = 0,vita=0;
string parole = "";
Console.WriteLine("------------------------------GIOCO DELL'IMPICCATO------------------------------");
while (uscire == false)
{
    parola = "";
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Il gioco lo vuoi in italiano o in inglese (i o e) (se sbagli verrà scelto inglese)");
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
        parola = scelgoParola(nomi, ref tema);
    }
    else
    {
        parola = scelgoParolaEN(nomi, ref tema);
    }
    char[] parolaT = trasformo(parola);
    for (int i = 0; i < 2; i++)
    {
        pos = rnd.Next(1, parola.Length - 1);
        if (parolaT[pos] == '_')
        {
            parolaT[pos] = parola[pos];
        }
        else
        {
            i--;
        }


    }
    int monete = 0;
    if (risposta == "i")
    {
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("dimmi la difficoltà:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Facile (10 tentativi)(30 monete)");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("2. Medio (5 tentativi)(20 monete)");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3. Difficile (3 tentativi)(10 monete)");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("4. Impossibile (1 tentativo)(5 monete)");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("digita il numero corrispondente se sbagli verrà scelto facile");
        int risposta1 = int.Parse(Console.ReadLine());
        if (risposta1 == 2)
        {
            vita = 5;
            monete = 20;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("hai scelto Medio la tua vita è 5 e le tue monete sono 20");
        }
        else if (risposta1 == 3)
        {
            vita = 3;
            monete = 10;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("hai scelto Difficile la tua vita è 3 e le tue monete sono 10");
        }
        else if (risposta1 == 4)
        {
            vita = 1;
            monete = 5;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("hai scelto Impossibile la tua vita è 1 e le tue monete sono 5");

        }
        else
        {
            vita = 10;
            monete = 30;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("hai scelto Facile la tua vita è 10 e le tue monete sono 30");
        }
        Console.ForegroundColor = ConsoleColor.White;
        
        gioco(parola, parolaT, vita, monete, tema, ref uscire,ref  parole);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Choose the difficulty:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Easy(10 attempts)(30 coins)");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("2. Medium (5 attempts)(20 coins)");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3. Hard (3 attempts)(10 coins)");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("4. Impossible (1 attempt)(5 coins)");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Type the corresponding number, if you make a mistake, easy will be chosen.");
        int risposta1 = int.Parse(Console.ReadLine());
        if (risposta1 == 2)
        {
            vita = 5;
            monete = 20;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You chose Medium, your life is 5 and your coins are 20");
         
        }
        else if (risposta1 == 3)
        {
            vita = 3;
            monete = 10;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("You chose Hard, your life is 3 and your coins are 10");
            
        }
        else if (risposta1 == 4)
        {
            vita = 1;
            monete = 5;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("You chose Impossible, your life is 1 and your coins are 5");
            
        }
        else
        {
            vita = 10;
            monete = 30;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You chose Easy, your life is 10 and your coins are 30");
            
        }
        Console.ForegroundColor = ConsoleColor.White;
        
        giocoEN(parola, parolaT, vita, monete, tema, ref uscire, ref parole);
    }
    if (parole.Length == 0)
    {
        Console.WriteLine("Non hai indovinato parole fino ad ora");
    }
    else
    {
        Console.WriteLine("Le parole indovinate fino ad ora sono: " + parole);
    } 
}