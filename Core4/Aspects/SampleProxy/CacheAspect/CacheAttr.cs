using SimpleProxy.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core4.Aspects.SampleProxy.CacheAspect
{
    public class CacheAttribute: MethodInterceptionAttribute
    {
        public int MillisecondsToExpire { get; set; }
    }
}
