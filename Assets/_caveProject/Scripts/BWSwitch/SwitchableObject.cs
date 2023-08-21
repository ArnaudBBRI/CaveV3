using Buildwise.Core;
using UnityEngine;

namespace Buildwise.Switchable
{
    public class SwitchableObject : MonoBehaviour, ISwitchableObject
    {
        [SerializeField]
        private int _groupID;

        public int GroupID { get => _groupID; set => _groupID = value; }

        private void OnEnable()
        {
            HelperFunctions.AddComponentToAllChildren<SwitchableObject>(this.transform, true);
            if (this.transform.parent.TryGetComponent<ISwitchableObject>(out ISwitchableObject so)) 
            { 
                GroupID= so.GroupID;
            }
        }
    }
}
