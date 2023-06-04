using Microsoft.Extensions.DependencyInjection;

namespace HC.EstudoDDD.CrossCutting
{
    public static class Ioc
    {
        public static void ResolverDependencia(this IServiceCollection services)
        {
            RegistrarDepenciasApplication(services);
            RegistrarDepenciasInfra(services);
        }

        private static void RegistrarDepenciasInfra(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        private static void RegistrarDepenciasApplication(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}