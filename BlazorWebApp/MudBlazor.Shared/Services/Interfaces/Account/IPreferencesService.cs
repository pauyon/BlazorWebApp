namespace MudBlazor.Shared.Services.Interfaces.Account;

public interface IPreferencesService
{
    Task<bool> GetDarkModePreference();

    Task SetDarkModePreference(bool value);
}
