﻿using Credit_Managment_System_ASP.NET_MVC.Models;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<Branch> GetByIdWithInclude(int id);
        Task<IEnumerable<Branch>> GetAllWithInclude();
    }
}
