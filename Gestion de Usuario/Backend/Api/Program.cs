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

            // Add services to the container.

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://tu-frontend.com") // Reemplaza con el dominio de tu frontend
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

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
            // builder.Services.AddScoped<IFin, ListadoRoles>();

            // USUARIO
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuarios, ListaUsuarios>();
            builder.Services.AddScoped<IFindUsuarioXId, FindUserXId>();
            builder.Services.AddScoped<IDeleteUsuario, BorrarUser>();
            builder.Services.AddScoped<IUpdateUsuario, UpdateUser>();
            builder.Services.AddScoped<IFindUserXMail, FindUserByMail>();

            // CONF DE LA BASE DE DATOS
            string strCon = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<GestionUsuariosContext>(options => options.UseSqlServer(strCon));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin"); // Usa la política de CORS
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
