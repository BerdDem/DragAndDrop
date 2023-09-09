using Grid.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> m_inputFilter;
        
        public void Run()
        {
            foreach (int i in m_inputFilter)
            {
                ref PlayerInputData dropObject = ref m_inputFilter.Get1(i);
                dropObject.isMouseClick = Input.GetMouseButtonDown(0);
            }
        }
    }
}