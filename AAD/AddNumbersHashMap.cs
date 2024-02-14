using System;
using System.Collections.Generic;
using System.Linq;

namespace AddTwoHashMap
{
    public class AddNumbersHashMap
    {

        public int[] addNums(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int restante = target - nums[i];
                if (numMap.ContainsKey(restante))
                {
                    return new int[] { numMap[restante], i };
                }
                if (!numMap.ContainsKey(nums[i]))
                {
                    numMap.Add(nums[i], i);
                }
            }

            throw new ArgumentException();
        }

    }

}
