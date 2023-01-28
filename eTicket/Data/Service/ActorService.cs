using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Service
{
    public class ActorService:EntityBaseRepositoty<Actor>, IActorService
    {
        public ActorService(AppDbContext Context):base(Context)
        {

        }
    }
}
