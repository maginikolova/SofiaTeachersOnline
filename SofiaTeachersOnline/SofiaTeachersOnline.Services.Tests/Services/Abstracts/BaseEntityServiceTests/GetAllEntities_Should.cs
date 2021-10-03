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
    public class GetAllEntities_Should
    {
        private SofiaTeachersOnlineDbContext _dbContext;
        private IEnumerable<Grade> _entities;
        private Mock<IMapper> _mapper;
        private EntityServiceMock _unit;

        [SetUp]
        public void Setup()
        {
            // Mock database
            var options = Utils.GetOptions(Guid.NewGuid().ToString());
            this._dbContext = new SofiaTeachersOnlineDbContext(options);

            // Setup test data
            this._entities = Utils.GetGrades();

            // Mock AutoMapper
            this._mapper = new Mock<IMapper>();

            // Arrange
            this._unit = new EntityServiceMock(this._dbContext, this._mapper.Object);
        }

        [Test]
        public async Task GetAllEntitiesWhen_EntitiesExist()
        {
            // Arrange
            await this._dbContext.Grades.AddRangeAsync(this._entities);
            await this._dbContext.SaveChangesAsync();
            var firstEntity = this._entities.First();
            var secondEntity = this._entities.Skip(1).First();

            this._mapper.Setup(x => x.Map<GradeDTO>(firstEntity))
                .Returns(new GradeDTO { Id = firstEntity.Id });
            this._mapper.Setup(x => x.Map<GradeDTO>(secondEntity))
                .Returns(new GradeDTO { Id = secondEntity.Id });

            // Act
            var result = this._unit.GetAllEntities();

            //Assert
            Assert.AreEqual(_entities.Count(), result.Count());
            Assert.AreEqual(firstEntity.Id, result.First().Id);
            Assert.AreEqual(secondEntity.Id, result.Skip(1).First().Id);
        }

        [Test]
        public void ReturnEmptyCollectionWhen_NoEntities()
        {
            // Act
            var result = this._unit.GetAllEntities().ToList();

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
