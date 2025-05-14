# Steps to set up identity 

1. Create identity layer (InterBanking.Infrastructure.Identity) project
2. Create context
   1. Add custom configurations classes (mandatory, this way we avoid error on the Program.cs)
         ```csharp
         builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
             .AddEntityFrameworkStores<IdentityContext>()
             .AddDefaultTokenProviders();
         ```
         This way we can add custom configurations later and can set this up without the method throwing an error becasue we're missing the ApplicationUser and ApplicationRole classes.
   2. Customize ApplicationRole (if necessary)
   3. Create ApplicationDbContext
   4. Create OnModelCreating method 
      1. Override OnModelCreating method (if needed)
3. Set up the Program.cs (AddDbContext and AddIdentity)