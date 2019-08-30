using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iRender.iDrive.Extensions
{
    public static class ImageSourceExtensions
    {
        public static async Task<Stream> GetSourceStreamAsync(this ImageSource imageSource)
        {
            return await ((StreamImageSource)imageSource).Stream(CancellationToken.None);
        }
    }
}