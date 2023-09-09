using System.Collections.Generic;
using Components;
using Grid.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Grid
{
    public class PlaceObjectOnTileSystem : IEcsRunSystem
    {
        private readonly List<Vector3Int> m_reservedTiles = new();
        private EcsFilter<MovableDropObjectData, PlayerInputData> m_filter;

        public void Run()
        {
            foreach (int i in m_filter)
            {
                ref MovableDropObjectData movableDropData = ref m_filter.Get1(i);
                ref PlayerInputData playerInputData = ref m_filter.Get2(i);

                if (!playerInputData.isMouseClick)
                {
                    continue;
                }

                if (m_reservedTiles.Contains(movableDropData.TilePosition))
                {
                    continue;
                }
                
                m_reservedTiles.Add(movableDropData.TilePosition);
                Object.Instantiate(movableDropData.gameObject, movableDropData.gameObject.transform.position, movableDropData.gameObject.transform.rotation);
            }
        }
    }
}