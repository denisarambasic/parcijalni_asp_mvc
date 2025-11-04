using AspNet.TODO.Models;
using AspNet.TODO.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AspNet.TODO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            var app = builder.Build();
            
            //var connectionString = "Data Source=DESKTOP-TLDLP4N;Initial Catalog=Algebra;Trusted_Connection=true;Encrypt=false;";
            var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            //using var command = new SqlCommand("INSERT INTO Author (Name, Bio) VALUES('Pero', '');", connection);
            //command.ExecuteNonQuery();
            //using var command = new SqlCommand("SELECT 1;", connection);
            //using var command = new SqlCommand("SELECT [Name] FROM Author;", connection);
            //using var command = new SqlCommand("SELECT * FROM Author WHERE AuthorId = @book_id", connection);
            //command.Parameters.Clear();
            //command.Parameters.AddWithValue("@book_id", 1);
            using var command = new SqlCommand("SELECT * FROM Author", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader[0];
                var authorId = reader["AuthorId"];
                var authorName = reader["Name"];
                var bio = reader["Bio"];
            }
            var result =  command.ExecuteScalar();


            //Todo:...
            connection.Close();
            connection.Dispose();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
