namespace Client.Components.Build
{
    public enum BuildingPreviewStates
    {
        Allow,
        Prohibited
    }
    
    public struct BuildingPreviewState
    {
        public BuildingPreviewStates State;
    }
}