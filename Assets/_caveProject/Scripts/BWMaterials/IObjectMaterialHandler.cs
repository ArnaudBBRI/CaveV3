using UnityEngine;

namespace Buildwise.Materials
{
    public interface IObjectMaterialHandler
    {
        /// <summary>
        /// The list of alternative materials for this object, without the initial one.
        /// </summary>
        Material[] AlternativeMaterials { get; set; }
        void ApplyMaterial(Material mat);
        void ApplyMaterialOnSubmesh(int subMeshIndex, Material mat);
        void ApplyNextAlternativeMaterial(int subMeshIndex);
        void ApplyNextAlternativeMaterialOnAllSubmeshes(int subMeshIndex);
        Material GetNextMaterial(int subMeshIndex);
    }
}