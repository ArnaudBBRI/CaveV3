using UnityEngine;

namespace Buildwise.BIM
{
    public class BIMInfoFormatter : MonoBehaviour, IBIMInfoFormatter
    {
        public string Format(GameObject bimObject)
        {
            string output = "";
            if (bimObject.TryGetComponent(out IBIMObject bimObjectComponent))
            {
                string objectName = bimObject.GetComponent<Transform>().name;
                output = $"{objectName}\n\n";
                output += $"\t<color=#0087B7><b>Family</b></color>: {bimObjectComponent.Family}\n";
                output += $"\t<color=#0087B7><b>Category</b></color>: {bimObjectComponent.Category}";
            }
            return output;
        }
    }
}
