using Users.Domain.Entities;

namespace Users.UnitTests.Domain;

public class UserEntityTests
{
    [Fact] // [Fact] significa que é um teste único e direto
    public void Should_Create_User_When_Data_Is_Valid()
    {
        // Arrange (Preparação)
        var name = "Caio";
        var email = "caio@teste.com";

        // Act (Ação)
        var user = new User(name, email);

        // Assert (Verificação)
        Assert.NotNull(user);
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
    }

    [Theory] // [Theory] permite testar vários cenários com o mesmo código
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void Should_Throw_Exception_When_Name_Is_Invalid(string invalidName)
    {
        // Act & Assert
        // Verifica se o código lança um erro ao tentar criar usuário sem nome
        Assert.Throws<ArgumentException>(() => new User(invalidName, "email@teste.com"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Should_Throw_Exception_When_Email_Is_Invalid(string invalidEmail)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new User("Caio", invalidEmail));
    }
}
