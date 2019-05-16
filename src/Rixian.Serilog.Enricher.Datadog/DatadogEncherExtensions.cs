using Rixian.Serilog.Enricher.Datadog;
using Serilog.Configuration;

namespace Serilog
{
    public static class DatadogEnricherExtensions
    {
        public static LoggerConfiguration WithDatadog(this LoggerEnrichmentConfiguration enrich)
        {
            return enrich?.With<DatadogSpanIdEnricher>()
                ?.Enrich?.With<DatadogTraceIdEnricher>();
        }
    }
}
