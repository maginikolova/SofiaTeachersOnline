/*using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.BaseEntityServiceTests
{
    [TestFixture]
    public class GetAllEntities_Should
    {
        private IEnumerable<Grade> _entities;
        private SofiaTeachersOnlineDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            this._dbContext = new SofiaTeachersOnlineDbContext(options);

            this._entities = Utils.GetGrades();
        }

        [Test]
        public async Task GetAllEntitiesWhen_EntitiesExist()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);

            await this._dbContext.Grades.AddRangeAsync(this._entities);
            await this._dbContext.SaveChangesAsync();

            // Act
            var result = entityServiceMock.GetAllEntities();

            //Assert
            Assert.AreEqual(_entities.Count(), result.Count());
            Assert.AreEqual(_entities.First().Id, result.First().Id);
            Assert.AreEqual(_entities.Skip(1).First().Id, result.Skip(1).First().Id);
        }

        [Test]
        public void ReturnEmptyCollectionWhen_NoEntities()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);

            // Act
            var result = entityServiceMock.GetAllEntities().ToList();

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
*/