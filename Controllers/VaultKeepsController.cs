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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;


    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }


    // GET api/vaultkeeps/:vaultId
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {
        var userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetALL(userid, id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/keeps
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep value)
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Create(value, id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/keeps/5
    // [Authorize]
    // [HttpPut("{id}")]
    // public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    // {
    //   try
    //   {
    //     value.id = id;
    //     return Ok(_repo.Update(value));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    // DELETE api/keeps/5
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<String> DeleteVaultKeep([FromBody] VaultKeep value)
    {
      try
      {
        var vaultId = value.vaultId;
        var keepId = value.keepId;
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.DeleteVaultKeep(vaultId, keepId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
