﻿using Credit_Managment_System_ASP.NET_MVC.Models;
namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithInclude();
        Task<Customer> GetByIdWithInclude(int id);

    }
}
