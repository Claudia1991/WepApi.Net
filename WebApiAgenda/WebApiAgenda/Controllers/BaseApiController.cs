using log4net;
using log4net.Config;
using System.Configuration;
using System.Web.Http;

namespace WebApiAgenda.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Properties
        protected ILog Log { get; set; }
        #endregion

        #region Constructor
        protected BaseApiController()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(ConfigurationManager.AppSettings["LoggerName"]);
        }
        #endregion
    }
}