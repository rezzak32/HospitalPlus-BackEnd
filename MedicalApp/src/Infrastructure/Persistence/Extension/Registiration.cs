

using Application.Abstract.Repositories;
using Application.Abstract.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence.Extension
{
    public static class Registiration
    {
        public static void AddPersistentRegistiration(this IServiceCollection services)
        {
            services.AddSingleton<MedicalAppDbContext>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            
        }

    }
}
