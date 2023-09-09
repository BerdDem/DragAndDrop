using Components;
using Grid;
using Grid.Components;
using Leopotam.Ecs;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class ESCStartup : MonoBehaviour
{
    [FormerlySerializedAs("dropObjectData")] public PlaceObjectData placeObjectData;

    private EcsWorld m_ecsWorld;
    private EcsSystems m_systems;
 
    private void Start()
    {
        m_ecsWorld = new EcsWorld();
        m_systems = new EcsSystems(m_ecsWorld);
    	
        m_systems.Add(new PlayerInitSystem())
            .Add(new PlaceObjectTranslatePositionSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlaceObjectOnTileSystem())
            .Inject(placeObjectData)
            .Init();
    }
 
    private void Update()
    {
        m_systems?.Run(); 
    }
 
    private void OnDestroy()
    {
        m_systems?.Destroy(); 
        m_systems = null;
        m_ecsWorld?.Destroy();
        m_ecsWorld = null;
    }
}
