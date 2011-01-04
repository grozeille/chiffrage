using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Spring.Aop.Framework.AutoProxy;
using Spring.Aop.Support;

namespace Chiffrage.Mvc.Views
{
    public class BeginInvokeAdvisor : AttributeMatchMethodPointcutAdvisor 
    {
        public BeginInvokeAdvisor()
        {
            this.Advice = new BeginInvokeMethodInterceptor();
            this.Attribute = typeof (BeginInvokeAttribute);
        }
    }
}
