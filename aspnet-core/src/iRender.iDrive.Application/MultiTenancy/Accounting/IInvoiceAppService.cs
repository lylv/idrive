using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using iRender.iDrive.MultiTenancy.Accounting.Dto;

namespace iRender.iDrive.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
