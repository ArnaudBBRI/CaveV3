using UnityEngine;
using System.Collections.Generic;
using Buildwise.Interactions;

namespace Buildwise.Switchable
{
    public class FurnitureSwitcher : MonoBehaviour, IInteractionResponse
    {
        private List<List<GameObject>> _inSceneFurnitureAlternatives;

        private void Start()
        {
            _inSceneFurnitureAlternatives = new List<List<GameObject>>();
            foreach (var t in FindObjectsOfType<Transform>(true))
            {
                if (t.TryGetComponent<ISwitchableObject>(out ISwitchableObject so))
                {
                    int groupID = so.GroupID;
                    while (_inSceneFurnitureAlternatives.Count < groupID + 1)
                    {
                        _inSceneFurnitureAlternatives.Add(new List<GameObject>());
                    }
                    _inSceneFurnitureAlternatives[groupID].Add(t.gameObject);
                }
            }
        }

        public void OnAction(Transform selection, RaycastHit hit)
        {
            ISwitchableObject so;
            if (!selection.TryGetComponent<ISwitchableObject>(out so))
            {
                return;
            }
            else
            {
                int groupID = so.GroupID;
                for (int i = 0; i < _inSceneFurnitureAlternatives[groupID].Count; i++)
                {
                    var enumerator = _inSceneFurnitureAlternatives[groupID].GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.GetInstanceID() == selection.gameObject.GetInstanceID())
                        {
                            enumerator.Current.SetActive(false);
                            if (enumerator.MoveNext())
                            {
                                enumerator.Current.SetActive(true);
                            }
                            else
                            {
                                var go = _inSceneFurnitureAlternatives[groupID][0];
                                go.SetActive(true);
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}