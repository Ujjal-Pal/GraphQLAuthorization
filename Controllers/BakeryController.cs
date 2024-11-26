using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQLAuthorization.Middleware;
using Microsoft.AspNetCore.Authorization;

namespace GraphQLAuthorization.Controllers
{
    public class BakeryController : GraphController
    {
        [QueryRoot("donut")]
        [CustomAuthorize("Admin")]
        //[RoleAuthorize("Admin")]
        //[Authorize(Policy = "Admin")]
        public Donut RetrieveDonut()
        {
            return new Donut()
            {
                Id = 3,
                Name = "Snowy Dream",
                Flavor = "Vanilla"
            };
        }

        [QueryRoot("cake")]
        [CustomAuthorize("User")]
        //[RoleAuthorize("User")]
        //[Authorize(Policy = "User")]
        public Cake RetrieveCake()
        {
            return new Cake()
            {
                Id = 1,
                Name = "Chocolate Delight",
                Flavor = "Chocolate"
            };
        }
    }

    public class Donut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
    }

    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
    }
}
