using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.EntityServiceTests
{
    [TestFixture]
    public class UpdateEntityAsync_Should
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
        public async Task UpdateEntityWhen_ValidParams()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);
            var toBeUpdatedId = this._entities.First().Id;
            var expected = new Grade
            {
                Id = toBeUpdatedId,
                StudentId = Guid.NewGuid(),
                TeacherId = Guid.NewGuid(),
                ExerciseId = 1,
                Mark = Mark.B
            };

            // Act
            var result = await entityServiceMock.UpdateEntityAsync(toBeUpdatedId, expected);

            // Assert
            Assert.AreEqual(toBeUpdatedId, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);
            var toBeUpdatedId = this._entities.First().Id;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => entityServiceMock.UpdateEntityAsync(toBeUpdatedId, null));
        }
    }
}
