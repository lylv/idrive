using Xamarin.Forms.Internals;

namespace iRender.iDrive.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}