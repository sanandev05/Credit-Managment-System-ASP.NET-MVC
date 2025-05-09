using Credit_Managment_System_ASP.NET_MVC.Data;
using Credit_Managment_System_ASP.NET_MVC.Models;
using Credit_Managment_System_ASP.NET_MVC.Repositories.Interfaces;

namespace Credit_Managment_System_ASP.NET_MVC.Repositories.Implementations
{
    public class LoanItemRepository : GenericRepository<LoanItem>,ILoanItemRepository  
    {
        public LoanItemRepository(AppDbContext _context): base(_context)
        {
                
        }

    }
}
