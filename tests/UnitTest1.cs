namespace Test;
public class Tests
{

    [Test]
    public void Test1()
    {
        var result = GSMS.Stock.getQuantityOfAnItem("carrot");
        Assert.IsInstanceOf<int>(result);
    }
}