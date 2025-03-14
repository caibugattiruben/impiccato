

void creoMatrice(string[,] NomiCompleti)
{
    string[] nomi1;
    string path = "nomi.txt";
    StreamReader r = new StreamReader(path);
    string nomi = r.ReadLine();
    int cont = 0;
    while (nomi != "")
    {
        nomi1 = nomi.Split(',');
        for (int i = 0; i < NomiCompleti.GetLength(1); i++)
        {
            NomiCompleti[cont,i]=nomi1[i];
        }
        cont++;
        nomi = r.ReadLine();
    }
}
string[,] nomi=new string[5,51];
creoMatrice(nomi);
for (int i = 0; i < nomi.GetLength(0); i++)
{
    for (int j = 0; j < nomi.GetLength(1); j++)
    {
        Console.Write(nomi[i,j]);
    }
    Console.WriteLine();
}


