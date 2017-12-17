using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using XDogService.Models;

namespace XDogService.Controllers
{
    public class DogController : TableController<Dog>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DogContext context = new DogContext();
            DomainManager = new EntityDomainManager<Dog>(context, Request);
        }

        // GET tables/Dog
        public IQueryable<Dog> GetAllDog()
        {
            return Query(); 
        }

        // GET tables/Dog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Dog> GetDog(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Dog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Dog> PatchDog(string id, Delta<Dog> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Dog
        public async Task<IHttpActionResult> PostDog(Dog item)
        {
            Dog current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Dog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDog(string id)
        {
             return DeleteAsync(id);
        }
    }
}
