using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
using LinqKit;
namespace Infrastructure.Persistence.Repos
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public RouteRepository(GreenairContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Route>> getRouteByOriginAsync(string origin)
        {
            var predicate = PredicateBuilder.New<Route>();
            predicate = predicate.And(m => m.Origin.Equals(origin));
            return await this.FindAsync(predicate);

        }
        public async Task<IEnumerable<Route>> getRouteByDestinationAsync(string dest)
        {
            var predicate = PredicateBuilder.New<Route>();
            predicate = predicate.And(m => m.Destination.Equals(dest));
            return await this.FindAsync(predicate);
        }
        public async Task<bool> isExisted(Route route)
        {
            if (route == null) return false;
            return await this.isExisted(route.Origin, route.Destination);
        }
        public async Task<bool> isExisted(string origin, string dest)
        {
            var predicate = PredicateBuilder.New<Route>();
            predicate = predicate.And(m => m.Origin.Equals(origin) && m.Destination.Equals(dest));
            var res = await this.FindAsync(predicate);
            if (res == null || res.Count() == 0) return false;
            return true;
        }
    }
}