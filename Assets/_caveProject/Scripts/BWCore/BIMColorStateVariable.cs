using UnityEngine;

namespace Buildwise.Core
{
    [CreateAssetMenu(menuName = "Buildwise/Variables/BIMColorState", fileName = "BIMColorStateVariable")]
    public class BIMColorStateVariable : ScriptableObject
    {
        public BIMColorState Value;
    }
}