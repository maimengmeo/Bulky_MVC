//Program.cs and startup.cs is combined in new version
//whenever have to configure something in the pipeline, go to this file
//pipeline means when a req comes to an app, how do you want to process that

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//this means we're using conrtoller
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//call files in wwwroot. all the files in there will be accessible in the app

app.UseRouting();//add routing to the req pipeline

app.UseAuthorization();

app.MapControllerRoute(// tell the app how the routing should work
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");//the ? in .net means can be defined or not
    //for default, nav to home/index, id is optional

app.Run();
