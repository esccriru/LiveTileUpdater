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


            ScheduledActionService.LaunchForTest(periodicTaskName,
              TimeSpan.FromMilliseconds(250));

            //if (ScheduledActionService.Find(periodicTaskName) != null)
            //{
            //    ScheduledActionService.Remove(periodicTaskName);
            //}

            //liveTileUpdaterTask = new PeriodicTask(periodicTaskName);
            //liveTileUpdaterTask.Description = "Actualiza el live tile de manera periodica";

            //try
            //{
            //    ScheduledActionService.Add(liveTileUpdaterTask);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}
