using UnityEngine;

namespace Buildwise.CaveProjection
{
    public class BuildwiseFlystickPointer : MonoBehaviour
    {
        public Ray LaserRay 
        {
            get
            {
                return _laserRay;
            }
            private set { }
        }
        private Ray _laserRay;
        private GameObject _sphere;
        private Renderer _sphereRenderer;
        private LineRenderer _laserRenderer;
        public Material LaserMaterial;
        [SerializeField] private float _laserDistance = 100.0f;
        [SerializeField] private float _laserSphereScale = 0.2f;
        [SerializeField] private float _laserWidth = 0.05f;


        void Start()
        {
            CreateLaser();
        }

        void Update()
        {
            //init ray to save the start and direction values
            _laserRay = new Ray(transform.position, transform.forward);
            UpdateLaserEnd(transform.position, _laserDistance, transform.forward, _laserRay);
        }

        void UpdateLaserEnd(Vector3 startPos, float distance, Vector3 direction, Ray ray)
        {
            RaycastHit hit;
            //the end Pos which defaults to the startPos + distance 
            Vector3 endPos = startPos + (distance * direction);

            if (Physics.Raycast(ray, out hit, distance))
            {
                //if we detect something
                endPos = hit.point;
                _sphereRenderer.enabled = true;
            }
            else
            {
                _sphereRenderer.enabled = false;
            }

            _laserRenderer.SetPosition(0, startPos);
            _laserRenderer.SetPosition(1, endPos);
            _sphere.transform.position = endPos;
        }

        /*
         * TODO: detect if over a button so that we can trigger onClick correctly
        private bool IsFlystickOverButton(RaycastHit hit)
        {
            if (hit.collider.gameObject.GetComponentInChildren)
            {
                endPos = hit.point;
                _sphereRenderer.enabled = true;
            }
        }
        */

        private void CreateLaser()
        {
            //Add LineRenderer to gameobject
            _laserRenderer = gameObject.AddComponent<LineRenderer>();
            _laserRenderer.material = LaserMaterial;
            _laserRenderer.widthMultiplier = _laserWidth;
            //Create a sphere
            _sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _sphere.transform.localScale = new Vector3(_laserSphereScale, _laserSphereScale, _laserSphereScale);
            //Disable sphere collider
            Collider s_Collider = _sphere.GetComponent<Collider>();
            s_Collider.enabled = false;
            //Attribute same material as the LineRenderer
            _sphereRenderer = _sphere.GetComponent<Renderer>();
            _sphereRenderer.material = LaserMaterial;
        }
    }
}
