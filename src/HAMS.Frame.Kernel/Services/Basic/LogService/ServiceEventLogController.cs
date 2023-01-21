﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using log4net.Core;
using log4net.Appender;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using HAMS.Frame.Kernel.Core;

namespace HAMS.Frame.Kernel.Services
{
    public class ServiceEventLogController : LogControllerBase
    {
        FileAppender serviceEventFileAppender;
        Logger serviceEventLogger;

        IEnvironmentMonitor environmentMonitor;

        public ServiceEventLogController(IContainerProvider containerProviderArg) : base(containerProviderArg)
        {
            environmentMonitor = containerProviderArg.Resolve<IEnvironmentMonitor>();

            serviceEventFileAppender = new FileAppender();
            serviceEventFileAppender.Name = "ServiceEventFlatFile";
            serviceEventFileAppender.Layout = base.TextLayout;
            serviceEventFileAppender.AppendToFile = true;
            serviceEventFileAppender.File = environmentMonitor.LogSetting[LogPart.ServicEvent].Content;

            serviceEventLogger = (Logger)LoggerManager.GetLogger("Base", "ServiceEvent");

            if (base.GlobalLogEnabledFilter == true)
            {
                serviceEventFileAppender.ActivateOptions();

                if (serviceEventLogger.GetAppender("ServiceEventFlatFile") != null)
                {
                    serviceEventLogger.RemoveAppender("ServiceEventFlatFile");
                }

                serviceEventLogger.AddAppender(serviceEventFileAppender);
            }
        }

        public override void Write(string messageArg)
        {
            serviceEventLogger.Log(Level.Debug, messageArg, null);
        }
    }
}
