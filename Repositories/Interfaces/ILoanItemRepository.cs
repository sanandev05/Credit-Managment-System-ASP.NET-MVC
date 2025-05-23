﻿using Credit_Managment_System_ASP.NET_MVC.Models;
namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface ILoanItemRepository : IGenericRepository<LoanItem>
    {
        Task<IEnumerable<LoanItem>> GetAllWithIncludeAsync();
        Task<LoanItem> GetByIdWithIncludeAsync(int id);
    }
}
