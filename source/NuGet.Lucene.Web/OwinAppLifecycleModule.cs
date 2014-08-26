using Autofac;
using Owin;
using NuGet.Lucene.Web.Util;

namespace NuGet.Lucene.Web
{
    public class OwinAppLifecycleModule : Module
    {
        private readonly IAppBuilder appBuilder;

        public OwinAppLifecycleModule(IAppBuilder appBuilder)
        {
            this.appBuilder = appBuilder;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var taskRunner = new TaskRunner { ShutdownToken = appBuilder.GetHostAppDisposing() };

            builder.RegisterInstance(taskRunner).As<ITaskRunner>();
        }
    }
}
