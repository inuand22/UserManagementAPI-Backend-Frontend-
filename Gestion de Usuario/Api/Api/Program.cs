
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


            //ROL
            builder.Services.AddScoped<IRepositorioRol, RepositorioRolesBD>();
            builder.Services.AddScoped<IListadoRoles, ListadoRoles>();


            //USUARIO
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IListadoUsuarios, ListaUsuarios>();
            builder.Services.AddScoped<IFindUsuarioXId, FindUserXId>();
            builder.Services.AddScoped<IDeleteUsuario, BorrarUser>();
            builder.Services.AddScoped<IUpdateUsuario, UpdateUser>();     


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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
