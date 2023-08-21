namespace Buildwise.BIM
{
    public interface IBIMObject
    {
        BIMCategory Category { get; set; }
        BIMFamily Family { get; set; }
    }
}
