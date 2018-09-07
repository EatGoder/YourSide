using Funq;
using ServiceStack;
using Project.API.ServiceInterface;
using System.ComponentModel.Composition.Hosting;

namespace Project.API
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("Project.API", typeof(ServiceStackServices).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            //配置跨域
            Plugins.Add(new CorsFeature());
            //注册用户认证证书


            string directoryName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "bin\\";
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            if (directoryName != null)
            {
                //DirectoryCatalog 在指定的目录发现部件。
                aggregateCatalog.Catalogs.Add(new DirectoryCatalog(directoryName, "Project.API*"));
            }
            CompositionContainer _mefContainer = new CompositionContainer(aggregateCatalog);
            container.Adapter = new MEFIOCAdapter(_mefContainer);
        }
    }
}