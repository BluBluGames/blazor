using BluBlu.Invoices.Domain.Localization;
using System.Text.Json;

namespace BluBlu.Invoices.Infrastructure.Localization;

public class JsonLocalizationService : IJsonLocalizationService
{
    private Dictionary<string, Dictionary<string, string>> _localizations;

    public JsonLocalizationService()
    {
        LoadLocalizations();
    }

    private void LoadLocalizations()
    {
        _localizations = new Dictionary<string, Dictionary<string, string>>();
        var filePath = Path.Combine("./Localization/localization.json");

        if (File.Exists(filePath))
        {
            var content = File.ReadAllText(filePath);
            _localizations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(content);
        }
    }

    public string Get(string key, string culture)
    {
        if (_localizations.ContainsKey(culture) && _localizations[culture].ContainsKey(key))
        {
            return _localizations[culture][key];
        }
        else
        {
            // Return the key if no translation is found
            return key;
        }
    }

}
