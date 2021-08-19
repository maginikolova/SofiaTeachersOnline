using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.BaseEntityServiceTests
{
    // NOTE: [TextFixture] attrinute is actually not really needed
    // https://docs.nunit.org/articles/nunit/writing-tests/attributes/testfixture.html
    // Is purely a convenience, beginning with NUnit 2.5, if a class satisfies the conditions to be a test fixture and specifies at
    // least a method marked with Test, TestCase or TestCaseSource than that class is treated as a test fixture.
    // The TestFixture attribute is required however for parameterized or generic test fixture because in that case you also specify
    // additional information through the attribute(parameters/concrete types).
    [TestFixture]
    public class CreateEntityAsync_Should
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
        public async Task CreateEntityWhen_ValidParams()
        {
            // Arrange
            var expected = _entities.First();
            var entityServiceMock = new EntityServiceMock(this._dbContext);

            // Act
            var result = await entityServiceMock.CreateEntityAsync(expected);

            // Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => entityServiceMock.CreateEntityAsync(null));
        }
    }
}
