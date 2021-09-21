using AutoMapper;
using CadastroTeste.Entities;
using CadastroTeste.EntityFramework;
using CadastroTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.Controllers
{
    [Route("[controller]")]
    public class EdicaoController : Controller
    {
        private UsuarioContext _appContext;
        private IMapper _mapper;

        public EdicaoController(UsuarioContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        [HttpGet("usuario/{id:int}")]
        public IActionResult CarregarUsuario([FromRoute] int id)
        {
            UsuarioViewModel usuario = _mapper.Map<UsuarioViewModel>(_appContext.Usuarios.Single(usuario => usuario.Id == id));
            return View("Edicao", usuario);
        }

        [HttpPost("usuario/{id:int}")]
        public IActionResult EditarUsuario([FromRoute] int id, UsuarioViewModel usuarioForm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _appContext.Usuarios.Single(usuario => usuario.Id == id);
                Usuario usuarioMapeado = _mapper.Map<Usuario>(usuarioForm);
                _appContext.Entry(usuario).CurrentValues.SetValues(usuarioMapeado);

                _appContext.SaveChanges();
                return RedirectToAction("Index", "Listagem");
            }
            
            return RedirectToAction("EditarUsuario", "Edicao", usuarioForm);
        }
    }
}
