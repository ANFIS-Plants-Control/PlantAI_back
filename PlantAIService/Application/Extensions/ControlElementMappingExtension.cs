using Application.DTOs.ControlElementDTOs;
using Core.Models;

namespace Application.Extensions
{
    public static class ControlElementMappingExtension
    {

        public static ControlElement ToEntity(this ControlElementCreateDto dto)
            => new ControlElement() { Name = dto.Name, Location = dto.Location, Description = dto.Description };

        public static ResponseControlElementDto ToResponseDto(this ControlElement entity)
            => new ResponseControlElementDto(entity.Id, entity.Name, entity.Location, entity.Description);

    }
}
