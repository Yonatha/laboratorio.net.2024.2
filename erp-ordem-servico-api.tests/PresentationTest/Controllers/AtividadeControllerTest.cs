using LaboratorioDev.Dto.Atividade;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace erp_ordem_servico_api.tests.PresentationTest.Controllers
{
    [Collection("ErpDbContext")]
    public class AtividadeControllerTest
    {
        private readonly HttpClient _client;
        private readonly ErpWebApplicationFactory _application;
        private readonly DatabaseFixture _fixture;

        public AtividadeControllerTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _application = new ErpWebApplicationFactory();
            _client = _application.CreateDefaultClient();
        }

        [Fact]
        public async Task Post_ShouldReturnCreatedResult()
        {
            // Arrange
            var atividade = new AtividadeRequestDto
            {
                Descricao = "Atividade 2"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/atividade", atividade);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequestResult()
        {
            // Arrange
            var atividade = new AtividadeRequestDto();

            // Act
            var response = await _client.PostAsJsonAsync("/atividade", atividade);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var problemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>(responseBody);

            Assert.NotNull(problemDetails);
            Assert.True(problemDetails.Errors.ContainsKey("Descricao"));
            Assert.Contains("A descrição deve ser informada", problemDetails.Errors["Descricao"]);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResult()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/atividade/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/atividade");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_ShouldReturnOkResult()
        {
            // Arrange
            // Act
            var response = await _client.DeleteAsync("/atividade/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
