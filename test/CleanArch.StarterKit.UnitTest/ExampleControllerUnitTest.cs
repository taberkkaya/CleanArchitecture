using System.ComponentModel.DataAnnotations;
using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Domain.Dtos;
using CleanArch.StarterKit.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using Moq;

namespace CleanArch.StarterKit.UnitTest;

public class ExampleControllerUnitTest
{
    [Fact]
    public async void Create_ReturnOkResult_WhenRequestIsValid()
    {
        //Arrange
        var mediator = new Mock<IMediator>();
        CreateExampleCommand createExampleCommand = new("Test Example",1,true);
        MessageResponse response = new("Example created successfully");
        CancellationToken cancellationToken = new();
        mediator.Setup(m => m.Send(createExampleCommand, cancellationToken)).ReturnsAsync(response);
        ExamplesController exampleController = new(mediator.Object);
        
        //Act
        var result = await exampleController.Create(createExampleCommand, cancellationToken);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response.Message, returnValue.Message);
        mediator.Verify(m => m.Send(createExampleCommand, cancellationToken), Times.Once);
    }
}
