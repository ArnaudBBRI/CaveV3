using UnityEngine;

namespace Buildwise.Hovering
{
    public interface IHoveringResponse
    {
        void OnSelect(Transform selection);
        void OnDeselect(Transform selection);

        /// <summary>
        /// Removes any effect that was applied to the selection.
        /// </summary>
        /// <param name="selection">The Transform of the selected GameObject</param>
        void ClearResponse(Transform selection);

        void OnMaterialChange();
    }
}