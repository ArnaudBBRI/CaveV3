using Buildwise.Materials;
using System.Collections.Generic;
using UnityEngine;

namespace Buildwise.BIM
{
    public class BIMObjectMaterialHandler : ObjectMaterialHandler, IBIMObjectMaterialHandler
    {
        private IBIMObject _bimObject;

        private void Start()
        {
            if (TryGetComponent(out Renderer r))
            {
                _initialMaterials = r.sharedMaterials;
                _previousRealMaterials = _initialMaterials;
            }
            else return;
            if (TryGetComponent(out ObjectMaterialOverride bomo))
            {
                _alternativeMaterials = bomo.OverrideMaterials;
            }
            _bimObject = GetComponent<IBIMObject>();
        }

        public void ApplyCategoryMaterial(Dictionary<BIMCategory, Material> categoriesMaterials)
        {
            if (!TryGetComponent(out Renderer r)) return;

            Material catMat = null;
            foreach (var kvp in categoriesMaterials)
            {
                if (kvp.Key == _bimObject.Category)
                {
                    catMat = kvp.Value;
                    break;
                }
            }

            Material[] currentMats = GetComponent<Renderer>().sharedMaterials;
            Material[] categoryMats = new Material[currentMats.Length];

            for (int i = 0; i < categoryMats.Length; i++) categoryMats[i] = catMat;
            r.sharedMaterials = categoryMats;
        }

        public void UnApplyCategoryMaterial()
        {
            if (!TryGetComponent(out Renderer r)) return;
            r.sharedMaterials = _previousRealMaterials;
        }

        /// <summary>
        /// Applies the transparent material to all submeshes of this object.
        /// This transparent material is not recorded as the previous real material.
        /// </summary>
        /// <param name="transparentMaterial">The transparent material to apply</param>
        public void ApplyTransparentCategoryMaterial(Material transparentMaterial)
        {
            if (TryGetComponent(out Renderer r))
            {
                Material[] currentMats = r.sharedMaterials;
                Material[] newMats = new Material[currentMats.Length];
                for (int i = 0; i < currentMats.Length; i++)
                {
                    newMats[i] = transparentMaterial;
                }
                r.sharedMaterials = newMats;
            }
        }
    }
}
