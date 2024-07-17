using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserPhotoAdd.DTOs;
using UserPhotoAdd.Infrastructure;
using UserPhotoAdd.Model;

namespace UserPhotoAdd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
           _context=context;
        }
        [HttpPost]

        public async Task<IActionResult> UserRegistration([FromForm] UserDto UserDto)
        { 
            if (ModelState.IsValid)
            {

                if (UserDto.UserPhoto == null || UserDto.UserPhoto.Length == 0)
                    return Content("File not selected");

                // Путь, куда будет сохранен файл
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UserDto.UserPhoto.Name);

                // Создаем директорию, если её нет
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                // Сохраняем файл
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await UserDto.UserPhoto.CopyToAsync(stream);
                }
    

            var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = UserDto.Name,
                    Email = UserDto.Email,
                    Password = UserDto.Password,
                    UserPhoto = path,
                    UserPhotoId = Guid.NewGuid()
                };
                 _context.Users.Add(user);
               await _context.SaveChangesAsync();
            }
            return Ok();
        
        }
    }
}
