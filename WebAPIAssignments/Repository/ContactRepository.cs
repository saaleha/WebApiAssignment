using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebAPIAssignments.Interfaces;
using WebAPIAssignments.Models;
using System.Data.Entity;

namespace WebAPIAssignments.Repository
{
    public class ContactRepository:IContactRepository
    {
        public async Task<List<RegistrationDetail>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var contactDetails = new MyDbContext())
            {
                return await contactDetails.RegistrationDetails.ToListAsync(cancellationToken);
            }
        }
        public async Task CreateAsync(RegistrationDetail model, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var contactDetails = new MyDbContext())
            {
                contactDetails.RegistrationDetails.Add(model);
                await contactDetails.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using(var contactdelete=new MyDbContext())
            {
                var FindId = await contactdelete.RegistrationDetails.FindAsync(cancellationToken, id);
                contactdelete.RegistrationDetails.Remove(FindId);
                await contactdelete.SaveChangesAsync(cancellationToken);

            }
        }
    }
}