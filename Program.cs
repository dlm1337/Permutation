using System;
using System.Collections.Generic;
using System.Linq; 

namespace Permutations
{ 
    class Program
    {
        public static void Main(String[] args)
        {
            var p = new Program();
            var nums = p.Permute(new int[] { 1, 2, 3, 5, 4 });
            int t = 0;
            foreach(var l in nums)
            {
                int x = 0;
                Console.Write(" { ");
                foreach(var n in l)
                {
                    if(x < l.Count - 1)
                    Console.Write(n + ", ");
                    else
                    Console.Write(n);
                    x++;
                }
                if(t < nums.Count - 1)
                Console.Write(" }, ");
                else
                Console.Write(" } ");
                t++;
            }
            Console.ReadLine();
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> builtLists = new List<IList<int>>();
            IList<int> buildList = new List<int>();
            int[] buildListRepeatBlock = new int[nums.Length];
            Permutation(builtLists, buildListRepeatBlock, buildList, nums);
            return builtLists;
        }
        public void Permutation(List<IList<int>> builtLists, int[] buildListRepeatBlock, IList<int> buildList, int[] nums)
        {
            if (buildList.Count == nums.Length)
            {
                builtLists.Add(buildList.ToList());
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (buildListRepeatBlock[i] == 0)
                    {
                        buildListRepeatBlock[i] = 1;
                        buildList.Add(nums[i]);
                        Permutation(builtLists, buildListRepeatBlock, buildList, nums);
                        buildList.RemoveAt(buildList.Count - 1);
                        buildListRepeatBlock[i] = 0;
                    }
                }
            }
        }
    }
}
