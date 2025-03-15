
void creoMatrice(string[,] NomiCompleti)
{
    string[] nomi1;
    string path = "nomi.txt";
    StreamReader r = new StreamReader(path);
    string nomi = r.ReadLine();
    int cont = 0;
    while (nomi != null)
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
    Console.WriteLine("Vuoi scegliere il tema della tua parola? (s o n) (se sbagli a digitare il computer sceglierà per te)");
    string risposta = Console.ReadLine();
    risposta=risposta.Trim().ToLower();
    int riga = 0,colonna=0;
    if (risposta =="s")
    {
        Console.WriteLine("dimmi il tema della tua parola (calcio, verbi, frutta e verdura, animali oppure nazioni) (se sbagli verrà scelto calcio)");
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
        riga=rnd.Next(0,5);
    }
    colonna=rnd.Next(1,52);
    parola = m[riga, colonna];
    return parola;
}

string[,] nomi=new string[5,51];
creoMatrice(nomi);
string parola=scelgoParola(nomi);
Console.WriteLine(parola);



