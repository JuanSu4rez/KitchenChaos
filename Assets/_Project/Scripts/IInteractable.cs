using System;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts
{
    public interface IInteractable
    {
        void Interact(Player interactor);
    }
}