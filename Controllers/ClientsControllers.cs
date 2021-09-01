using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FistApi.Models;

using Microsoft.AspNetCore.Authorization;
using ApiCom.Models;

namespace ApiCom.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController  : SuperController<Client>
    {
        public ClientsController(ApiComContext context): base(context) { }
    }
}
