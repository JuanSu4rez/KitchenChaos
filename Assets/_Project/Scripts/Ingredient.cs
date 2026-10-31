using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class Ingredient : KitchenObject
    {
        private bool _isLocked;
        private IngredientStates _state;
    }
}