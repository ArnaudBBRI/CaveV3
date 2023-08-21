/*
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class MouseInteractionMapper : MonoBehaviour, IInteractionMapper
    {
        public IntGameEvent ActionIntEvent;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) ActionIntEvent.Raise(0);
            else if (Input.GetMouseButtonDown(1)) ActionIntEvent.Raise(1);
            else if (Input.GetMouseButtonDown(2)) ActionIntEvent.Raise(2);
            else if (Input.GetMouseButtonDown(3)) ActionIntEvent.Raise(3);
            else if (Input.GetMouseButtonDown(4)) ActionIntEvent.Raise(4);
        }

        // Unused
        public InteractionsEnums IdentifyAction()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return InteractionsEnums.MainAction;
            }
            else if (Input.GetMouseButtonDown(1)) return InteractionsEnums.SecondaryAction;
            else if (Input.GetMouseButtonDown(2)) return InteractionsEnums.TertiaryAction;
            else if (Input.GetMouseButtonDown(3)) return InteractionsEnums.QuaternaryAction;
            else if (Input.GetMouseButtonDown(4)) return InteractionsEnums.QuinaryAction;
            else return InteractionsEnums.NoAction;
        }
    }
}
*/