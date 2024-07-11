using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "help",
        documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help : IComando
    {
        private Dictionary<string, DocComando> _docs;

        public Help()
        {
            _docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task ExecutarAsync(string[] args)
        {
            ExibeDocumentacao(args);
            return Task.CompletedTask;
        }

        public void ExibeDocumentacao(string[] parametros)
        {
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");

                foreach (var doc in _docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (_docs.ContainsKey(comandoASerExibido))
                {
                    var comando = _docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);
                }
            }
        }
    }
}
