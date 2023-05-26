using LoginRegistration.Interfaces;
using LoginRegistration.Models;
using LoginRegistration.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace LoginRegistration.Services
{
      public class UserService
    {
        private IBaseRepo<string, User> _repo;
        private ITokenGenerate _tokenService;

        public UserService(IBaseRepo<string, User> repo, ITokenGenerate tokenGenerate)
        {
            _repo = repo;
            _tokenService = tokenGenerate;

        }
        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userdata = _repo.get(userDTO.Username);
            if (userdata != null)
            {
                var hmac = new HMACSHA512(userdata.Hashkey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userdata.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Username = userdata.Username;
                user.Role = userdata.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public UserDTO Register(UserRegisterDTO userDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            userDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.PasswordClear));
            userDTO.Hashkey = hmac.Key;
            var resultUser = _repo.add(userDTO);
            if (resultUser != null)
            {
                user = new UserDTO();
                user.Username = resultUser.Username;
                user.Role = resultUser.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}