using NewEmployeeBuddy.Data.Configurations;
using NewEmployeeBuddy.Data.DataContext;
using NewEmployeeBuddy.Data.Entities.Employee;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewEmployeeBuddy.Data
{
    /// <summary>
    /// This class is the starting entry of our project with Entity Framework; 
    /// here we define connection string, add tables and other configurations
    /// </summary>
    public class NewEmployeeDbContext : DbContext
    {
        #region Properties
        //This property is used to loosely couple the connection string from this class
        //to a configuration file. Instead of passing the connection string into the constructor,
        //we'll read it from the configuration file and pass it here.
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                return "DefaultConnection";
            }
        }

        //Add models here to reflect as tables in database
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        #endregion

        #region Constructor
        static NewEmployeeDbContext()
        {
            Database.SetInitializer(new DataInitializer());
        }

        public NewEmployeeDbContext() : base(nameOrConnectionString: NewEmployeeDbContext.ConnectionStringName) { }
        #endregion

        #region Methods
        /// <summary>
        /// This method is used to define custom settings on Models defined above
        /// A common scenario is if in Model-First approach , suppose the tables are already created in database
        /// and you want to map your models with it, simply use "To Table" 
        /// Another scenario is by default, Entity Framework pluralize tables. 
        /// To stop it from doing that remove the convention 'PluralizingEntitySetNameConvention' 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //This statement is used to register model configurations using FluentAPI for data annotations
            //modelBuilder.Configurations.Add(new EmployeeConfiguration());

            //This statement will restrict Entity Framework to pluralize table names by default.
            modelBuilder.Entity<Employee>().ToTable("tbl_Employee");
            modelBuilder.Entity<Address>().ToTable("tbl_Address");
            modelBuilder.Entity<Contact>().ToTable("tbl_Contact");
            modelBuilder.Entity<Payroll>().ToTable("tbl_Payroll");

            //This statement is used in case you have already created a table in database
            //and wants to map your Model with it
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
        #endregion
    }
}
