using Buildwise.BIM;
using UnityEngine;

namespace Buildwise.Hovering
{
    public abstract class ShowBIMInfoOnHoveringBase : MonoBehaviour, IHoveringResponse
    {
        protected IBIMInfoFormatter _formatter;
        [SerializeField] public GameObject infoCanvas;

        protected virtual void Awake()
        {
            var allObjs = FindObjectsOfType<Transform>();
            foreach (var obj in allObjs)
            {
                if (obj.TryGetComponent(out IBIMInfoFormatter bIMInfoFormatter))
                {
                    _formatter = bIMInfoFormatter;
                    break;
                }
            }
            if (_formatter == null)
            {
                Debug.LogError("No BIMInfoFormatter has been found!");
            }
        }
        
        public void ClearResponse(Transform selection)
        {
            if (_formatter == null || infoCanvas == null) return;
            infoCanvas.SetActive(false);
        }

        public void OnDeselect(Transform selection)
        {
            if (_formatter == null || infoCanvas == null) return;
            infoCanvas.SetActive(false);
        }

        public void OnMaterialChange()
        {
            // Do Nothing
        }

        public abstract void OnSelect(Transform selection);
    }
}