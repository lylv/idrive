using System.Threading.Tasks;
using iRender.iDrive.Views;
using Xamarin.Forms;

namespace iRender.iDrive.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
