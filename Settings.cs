using System.ComponentModel;
using System.Configuration;

namespace _3mpacador4.Properties
{
    // Esta clase le permite controlar eventos específicos en la clase de configuración:
    //  El evento SettingChanging se desencadena antes de cambiar un valor de configuración.
    //  El evento PropertyChanged se desencadena después de cambiar el valor de configuración.
    //  El evento SettingsLoaded se desencadena después de cargar los valores de configuración.
    //  El evento SettingsSaving se desencadena antes de guardar los valores de configuración.
    internal sealed partial class Settings
    {
        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
            // Agregar código para administrar aquí el evento SettingChangingEvent.
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
            // Agregar código para administrar aquí el evento SettingsSaving.
        }
    }
}