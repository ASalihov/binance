using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Binance.Models;
using Microsoft.AspNetCore.Builder;

namespace Binance
{
    // public class Startup
    // {
    //     public Startup(IConfiguration configuration)
    //     {
    //         Configuration = configuration;
    //     }
    //     public IConfiguration Configuration { get; }
    //     public void ConfigureServices(IServiceCollection services)
    //     {
    //         services
    //             .AddEntityFrameworkNpgsql()
    //             .AddDbContext<BinanceContext>();
    //     }

    //     public void Configure(IApplicationBuilder app)
    //     {
    //     }
    // }
}