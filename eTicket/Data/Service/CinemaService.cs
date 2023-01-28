using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Service
{
    public class CinemaService:EntityBaseRepositoty<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext context):base(context)
        {

        }
    }
}
