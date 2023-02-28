using Microsoft.AspNetCore.Mvc;

namespace LCPOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationSingleton _operationSingleton;

        public TestController(IOperationScoped operationScoped,
            IOperationTransient operationTransient,
            IOperationSingleton operationSingleton)
        {
            _operationScoped = operationScoped;
            _operationTransient = operationTransient;
            _operationSingleton = operationSingleton;
        }

        [HttpGet("TestLifeCycle")]
        public IActionResult GetFromConstructor(
            [FromServices] IOperationScoped operationScoped,
            [FromServices] IOperationTransient operationTransient,
            [FromServices] IOperationSingleton operationSingleton)
        {
            return Ok(new
            {
                    //Injetado via construtor
                    Scoped = _operationScoped.Id,
                    Transient = _operationTransient.Id,
                    Singleton = _operationSingleton.Id,
                    
                    //Injetado via services
                    ScopedTwo = operationScoped.Id,
                    TransientTwo = operationTransient.Id,
                    SingletonTwo = operationSingleton.Id,
            });
        }
    }
}