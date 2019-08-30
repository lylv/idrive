using Abp.Application.Services;
using iRender.iDrive.Tenants.Dashboard.Dto;

namespace iRender.iDrive.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();

        GetDashboardDataOutput GetDashboardData(GetDashboardDataInput input);

        GetSalesSummaryOutput GetSalesSummary(GetSalesSummaryInput input);

        GetRegionalStatsOutput GetRegionalStats();

        GetGeneralStatsOutput GetGeneralStats();
    }
}
