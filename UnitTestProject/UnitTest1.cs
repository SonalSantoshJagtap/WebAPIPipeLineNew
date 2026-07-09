using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Runtime.InteropServices;
using WebAPIToPracticeLinq.Models;

namespace UnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllEmployeesTest()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync("api/GetAllEmployees");
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }

        //[Fact]
        //public async Task GetAllEmployeeByIdTest()
        //{
        //    var factory = new WebApplicationFactory<Program>();
        //    var client = factory.CreateClient();
        //    var response = await client.GetAsync("api/GetAllEmployeeById/2");
        //    Assert.Equal(200,(int)response.StatusCode);
        //}

        //With mutiple data
        [Theory]
        [InlineData(5,200)]
        [InlineData(22,204)]
        [InlineData(3,200)]
        [InlineData(40,204)]
        public async Task GetEmployeeByIdTest(int id,int expected)
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync($"api/GetEmployeeById/{id}");
            Assert.Equal(expected, (int)response.StatusCode);
            
        }


        [Fact]
        public async Task GetEmpWithHighestSalTest()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync("api/Employee/GetEmpWithHighestSal");
            Assert.Equal(200, (int)response.StatusCode);
           
        }

        [Fact]
        public async Task FindByEmail()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync("api/Employee/FindByEmail");
            Assert.Equal(200, (int)response.StatusCode);

        }

       
         [Fact]
        public async Task CalculateTotalSal()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync("api/CalculateTotalSal");
            Assert.Equal(200, (int)response.StatusCode);

        }
    }
}
