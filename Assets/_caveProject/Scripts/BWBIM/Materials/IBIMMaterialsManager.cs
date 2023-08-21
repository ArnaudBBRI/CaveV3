using UnityEngine;

namespace Buildwise.BIM
{
    /// <summary>
    /// Defines how materials are applied on a global scale.
    /// </summary>
    public interface IBIMMaterialsManager
    {
        AlternativeMaterialsPerCategorySO AlternativeMaterialsPerCategory { get; set; }

        /// <summary>
        /// Colors all IBIMObjectMaterialHandler objects by their BIM Category.
        /// </summary>
        void ColorByBIMCategory();
        /// <summary>
        /// Colors all IBIMObjectMaterialHandler objects that have the same BIMCategory than selection 
        /// by their BIM Category. The other IBIMObjectMaterialHandler objects are colored transparent.
        /// </summary>
        /// <param name="selection">The object of which catergory has to be drawn</param>
        void ColorByTransparentBIMCategory(Transform selection);
        void ColorByMaterials();
        /// <summary>
        /// Colors all BIM Objects of a given BIMCategory with Material mat.
        /// All submeshes are applied the same material.
        /// </summary>
        /// <param name="category">The BIMCategory to color</param>
        /// <param name="mat">The material to use for the coloring</param>
        void ColorWholeCategoryByNextMaterial(BIMCategory category, Material mat);
    }
}
