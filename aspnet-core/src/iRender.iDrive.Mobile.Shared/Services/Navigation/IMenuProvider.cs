using System.Collections.Generic;
using MvvmHelpers;
using iRender.iDrive.Models.NavigationMenu;

namespace iRender.iDrive.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}