var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationLayer(configuration);

builder.Services.AddInfrastructureLayer(configuration);

builder.Services.AddCommonLayer();

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("300SecondsCacheProfile", new CacheProfile()
    {
        Duration = 300,
        Location = ResponseCacheLocation.Any
    });
    options.Filters.Add<ModelValidationFilter>();
    options.ReturnHttpNotAcceptable = true;
    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    options.RespectBrowserAcceptHeader = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
}).AddNewtonsoftJson();

builder.Services.AddValidatorsFromAssemblyContaining<PostNftRequestValidator>();

builder.Services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
    options.IncludeXmlComments(XmlCommentsHelper.XmlCommentsFilePath(), true);
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CryptoAxus.API", Version = "v1" });
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<PatchArtistResponse>();

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

builder.Services.Configure<RouteOptions>(routeOptions =>
{
    routeOptions.ConstraintMap.Add("string", typeof(StringRouteConstraint));
});

builder.Services.AddResponseCaching();

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

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
