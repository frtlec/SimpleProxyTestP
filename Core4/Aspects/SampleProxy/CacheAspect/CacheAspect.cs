using Microsoft.Extensions.Caching.Memory;
using SimpleProxy;
using SimpleProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core4.Aspects.SampleProxy.CacheAspect
{
    public class CacheAspect : IMethodInterceptor
    {
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// Initialises a new instance of the <see cref="CacheInterceptor"/>
        /// </summary>
        public CacheAspect(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public void BeforeInvoke(InvocationContext invocationContext)
        {

            // Check the Memory Cache for a cached value for this method
            this.memoryCache.TryGetValue(invocationContext.GetExecutingMethodName(), out var result);

            var x = invocationContext.GetExecutingMethodInfo();
            var logParamters = x.GetParameters();
            var get = invocationContext.GetParameterValue(0);

            // If a cached value is found; replace the method return value and dont execute
            // the real underlying method
            if (result != null)
            {
                invocationContext.OverrideMethodReturnValue(result);
                invocationContext.BypassInvocation();
            }
        }

        public void AfterInvoke(InvocationContext invocationContext, object methodResult)
        {

           
            // Save the result to the MemoryCahe with an expiration time if availble
            if (invocationContext.GetAttributeFromMethod<CacheAttribute>() != null
                && invocationContext.GetAttributeFromMethod<CacheAttribute>().MillisecondsToExpire > 0)
            {
                this.memoryCache.Set(invocationContext.GetExecutingMethodName(), methodResult, TimeSpan.FromMilliseconds(invocationContext.GetAttributeFromMethod<CacheAttribute>().MillisecondsToExpire));
            }
            else
            {
                // Save the result to the MemoryCache without any expiration time
                this.memoryCache.Set(invocationContext.GetExecutingMethodName(), methodResult);
            }
        }

      
    }
}
