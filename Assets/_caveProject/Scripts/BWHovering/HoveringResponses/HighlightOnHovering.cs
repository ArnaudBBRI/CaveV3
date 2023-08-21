using System.Collections;
using UnityEngine;

namespace Buildwise.Hovering
{
    /// <summary>
    /// Highlights the hovered object by applying it a given 'highlight' color.
    /// Only reason to modify it is to modify the way it is highlighted.
    /// </summary>
    public class HighlightOnHovering : MonoBehaviour, IHoveringResponse
    {
        [SerializeField] private Color highlightColor = Color.red;
        [SerializeField] private float highlightDuration = 0.8f;
        private Color[] _initialColors;
        private Coroutine[] _highlightCoroutines;
        private Transform _lastHighlightedObject;
        private Material[] _initialMaterials;
        
        public void OnSelect(Transform selection)
        {
            if (_lastHighlightedObject != null && _lastHighlightedObject == selection) return;
            if (_lastHighlightedObject != null && _lastHighlightedObject != selection) ClearResponse(_lastHighlightedObject);
            _lastHighlightedObject = selection;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                _initialMaterials = selectionRenderer.sharedMaterials;
                Color[] highlightedColors = new Color[_initialMaterials.Length];
                _initialColors = new Color[_initialMaterials.Length];
                _highlightCoroutines = new Coroutine[_initialMaterials.Length];

                for (int i = 0; i < highlightedColors.Length; i++)
                {
                    _initialColors[i] = _initialMaterials[i].color;
                    highlightedColors[i] = highlightColor;
                    _highlightCoroutines[i] = StartCoroutine(HighlightAndFadeOut(selectionRenderer, highlightedColors[i], _initialColors[i]));
                }
            }
        }
        
        public void OnDeselect(Transform selection)
        {
            // Do nothing, just let it fade out.
        }

        public void ClearResponse(Transform selection)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null && _highlightCoroutines != null)
            {
                foreach (var cr in _highlightCoroutines)
                {
                    StopCoroutine(cr);
                }
                selectionRenderer.sharedMaterials = _initialMaterials;
            }
        }
        public void OnMaterialChange()
        {
            _initialMaterials = _lastHighlightedObject.GetComponent<Renderer>().sharedMaterials;
        }

        private IEnumerator HighlightAndFadeOut(Renderer rend, Color colorStart, Color colorEnd)
        {
            float startTime = Time.time;
            rend.material.color = colorStart;
            yield return null;
            while (Time.time < startTime + highlightDuration)
            {
                rend.material.color = Color.Lerp(colorStart, colorEnd, (Time.time - startTime) / highlightDuration);
                yield return null;
            }
            rend.sharedMaterials = _initialMaterials;
        }
    }
}