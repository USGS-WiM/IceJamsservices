using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WiM.Security;
using IceJamsDB.Resources;

namespace IceJamsDB.Test
{
    [TestClass]
    public class IceJamsDBTest
    {
        private string connectionstring = new ConfigurationBuilder()
                    //a completed appsettings.json file needs to be located in at .\IceJamsDB.Test\bin\Debug\netcoreapp2.2
                    //that contains the connection string.
                    .AddJsonFile("appsettings.json")
                    .Build().GetConnectionString("IceJamsConnection");

        [TestMethod]
        public void ConnectionTest()
        {
            using (IceJamsDBContext context = new IceJamsDBContext(new DbContextOptionsBuilder<IceJamsDBContext>().UseNpgsql(this.connectionstring, x => x.UseNetTopologySuite()).Options))
            {
                try
                {
                    if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists()) throw new Exception("db does ont exist");
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false, ex.Message);
                }
            }
        }
        [TestMethod]
        public void QueryTest()
        {
            using (IceJamsDBContext context = new IceJamsDBContext(new DbContextOptionsBuilder<IceJamsDBContext>().UseNpgsql(this.connectionstring, x => x.UseNetTopologySuite()).Options))
            {
                try
                {
                    var testQuery = context.IceJams.ToList();
                    Assert.IsNotNull(testQuery, testQuery.Count.ToString());
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false, ex.Message);
                }
                finally
                {
                }

            }
        }
        [TestMethod]
        public void AddManagerTest()
        {
            using (IceJamsDBContext context = new IceJamsDBContext(new DbContextOptionsBuilder<IceJamsDBContext>().UseNpgsql(this.connectionstring, x => x.UseNetTopologySuite()).Options))
            { 
                try
                {
                    var salt = Cryptography.CreateSalt();
                    var password = "";

                    if (String.IsNullOrEmpty(password)) throw new Exception("password cannot be empty");

                    Observer observer = new Observer()
                    {
                        FirstName = "Test",
                        Email = "testAdmin@usgs.gov",
                        LastName = "Administrator",
                        RoleID = 1,
                        Username = "testAdmin",
                        Password = Cryptography.GenerateSHA256Hash(password, salt),
                        Salt = salt

                    };
                    context.Observers.Add(observer);
                    context.SaveChanges();

                    Assert.IsTrue(Cryptography.VerifyPassword(password, observer.Salt, observer.Password));

                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
                finally
                {
                }

            }
        }

    }
}
