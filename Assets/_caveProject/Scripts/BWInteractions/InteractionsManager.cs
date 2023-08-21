using UnityEngine;
using UnityAtoms.BaseAtoms;
using Buildwise.Core;

namespace Buildwise.Interactions
{
    public class InteractionsManager : MonoBehaviour
    {
        private IInteractionResponse _mainActionInteractor;
        private IInteractionResponse _secondaryActionInteractor;
        private IInteractionResponse _tertiaryActionInteractor;
        private IInteractionResponse _quaternaryActionInteractor;
        private int nbInteractionResponses;

        [SerializeField] private GameObjectVariable _hoveredObject;
        [SerializeField] private RayCastHitVariable _hoveredObjectHit;

        private void Awake()
        {
            /*
            var hms = FindObjectsOfType<HoveringManager>();
            if (hms.Length != 1)
            {
                Debug.LogError("There should be one and only one HoveringManager in the Scene!");
                return;
            }
            _hoveringManager = hms[0];
            */
            nbInteractionResponses = GetComponents<IInteractionResponse>().Length;
            if (nbInteractionResponses > 0) _mainActionInteractor = GetComponents<IInteractionResponse>()[0];
            if (nbInteractionResponses > 1) _secondaryActionInteractor = GetComponents<IInteractionResponse>()[1];
            if (nbInteractionResponses > 2) _tertiaryActionInteractor = GetComponents<IInteractionResponse>()[2];
            if (nbInteractionResponses > 3) _quaternaryActionInteractor = GetComponents<IInteractionResponse>()[3];

        }
        private void Update()
        {
            /*
            Transform currentHover = _hoveringManager.CurrentHover;
            RaycastHit hit = _hoveringManager.CurrentHit;

            if (currentHover == null) return;
            
            InteractionsEnums action = _interactionMapper.IdentifyAction();
            Debug.Log("***************");
            Debug.Log($"This is frame {Time.frameCount}");
            Debug.Log($"I have identified action {action}");
            if (action == InteractionsEnums.MainAction && nbInteractionResponses > 0) _mainActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.SecondaryAction && nbInteractionResponses > 1 ) _secondaryActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.TertiaryAction && nbInteractionResponses > 2) _tertiaryActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.QuaternaryAction && nbInteractionResponses > 3) _quaternaryActionInteractor.OnAction(currentHover, hit);
            */
        }

        public void TriggerAction(int actionIndex)
        {
            Transform currentHover = _hoveredObject.Value.transform;
            RaycastHit hit = _hoveredObjectHit.Value;

            if (currentHover == null) return;

            InteractionsEnums action;
            if (actionIndex == 0)
            {
                action = InteractionsEnums.MainAction;
            }
            else if (actionIndex == 1)
            {
                action = InteractionsEnums.SecondaryAction;
            }
            else if (actionIndex == 2)
            {
                action = InteractionsEnums.TertiaryAction;
            }
            else if (actionIndex == 3)
            {
                action = InteractionsEnums.QuaternaryAction;
            }
            else
            {
                action = InteractionsEnums.NoAction;
            }
            if (action == InteractionsEnums.MainAction && nbInteractionResponses > 0) _mainActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.SecondaryAction && nbInteractionResponses > 1) _secondaryActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.TertiaryAction && nbInteractionResponses > 2) _tertiaryActionInteractor.OnAction(currentHover, hit);
            else if (action == InteractionsEnums.QuaternaryAction && nbInteractionResponses > 3) _quaternaryActionInteractor.OnAction(currentHover, hit);
        }
    }
}
