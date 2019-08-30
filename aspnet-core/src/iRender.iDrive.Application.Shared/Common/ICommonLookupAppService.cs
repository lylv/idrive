using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using iRender.iDrive.Common.Dto;
using iRender.iDrive.Editions.Dto;

namespace iRender.iDrive.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}