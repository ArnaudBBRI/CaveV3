using UnityAtoms.BaseAtoms;
using Buildwise.Switchable;
using UnityEngine;

namespace Buildwise.Hovering
{
    public class RaycastBasedSwitchableObjectHoverer : BaseHoverer
    {
        [SerializeField] private GameObjectEvent SwitchableObjectRecognized;
        public override void Check(GameObjectPair go)
        {
            if (go.Item1 == null)
            {
                return;
            }
            ISwitchableObject switchableObject;
            if (go.Item1.TryGetComponent(out switchableObject))
            {
                //SwitchableObjectRecognized.Raise(go.Item1);
                ObjectRecognized.Raise(go.Item1);
            }
        }
    }
}