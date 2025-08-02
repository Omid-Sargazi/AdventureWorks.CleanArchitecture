using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using MediatR;

namespace AdventureWorks.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthService _auth;
        public LoginCommandHandler(IAuthService auth)
        {
            _auth = auth;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request.Username == "admin" && request.Password == "1234")
            {
                var user = new UserDto
                {
                    Username = "admin",
                    Role = "Administrator"
                };
                return _auth.GenerateToken(user);
            }

            throw new UnauthorizedAccessException("Invalid credentials");
        }

        

    }

}