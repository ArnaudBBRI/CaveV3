using UnityEngine;
using UnityEngine.UI;

namespace Buildwise.Hovering
{
    public class ShowBIMInfoOnHovering : ShowBIMInfoOnHoveringBase
    {
        
        [SerializeField] private float _menuDistanceFromCamera = 1.5f;

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
            PlaceMenu(infoCanvas);
        }

        private void PlaceMenu(GameObject menu)
        {
            OrientMenu(menu);

            float height;

            if (Camera.main.orthographic)
            {
                height = Camera.main.orthographicSize * 2.0f;
            }
            else
            {
                height = 2.0f * _menuDistanceFromCamera * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
            }

            float width = height * Camera.main.aspect;

            Vector3 cameraPosition = Camera.main.transform.position;
            Quaternion cameraRotation = Camera.main.transform.rotation;

            Vector3 topLeft = cameraPosition + cameraRotation * new Vector3(-width / 2.0f, height / 2.0f, _menuDistanceFromCamera);

            float canvasWidth = menu.GetComponentInChildren<RectTransform>().sizeDelta.x;
            float canvasHeight = menu.GetComponentInChildren<RectTransform>().sizeDelta.y;

            float menuWidth = canvasWidth * menu.transform.localScale.x;
            float menuHeight = canvasHeight * menu.transform.localScale.y;

            menu.transform.position = topLeft;
            menu.transform.Translate(new Vector3(1.1f * menuWidth / 2.0f, -1.1f * menuHeight / 2.0f, 0));
        }

        private void OrientMenu(GameObject menu)
        {
            menu.transform.LookAt(Camera.main.transform.position - 10000 * Camera.main.transform.forward, Camera.main.transform.up);
            menu.transform.Rotate(180 * Vector3.up, Space.Self);
        }
    }
}