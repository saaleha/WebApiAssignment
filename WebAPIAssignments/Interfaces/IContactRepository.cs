using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebAPIAssignments.Models;

namespace WebAPIAssignments.Interfaces
{
    public interface IContactRepository
    {
        Task<List<RegistrationDetail>> GetAllAsync(CancellationToken cancellationtolen = default(CancellationToken));
        Task CreateAsync(RegistrationDetail contect, CancellationToken cancellationtolen = default(CancellationToken));
        Task DeleteAsync(int id, CancellationToken cancellationtolen = default(CancellationToken));
    }
}