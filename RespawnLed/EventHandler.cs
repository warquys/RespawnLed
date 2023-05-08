using Neuron.Core.Events;
using Respawning;

namespace RespawnLed;

[Automatic]
public class EventHandler : Listener
{
    private readonly RoomService _room;

    public EventHandler(RoomService room)
    {
        _room = room;
    }

    [EventHandler]
    public void OnSpawn(SpawnTeamEvent ev)
    {
        switch (ev.TeamId)
        {
            case (uint)SpawnableTeamType.NineTailedFox:
                ChangeFacilityColor(Color.blue);
                break;
            case (uint)SpawnableTeamType.ChaosInsurgency:
                ChangeFacilityColor(Color.green);
                break;
            default:
                ChangeFacilityColor(default);
                break;
        }
    }

    private void ChangeFacilityColor(Color color)
    {
        foreach (var room in _room.Rooms)
        {
            room.RoomColor = color;
        }
    }
}
