using UnityEngine;

namespace Buildwise.Hovering
{
    /// <summary>
    /// Determines how a ray is created and shot.
    /// </summary>
    public interface IRayProvider
    {
        Ray CreateRay();

        void ShootRay(Ray ray);
    }
}