using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PruebaIngresoBibliotecario.Domain.DomainServices.Loans;
using PruebaIngresoBibliotecario.Domain.Entities;
using PruebaIngresoBibliotecario.Domain.Ports;
using System;

namespace PruebaIngresoBibliotecario.Domain.Tests
{
    [TestClass]
    public class LoanServiceTests
    {
        IGenericRepository<Loan, Guid> genericRepository = default;
        LoanService loanService = default;

        [TestInitialize]
        public void Init()
        {
            genericRepository = Substitute.For<IGenericRepository<Loan, Guid>>();
            loanService = new LoanService(genericRepository);
        }

        [TestMethod]
        public void AddBusinessDaysReturnCorrectDate()
        {
            //Arrange
            int daysToAdd = 8;
            DateTime date = new DateTime(2023, 7, 24);
            DateTime correctDate = new DateTime(2023, 8, 3);

            //Act
            DateTime result = loanService.AddBusinessDays(date, daysToAdd);

            //Assert
            Assert.AreEqual(correctDate, result);

        }


        [TestMethod]
        public void IsBussinessDayReturnTrue()
        {
            //Arrange
            DateTime date = new DateTime(2023, 7, 24);

            //Act
            bool result = loanService.IsBussinessDay(date);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBussinessDayReturnFalse()
        {
            //Arrange
            DateTime date = new DateTime(2023, 7, 23);

            //Act
            bool result = loanService.IsBussinessDay(date);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
