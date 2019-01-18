using Microsoft.AspNetCore.Mvc;
using Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        
        [HttpGet("profile")]
        public ActionResult UserInfo()
        {
            var user = _unitOfWork.Users.Get(UserHelper.GetCurrentUserId(User));
            return Ok(user);
            
        }

    }
}
