using SimpleProxy.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core4.Aspects.SampleProxy.CacheAspect
{
    public class RemoveCacheAttribute: MethodInterceptionAttribute
    {
        public string RemoveMethodName { get; set; }
    }
}
