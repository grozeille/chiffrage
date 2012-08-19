using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Chiffrage.Catalogs.Module.Controllers;
using Chiffrage.Catalogs.Domain.Services;
using Chiffrage.Mvc.Services;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Ioc
{
    public class ModuleBootstrap : IStartable
    {
        public IEnumerable<IController> Controllers { get; set; }

        public IEnumerable<IService> Services { get; set; }

        public IEnumerable<IView> Views { get; set; }

        public void Start()
        {
        }
    }
}
