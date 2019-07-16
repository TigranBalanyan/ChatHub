using AccountControlService.Models;
using AutoMapper;
using DbAccessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountControlService.Mapping
{
    public class UserDTOToUserEntity : Profile
    {
        public UserDTOToUserEntity()
        {
            CreateMap<UserDTO, UserEntity>();
        }
    }
}
