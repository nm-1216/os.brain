using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Os.Brain.Models;

namespace Os.Brain.WCF.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        #region FromServices
        [FromServices]
        private UserManager<User> _userManager { get; set; }

        [FromServices]
        private RoleManager<Role> _roleManager { get; set; }
        #endregion

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.Users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            var model = await _userManager.FindByIdAsync(id.Limit(36));

            if (null == model)
                throw new NullReferenceException("User can't found!");

            return model;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IdentityResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            var model = await _userManager.FindByIdAsync(id);

            if (null == model)
                throw new NullReferenceException("User can't found!");

            return await _userManager.DeleteAsync(model);
        }
    }
}
