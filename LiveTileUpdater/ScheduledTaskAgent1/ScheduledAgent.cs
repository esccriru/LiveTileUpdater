﻿using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Linq;

namespace ScheduledTaskAgent1
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        /// <remarks>
        /// Constructor de ScheduledAgent que inicializa el controlador UnhandledException
        /// </remarks>
        static ScheduledAgent()
        {
            // Suscribirse al controlador de excepciones administradas
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Código para ejecutar en excepciones no controladas
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Se ha producido una excepción no controlada; interrumpir el depurador
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agente que ejecuta una tarea programada
        /// </summary>
        /// <param name="task">
        /// Tarea invocada
        /// </param>
        /// <remarks>
        /// Se llama a este método cuando se invoca una tarea periódica o con uso intensivo de recursos
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            //TODO: Agregar código para realizar la tarea en segundo plano

            //ShellToast shellToast = new ShellToast()
            //{
            //    Title = "LiveTileUpdater",
            //    Content = "Background Task Launched",
            //    NavigationUri = new Uri("/MainPage.xaml", UriKind.Relative)
            //};
            
            //shellToast.Show();

            StandardTileData ftiledata = new StandardTileData();
            ftiledata.Title = "titulo";
            ftiledata.BackTitle = "titulo atras";
            ftiledata.BackContent = "contenido";

            ShellTile tile = ShellTile.ActiveTiles.First();
            tile.Update(ftiledata);

#if DEBUG_AGENT
            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));
#endif

            NotifyComplete();
        }
    }
}