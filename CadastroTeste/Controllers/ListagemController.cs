using AutoMapper;
using CadastroTeste.EntityFramework;
using CadastroTeste.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.Controllers
{
    public class ListagemController : Controller
    {
        private UsuarioContext _appContext;
        private IMapper _mapper;
        
        public ListagemController(UsuarioContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<UsuarioViewModel> usuarios = _mapper.Map<List<UsuarioViewModel>>(_appContext.Usuarios.ToList());
            return View("Listagem", usuarios);
        }

    }
}
