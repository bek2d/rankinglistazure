using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MvcAppCollect.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public IActionResult OnPost()
    {
        var res = "";
        var last_login = DateTime.Now.ToString();
        var email = "";
        var password = "";
        email = Request.Form["email"];
        password = Request.Form["password"];
        if (email != "" && password != "")
        
        {
            string connectionString =
                "Data Source=tcp:razormvcit.database.windows.net;Initial Catalog=itransitionproject;User ID=beks;Password=*";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT email FROM [Table] WHERE email = @email";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    try
                    {
                        var result = command.ExecuteScalar().ToString();

                    }

                    catch
                    {

                        ModelState.AddModelError("", "Invalid username or password!");

                    }

                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT email FROM [Table] WHERE password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", password);
                    try
                    {
                        var result = command.ExecuteScalar().ToString();
                    }

                    catch
                    {

                        ModelState.AddModelError("", "Invalid username or password!");



                    }

                }

            }

        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        string connectionStrin = "Data Source=tcp:razormvcit.database.windows.net;Initial Catalog=itransitionproject;User ID=beks;Password=*";
        using (SqlConnection connection = new SqlConnection(connectionStrin))
        {
            connection.Open();
            string sql = "UPDATE [Table] SET last_login = @last_login WHERE email=@email;";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@last_login", last_login);
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();

            }
        }

        string connectionStri = "Data Source=tcp:razormvcit.database.windows.net;Initial Catalog=itransitionproject;User ID=beks;Password=*";
        using (SqlConnection connection = new SqlConnection(connectionStri))
        {
            connection.Open();
            string sql = "SELECT status FROM [Table] where email = @email;";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@email", email);

                res = command.ExecuteScalar().ToString();

            }
        }



        if (res == "Blocked")
        {
            ModelState.AddModelError("", "User is blocked");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

        var user = new ClaimsPrincipal(
            new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Name, email) },
                scheme
            )
        );
        Response.Redirect("/Clients");
        return SignIn(user, scheme);
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Account/Login");
    }    
}

