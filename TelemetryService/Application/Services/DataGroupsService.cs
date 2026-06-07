using Application.DTOs.DataGroup;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;
using Core.Models;

namespace Application.Services
{
    public class DataGroupsService : IDataGroupService
    {
        private readonly IDataGroupRepository _repository;
        public DataGroupsService(IDataGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseDataGroupDto>> GetAllAsync()
        {
            var response = await _repository.GetAllGroupsAsync();
            return response.Select(x => x.ToResponse());
        }

        public async Task<ResponseDataGroupDto> SaveAsync(int MqttClientId, int topicId)
        {
            DataGroup data = new DataGroup { GroupDate  = DateTime.UtcNow, MqttClientId = MqttClientId, TopicId = topicId };
            await _repository.SaveAsync(data);
            var entity = await _repository.GetLastGroupAsync();
            return entity.ToResponse();
        }
    }
}
