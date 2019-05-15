using Datadog.Trace;
using Serilog.Core;
using Serilog.Events;

namespace Rixian.Serilog.Enricher.Datadog
{
    public class DatadogSpanIdEnricher : ILogEventEnricher
    {
        public const string PropertyName = "dd.span_id";

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var value = Tracer.Instance?.ActiveScope?.Span?.SpanId;

            if (value != null)
            {
                var property = propertyFactory.CreateProperty(PropertyName, value);
                logEvent.AddPropertyIfAbsent(property);
            }
        }
    }
}
