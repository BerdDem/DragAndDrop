using Components;
using Grid.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld m_ecsWorld;
        private PlaceObjectData m_staticData; 
        
        public void Init()
        {
            EcsEntity playerEntity = m_ecsWorld.NewEntity();

            ref PlayerInputData InputData = ref playerEntity.Get<PlayerInputData>();
            ref MovableDropObjectData dropObjectData = ref playerEntity.Get<MovableDropObjectData>();

            dropObjectData.gameObject = Object.Instantiate(m_staticData.dropPrefab);
        }
    }
}