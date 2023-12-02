namespace DotNet7StudLTE.Helpers
{
    public class Constants
    {
        //declare the appsettings reference.
        static IConfiguration MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //api root directory.
        public static string DATABASE_URL = MyConfig.GetValue<string>("ConnectionStrings:DbConnector");

        //api root directory.
        public static string DEFAULT_LOGIN = MyConfig.GetValue<string>("ConnectionStrings:LoginPath");
    }
}
