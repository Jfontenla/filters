using System.Collections.Generic;

namespace Koa.Platform.Ddd.Application.Constracts.Dtos
{ 
    public class CompositeFilterDescriptor
    {

        public List<FilterDescriptor> Filters { get; set; }
       
        public string Logic { get; set; }
    }
}
