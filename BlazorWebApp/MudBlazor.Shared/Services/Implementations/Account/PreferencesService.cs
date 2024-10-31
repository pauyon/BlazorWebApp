using Microsoft.JSInterop;
using MudBlazor.Shared.Constants;
using MudBlazor.Shared.Services.Interfaces.Account;

namespace MudBlazor.Shared.Services.Implementations.Account;

public class PreferencesService : IPreferencesService
{
    private readonly IJSRuntime _js;
    private readonly string darkModeKey = "DarkMode";

    public PreferencesService(IJSRuntime js)
    {
        _js = js;
    }

    public bool IsDarkMode { get; private set; }

    public async Task<bool> GetDarkModePreference()
    {
        var isDarkModeString = await _js!.InvokeAsync<string>("localStorage.getItem", darkModeKey);
        return isDarkModeString.ToLower() == "true";
    }

    public async Task SetDarkModePreference(bool isDarkMode)
    {
        UIConstants.IsDarkMode = isDarkMode;
        await _js!.InvokeVoidAsync("localStorage.setItem", darkModeKey, isDarkMode.ToString().ToLower());
    }
}
