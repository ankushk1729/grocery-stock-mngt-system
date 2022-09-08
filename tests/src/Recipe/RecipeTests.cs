namespace Test;
public class RecipeTests
{

    private Recipe? _recipe;

    [SetUp]
    public void SetUp(){
        _recipe = new Recipe(new Json());
    }

    [Test]
    [TestCase("rice")]
    public void GetRecipesThatContainsItem_WhenCalled_ReturnsRecipeThatContainItem(string itemName){
        var recipes = _recipe!.getRecipesThatContainsItem(itemName);

        foreach(KeyValuePair<string, Dictionary<string, int>> recipe in recipes){
            Assert.That(recipe.Value, Does.ContainKey(itemName));
        }
    }
}