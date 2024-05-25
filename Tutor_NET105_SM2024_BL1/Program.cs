namespace Tutor_NET105_SM2024_BL1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(10);
            }); // Mặc định thời gian timeout là 15 phút
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession(); // Thêm dòng này vào
            app.UseAuthorization();

            app.MapControllerRoute( // Set đường dẫn cơ bản khi khởi chạy chương trình
                name: "default",
                pattern: "{controller=Account}/{action=Login}");

            app.Run();
        }
    }
}