using UnityEngine;

namespace Buildwise.BIM
{
    public interface IBIMInfoFormatter
    {
        string Format(GameObject bimObject);
    }
}