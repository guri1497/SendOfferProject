using Product.BL;
using Product.IBL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SendOfferMVCApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IProductRepo, ProductRepo>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IProductOfferRepo, ProductOfferRepo>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}