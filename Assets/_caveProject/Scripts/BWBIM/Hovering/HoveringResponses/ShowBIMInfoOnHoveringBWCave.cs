using UnityEngine;
using UnityEngine.UI;

namespace Buildwise.Hovering
{
    public class ShowBIMInfoOnHoveringBWCave : ShowBIMInfoOnHoveringBase
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void OnSelect(Transform selection)
        {
            if (_formatter == null || infoCanvas == null) return;
            string infoText = _formatter.Format(selection.gameObject);
            infoCanvas.SetActive(true);
            var texts = infoCanvas.GetComponentsInChildren<Text>();
            foreach (var t in texts)
            {
                if (t.gameObject.name == "Infos")
                {
                    t.text = infoText;
                }
            }
        }
    }
}