using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using XDogService.Models;
using Microsoft.AspNet.Identity;

namespace XDogService.Controllers
{
    public class DogOwnerController : TableController<DogOwner>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DogXContext context = new DogXContext();
            DomainManager = new EntityDomainManager<DogOwner>(context, Request);
        }

        // GET tables/DogOwner
        public IQueryable<DogOwner> GetAllDogOwner()
        {
            IQueryable<DogOwner> x = Query();
            return x; 
        }

        // GET tables/DogOwner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DogOwner> GetDogOwner(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DogOwner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DogOwner> PatchDogOwner(string id, Delta<DogOwner> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DogOwner
        public async Task<IHttpActionResult> PostDogOwner(DogOwner item)
        {
            DogOwner current = await InsertAsync(item);
            current.UserId = User.Identity.GetUserId() ?? "";
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DogOwner/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDogOwner(string id)
        {
             return DeleteAsync(id);
        }
    }
}
