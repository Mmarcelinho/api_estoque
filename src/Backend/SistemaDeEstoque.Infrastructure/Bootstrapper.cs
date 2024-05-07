namespace SistemaDeEstoque.Infrastructure;

public static class Bootstrapper
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarFluentMigrator(services, configuration);
        AdicionarContexto(services, configuration);
    }

    private static void AdicionarContexto(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConexaoCompleta();
        var versaoServidor = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<SistemaDeEstoqueContext>(opcoes =>
        {
            opcoes.UseMySql(connectionString, versaoServidor);
        });
    }

    private static void AdicionarFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c => c.AddMySql8().WithGlobalConnectionString(configuration.GetConexaoCompleta()).ScanIn(Assembly.Load("SistemaDeEstoque.Infrastructure")).For.All());
    }
}
