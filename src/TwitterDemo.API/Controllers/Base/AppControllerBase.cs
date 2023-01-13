using Microsoft.AspNetCore.Mvc;

namespace TwitterDemo.API.Controllers.Base
{
    public class AppControllerBase : ControllerBase
    {
        protected long GetAuthenticatedUserId()
        {
            // TODO: Change when implement authorization
            // Hard-coded because don't have authorization implemented            
            // Usually this information will come from the JWT token            
            return 1;
        }
    }
}
