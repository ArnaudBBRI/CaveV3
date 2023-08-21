using Buildwise.Core;
using UnityEngine;

namespace Buildwise.BIM
{
    /// <summary>
    /// Class responsible for managing the materials of the BIM objects on a global scale (not per object).
    /// </summary>
    public class BIMMaterialsManager : MonoBehaviour, IBIMMaterialsManager
    {
        [SerializeField] private BIMColorStateVariable _bimColorState;
        public AlternativeMaterialsPerCategorySO AlternativeMaterialsPerCategory
        {
            get => _alternativeMaterialsPerCategory; set => _alternativeMaterialsPerCategory = value;
        }

        public Material TransparentMaterial;
        public CategoriesMaterialsSO MaterialsPerCategory;
        [SerializeField] private AlternativeMaterialsPerCategorySO _alternativeMaterialsPerCategory;

        private Transform[] _allObjects;

        private void Start()
        {
            _bimColorState.Value = BIMColorState.NoBIMColor;
            _allObjects = FindObjectsOfType<Transform>();
        }

        public void ColorByMaterials()
        {
            foreach (var bo in _allObjects)
            {
                if (bo == null) continue;
                if (bo.TryGetComponent(out IBIMObjectMaterialHandler bomh))
                {
                    bomh.UnApplyCategoryMaterial();
                }
            }
            _bimColorState.Value = BIMColorState.NoBIMColor;
        }
        public void ColorByBIMCategory()
        {
            foreach (var bo in _allObjects)
            {
                if (bo == null) continue;
                if (bo.TryGetComponent(out IBIMObjectMaterialHandler bomh))
                {
                    bomh.ApplyCategoryMaterial(MaterialsPerCategory.MaterialsPerCategory);
                }
            }
            _bimColorState.Value = BIMColorState.PerCategory;
        }

        public void ColorByTransparentBIMCategory(Transform selection)
        {
            if (!selection.TryGetComponent(out IBIMObject b)) return;
            BIMCategory nonTransparentCategory = selection.GetComponent<IBIMObject>().Category;
            foreach (var bo in _allObjects)
            {
                if (bo == null) continue;
                if (!bo.TryGetComponent(out IBIMObject ibo)) continue;
                if (bo.TryGetComponent(out IBIMObjectMaterialHandler bomh))
                {
                    if (ibo.Category == nonTransparentCategory)
                    {
                        bomh.ApplyCategoryMaterial(MaterialsPerCategory.MaterialsPerCategory);
                    }
                    else
                    {
                        bomh.ApplyTransparentCategoryMaterial(TransparentMaterial);
                    }
                }
            }
            _bimColorState.Value = BIMColorState.PerCategoryTransparent;
        }

        public void ColorWholeCategoryByNextMaterial(BIMCategory category, Material mat)
        {
            foreach (var bo in _allObjects)
            {
                if (bo == null) continue;
                if (!bo.TryGetComponent(out IBIMObject ibo)) continue;
                if (bo.TryGetComponent(out IBIMObjectMaterialHandler bomh))
                {
                    if (ibo.Category == category)
                    {
                        bomh.ApplyMaterial(mat);
                    }
                }
            }
        }
    }
}