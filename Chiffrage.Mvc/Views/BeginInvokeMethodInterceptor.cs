using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AopAlliance.Intercept;

namespace Chiffrage.Mvc.Views
{
    public class BeginInvokeMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if(invocation.Target is Control)
            {
                var func = new Func<object>(invocation.Proceed);
                var asyncResult = ((Control) invocation.Target).BeginInvoke(func);
                return ((Control) invocation.Target).EndInvoke(asyncResult);
            }
            else
            {
                return invocation.Proceed();
            }
        }
    }
}
