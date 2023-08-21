using UnityAtoms.BaseAtoms;
using Buildwise.BIM;

namespace Buildwise.Hovering
{
    public class RayCastBasedBIMHoverer : BaseHoverer
    {
        public override void Check(GameObjectPair go)
        {
            if (go.Item1 == null)
            {
                return;
            }
            BIMObject bimObject;
            if (go.Item1.TryGetComponent(out bimObject))
            {
                ObjectRecognized.Raise(go.Item1);
            }
        }
    }
}