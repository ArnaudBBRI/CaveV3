using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buildwise.BIM
{
    [CreateAssetMenu(menuName = "Buildwise/Categories Materials", fileName = "Categories Materials")]
    public class CategoriesMaterialsSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public List<Material> CategoryMaterials = new List<Material>();
        public List<BIMCategory> Categories = new List<BIMCategory>();

        public Dictionary<BIMCategory, Material> MaterialsPerCategory 
        {
            get => _materialsPerCategory; 
        }
        private Dictionary<BIMCategory, Material> _materialsPerCategory;

        public void OnBeforeSerialize()
        {
            // Nothing to do
        }

        public void OnAfterDeserialize()
        {
            _materialsPerCategory = new Dictionary<BIMCategory, Material>();

            for (int i = 0; i != Math.Min(CategoryMaterials.Count, Categories.Count); i++)
                _materialsPerCategory.Add(Categories[i], CategoryMaterials[i]);
        }
    }
}
