using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using XDogService.Models;
using Microsoft.AspNet.Identity;
using System.Diagnostics;

namespace XDogService.Controllers
{
    public class DogController : TableController<Dog>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DomainManager = new EntityDomainManager<Dog>(new DogXContext(), Request);
        }

        // GET tables/Dog  
        public IQueryable<Dog> GetAllDog()
        {
            IQueryable<Dog> x = Query();
            Debug.WriteLine("Server Debugger: " + x.Count());
            return x; 
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
            //item.MainOwnerUserId = User.Identity.GetUserId();
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
