using Application.DTOs;

namespace Application.Interfaces.Anfis
{
    public interface IAnfisAnswerProvider
    {

        Task<double> GetNetAnswer(ClimatStatusDto dto);

    }
}
