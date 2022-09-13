namespace Client.Components.Animation
{
    public enum UnitStateEnum
    {
        Idle,
        Shoot,
        Walk
    }
    
    public struct UnitState
    {
        public UnitStateEnum Value;
    }
}