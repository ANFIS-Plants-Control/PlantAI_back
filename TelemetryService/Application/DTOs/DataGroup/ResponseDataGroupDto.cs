using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DataGroup
{
    public record ResponseDataGroupDto(int Id, DateTime date, int MqttClient);
}
