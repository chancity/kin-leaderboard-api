using AutoMapper;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Services.Abstract;
using Microsoft.Extensions.Logging;

namespace kin_leaderboard_api.Services
{
    public class OperationsService : AbstractService<AppOperationDto, Operation, long>
    {

        public OperationsService(ILoggerFactory loggerFactory, ApplicationContext context, IMapper mapper) 
            : base(loggerFactory.CreateLogger<OperationsService>(), context, mapper) {}
    }

}
