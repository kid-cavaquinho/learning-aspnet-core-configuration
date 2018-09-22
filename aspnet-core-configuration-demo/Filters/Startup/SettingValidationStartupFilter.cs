using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApplication.Filters.Startup.Interfaces;

namespace WebApplication.Filters
{
    public class SettingValidationStartupFilter : IStartupFilter
    {
        private readonly ILogger<SettingValidationStartupFilter> _logger;
        private readonly IEnumerable<IValidatable> _settings;

        public SettingValidationStartupFilter(ILogger<SettingValidationStartupFilter> logger, IEnumerable<IValidatable> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            foreach (var setting in _settings)
            {
                var (results, valid) = setting.Validate();

                if (valid)
                {
                    continue;
                }

                var settingName = setting.GetType().Name;
                var message = $"Invalid {settingName} configuration. {string.Join(",", results)}";
                var invalidOperationException = new InvalidOperationException(message);

                _logger.LogError(invalidOperationException, message);

                throw invalidOperationException;
            }

            return next;
        }
    }
}
