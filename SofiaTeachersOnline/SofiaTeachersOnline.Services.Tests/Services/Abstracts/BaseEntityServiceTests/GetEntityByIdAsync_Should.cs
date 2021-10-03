using AutoMapper;
using Moq;
using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.BaseEntityServiceTests
{
    [TestFixture]
    public class GetEntityByIdAsync_Should
    {
        private SofiaTeachersOnlineDbContext _dbContext;
        private IEnumerable<Grade> _entities;
        private Mock<IMapper> _mapper;
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
            this._mapper = new Mock<IMapper>();

            // Arrange
            this._unit = new EntityServiceMock(this._dbContext, this._mapper.Object);
        }

        [Test]
        public async Task GetCorrectEntityWhen_ValidParams()
        {
            // Arrange
            var expected = this._entities.Skip(1).First();

            this._mapper.Setup(x => x.Map<GradeDTO>(expected))
                .Returns(new GradeDTO
                {
                    Id = expected.Id,
                    TeacherId = expected.TeacherId,
                    StudentId = expected.StudentId,
                    ExerciseId = expected.ExerciseId
                });

            // Act
            var result = await this._unit.GetEntityByIdAsync(expected.Id);

            // Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public async Task ReturnNullEntityWhen_WrongId()
        {
            // Act
            var result = await this._unit.GetEntityByIdAsync(-1);

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