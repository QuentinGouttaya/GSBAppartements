using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;



using GSBAppartement.Domain.Appartement;

namespace GSBAppartement.Repository.Interfaces
{
    public interface IAppartementRepository
    {
        Task<IEnumerable<Appartement>> GetAllAsync();
        Task<Appartement> GetByIdAsync(Guid id);
        Task<Appartement> AddAsync(Appartement appartement);
        Task<Appartement> UpdateAsync(Appartement appartement);
        Task<Appartement> DeleteAsync(Guid id);
    }
}