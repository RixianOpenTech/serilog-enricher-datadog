using Rixian.Serilog.Enricher.Datadog;
using Serilog;
using Serilog.Configuration;
using System;

namespace Serilog.Configuration
{
    public static class DatadogEncherExtensions
    {
        public static LoggerConfiguration WithDatadog(this LoggerEnrichmentConfiguration enrich)
        {
            return enrich?.With<DatadogSpanIdEnricher>()
                ?.Enrich?.With<DatadogTraceIdEnricher>();
        }
    }
}
