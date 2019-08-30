using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
