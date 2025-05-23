﻿using AutoMapper;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.Services.Interfaces;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employee, IMapper mapper)
        {
            _repo = employee;
            _mapper = mapper;
        }
        public async Task<EmployeeVM> AddAsync(EmployeeVM entity)
        {
            if (entity == null)
            {
                return null;
            }

            var employee = new Employee
            {
                BranchId = entity.BranchId,
                LoansCreated = _mapper.Map<ICollection<Loan>>(entity.LoansCreatedVMs),
                PhoneNumber = entity.PhoneNumber,
                Surname = entity.Surname,
                Name = entity.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _repo.AddAsync(employee);
            return _mapper.Map<EmployeeVM>(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getData = _repo.GetByIdWithInclude(id);
            if (getData == null)
            {
                return false;
            }
           await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<EmployeeVM>> GetAllAsync()
        {
            var employees = await _repo.GetAllWithInclude();
            return _mapper.Map<IEnumerable<EmployeeVM>>(employees);
        }

        public async Task<EmployeeVM> GetByIdAsync(int id)
        {
            var employee = await _repo.GetByIdWithInclude(id);
            if (employee == null)
            {
                return null;
            }
            var data = new EmployeeVM()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                PhoneNumber = employee.PhoneNumber,
                BranchId = employee.BranchId,
                Branch = _mapper.Map<BranchVM>(employee.Branch),
                LoansCreatedVMs = _mapper.Map<ICollection<LoanVM>>(employee.LoansCreated),
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt,
            };
            return data;
        }

        public async Task UpdateAsync(EmployeeVM entity)
        {
            var getData = await _repo.GetByIdAsync(entity.Id);
            getData.Surname = entity.Surname;
            getData.PhoneNumber = entity.PhoneNumber;
            getData.BranchId = entity.BranchId;
            getData.Branch= _mapper.Map<Branch>(entity.Branch);
            getData.CreatedAt = entity.CreatedAt;
            getData.UpdatedAt = entity.UpdatedAt;
            getData.LoansCreated = _mapper.Map<ICollection<Loan>>(entity.LoansCreatedVMs);
            await _repo.UpdateAsync(getData);
        }

      
    }
}
