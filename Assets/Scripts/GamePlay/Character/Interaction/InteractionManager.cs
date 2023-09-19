using UnityEngine;

namespace GamePlay.Character.Interaction
{
    public class InteractionManager
    {
        public void InteractWithEnvironment(GameObject interactableObject)
        {
            if (interactableObject != null)
            {
                interactableObject.GetComponent<IInteractable>().InteractWithCharacter();
            }
            
        }
    }
}
