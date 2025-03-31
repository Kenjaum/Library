using Library.Application.ViewModels;
using Library.Core.Repositories;
using Library.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository repository)
        {
            _authService = authService;
            this._repository = repository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //Se não existir, erro no login
            if (user == null)
            {
                return null;
            }

            //Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);

        }
    }
}
