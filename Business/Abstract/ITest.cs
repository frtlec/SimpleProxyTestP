using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITest
    {
        public List<string> GetAll(string testId);
        public void Add();
    }
}
