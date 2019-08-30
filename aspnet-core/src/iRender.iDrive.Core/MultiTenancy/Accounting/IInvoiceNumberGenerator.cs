using System.Threading.Tasks;
using Abp.Dependency;

namespace iRender.iDrive.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}