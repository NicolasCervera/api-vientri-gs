
using iaas.vientri.gs.Application.Implementation;
using iaas.vientri.gs.Application.Implementation.Interfaces;
using iaas.vientri.gs.Domain.Repositories;
using iaas.vientri.gs.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IVientriServices, VientriServices>();

            builder.Services.AddTransient<IVientriRepositories, VientriRepositories>();

            //builder.Services.AddDbContext<DemoContext>(
            //    options =>
            //    {
            //        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //    });

var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



