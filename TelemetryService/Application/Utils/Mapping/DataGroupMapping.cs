using Application.DTOs.DataGroup;
using Core.Models;

namespace Application.Utils.Mapping
{
    public static class DataGroupMapping
    {

        public static ResponseDataGroupDto ToResponse(this DataGroup data)
            => new ResponseDataGroupDto(data.Id, data.GroupDate, data.MqttClientId, data.TopicId);

    }
}
