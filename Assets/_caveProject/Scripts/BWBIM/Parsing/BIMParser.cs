using UnityEngine;
//using Buildwise.Hovering;

namespace Buildwise.BIM
{
    public abstract class BIMParser : MonoBehaviour, IBIMModelParser
    {
        //public IntGameEvent ActionIntEvent;
        //public GameEvent BIMMaterialsManagerInitialized;

        [SerializeField] public GameObject bimRoot;
        [SerializeField] protected GameObject materialsManager;

        private void Awake()
        {
            //BIMMaterialsManagerInitialized.AddListener(ParseBIMModel);
            if (materialsManager == null)
            {
                Debug.LogError("No Materials Manager defined. Can't parse BIM model!");
            }
            ParseBIMModel();
        }
        /*
        public bool IsMazeFlystickUsed()
        {
            bool output = false;
            var frp = FindObjectOfType<FlystickRayProvider>();
            if (frp != null)
            {
                output = true;
            }
            return output;
        }
        */
        public abstract void Parse(GameObject go, bool usingMazeFlystick);

        public abstract void ParseBIMModel(GameObject root);
        public abstract void ParseBIMModel();
    }
}