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
    // NOTE: [TextFixture] attrinute is actually not really needed
    // https://docs.nunit.org/articles/nunit/writing-tests/attributes/testfixture.html
    // Is purely a convenience, beginning with NUnit 2.5, if a class satisfies the conditions to be a test fixture and specifies at
    // least a method marked with Test, TestCase or TestCaseSource than that class is treated as a test fixture.
    // The TestFixture attribute is required however for parameterized or generic test fixture because in that case you also specify
    // additional information through the attribute(parameters/concrete types).
    [TestFixture]
    public class CreateEntityAsync_Should
    {
        private SofiaTeachersOnlineDbContext _dbContext;
        private IEnumerable<GradeDTO> _entities;
        private Mock<IMapper> _mapper;
        private EntityServiceMock _unit;

        [SetUp]
        public void Setup()
        {
            // Mock database
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            this._dbContext = new SofiaTeachersOnlineDbContext(options);

            // Setup test data
            this._entities = Utils.GetGradeDTOs();

            // Mock AutoMapper
            this._mapper = new Mock<IMapper>();

            // Arrange
            this._unit = new EntityServiceMock(this._dbContext, this._mapper.Object);
        }

        [Test]
        public async Task CreateEntityWhen_ValidParams()
        {
            // Arrange
            var expected = _entities.First();

            this._mapper.Setup(x => x.Map<Grade>(expected))
                .Returns(new Grade 
                { 
                    Id = expected.Id,
                    TeacherId = expected.TeacherId,
                    StudentId = expected.StudentId,
                    ExerciseId = expected.ExerciseId
                });

            // Act
            var result = await this._unit.CreateEntityAsync(expected);

            // Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.TeacherId, result.TeacherId);
            Assert.AreEqual(expected.StudentId, result.StudentId);
            Assert.AreEqual(expected.ExerciseId, result.ExerciseId);
        }

        [Test]
        public void ThrowWhen_EntityIsNull()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => this._unit.CreateEntityAsync(null));
        }
    }
}