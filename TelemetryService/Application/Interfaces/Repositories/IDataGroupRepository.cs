using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IDataGroupRepository
    {

        public Task SaveAsync(DataGroup data);
        public Task<DataGroup> GetLastGroupAsync();
    }
}
