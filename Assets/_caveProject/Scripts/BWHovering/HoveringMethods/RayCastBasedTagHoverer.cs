using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Hovering
{
    public class RayCastBasedTagHoverer : BaseHoverer
    {
        [SerializeField] 
        public string selectableTag = "Selectable";

        public override void Check(GameObjectPair go)
        {
            if (go.Item1 == null)
            {
                return;
            }
            if (go.Item1.CompareTag(selectableTag))
            {
                ObjectRecognized.Raise(go.Item1);
            }
        }
    }
}