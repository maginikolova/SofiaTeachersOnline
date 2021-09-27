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
    public class DeleteEntityAsync_Should
    {
        private IEnumerable<Grade> _entities;
        private SofiaTeachersOnlineDbContext _dbContext;

        [SetUp]
        public async Task Setup()
        {
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            this._dbContext = new SofiaTeachersOnlineDbContext(options);

            this._entities = Utils.GetGrades();
            await this._dbContext.Grades.AddRangeAsync(this._entities);
            await this._dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task DeleteEntityWhen_ValidParams()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);
            var toBeDeletedId = this._entities.First().Id;
        
            // Act
            await entityServiceMock.DeleteEntityAsync(toBeDeletedId);
        
            // Assert
            Assert.AreEqual(_dbContext.Grades.Count(), 1);
            Assert.IsFalse(_dbContext.Grades.Any(x => x.Id == toBeDeletedId));
        }
        
        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);
        
            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => entityServiceMock.DeleteEntityAsync(-1));   // TODO: Crete a NotFoundException?
        }
    }
}
*/