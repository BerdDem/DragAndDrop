using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Grid
{
    public class PlaceObjectTranslatePositionSystem : IEcsRunSystem
    {
        private PlaceObjectData m_staticData; 
        
        private EcsWorld m_world;
        private EcsFilter<MovableDropObjectData> m_dropObjectFilter;
        
        public void Run()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool hit = Physics.Raycast(ray, out RaycastHit hitInfo);
            
            foreach (int i in m_dropObjectFilter)
            {
                ref MovableDropObjectData dropObject = ref m_dropObjectFilter.Get1(i);
                
                if (!hit)
                {
                    dropObject.gameObject.SetActive(false);
                    continue;
                }

                dropObject.gameObject.SetActive(true);
                
                dropObject.TilePosition = m_staticData.tilemap.WorldToCell(hitInfo.point);
                dropObject.gameObject.transform.position = m_staticData.tilemap.GetCellCenterWorld(dropObject.TilePosition);
            }
        }
    }
}