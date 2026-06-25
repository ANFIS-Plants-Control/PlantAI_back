namespace Application.DTOs.FnnAnswerDTOs
{
    public record FnnAnswerCreateDto(int FnnId, int DataGroupId, int UserId, double Answer, DateTime DateTime);
}