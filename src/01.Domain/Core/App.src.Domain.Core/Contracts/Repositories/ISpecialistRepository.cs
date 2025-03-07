using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ISpecialistRepository
    {
        Task<Result> Create(int userId, string resume, CancellationToken cancellationToken);
        Task<int> GetTotalCount(CancellationToken cancellationToken);
    }
}
