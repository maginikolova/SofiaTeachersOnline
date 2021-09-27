using AutoMapper;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;

namespace SofiaTeachersOnline.Services.AutoMapperConfigs
{
    public class VideoMapperConfig : Profile
    {
        public VideoMapperConfig()
        {
            this.CreateMap<Video, VideoDTO>();
            this.CreateMap<VideoDTO, Video>();
        }
    }
}
