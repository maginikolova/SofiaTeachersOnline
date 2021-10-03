using AutoMapper;
using Moq;
using NUnit.Framework;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Enums;
using SofiaTeachersOnline.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Tests.Services.Abstracts.BaseEntityServiceTests
{
    [TestFixture]
    public class UpdateEntityAsync_Should
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
        public async Task UpdateEntityWhen_ValidParams()
        {
            // Arrange
            var toBeUpdated = this._entities.First();
            var expected = new GradeDTO
            {
                Id = toBeUpdated.Id,
                StudentId = Guid.NewGuid(),
                TeacherId = Guid.NewGuid(),
                ExerciseId = 1,
                Mark = Mark.B
            };
            this._mapper.Setup(x => x.Map<Grade>(expected))
                .Returns(new Grade
                {
                    Id = expected.Id,
                    TeacherId = expected.TeacherId,
                    StudentId = expected.StudentId,
                    ExerciseId = expected.ExerciseId
                });

            // Act
            var result = await this._unit.UpdateEntityAsync(toBeUpdated.Id, expected, null);

            // Assert
            Assert.AreEqual(toBeUpdated.Id, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Arrange
            var toBeUpdatedId = this._entities.First().Id;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => this._unit.UpdateEntityAsync(toBeUpdatedId, null, null));
        }
    }
}
