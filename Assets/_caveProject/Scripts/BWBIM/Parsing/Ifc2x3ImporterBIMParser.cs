using UnityEngine;
using IfcToolkit;
//using Buildwise.Interactions;
using System.Collections.Generic;

namespace Buildwise.BIM
{

    public class Ifc2x3ImporterBIMParser : BIMParser
    {
        private IBIMObjectMaterialHandler _bimObjectMaterialHandler;
        private IBIMMaterialsManager _bimMaterialsManager;
        private Dictionary<BIMCategory, Material[]> _alternativeMaterials;

        /// <summary>
        /// Parse a BIM Model based on a root GameObject. Every object under the root GameObject is parsed.
        /// </summary>
        /// <param name="root">The root GameObject</param>
        public override void ParseBIMModel(GameObject root)
        {
            //bool usingMazeFlystick = IsMazeFlystickUsed();
            if (!CheckIfcVersion(root)) return; // TODO: Show error message to user

            _bimObjectMaterialHandler = materialsManager.GetComponent<IBIMObjectMaterialHandler>();
            _bimMaterialsManager = materialsManager.GetComponent<IBIMMaterialsManager>();
            _alternativeMaterials = new Dictionary<BIMCategory, Material[]>();
            BIMCategory[] categories = _bimMaterialsManager.AlternativeMaterialsPerCategory.Categories;
            for (int i = 0; i < categories.Length; i++)
            {
                _alternativeMaterials.Add(categories[i], _bimMaterialsManager.AlternativeMaterialsPerCategory.Materials[i].Items);
            }
            /*
            var allBos = FindObjectsOfType<Transform>();
            foreach (var bo in allBos)
            {
                if (bo.TryGetComponent(out IBIMMaterialsManager bmm))
                {
                    _bimObjectMaterialHandler = bmm.TypeOfBIMObjectMaterialHandler;
                    _alternativeMaterials = new Dictionary<BIMCategory, Material[]>();
                    BIMCategory[] categories = bmm.AlternativeMaterialsPerCategory.Categories;
                    for (int i = 0; i < categories.Length; i++)
                    {
                        _alternativeMaterials.Add(categories[i], bmm.AlternativeMaterialsPerCategory.Materials[i].Items);
                    }
                    break;
                }
            }
            */

            Transform[] allChildren = root.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                //Parse(allChildren[i].gameObject, usingMazeFlystick);
                Parse(allChildren[i].gameObject, false);
            }
        }

        public override void ParseBIMModel()
        {
            GameObject root = bimRoot;
            if (root == null)
            {
                Debug.LogError("No BIM root specified, can't parse model!");
                return;
            }
            else
            {
                ParseBIMModel(root);
            }
        }

        public override void Parse(GameObject go, bool usingMazeFlystick)
        {
            IfcAttributes ifca;
            if (go.TryGetComponent(out ifca))
            {
                BIMObject bo;
                if (go.TryGetComponent(out bo));
                else bo = go.AddComponent<BIMObject>(); //TODO: replace by interface
                if (!go.TryGetComponent(out IBIMObjectMaterialHandler bimObjectMaterialHandler))
                {
                    if (_bimObjectMaterialHandler != null)
                    {
                        go.AddComponent(_bimObjectMaterialHandler.GetType()); // TODO : replace with PropertyDrawer
                    }
                }
                /*
                if (usingMazeFlystick)
                {
                    if (go.TryGetComponent(out FlystickEventListener fel))
                    {
                        fel.ActionIntEvent = ActionIntEvent;
                    }
                    else
                    {
                        fel = go.AddComponent<FlystickEventListener>();
                        fel.ActionIntEvent = ActionIntEvent;
                    }
                }
                */
                AssignCategoryAndFamily(ifca, bo);
                if (go.TryGetComponent(out IBIMObjectMaterialHandler materialHandler))
                {
                    foreach (var kvp in _alternativeMaterials)
                    {
                        if (bo.Category == kvp.Key)
                        {
                            materialHandler.AlternativeMaterials = kvp.Value;
                            break;
                        }
                    }
                }
            }
        }

        private void AssignCategoryAndFamily(IfcAttributes ifca, IBIMObject bo)
        {
            int index = 0;
            foreach (var attribute in ifca.attributes)
            {
                if (attribute == "IfcElementType")
                {
                    var ifcType = ifca.values[index];
                    if (ifcType.Contains("IfcWall")) bo.Category = BIMCategory.Walls;
                    else if (ifcType.Contains("IfcSlab")) bo.Category = BIMCategory.Floors;
                    else if (ifcType.Contains("IfcFlow")) bo.Category = BIMCategory.HVAC;
                    else if (ifcType.Contains("IfcWindow")) bo.Category = BIMCategory.Windows;
                    else if (ifcType.Contains("IfcDoor")) bo.Category = BIMCategory.Doors;
                    else if (ifcType.Contains("IfcBeam")) bo.Category = BIMCategory.Structural;
                    else bo.Category = BIMCategory.UnClassified;
                    bo.Family = BIMFamily.UnClassified;
                    break;
                }
                index++;
            }
        }

        private bool CheckIfcVersion(GameObject go)
        {
            if (go.TryGetComponent(out IfcHeader header))
            {
                int index = 0;
                foreach (var h in header.headers)
                {
                    if (h == "schema_identifiers")
                    {
                        string schema = header.values[index];
                        return (schema == "IFC2X3");
                    }
                    index++;
                }
            }
            return false;
        }
    }
}