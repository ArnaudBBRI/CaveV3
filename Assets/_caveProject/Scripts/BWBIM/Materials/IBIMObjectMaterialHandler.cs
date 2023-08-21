using System.Collections.Generic;
using UnityEngine;
using Buildwise.Materials;

namespace Buildwise.BIM
{
    /// <summary>
    /// Defines how materials are applied to a BIMObject.
    /// For instance, a BIMObject can have a list of alternative materials, and this class defines how to apply them.
    /// Or calling ApplyMaterial on an object with several materials could apply the same material to all submeshes, or not.
    /// </summary>
    public interface IBIMObjectMaterialHandler : IObjectMaterialHandler
    {
        /// <summary>
        /// Replaces all materials of the object by its BIMCategory Material.
        /// </summary>
        /// <param name="categoriesMaterials">The list of Materials per Category</param>
        void ApplyCategoryMaterial(Dictionary<BIMCategory, Material> categoriesMaterials);
        void ApplyTransparentCategoryMaterial(Material transparentMaterial);
        void UnApplyCategoryMaterial();
    }
}