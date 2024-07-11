using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes;

public class HttpClientPetTest
{
    [Fact]
    public async void ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        // Arrange
        var clientPet = new HttpClientPet();

        // Act
        var lista = await clientPet.ListPetsAsync();

        // Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async void QuandoAPIForaDeveRetornarUmaExcecao()
    {
        // Arrange
        var clientPet = new HttpClientPet(uri: "http://localhost:1111");

        // Act + Assert
        await Assert.ThrowsAnyAsync<Exception>(() => clientPet.ListPetsAsync());
    }
}