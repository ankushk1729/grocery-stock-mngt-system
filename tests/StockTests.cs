namespace Test;
public class StockTests
{
    [Test]
    [TestCase("onion")]
    [TestCase("wheat")]
    public void DeleteItem_WhenItemExists_ShouldDeleteTheItem(string itemName)
    {
        var containsBefore = Stock.checkContainsItem(itemName);
        if(!containsBefore) {
            Stock.addItem(itemName);
        }

        var result = Stock.deleteItem(itemName);
        var containsAfter = Stock.checkContainsItem(itemName);

        Assert.That(result, Is.True);
        Assert.That(containsAfter, Is.False);
    }

    [Test]
    [TestCase("apple")]
    public void DeleteItem_WhenItemsDoesNotExist_ReturnsFalse(string itemName)
    {
        var containsBefore = Stock.checkContainsItem(itemName);
        if(containsBefore) {
            Stock.deleteItem(itemName);
        }

        var result = Stock.deleteItem(itemName);
        Assert.That(result, Is.False);
    }



    [Test]
    [TestCase("onion")]
    [TestCase("wheat")]
    public void AddItem_WhenItemExists_ReturnsFalse(string itemName)
    {
        var containsBefore = Stock.checkContainsItem(itemName);
        if(!containsBefore) {
            Stock.addItem(itemName);
        }

        var result = Stock.addItem(itemName);
        var containsAfter = Stock.checkContainsItem(itemName);

        Assert.That(result, Is.False);
    }

    [Test]
    [TestCase("apple")]
    public void AddItem_WhenItemsDoesNotExist_ShouldAddItem(string itemName)
    {
        var containsBefore = Stock.checkContainsItem(itemName);
        if(containsBefore) {
            Stock.deleteItem(itemName);
        }

        var result = Stock.addItem(itemName);
        var containsAfter = Stock.checkContainsItem(itemName);

        Assert.That(result, Is.True);
        Assert.That(containsAfter, Is.True);
    }
}