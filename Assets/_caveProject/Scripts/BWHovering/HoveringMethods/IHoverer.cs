using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Hovering
{
    public interface IHoverer
    {
        /// <summary>
        /// Checks if an object is hoverable by this hoverer.
        /// </summary>
        /// <param name="go">The GameObject to be checked</param>
        void Check(GameObjectPair go);
    }
}