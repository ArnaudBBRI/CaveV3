using UnityEngine;
using Buildwise.CaveProjection;

namespace Buildwise.Hovering
{
    public class BuildwiseFlystickRayProvider : BaseRayProvider
    {
        private BuildwiseFlystickPointer _buildwisePointer;
        private void Start()
        {
            _buildwisePointer = FindObjectOfType<BuildwiseFlystickPointer>();
        }

        public override Ray CreateRay()
        {
            if (_buildwisePointer == null) return new Ray();
            return _buildwisePointer.LaserRay;
        }
    }
}