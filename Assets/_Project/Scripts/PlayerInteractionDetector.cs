using UnityEngine;

namespace _Project.Scripts
{
    internal static class PlayerInteractionDetector
    {
        internal static void UpdateSelection(Player player)
        {
            if (player == null)
            {
                return;
            }

            Vector2 inputVector = player.GameInput.GetMovementVectorNormalized();
            Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

            if (movementDirection != Vector3.zero)
            {
                player.SetLastInteractDirection(movementDirection);
            }

            const float interactionDistance = 1.5f;
            if (Physics.Raycast(player.transform.position, player.GetLastInteractDirection(), out RaycastHit hit, interactionDistance))
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    SetSelectedInteractable(player, interactable);
                    return;
                }
            }

            SetSelectedInteractable(player, null);
        }

        private static void SetSelectedInteractable(Player player, IInteractable interactable)
        {
            if (player.SelectedObject == interactable)
            {
                return;
            }

            player.SelectedObject = interactable;
            player.NotifySelectedInteractableChanged(interactable);
        }
    }
}
