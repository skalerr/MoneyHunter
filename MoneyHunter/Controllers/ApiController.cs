using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.Implementations;
using MoneyHunter.Service.Services.ReasonService;
using MoneyHunter.Service.Services.UserService;
using MoneyHunter.Service.Services.ValidateService;

namespace MoneyHunter.Controllers
{
    public class ApiController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReasonService _reasonService;
        private readonly IValidateService _validateService;

        public ApiController(IUserService userService, IReasonService reasonService, IValidateService validateService)
        {
            _userService = userService;
            _reasonService = reasonService;
            _validateService = validateService;
        }
        public IActionResult AddUser(string chat_id)
        {
            var validate = _validateService.Validate(chat_id);
            if (!validate.Item1)
                return BadRequest(validate.Item2);
            
            var result =_userService.AddUser(chat_id);
            if (!result.Item1)
                return BadRequest(result.Item2);
            
            return Ok(result.Item2);
        }

        public IActionResult AddReason(string message, string chat_id)
        {
            var validate = _validateService.Validate(chat_id);
            if (!validate.Item1)
                return BadRequest(validate.Item2);

            var addReason = _reasonService.AddReason(chat_id: chat_id, message: message);
            
            if (!addReason.Item1)
                return BadRequest(addReason.Item2);
            
            return Ok(addReason.Item2);
        }
        
        public IActionResult SetReasonPrice(string message, string chat_id)
        {
            var validate = _validateService.Validate(chat_id);
            if (!validate.Item1)
                return BadRequest(validate.Item2);

            var addReason = _reasonService.AddReasonPrice(chat_id: chat_id, message: message);
            
            if (!addReason.Item1)
                return BadRequest(addReason.Item2);
            
            return Ok(addReason.Item2);
        }

        public IActionResult SelectReason(string message, string reason, string chat_id)
        {
            return Ok();
        }
    }
}