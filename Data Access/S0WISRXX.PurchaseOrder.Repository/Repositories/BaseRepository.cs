using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories
{
    /// <summary>
    /// Base respository that connects a model to a database table
    /// </summary>
    /// <typeparam name="T">Model that is going to be connected to a table</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable//where T : BaseModel
    {
        private bool _disposed = false;
        public PurchaseOrderContext _context = new PurchaseOrderContext();
        private string env;
        private string systemID;
        private readonly IUtilityLogger _logger;

        // Constructor

        public BaseRepository(PurchaseOrderContext entities, IUtilityLogger logger)
        {
            Setvariables();
            _logger = logger;
        }

        public string SystemID { get { return systemID; } }

        public void Setvariables()
        {
            env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
            .Build();


            systemID = configuration["AppSettings:SystemID"];
        }


        public async Task<T> ExecuteWithLoggingAsync<T>(Func<Task<T>> func, string errorMessage)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                throw new Exception(ex.Message);
            }
        }

        public async Task ExecuteWithLoggingAsync(Func<Task> func, string errorMessage)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}