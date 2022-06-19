using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Week2Homework.DataModel;
using Week2Homework.DBOperations;
using Week2Homework.Repository;

namespace Week2Homework.Uow 
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IConfiguration configuration;
        private readonly CustomerDbContext context;
        private readonly ILogger logger;

        public IGenericRepository<Customer> CustomerRepository { get; private set; }

        public UnitOfWork(CustomerDbContext _context, ILoggerFactory _logger, IConfiguration _config)
        {
            context = _context;
            logger = _logger.CreateLogger("Log");
            configuration = _config;

            CustomerRepository = new GenericRepository<Customer>(context, logger);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
