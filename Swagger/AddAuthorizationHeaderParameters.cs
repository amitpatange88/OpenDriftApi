using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle;
using Swashbuckle.Swagger;

namespace OpenDriftApi.Swagger
{
    /// <summary>
    /// This will add extra header params in Swagger.
    /// </summary>
    public class AddAuthorizationHeaderParameters : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            //if (operation.parameters != null) bearer
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}