using AutoMapper;
using CadastroTeste.Entities;
using CadastroTeste.EntityFramework;
using CadastroTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.Controllers
{
    public class CadastroController : Controller
    {
        private UsuarioContext _appContext;
        private IMapper _mapper;
        public CadastroController(UsuarioContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        
        public IActionResult Index()
        {
            return View("Cadastro");
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _appContext.Add(usuario);
                _appContext.SaveChanges();
                return RedirectToAction("Index", "Listagem");
            }
            return View("Cadastro", _mapper.Map<UsuarioViewModel>(usuario));
        }
    }
}
