using Application.Interfaces.Repositories.General;
using Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.General
{
    public class AttachmentRepository:BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(HiringDbContext dbContext) : base(dbContext)
        {

        }
    }
}
