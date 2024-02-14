using AddTwoHashMap;
namespace AddTwoHashMap.Tests;

public class UnitTest1
{
    [Fact]
    public void Add_NumbersHashMap()
    {

        AddNumbersHashMap addTwo = new AddNumbersHashMap();

        int[] nums = new int[] { 2, 7, 11, 15 };
        int target = 9;

        int[] result = addTwo.addNums(nums, target);

        Assert.Equal(new int[] { 0, 1 }, result);

    }

    [Fact]
    public void Add_NumbersHashMap_Test_0()
    {

        AddNumbersHashMap addTwo = new AddNumbersHashMap();

        int[] nums = new int[] { 3, 2, 4 };
        int target = 6;

        int[] result = addTwo.addNums(nums, target);

        Assert.Equal(new int[] { 1, 2 }, result);

    }

    [Fact]
    public void Add_NumbersHashMap_Test_1()
    {

        AddNumbersHashMap addTwo = new AddNumbersHashMap();

        int[] nums = new int[] { 3, 3 };
        int target = 6;

        int[] result = addTwo.addNums(nums, target);

        Assert.Equal(new int[] { 0, 1 }, result);

    }

    [Fact]
    public void Add_NumbersHashMap_Test_2()
    {

        AddNumbersHashMap addTwo = new AddNumbersHashMap();

        int[] nums = new int[] { 3, 2, 3 };
        int target = 6;

        int[] result = addTwo.addNums(nums, target);

        Assert.Equal(new int[] { 0, 2 }, result);

    }
}