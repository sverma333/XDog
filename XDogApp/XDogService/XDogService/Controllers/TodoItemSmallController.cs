using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using XDogService.Models;

namespace XDogService.Controllers
{
    public class TodoItemSmallController : TableController<TodoItemSmall>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TodoItemSmallContext context = new TodoItemSmallContext();
            DomainManager = new EntityDomainManager<TodoItemSmall>(context, Request);
        }

        // GET tables/TodoItemSmall
        public IQueryable<TodoItemSmall> GetAllTodoItemSmall()
        {
            return Query(); 
        }

        // GET tables/TodoItemSmall/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TodoItemSmall> GetTodoItemSmall(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItemSmall/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TodoItemSmall> PatchTodoItemSmall(string id, Delta<TodoItemSmall> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TodoItemSmall
        public async Task<IHttpActionResult> PostTodoItemSmall(TodoItemSmall item)
        {
            TodoItemSmall current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItemSmall/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItemSmall(string id)
        {
             return DeleteAsync(id);
        }
    }
}
