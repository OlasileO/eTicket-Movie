using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Service
{
    public class ProducerService:EntityBaseRepositoty<Producer>,IProducerService
    {
        public ProducerService(AppDbContext context):base(context)
        {

        }
    }
}
