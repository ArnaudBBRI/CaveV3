using UnityEngine;

namespace Buildwise.Interactions
{
    public interface IInteractionResponse
    {
        void OnAction(Transform selection, RaycastHit hit);
    }
}