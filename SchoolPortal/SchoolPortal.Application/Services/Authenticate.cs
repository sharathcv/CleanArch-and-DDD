using Microsoft.IdentityModel.Tokens;
using SchoolPortal.Application.Responses;
using SchoolPortal.Domain.Entities.StudentAggregate;
using SchoolPortal.Domain.SeedWork;
using System.Security.Claims;

namespace SchoolPortal.Application.Services;

public class Authenticate
{
    readonly IGenericRepository<Student> _studentRepository;

    public Authenticate(IGenericRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IResponseData> CreateToken(string email, string password)
    {
        var student = await _studentRepository.GetAsync(s => s.Email.ToLower() == email.ToLower()
                                                        && s.Password.ToLower() == password.ToLower());
        
        if (student == null)
        {
            return new Error
            {
                Detail = "Invalid email or password.",
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, student.Id.ToString()),
            new Claim(ClaimTypes.Email, student.Email),
        };

        //return new Success {
        //    Detail = new
        //    {
        //        Token = GenerateToken(claims),
        //        StudentId = student.Id,
        //        Email = student.Email,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName
        //    },
        //    StatusCode = StatusCodes.Status200OK
        //};
    }
}
