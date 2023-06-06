using FourPointImport.Data;
using FourPointImport.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class IController<TEntity> : ControllerBase
        where TEntity : class, IImport, new()
    {
        protected readonly IGenericService<TEntity> _service;
        protected IController([NotNull] IGenericService<TEntity> service)
        {
            _service = service;
        }
    }
}
