using Web.Model.ViewModel;
using Web.Models;

namespace Web.Contracts
{
    public interface IRecordService
    {
        Task<Guid> CreateRecord(RegistrationModel recordModel);
       Task<RecordsViewModel> GetAllRecords();
    }
}
