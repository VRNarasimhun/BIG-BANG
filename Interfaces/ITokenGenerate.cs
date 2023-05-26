using LoginRegistration.Models.DTO;

namespace LoginRegistration.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
