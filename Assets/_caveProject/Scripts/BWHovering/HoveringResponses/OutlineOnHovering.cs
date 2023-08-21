using UnityEngine;
using Buildwise.Core;

namespace Buildwise.Hovering
{
    /// <summary>
    /// Highlights the hovered object by applying it an outline.
    /// Only reason to modify it is to modify the way it is outlined.
    /// </summary>

    public class OutlineOnHovering : MonoBehaviour, IHoveringResponse
    {
        [SerializeField] private Color _outlineColor = Color.yellow;
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