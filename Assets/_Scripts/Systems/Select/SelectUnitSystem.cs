using Client.Components;
using Client.UnityComponents.Services;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class SelectUnitSystem: IEcsRunSystem
    {
        private UnitSelectingService unitSelectingService;
        
        public void Run()
        {
            if (unitSelectingService.SelectedUnit)
            {
                unitSelectingService.SelectedUnit._entity.Get<SelectedFlag>();
            }    
        }
    }
}