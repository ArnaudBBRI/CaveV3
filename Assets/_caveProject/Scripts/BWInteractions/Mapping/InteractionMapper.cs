using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class InteractionMapper : MonoBehaviour
    {
        public IntEvent OnActionInput;

        private void Update()
        {
            if (Input.GetButtonDown("Action0")) 
            {
                OnActionInput.Raise(0);
            }
            else if (Input.GetButtonDown("Action1"))
            {
                OnActionInput.Raise(1);
            }
            else if (Input.GetButtonDown("Action2"))
            {
                OnActionInput.Raise(2);
            }
            else if (Input.GetButtonDown("Action3"))
            {
                OnActionInput.Raise(3);
            }
            else if (Input.GetButtonDown("Action4"))
            {
                OnActionInput.Raise(4);
            }
            else if (Input.GetButtonDown("Action5"))
            {
                OnActionInput.Raise(5);
            }
        }
    }
}