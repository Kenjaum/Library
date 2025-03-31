using MediatR;

namespace Library.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; set; }
    }
}