using System.Collections;

namespace AAD.Tests;

/**
* Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
*
* An input string is valid if:
*
* Open brackets must be closed by the same type of brackets.
* Open brackets must be closed in the correct order.
* Every close bracket has a corresponding open bracket of the same type.
*/
public class ValidParenthesisTests
{
    [Theory]
    [InlineData("", true)]
    [InlineData("hello", true)]
    [InlineData("()", true)]
    [InlineData("()()", true)]
    [InlineData("(())", true)]
    [InlineData("(())()(())", true)]
    [InlineData("((a))(b)((cd))", true)]
    [InlineData("()[]{}", true)]
    [InlineData("a{([d](v))}(c)[v]b", true)]
    [InlineData("(", false)]
    [InlineData("()()(", false)]
    [InlineData(")", false)]
    [InlineData("(()))()", false)]
    [InlineData("(]", false)]
    [InlineData("[", false)]
    [InlineData("}", false)]
    public void Test(string input, bool expectedResult)
    {
        var result = ValidParenthesis(input);

        Assert.Equal(expectedResult, result);
    }

    private bool ValidParenthesis(string input)
    {
        var pairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };
        
        var expectedStack = new Stack<char>();
        foreach (var chr in input)
        {
            if (pairs.Keys.Contains(chr))
            {
                expectedStack.Push(pairs[chr]);
                continue;
            }

            if (pairs.Values.Contains(chr))
            {
                if (expectedStack.Count == 0)
                    return false;
                
                var expectedCloser = expectedStack.Pop();
                if (expectedCloser != chr)
                    return false;
            }
        }
        return expectedStack.Count == 0;
    }
}