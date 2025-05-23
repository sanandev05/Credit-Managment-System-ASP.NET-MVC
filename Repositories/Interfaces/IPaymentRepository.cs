﻿using Credit_Managment_System_ASP.NET_MVC.Models;
namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllWithIncludeAsync();
        Task<Payment> GetByIdWithIncludeAsync(int id);
    }
}
