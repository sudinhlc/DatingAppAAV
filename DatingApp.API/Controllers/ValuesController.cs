using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // attributes
    [Authorize]
    [Route("api/[controller]")]// thuộc tính Route chỉ mặc định đường dẫn đến api/controller
    [ApiController]// thuộc tính này kế thừa một số tính năng controller 
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/valuesss
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }
        [AllowAnonymous] // hàm Getvalues này sẽ dùng thử Authorize với thuộc tính Attributes này
        // đối với các hàm nào mà sử dụng attributes này thì đều phải thông qua token mới thực hiện được
        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
        [AllowAnonymous]

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        // POST api/values/5
        [HttpPost("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}