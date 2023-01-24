using Autofac;
using Library.Web.Areas.App.Models.Books;
using Library.Web.Areas.App.Models.Students;

namespace Library.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookCreateModel>().AsSelf();

            builder.RegisterType<BookListModel>().AsSelf();

            builder.RegisterType<StudentListModel>().AsSelf();

            builder.RegisterType<BookDetailsCreateModel>().AsSelf();

            builder.RegisterType<BookDetailsListModel>().AsSelf();

            builder.RegisterType<EBookCreateModel>().AsSelf();

            builder.RegisterType<EBookListModel>().AsSelf();

            builder.RegisterType<StudentApproveModel>().AsSelf();


            base.Load(builder);
        }
    }
}
