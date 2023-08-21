/*
using Buildwise.Interactions;
using System.Collections.Generic;
using UnityEngine;

namespace Buildwise.BIM
{
    /// <summary>
    /// This class implements the IBIMObjectParser interface and is used to parse the BIM data from a GameObject 
    /// that has been preprocessed with VirtualMaze scripts, and therefore has a MetadataContent Component.
    /// </summary>
    public class MazeBIMParser : BIMParser
    {
        private IBIMObjectMaterialHandler _bimObjectMaterialHandler;
        private Dictionary<BIMCategory, Material[]> _alternativeMaterials;

        /// <summary>
        /// Parse a BIM Model based on a root GameObject. Every object under the root GameObject is parsed.
        /// </summary>
        /// <param name="root">The root GameObject</param>
        public override void ParseBIMModel(GameObject root)
        {
            bool usingMazeFlystick = IsMazeFlystickUsed();
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

            Transform[] allChildren = root.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < allChildren.Length; i++)
            {
                Parse(allChildren[i].gameObject, usingMazeFlystick);
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

        /// <summary>
        /// Parse a single BIM Object
        /// </summary>
        /// <param name="go">The GameObject to parse</param>
        public override void Parse(GameObject go, bool usingMazeFlystick)
        {
            MetadataContent mdc;
            if (go.TryGetComponent(out mdc))
            {
                BIMObject bo;
                if (go.TryGetComponent(out bo)) ;
                else bo = go.AddComponent<BIMObject>(); //TODO: replace by interface
                if (!go.TryGetComponent(out IBIMObjectMaterialHandler bimObjectMaterialHandler))
                {
                    if (_bimObjectMaterialHandler != null) go.AddComponent(_bimObjectMaterialHandler.GetType()); // TODO : replace with PropertyDrawer
                }
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
                
                AssignCategoryAndFamily(mdc, bo);
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

        private void AssignCategoryAndFamily(MetadataContent mdc, IBIMObject bo)
        {
            int c_id = mdc.Keys.IndexOf("Category"); // 'magic' string??
            int f_id = mdc.Keys.IndexOf("Family"); // 'magic' string??
            string categoryValue = mdc.Values[c_id];
            string familyValue = mdc.Values[f_id];
            if (categoryValue.Contains("Wall") && !familyValue.Contains("Curtain")) bo.Category = BIMCategory.Walls;
            else if (categoryValue.Contains("Window")) bo.Category = BIMCategory.Windows;
            else if (categoryValue.Contains("Door")) bo.Category = BIMCategory.Doors;
            else if (categoryValue.Contains("Duct") || categoryValue.Contains("Air") || categoryValue.Contains("Pipe")) bo.Category = BIMCategory.HVAC;
            else if (categoryValue.Contains("Structural")) bo.Category = BIMCategory.Structural;
            else if (categoryValue.Contains("Floor")) bo.Category = BIMCategory.Floors;
            else bo.Category = BIMCategory.UnClassified;
            if (familyValue.Contains("Wall") && !familyValue.Contains("Curtain")) bo.Family = BIMFamily.BasicWall;
            else if (familyValue.Contains("Curtain")) bo.Family = BIMFamily.CurtainWall;
            else if (familyValue.Contains("Floor")) bo.Family = BIMFamily.Floor;
            else if (familyValue.Contains("Roof")) bo.Family = BIMFamily.BasicRoof;
            else if (familyValue.Contains("Duct")) bo.Family = BIMFamily.RoundDuct;
            else bo.Family = BIMFamily.UnClassified;
        }
    }
}
*/