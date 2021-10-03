using AutoMapper;
using Moq;
using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.BaseEntityServiceTests
{
    [TestFixture]
    public class DeleteEntityAsync_Should
    {
        private SofiaTeachersOnlineDbContext _dbContext;
        private IEnumerable<Grade> _entities;
        private EntityServiceMock _unit;

        [SetUp]
        public async Task Setup()
        {
            // Mock database
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            this._dbContext = new SofiaTeachersOnlineDbContext(options);

            // Setup test data
            this._entities = Utils.GetGrades();

            await this._dbContext.Grades.AddRangeAsync(this._entities);
            await this._dbContext.SaveChangesAsync();

            // Mock AutoMapper
            var mapper = new Mock<IMapper>();

            // Arrange
            this._unit = new EntityServiceMock(this._dbContext, mapper.Object);
        }

        [Test]
        public async Task DeleteEntityWhen_ValidParams()
        {
            // Arrange
            var toBeDeletedId = this._entities.First().Id;

            // Act
            await this._unit.DeleteEntityAsync(toBeDeletedId);

            // Assert
            Assert.AreEqual(_dbContext.Grades.Count(), 1);
            Assert.IsFalse(_dbContext.Grades.Any(x => x.Id == toBeDeletedId));
        }

        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => this._unit.DeleteEntityAsync(-1));   // TODO: Crete a NotFoundException?
        }
    }
}
