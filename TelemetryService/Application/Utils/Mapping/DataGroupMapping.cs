using Application.DTOs.DataGroup;
using Application.DTOs.SensorData;
using Core.Models;

namespace Application.Utils.Mapping
{
    public static class DataGroupMapping
    {

        public static ResponseDataGroupDto ToResponse(this DataGroup data)
            => new ResponseDataGroupDto(data.Id, data.GroupDate, data.MqttClientId, data.TopicId);

        public static GroupedDataResponseDto ToGroupedDataResponse(this DataGroup data)
            => new GroupedDataResponseDto(data.Id, data.GroupDate, data.SensorsData.Select(x => x.ToResponseDto()));
    }
}
