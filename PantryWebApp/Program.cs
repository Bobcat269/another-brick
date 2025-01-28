using Microsoft.AspNetCore.Identity; //Auth
using Microsoft.EntityFrameworkCore; //ORM
using PantryWebApp.Data; //ApplicationDbContext (Database Entity Framework Context)

var builder = WebApplication.CreateBuilder(args);//allows us to configure services below...

// Add services to the container.
//Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//Registers ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//create default user, require email conf before sign-in.  Strangely enough doesn't follow through yet.
//because it runs locally, but they thought of a workaround :)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
//^^Use the same DB we are storing app data in to hold user data

//MVC services.
builder.Services.AddControllersWithViews();


//Build the Web App object
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Middleware
app.UseHttpsRedirection(); //http becomes https
app.UseStaticFiles(); //allows static files in wwwroot (css, JS, image assets, etc.)

app.UseRouting(); //routes incoming requests to controllers/pages

app.UseAuthorization();//Anywhere you see [Authorize] in a controller, this ensures
                        //that users can only access if they are authorized/signed in.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //template for URLS
//^^Basically saying thing1/thing2/thing3 will be read as
//Thing1: The controller being used
//Thing2: the action(method) being used (Index(), ListItems(), Details(), Create(), Edit(), Delete(), DeleteConfirmed()
//Thing3: parameter being passed (think items/:Id)

app.MapRazorPages();//maps the pages to the application

app.Run();//I hope we all know what this does by now.
