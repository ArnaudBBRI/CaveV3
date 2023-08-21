using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Hovering
{
    /// <summary>
    /// This class manages what happens when an object is hovered.
    /// Only one hoverer can be active at a time (because only one object can be hovered at a time). 
    /// So the 1st one that returns true is the one that is used.
    /// Multiple hovering responses are possible.
    /// </summary>

    [DisallowMultipleComponent]
    public class HoveringManager : MonoBehaviour
    {
        private IRayProvider _rayProvider;
        private IHoveringResponse[] _hoveringResponses;
        public GameObjectPairEvent OnHoveringCleared;

        private void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();

            List<IHoveringResponse> responses = new List<IHoveringResponse>();
            foreach (var hoveringResponse in GetComponents<IHoveringResponse>())
            {
                responses.Add(hoveringResponse);
            }
            foreach (var hoveringResponse in GetComponentsInChildren<IHoveringResponse>())
            {
                responses.Add(hoveringResponse);
            }
            _hoveringResponses = responses.ToArray();
        }

        private void Update()
        {
            var ray = _rayProvider.CreateRay();
            _rayProvider.ShootRay(ray);
        }

        public void ApplyHovers(GameObject go)
        {
            if (go != null)
            {
                foreach (var hoveringResponse in _hoveringResponses)
                {
                    hoveringResponse.OnSelect(go.transform);
                }
            }
        }

        public void ClearAllHoveringResponses(GameObjectPair go)
        {
            if (go.Item2 != null)
            {
                foreach (var hoverResponse in GetComponents<IHoveringResponse>())
                {
                    hoverResponse.ClearResponse(go.Item2.transform);
                }
            }
            OnHoveringCleared.Raise(go);
        }

        public void ClearAllHoveringResponses(GameObject go)
        {
            if (go != null)
            {
                foreach (var hoverResponse in GetComponents<IHoveringResponse>())
                {
                    hoverResponse.ClearResponse(go.transform);
                }
            }
        }
    }
}
