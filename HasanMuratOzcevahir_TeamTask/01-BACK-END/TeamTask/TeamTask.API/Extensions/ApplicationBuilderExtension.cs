namespace TeamTask.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SetCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(options =>
                    options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );

            app.UseAuthorization();

            return app;
        }
    }
}
