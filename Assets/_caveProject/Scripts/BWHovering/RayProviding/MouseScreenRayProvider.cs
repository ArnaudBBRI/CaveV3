using UnityEngine;

namespace Buildwise.Hovering
{
    public class MouseScreenRayProvider : BaseRayProvider
    {
        public override Ray CreateRay()
        {
            Vector2 mousePosition = _caveControls.InGame.point.ReadValue<Vector2>();
            //return Camera.main.ScreenPointToRay(Input.mousePosition);
            return Camera.main.ScreenPointToRay(mousePosition);
        }
    }
}