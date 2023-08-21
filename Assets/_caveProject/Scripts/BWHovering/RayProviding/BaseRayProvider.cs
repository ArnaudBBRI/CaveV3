using UnityEngine;
using UnityAtoms.BaseAtoms;
using Buildwise.Core;

namespace Buildwise.Hovering
{
    public abstract class BaseRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        private GameObjectVariable _hoveredObject;
        [SerializeField]
        private RayCastHitVariable _hoveredHit;

        protected CaveControls _caveControls;

        private void Awake()
        {
            _caveControls = ControlsManager.CaveControls;
        }

        public abstract Ray CreateRay();
        public void ShootRay(Ray ray)
        {
            if (Physics.Raycast(ray, out var hit))
            {
                _hoveredObject.Value = hit.transform.gameObject;
                _hoveredHit.Value = hit;
            }
            else
            {
                _hoveredObject.Value = null;
                _hoveredHit.Value = new RaycastHit();
            }
        }
    }
}