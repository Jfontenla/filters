using System;
using System.Collections.Generic;
using System.Text;

namespace Koa.Platform.Ddd.Application.Constracts.Dtos
{
    public class KendoGridStateDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public CompositeFilterDescriptor Filter { get; set; }
        public int Sort { get; set; }
    }
}
