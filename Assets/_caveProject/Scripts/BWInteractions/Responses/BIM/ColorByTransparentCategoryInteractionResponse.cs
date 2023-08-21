using UnityEngine;
using Buildwise.BIM;
using Buildwise.Core;

namespace Buildwise.Interactions
{
    public class ColorByTransparentCategoryInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        private IBIMMaterialsManager _bimMaterialsManager;
        [SerializeField] private BIMColorStateVariable _bimColorState;

        private void Start()
        {
            var allBos = FindObjectsOfType<Transform>();
            foreach (var bo in allBos)
            {
                if (bo.GetComponent<IBIMMaterialsManager>() != null)
                {
                    _bimMaterialsManager = bo.GetComponent<IBIMMaterialsManager>();
                    break;
                }
            }
        }
        
        public void OnAction(Transform selection, RaycastHit hit)
        {
            if (_bimMaterialsManager == null) return;

            if (_bimColorState.Value != BIMColorState.PerCategoryTransparent)
            {
                _bimMaterialsManager.ColorByTransparentBIMCategory(selection);
            }
            else _bimMaterialsManager.ColorByMaterials();
        }
    }
}