using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository1;

    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        this._userRepository1 = userRepository;
        this. _mapper = mapper;
    }

    [HttpGet("{username}")] //api/users/1
    public async Task<ActionResult<CustomerDto>> GetUser(string username)
    {
        return await _userRepository1.GetCustomerAsync(username);
    }

    [HttpPut]
    public  async Task<ActionResult> UpdateUser(CustomerUpdateDto customerUpdateDto)
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userRepository1.GetUserByUsernameAsync(username);

        if(user == null) return NotFound();

        _mapper.Map(customerUpdateDto, user);

        if(await _userRepository1.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update user");
    }
      
}
