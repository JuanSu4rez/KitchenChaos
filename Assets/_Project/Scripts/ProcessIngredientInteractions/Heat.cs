namespace _Project.Scripts.ProcessIngredientInteractions
{
    public class Heat : IPreparationInteraction
    {
        private readonly PreparationSteps step;

        public Heat(PreparationSteps step)
        {
            this.step = step;
        }

        public void Apply(Ingredient ingredient, float workAmount)
        {
            ingredient.ApplyWork(step, workAmount);
        }
    }
}