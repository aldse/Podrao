using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BACK.Controllers;

using System.Security.Cryptography;
using DTO;
using Model;
using Services;

using Trevisharp.Security.Jwt;

[ApiController]
[Route("user")]

public class UserController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]UserData user,
        [FromServices]IClienteservice service,
        [FromServices]ISecurityService security,
        [FromServices]CryptoService crypto)
    {
        System.Console.WriteLine(user.Login);
        System.Console.WriteLine(user.Password);
        var loggedUser = await service
            .GetByLogin(user.Login);
        System.Console.WriteLine(loggedUser);
        
        if (loggedUser == null)
            return Unauthorized("Usuário não existe.");
        
        var password = await security.HashPassword(
            user.Password, loggedUser.Salt
        );
        System.Console.WriteLine(password);
        var realPassword = loggedUser.Senha;
        if (password != realPassword)
            return Unauthorized("Senha incorreta.");
        
        var jwt = crypto.GetToken(new {
            id = loggedUser.Id,
            nome = loggedUser.Nome,
            email = loggedUser.Email,
            cpf = loggedUser.Cpf,
            senha = loggedUser.Senha,
        });

        // var jwt = await security.GenerateJwt(new {
        //     id = loggedUser.Id,
        //     photoId = loggedUser.ImagemId
        // });

        return Ok(new { jwt });
    }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]UserDataRegister user,
        [FromServices]IClienteservice service)
    {
        var errors = new List<string>();
        if (user is null || user.Login is null)
            errors.Add("É necessário informar um login.");
        if (user.Login.Length < 11)
            errors.Add("O Login deve conter ao menos 11 caracteres.");

        if (errors.Count > 0)
            return BadRequest(errors);

        await service.Create(user);
        return Ok();
    }

    [HttpDelete]
    [EnableCors("DefaultPolicy")]
    public IActionResult DeleteUser()
    {
        throw new NotImplementedException();
    }

    [HttpGet("image")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> GetImage(
        int photoId,
        [FromServices]ISecurityService security,
        [FromServices]PodraoBcContext ctx)
    {
        var query =
            from image in ctx.Imagems
            where image.Id == photoId
            select image;
        
        var photo = await query.FirstOrDefaultAsync();
        if (photo is null)
            return NotFound();

        return File(photo.Foto, "image/jpeg");
    }

    [DisableRequestSizeLimit]
    [HttpPut("image")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> AddImage(
        [FromServices]ISecurityService security
    )
    {
        var jwtData = Request.Form["jwt"];
        var jwtObj = JsonSerializer
            .Deserialize<JwtToken>(jwtData);
        var jwt = jwtObj.jwt;

        var userOjb = await security
            .ValidateJwt<JwtPayload>(jwt);
        if (userOjb is null)
            return Unauthorized();
        var userId = userOjb.id;

        var files = Request.Form.Files;
        if (files is null || files.Count == 0)
            return BadRequest();
        
        var file = Request.Form.Files[0];
        if (file.Length < 1)
            return BadRequest();
 
        using MemoryStream ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var data = ms.GetBuffer();

        Imagem img = new Imagem();
        img.Foto = data;

        PodraoBcContext ctx = new PodraoBcContext();
        ctx.Add(img);
        await ctx.SaveChangesAsync();
        
        var query =
            from user in ctx.Clientes
            where user.Id == userId
            select user;
        var loggedUser = query.FirstOrDefault();
        loggedUser.ImagemId = img.Id;

        await ctx.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("image")]
    [EnableCors("DefaultPolicy")]
    public IActionResult RemoveImage()
    {
        throw new NotImplementedException();
    }
}