using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data;
using UsuariosApi.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly SignInManager<UsuarioModel> _signInManager;
        private readonly TokenService _tokenService;

        public UsuarioService(IMapper mapper, 
            UserManager<UsuarioModel> userManager,
            SignInManager<UsuarioModel> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task Cadastro(CreateUsuarioDto dto)
        {
            UsuarioModel usuario = _mapper.Map<UsuarioModel>(dto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha no cadastro do usuário!");
            }
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager
                .PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha na autenticação do usuário!");
            }

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            return _tokenService.GenerateToken(usuario);
        }
    }
}
