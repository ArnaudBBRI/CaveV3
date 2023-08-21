using UnityEngine;

namespace Buildwise.Materials
{
    public class ObjectMaterialHandler : MonoBehaviour, IObjectMaterialHandler
    {
        protected Material[] _alternativeMaterials;
        protected Material[] _initialMaterials;
        protected Material[] _previousRealMaterials;
        public Material[] AlternativeMaterials { get => _alternativeMaterials; set => _alternativeMaterials = value; }

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
        }

        public void ApplyMaterial(Material mat)
        {
            if (TryGetComponent(out Renderer r))
            {
                Material[] currentMats = r.sharedMaterials;
                Material[] newMats = new Material[currentMats.Length];
                for (int i = 0; i < currentMats.Length; i++)
                {
                    newMats[i] = mat;
                }
                r.sharedMaterials = newMats;
                _previousRealMaterials = newMats;
            }
        }

        public void ApplyMaterialOnSubmesh(int subMeshIndex, Material mat)
        {
            Debug.Log("Applying material on submesh " + subMeshIndex + " of " + gameObject.name);
            if (!TryGetComponent(out Renderer r)) return;

            Material[] currentMats = GetComponent<Renderer>().sharedMaterials;
            Material[] updatedMats = currentMats;
            for (int i = 0; i < currentMats.Length; i++)
            {
                if (i == subMeshIndex) updatedMats[i] = mat;
            }
            r.sharedMaterials = updatedMats;
            _previousRealMaterials = updatedMats;
        }

        public void ApplyNextAlternativeMaterial(int subMeshIndex)
        {
            if (!TryGetComponent(out Renderer r)) return;

            Material[] currentMats = GetComponent<Renderer>().sharedMaterials;
            Material[] updatedMats = currentMats;

            for (int i = 0; i < currentMats.Length; i++)
            {
                if (i == subMeshIndex)
                {
                    updatedMats[i] = GetNextMaterial(subMeshIndex);
                    break;
                }
            }
            r.sharedMaterials = updatedMats;
            _previousRealMaterials = updatedMats;
        }

        public void ApplyNextAlternativeMaterialOnAllSubmeshes(int subMeshIndex)
        {
            if (!TryGetComponent(out Renderer r)) return;

            Material[] currentMats = GetComponent<Renderer>().sharedMaterials;
            Material[] updatedMats = currentMats;
            Material nextMaterial = GetNextMaterial(subMeshIndex);
            for (int i = 0; i < currentMats.Length; i++)
            {
                updatedMats[i] = nextMaterial;
            }
            r.sharedMaterials = updatedMats;
            _previousRealMaterials = updatedMats;
        }

        /// <summary>
        /// Gets the next material for this object, and for this submesh.
        /// The next material is either in the _alternativeMaterials list, or the initial material.
        /// </summary>
        /// <param name="subMeshIndex">The index of the submesh</param>
        /// <returns>The next Material</returns>
        public Material GetNextMaterial(int subMeshIndex)
        {
            Material output;
            Material mat = GetComponent<Renderer>().sharedMaterials[subMeshIndex];
            if (_alternativeMaterials == null) return mat;

            for (int i = 0; i < _alternativeMaterials.Length - 1; i++)
            {
                if (mat == _alternativeMaterials[i])
                {
                    output = _alternativeMaterials[i + 1];
                    return output;
                }
            }

            if (mat == _alternativeMaterials[_alternativeMaterials.Length - 1])
            {
                output = _initialMaterials[subMeshIndex];
            }
            else output = _alternativeMaterials[0];
            return output;
        }
    }
}