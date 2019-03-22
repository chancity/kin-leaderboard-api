﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kin_leaderboard_api.Repository;
using Microsoft.Extensions.Logging;

namespace kin_leaderboard_api.Services
{
    public class OperationsService
    {
        private ILogger _logger;
        private OperationsRepository _operationsRepository;
        public OperationsService(ILoggerFactory loggerFactory, OperationsRepository operationsRepository)
        {
            _logger = loggerFactory.CreateLogger<OperationsService>();
            _operationsRepository = operationsRepository;
        }
    }

}