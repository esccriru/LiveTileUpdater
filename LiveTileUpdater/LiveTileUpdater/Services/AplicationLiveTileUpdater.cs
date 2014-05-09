using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LiveTileUpdater.Services
{
    public class AplicationLiveTileUpdater
    {
        private String periodicTaskName = "LiveTileUpdater";
        private PeriodicTask liveTileUpdaterTask;

        public void UpdateLiveTile()
        {
            liveTileUpdaterTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;
            if (liveTileUpdaterTask != null)
            {
                ScheduledActionService.Remove(periodicTaskName);
            }
            liveTileUpdaterTask = new PeriodicTask(periodicTaskName);
            liveTileUpdaterTask.Description = "Task for upadte live tile";
            liveTileUpdaterTask.ExpirationTime = DateTime.Now.AddDays(1);

            try
            {
                ScheduledActionService.Add(liveTileUpdaterTask);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }
    }
}
