using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Repository.Interfaces;

namespace GSBAppartement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppartementController : ControllerBase
    {
        private readonly IAppartementRepository _appartementRepository;

        public AppartementController(IAppartementRepository appartementRepository)
        {
            _appartementRepository = appartementRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Appartement>> GetAll()
        {
            return await _appartementRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appartement>> GetById(Guid id)
        {
            var appartement = await _appartementRepository.GetByIdAsync(id);

            if (appartement == null)
            {
                return NotFound();
            }

            return appartement;
        }

    }
}
