using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.services.Scheduler
{
    public class Scheduler
    {
        public IScheduler _scheduler;

        private Scheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public static async Task<Scheduler> InitialiseScheduler()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            return new Scheduler(scheduler);
        }

        public IJobDetail createJob<T>(string jobName, string jobGroup = "default") where T : IJob
        {
            return JobBuilder.Create<T>()
                .WithIdentity(jobName, jobGroup)
                .Build();
        }

        public ITrigger createTrigger(string schedule, string triggerName, string triggerGroup = "default")
        {
            return TriggerBuilder.Create()
                .WithIdentity(triggerName, triggerGroup)
                .WithCronSchedule(schedule)
                .Build();
        }

        public async Task<bool> scheduleJob(IJobDetail job, ITrigger trigger)
        {
            await _scheduler.ScheduleJob(job, trigger);
            return true;
        }

        public void setJobListener(IJobListener listener, string jobName, string jobGroup = "default")
        {
            _scheduler.ListenerManager.AddJobListener(listener, KeyMatcher<JobKey>.KeyEquals(new JobKey(jobName, jobGroup)));
        }
    }
}
