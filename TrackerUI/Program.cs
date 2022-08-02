using System.Configuration;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Iniialize he database connection
            TrackerLibrary.GlobalConfig.SqlConnectionString = ConfigurationManager.ConnectionStrings["Tournaments"].ConnectionString;
            TrackerLibrary.GlobalConfig.InitializeConnections(TrackerLibrary.DatabaseType.Sql);
            Application.Run(new CreateTournamentForm());

            //Application.Run(new TournamentDashboardForm());
        }
    }
}