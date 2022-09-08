namespace Test;
public class RecipeTests
{
    [Test]
    [TestCase("rice")]
    public void GetRecipesThatContainsItem_WhenCalled_ReturnsRecipeThatContainItem(string itemName){
        var recipes = Recipe.getRecipesThatContainsItem(itemName);

        foreach(KeyValuePair<string, Dictionary<string, int>> recipe in recipes){
            Assert.That(recipe.Value, Does.ContainKey(itemName));
        }
    }
}