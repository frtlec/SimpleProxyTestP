using Business.Abstract;
using Core4.Aspects.SampleProxy.CacheAspect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Test : ITest
    {
        [RemoveCache(RemoveMethodName = "GetAll")]
        public void Add()
        {
           
        }


        [Cache(MillisecondsToExpire = 10800)]
        public List<string> GetAll(string testId)
        {
          
            return new List<string>
            {
                "asdadsad","csacsa"
            };
        }
    }
}
