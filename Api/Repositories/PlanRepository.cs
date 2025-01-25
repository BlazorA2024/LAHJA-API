using Data;
using Dto.Plan;
using Dto.PlanServices;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public interface IPlanRepository : IBaseRepository<Plan>
    {
        Task<IEnumerable<object>> GetAllAsGroupAsync();
        void EventOccured(Plan plan, int number);

    }
    public class PlanRepository(DataContext db) : BaseRepository<Plan>(db), IPlanRepository
    {
        public async Task<IEnumerable<object>> GetAllAsGroupAsync()
        {
            //var s= await db.Database.SqlQuery <PlanResponse> (@$"select ").ToListAsync();

            return await _dbSet.GroupBy(x => x.ProductName).Select(p => new
            {
                ProductName = p.Key,
                Plans = p.Select(static o => new PlanGrouping
                {
                    ProductId = o.Id,
                //#    BillingPeriod = o.BillingPeriod,
                    Amount = o.Amount,
                    Active = o.Active,
                    Services = o.PlanServices.Select(ps => new PlanServicesResponse
                    {
                        ServiceId = ps.ServiceId,
                        Name = ps.Service.Name,
                        Token = ps.Service.Token,
                        Processor = ps.Processor,
                        ConnectionType = ps.ConnectionType,
                        NumberRequests = ps.NumberRequests
                    }).ToList(),

                }).ToList()
            }).ToListAsync();

        }

        public void EventOccured(Plan plan, int number)
        {
            //plan.NumberRequests = number;
        }
    }
}