using Buildwise.BIM;
using Buildwise.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class ColorCategoryByNextMaterialInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        [SerializeField] private GameObject _bimMaterialsManagerObject;
        [SerializeField] private BIMColorStateVariable _bimColorState;
        [SerializeField] private GameObjectEvent OnActionApplied;

        private IBIMMaterialsManager _bimMaterialsManager;
        private HelperFunctions _helper;
        
        private void Start()
        {
            if (_bimMaterialsManagerObject == null)
            {
                Debug.LogError("Missing BIMMaterialsManager on ColorCategoryByNextMaterialInteractionResponse");
                return;
            }
            else
            {
                _bimMaterialsManager = _bimMaterialsManagerObject.GetComponent<IBIMMaterialsManager>();
                if (_bimMaterialsManager == null)
                {
                    Debug.LogError("Missing IBIMMaterialsManager Component on the BIMManager");
                    return;
                }
            }
            
            _helper = new HelperFunctions();
        }
        
        public void OnAction(Transform selection, RaycastHit hit)
        {
            if (_bimMaterialsManager == null) return;
            if (_bimColorState.Value != BIMColorState.NoBIMColor) return;
            
            int index = _helper.GetMaterialIndex(selection, hit);
            if (selection.TryGetComponent(out BIMObjectMaterialHandler bo))
            {
                OnActionApplied.Raise(selection.gameObject);
                Material mat = bo.GetNextMaterial(index);
                BIMCategory bimCategory = bo.GetComponent<IBIMObject>().Category;
                _bimMaterialsManager.ColorWholeCategoryByNextMaterial(bimCategory, mat);
            }
        }
    }
}