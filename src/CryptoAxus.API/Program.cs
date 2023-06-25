using Serilog;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.WithProperty("ICryptoAxusContext", Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty)
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341", LogEventLevel.Information, apiKey: "XbKEj2UbbqQrGzFll4Ff")
            .WriteTo.Http("http://localhost:5341", null, restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", cors => cors.AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials()
                                                .SetIsOriginAllowed(origin => true));
});

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationLayer(configuration);

builder.Services.AddInfrastructureLayer(configuration);

builder.Services.AddCommonLayer();

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("120SecondsCacheProfile", new CacheProfile()
    {
        Duration = 120,
        Location = ResponseCacheLocation.Any
    });
    options.Filters.Add<ModelValidationFilter>();
    options.ReturnHttpNotAcceptable = true;
    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
    options.IncludeXmlComments(XmlCommentsHelper.XmlCommentsFilePath(), true);
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CryptoAxus.API", Version = "v1" });
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<PatchArtistUsernameResponse>();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("X-Version"));
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCustomMediaTypes();

builder.Services.AddScoped<RequestHeaderFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoAxus.API V1");
    });
}

app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "Handled {RequestPath}";
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.ConfigureCustomMiddleware();

app.MapHealthChecks("/health");

app.MapControllers();

app.Run();