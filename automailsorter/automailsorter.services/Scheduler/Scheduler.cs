using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.services.Scheduler
{
    public sealed class Scheduler
    {
        public IScheduler _scheduler;

        private Scheduler(IScheduler scheduler)
        {
            this._scheduler = scheduler;
        }

        public static async Task<Scheduler> InitialiseScheduler()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            return new Scheduler(scheduler);
        }

        public IJobDetail createJob<T>(string jobName, string jobGroup) where T : IJob
        {
            return JobBuilder.Create<T>()
                .WithIdentity(jobName, jobGroup)
                .Build();
        }

        public ITrigger createTrigger(string triggerName, string triggerGroup, string schedule)
        {
            return TriggerBuilder.Create()
                .WithIdentity(triggerName, triggerGroup)
                .WithCronSchedule(schedule)
                .Build();
        }

        public async Task<bool> scheduleJob(IJobDetail job, ITrigger trigger)
        {
            await this._scheduler.ScheduleJob(job, trigger);
            return true;
        }
    }
}
