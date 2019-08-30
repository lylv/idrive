using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iRender.iDrive.MultiTenancy.HostDashboard.Dto;

namespace iRender.iDrive.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}