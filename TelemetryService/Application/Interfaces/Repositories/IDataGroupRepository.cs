using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface IDataGroupRepository
    {

        public Task SaveAsync(DataGroup data);
        public Task<DataGroup> GetLastGroupAsync();
        public Task<IEnumerable<DataGroup>> GetAllGroupsAsync();
        public Task<DataGroup> GetLastGroupdSensorDataAsync();
    }
}
