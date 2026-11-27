using System;

namespace _Project.Scripts
{
    [Serializable]
    public abstract class CookingTask : KitchenTask
    {   
        private CookingStepTypes _stepType;
        private Ingredient _ingredient;

        public CookingTask(CookingStepTypes stepType) => _stepType = stepType;
        
        public CookingStepTypes StepType => _stepType;
       
    }
}
