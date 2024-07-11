using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        var listaDePets = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            while (!sr.EndOfStream)
            {
                listaDePets.Add(sr.ReadLine().ConverteDoTexto());
            }
        }

        return listaDePets;
    }
}
