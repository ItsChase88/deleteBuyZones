///////////
//IMPORTS//
///////////

using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

// Specify the namespace for the plugin
namespace deleteBuyZones;

// Specify the main class
public class deleteBuyZones : BasePlugin {
    // Plugin Information
    public override string ModuleName => "Delete Buyzones";
    public override string ModuleAuthor => "Chase88";
    public override string ModuleDescription => "This is a simple plugin that will delete all buyzones on a map.";
    public override string ModuleVersion => "1.0.0";

    // Load function - Called when the plugin is loaded
    public override void Load(bool hotReload) {
        //Hook into the enter buyzone event
        RegisterEventHandler<EventEnterBuyzone>((@event, info) => {

            //Get a list of all the buyzones on the map
            var buyZones = Utilities.FindAllEntitiesByDesignerName<CEntityInstance>("func_buyzone");

            //Loop through each zone in the buyZone
            foreach(var zone in buyZones) {
                //Delete the buyzone.
                zone.Remove();
            }

            //Return and allow Event to continue.
            return HookResult.Continue;
        });
    }
}