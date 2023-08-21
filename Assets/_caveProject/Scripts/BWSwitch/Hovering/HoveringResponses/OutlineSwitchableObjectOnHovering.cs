using UnityEngine;
using Buildwise.Core;
using Buildwise.Switchable;

namespace Buildwise.Hovering
{
    public class OutlineSwitchableObjectOnHovering : MonoBehaviour, IHoveringResponse
    {
        [SerializeField] private Color _outlineColor = Color.red;
        [SerializeField] private float _outlineWidth = 5f;
        [SerializeField] private Outline.Mode _outlineMode = Outline.Mode.OutlineVisible;
        private Material _outlineMaskMaterial;
        private Material _outlineFillMaterial;
        [SerializeField] public GameObject outlineMaterialsHolder;

        private void Awake()
        {
            _outlineMaskMaterial = outlineMaterialsHolder.transform.Find("OutlineMask").GetComponent<MeshRenderer>().sharedMaterial;
            _outlineFillMaterial = outlineMaterialsHolder.transform.Find("OutlineFill").GetComponent<MeshRenderer>().sharedMaterial;
        }

        public void OnSelect(Transform selection)
        {
            if (!selection.TryGetComponent<ISwitchableObject>(out ISwitchableObject so)) return;
            Outline selectionRenderer;
            if (selection.gameObject.TryGetComponent<Outline>(out selectionRenderer))
            {
                selectionRenderer.enabled = true;
            }
            else
            {
                selectionRenderer = selection.gameObject.AddComponent<Outline>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.OutlineMode = _outlineMode;
                    selectionRenderer.OutlineColor = _outlineColor;
                    selectionRenderer.OutlineWidth = _outlineWidth;
                    selectionRenderer.outlineMaskMaterial = Instantiate(_outlineMaskMaterial);
                    selectionRenderer.outlineFillMaterial = Instantiate(_outlineFillMaterial);
                    selectionRenderer.outlineMaskMaterial.name = "OutlineMask (Instance)";
                    selectionRenderer.outlineFillMaterial.name = "OutlineFill (Instance)";
                    selectionRenderer.enabled = false;
                    selectionRenderer.enabled = true;
                    selectionRenderer.UpdateMaterialProperties();
                }
            }
        }

        public void OnDeselect(Transform selection)
        {
            if (selection == null) return;
            Outline selectionRenderer;
            if (selection.gameObject.TryGetComponent(out selectionRenderer))
            {
                selectionRenderer.enabled = false;
            }
        }

        public void ClearResponse(Transform selection)
        {
            OnDeselect(selection);
        }

        public void OnMaterialChange()
        {
            // Nothing to do.
        }
    }
}
