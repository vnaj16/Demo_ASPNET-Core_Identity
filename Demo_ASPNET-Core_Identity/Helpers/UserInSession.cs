using Demo_ASPNET_Core_Identity.Data;
using System.Linq;
using System.Security.Claims;

namespace Demo_ASPNET_Core_Identity.Helpers
{
    public class UserInSession
    {
        public string Nombre { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
        private readonly ApplicationDbContext _applicationDbContext;

        public UserInSession(ClaimsPrincipal user, ApplicationDbContext applicationDbContext)
        {
            try
            {
                _applicationDbContext = applicationDbContext;
                var alumno = _applicationDbContext.Alumnos.Where(x => x.Codigo == user.Identity.Name).FirstOrDefault();
                Nombre = alumno.Nombre;
                Username = alumno.Codigo;
                Id = alumno.AlumnoId;
                Role = alumno.Tipo == "A" ? "Admin" : "Estudiante";
            }
            catch (System.Exception)
            {

            }

        }

        public bool IsAdmin()
        {
            if(Role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
