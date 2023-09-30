namespace BluBlu.Invoices.Domain.Localization;

public interface IJsonLocalizationService
{
    string Get(string key, string culture);
}