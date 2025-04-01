using AutoMapper;
using Library.Application.Commands.CreateBook;
using Library.Core.Entities;
using Library.Core.Repositories;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateBookCommandHandler _handler;

        public CreateBookCommandHandlerTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddBook_AndReturnGeneratedId()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "1234567890",
                PublicationYear = 2023
            };

            var book = new Book { Title = command.Title, Author = command.Author, ISBN = command.ISBN, PublicationYear = command.PublicationYear };

            _mockMapper.Setup(m => m.Map<Book>(command)).Returns(book);

            var generatedId = 1; // ID gerado pelo banco
            _mockRepository.Setup(r => r.AddAsync(book)).ReturnsAsync(generatedId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(generatedId, result);
            _mockRepository.Verify(r => r.AddAsync(book), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryFails()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "1234567890",
                PublicationYear = 2023
            };

            var book = new Book { Title = command.Title, Author = command.Author, ISBN = command.ISBN, PublicationYear = command.PublicationYear };

            _mockMapper.Setup(m => m.Map<Book>(command)).Returns(book);

            _mockRepository.Setup(r => r.AddAsync(book)).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            _mockRepository.Verify(r => r.AddAsync(book), Times.Once);
        }
    }
}
