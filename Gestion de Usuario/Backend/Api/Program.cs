using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policyBuilder =>
                    {
                        policyBuilder.WithOrigins("http://localhost:5173") // Origen sin barra al final
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                    });
            });

            // Inyección de dependencias
            // EVENTO
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEventosBD>();
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IDeleteEvento, BorrarEvento>();
            builder.Services.AddScoped<IFindEveXDescripcion, FindEventosXDescripcion>();
            builder.Services.AddScoped<IFindEveXFecha, FindEventosXFecha>();
            builder.Services.AddScoped<IFindEveXTipoTramite, FindEventosXTipoTramite>();
            builder.Services.AddScoped<IFindEveXUser, FindEventosXUser>();
            builder.Services.AddScoped<IFindEveXId, FindEventoXId>();
            builder.Services.AddScoped<IListadoEve, ListadoEventos>();
            builder.Services.AddScoped<IUpdateEven, UpdateEvento>();

            // ROL
            builder.Services.AddScoped<IRepositorioRol, RepositorioRolesBD>();
            builder.Services.AddScoped<IListadoRoles, ListadoRoles>();

            // TIPOTRAMITE
            builder.Services.AddScoped<IRepositorioTipoTramite, RepositorioTiposTramitesDB>();

            // USUARIO
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuarios, ListaUsuarios>();
            builder.Services.AddScoped<IFindUsuarioXId, FindUserXId>();
            builder.Services.AddScoped<IDeleteUsuario, BorrarUser>();
            builder.Services.AddScoped<IUpdateUsuario, UpdateUser>();
            builder.Services.AddScoped<IFindUserXMail, FindUserByMail>();

            // Configuración de la base de datos
            string strCon = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<GestionUsuariosContext>(options => options.UseSqlServer(strCon));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Pipeline de la aplicación
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Habilitar CORS antes de otros middlewares
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}