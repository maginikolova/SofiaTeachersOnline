using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.EntityServiceTests
{
    [TestFixture]
    public class GetEntityByIdAsync_Should
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
        public async Task GetCorrectEntityWhen_ValidParams()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);
            var expected = this._entities.Skip(1).First();

            // Act
            var result = await entityServiceMock.GetEntityByIdAsync(expected.Id);

            // Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public async Task ReturnNullEntityWhen_WrongId()
        {
            // Arrange
            var entityServiceMock = new EntityServiceMock(this._dbContext);

            // Act
            var result = await entityServiceMock.GetEntityByIdAsync(-1);

            //Assert
            Assert.IsNull(result);
        }
    }
}

/*
// If we use Assert.Multiple() then NUnit is storing any failures encountered in the block and reporting all of them
// together upon exit from the block. If both asserts failed, then both would be reported.
// Otherwise the test would stop on the first assert
// https://docs.nunit.org/articles/nunit/writing-tests/assertions/multiple-asserts.html

    Assert.Multiple(() =>
    {
        Assert.AreEqual(expected.Id, 5);
        Assert.AreEqual(expected.TeacherId, Guid.NewGuid());
        Assert.AreEqual(expected.StudentId, result.StudentId);
        Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
    });
*/