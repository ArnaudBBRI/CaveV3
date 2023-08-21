using UnityEngine;
using Buildwise.Materials;
using Buildwise.Core;
using UnityAtoms.BaseAtoms;

namespace Buildwise.Interactions
{
    public class ColorByMaterialInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        [SerializeField] private BIMColorStateVariable _bimColorState;
        private HelperFunctions _helper;

        [SerializeField] private GameObjectEvent OnActionApplied;

        private void Start()
        {
            _helper = new HelperFunctions();
        }
        
        public void OnAction(Transform selection, RaycastHit hit)
        {
            if (_bimColorState.Value != BIMColorState.NoBIMColor) return;
            int index = _helper.GetMaterialIndex(selection, hit);
            
            if (selection.TryGetComponent(out IObjectMaterialHandler bo))
            {
                OnActionApplied.Raise(selection.gameObject);
                Material mat = bo.GetNextMaterial(index);
                bo.ApplyMaterialOnSubmesh(index, mat);
            }
        }
    }
}