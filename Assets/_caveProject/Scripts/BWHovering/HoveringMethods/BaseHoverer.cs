using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Buildwise.Hovering
{
    public abstract class BaseHoverer : MonoBehaviour, IHoverer
    {
        public GameObjectEvent ObjectRecognized;
        public abstract void Check(GameObjectPair go);
    }
}