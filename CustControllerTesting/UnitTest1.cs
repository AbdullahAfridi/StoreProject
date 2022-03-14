using BussinessAccessLayer.Services;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using StoreCURD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CustControllerTesting
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetCustomer_Return_Truse_Number_Of_Customers()
        {
            //Arrange
            int count = 7;
            var fakeCustomers = A.CollectionOfDummy<Customer>(count).AsEnumerable();
            var dataStore = A.Fake<IRepository<Customer>>();
            object p = A.CallTo(() => dataStore.GetById(count)).Return(Task.FromResult(fakeCustomers));
            var controller = new CustomerController(dataStore);

            //Act
            var actionResult=  controller.GetAllCustomers();

            //Assert

            var result = actionResult.Result as OkObjectResult;
            var returnCustomer = result.Value as IEnumerable<Customer>;
            Assert.Equal(Count, returnCustomer.Count));
        
        }
    }
}
