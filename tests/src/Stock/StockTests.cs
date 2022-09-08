namespace Test;
public class StockTests
{
    private Stock? _stock;

    [SetUp]
    public void SetUp(){
        _stock = new Stock(new Json());
    }


    [Test]
    [TestCase("onion")]
    [TestCase("wheat")]
    public void DeleteItem_WhenItemExists_ShouldDeleteTheItem(string itemName)
    {
        var containsBefore = _stock!.checkContainsItem(itemName);
        if(!containsBefore) {
            _stock!.addItem(itemName);
        }

        var result = _stock!.deleteItem(itemName);
        var containsAfter = _stock!.checkContainsItem(itemName);

        Assert.That(result, Is.True);
        Assert.That(containsAfter, Is.False);
    }

    [Test]
    [TestCase("apple")]
    public void DeleteItem_WhenItemsDoesNotExist_ReturnsFalse(string itemName)
    {
        var containsBefore = _stock!.checkContainsItem(itemName);
        if(containsBefore) {
            _stock!.deleteItem(itemName);
        }

        var result = _stock!.deleteItem(itemName);
        Assert.That(result, Is.False);
    }



    [Test]
    [TestCase("onion")]
    [TestCase("wheat")]
    public void AddItem_WhenItemExists_ReturnsFalse(string itemName)
    {
        var containsBefore = _stock!.checkContainsItem(itemName);
        if(!containsBefore) {
            _stock!.addItem(itemName);
        }

        var result = _stock!.addItem(itemName);
        var containsAfter = _stock!.checkContainsItem(itemName);

        Assert.That(result, Is.False);
    }

    [Test]
    [TestCase("apple")]
    public void AddItem_WhenItemsDoesNotExist_ShouldAddItem(string itemName)
    {
        var containsBefore = _stock!.checkContainsItem(itemName);
        if(containsBefore) {
            _stock!.deleteItem(itemName);
        }

        var result = _stock!.addItem(itemName);
        var containsAfter = _stock!.checkContainsItem(itemName);

        Assert.That(result, Is.True);
        Assert.That(containsAfter, Is.True);
    }
}