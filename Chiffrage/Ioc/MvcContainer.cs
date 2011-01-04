﻿using Chiffrage.App.Controllers;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Spring.Aop.Framework.AutoProxy;
using Spring.Objects.Factory.Config;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Ioc
{
    public class MvcContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            Define<EventBroker>()
                .AutoWire(AutoWiringMode.ByType)
                .AsSingleton();

            Define<EventHandlersFactory>()
                .AsSingleton();
            
            Define<ApplicationController>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<CatalogController>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<DealController>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<ApplicationItemUserControl>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<CatalogUserControl>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<DealUserControl>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();

            Define<FormContainer>()
                .AutoWire(AutoWiringMode.Constructor)
                .AsSingleton();
        }
    }
}