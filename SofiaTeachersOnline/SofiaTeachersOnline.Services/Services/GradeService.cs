using Microsoft.EntityFrameworkCore;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Enums;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly SofiaTeachersOnlineDbContext dbContext;
        //private readonly IMapper mapper;

        public GradeService(SofiaTeachersOnlineDbContext dbContext/*, IMapper mapper*/)
        {
            this.dbContext = dbContext;
            //this.mapper = mapper;
        }

        public async Task<GradeDTO> CreateGradeAsync(GradeDTO gradeDTO)
        {
            if (gradeDTO == null)
            {
                throw new ArgumentNullException(/*string.Join(ExceptionMessages.InvalidEntry, nameof(Grade))*/);
            }

            //var GradeToAdd = this.mapper.Map<Grade>(gradeDTO);

            var GradeToAdd2 = new Grade
            {
                Mark = Mark.B,
                CreatedOn = DateTime.UtcNow,
                ExerciseId = 2
            };

            var grade = await this.dbContext.Grades.AddAsync(GradeToAdd2);

            await this.dbContext.SaveChangesAsync();

            //return this.mapper.Map<GradeDTO>(grade.Entity);
            return default;
        }

        public async Task<GradeDTO> GetGradeByIdAsync(int id)
        {
            var grade = await this.dbContext.Grades
                .Include(x => x.Exercise)
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (grade == null)
            {
                throw new ArgumentNullException(/*string.Join(ExceptionMessages.NotFoundException, nameof(Grade))*/);
            }

            //return this.mapper.Map<GradeDTO>(grade);
            return default;
        }

        /*        public async Task<GradeDTO> UpdateGradeAsync(int id, GradeDTO gradeDTO)
                {
                    var grade = await this.dbContext.Grades
                        .Include(g => g.Exercise)
                        .Include(g => g.Student)
                        .Include(g => g.Teacher)
                        .FirstOrDefaultAsync(g => g.Id == id);

                    if (grade == null)
                    {
                        throw new ArgumentNullException(string.Join(ExceptionMessages.NotFoundException, nameof(Grade)));
                    }

                    grade.Mark = gradeDTO.Mark;

                    await this.dbContext.SaveChangesAsync();

                    return 
                }*/
    }
}
