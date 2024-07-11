using System.Net.Http.Headers;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "list",
        documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List : IComando
    {
        HttpClientPet clientPet;

        public List()
        {
            clientPet = new HttpClientPet();
        }

        public async Task ExecutarAsync(string[] args)
        {
            await ListaDadosPetsDaAPIAsync();
        }

        public async Task ListaDadosPetsDaAPIAsync()
        {
            IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
