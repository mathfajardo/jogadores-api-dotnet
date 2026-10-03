using System.Net.Http.Json;
using CommonTestUtilities.Requests;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests.User.Register;

public class RegistrarContaUsuarioTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpCliente;

    public RegistrarContaUsuarioTests(WebApplicationFactory<Program> factory)
    {
        _httpCliente = factory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        await _httpCliente.PostAsJsonAsync("/users", request);
    }
}
