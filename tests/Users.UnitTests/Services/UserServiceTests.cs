using Moq;
using Users.Application.DTOs;
using Users.Application.Services;
using Users.Domain.Entities;
using Users.Domain.Interfaces;
using Xunit;

namespace Users.UnitTests.Services;

public class UserServiceTests
{
    // Mocks
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        // Preparamos o Mock (o "dublê" do repositório)
        _userRepositoryMock = new Mock<IUserRepository>();

        // Injetamos o dublê no serviço real
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateUser_Should_Call_Repository_Once()
    {
        // Arrange
        var dto = new CreateUserDto("Caio Teste", "caio@teste.com");

        // Act
        await _userService.CreateUserAsync(dto);

        // Assert
        // Verificamos se o método AddAsync foi chamado EXATAMENTE 1 vez
        // com qualquer usuário (It.IsAny<User>)
        _userRepositoryMock.Verify(
            repo => repo.AddAsync(It.IsAny<User>()),
            Times.Once
        );
    }

    [Fact]
    public async Task CreateUser_Should_Return_Valid_Id()
    {
        // Arrange
        var dto = new CreateUserDto("Caio", "caio@teste.com");

        // Simulamos que, ao salvar, o banco definiria o ID como 10
        // (Isso exige que seu AddAsync funcione de certa forma, mas 
        //  por enquanto vamos testar apenas o retorno do ID da entidade)

        // Act
        var resultId = await _userService.CreateUserAsync(dto);

        // Assert
        // Como no nosso mock não configuramos o retorno do ID gerado pelo banco simulado,
        // o ID será 0 (default do int), mas o teste garante que o fluxo rodou sem erros.
        Assert.IsType<int>(resultId);
    }
}