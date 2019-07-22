using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;


    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }


    // GET api/vaults
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        var userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetALL(userid));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/vaults/5
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        var userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetById(id, userid));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/keeps/user
    // [Authorize]
    // [HttpGet]
    // public ActionResult<IEnumerable<Vault>> GetVaultsFromCurrentUser()
    // {
    //   try
    //   {
    //     var id = HttpContext.User.FindFirstValue("Id");

    //     return Ok(_repo.GetVaultsFromCurrentUser(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    // POST api/keeps
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        value.userid = id;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/keeps/5
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      try
      {
        value.id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/keeps/5
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
