using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    internal class Import : IComando
    {
        HttpClientPet clientPet;

        public Import()
        {
            clientPet = new HttpClientPet();
        }

        public async Task ExecutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            System.Console.WriteLine("----- Dados importados -----");

            var leitorDeArquivo = new LeitorDeArquivo();
            var listaDePets = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoDeImportacao);

            foreach (var pet in listaDePets)
            {
                System.Console.WriteLine(pet);

                try
                {
                    var resposta = await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
