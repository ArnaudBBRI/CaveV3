using System;
using UnityEngine;

namespace Buildwise.BIM
{
    [CreateAssetMenu(menuName = "Buildwise/Alternative Materials Per Category", fileName = "Alternative Materials Per Category")]
    public class AlternativeMaterialsPerCategorySO : ScriptableObject
    {
        public BIMCategory[] Categories;
        public MaterialsArray[] Materials;

        [Serializable]
        public class MaterialsArray
        {
            public Material[] Items;
        }
    }
}