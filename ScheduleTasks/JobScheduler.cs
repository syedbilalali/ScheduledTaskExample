

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace ScheduledTaskExample.ScheduleTasks
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = (IScheduler)StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity("trigger1", "group1")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(10)
        .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}