using log4net;
using log4net.Config;
using System.Configuration;

namespace WebApiAgenda.Dao.Dao
{
    public class BaseDao
    {
        #region Properties
        protected ILog Log { get; set; }
        #endregion
        #region Constructor
        public BaseDao()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(ConfigurationManager.AppSettings["LoggerName"]);
        }
        #endregion
    }
}
