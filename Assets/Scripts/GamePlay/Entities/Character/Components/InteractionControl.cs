using System;
using GamePlay.Environment;
using UnityEngine;

namespace GamePlay.Entities.Character.Components
{
    [Serializable]
    public class InteractionControl
    {
        [SerializeField] private GameObject _currentInteractableObject;

        public GameObject CurrentInteractableObject
        {
            get => _currentInteractableObject;
            set => _currentInteractableObject = value;
        }
        public void InteractWithEnvironment(GameObject interactableObject)
        {
            if (interactableObject != null)
            {
                interactableObject.GetComponent<IInteractable>().InteractWithCharacter();
            }
            
        }
    }
}
