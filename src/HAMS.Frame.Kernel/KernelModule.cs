﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using HAMS.Frame.Kernel.Core;

namespace HAMS.Frame.Kernel
{
    public class KernelModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProviderArgs)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistryArgs)
        {
            containerRegistryArgs.RegisterSingleton<IEnvironmentMonitor, EnvironmentMonitor>();
        }
    }
}