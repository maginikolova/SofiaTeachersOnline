using SofiaTeachersOnline.Services.DTOs;
using System.Threading.Tasks;

namespace SofiaTeachersOnline.Services.Services.Contracts
{
    public interface IGradeService
    {
        Task<GradeDTO> CreateGradeAsync(GradeDTO newGrade);
        Task<GradeDTO> GetGradeByIdAsync(int Id);
    }
}
