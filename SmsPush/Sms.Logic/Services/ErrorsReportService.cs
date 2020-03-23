using Sms.Domain.Services;
using Sms.Logic.Mappers;
using Sms.Model.DTO;
using Sms.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Logic.Services
{
    public class ErrorsReportService : IErrorsReportService
    {
        private readonly IErrorsReportRepository _errorsReportRepository;
        public ErrorsReportService(IErrorsReportRepository errorsReportRepository)
        {
            _errorsReportRepository = errorsReportRepository;
        }
        public async Task Publish(ErrorsReportDTO error)
        {
           await _errorsReportRepository.Publish(MapToModel.ErrorsReportToModel(error));
        }
    }
}
