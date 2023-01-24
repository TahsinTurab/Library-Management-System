using Autofac;
using Library.Web.Areas.App.Models.Books;

namespace Library.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookCreateModel>().AsSelf();

            builder.RegisterType<BookDetailsCreateModel>().AsSelf();

            base.Load(builder);
        }
    }
}
