using Microsoft.Extensions.Caching.Memory;
using SimpleProxy;
using SimpleProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core4.Aspects.SampleProxy.CacheAspect
{
    public class RemoveCacheAspect : IMethodInterceptor
    {
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// Initialises a new instance of the <see cref="CacheInterceptor"/>
        /// </summary>
        public RemoveCacheAspect(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public void BeforeInvoke(InvocationContext invocationContext)
        {
            
        }
       
        public void AfterInvoke(InvocationContext invocationContext, object methodResult)
        {
            var attr = invocationContext.GetAttributeFromMethod<RemoveCacheAttribute>();
            this.memoryCache.Remove(attr.RemoveMethodName);
        }

       
    }
}
