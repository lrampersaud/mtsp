using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTSP
{
    public class Solution
    {
        public List<int> Element { get; set; }
        public double Cost { get; set; }
        public Solution()
        {
            this.Element = new List<int>();
            this.Cost = 0f;
        }
        public Solution(List<int> pElement)
        {
            this.Element = pElement;
            this.Cost = 0f;
        }
        public Solution Clone()
        {
            Solution sol = new Solution();
            for (int i = 0; i < this.Element.Count; i++)
            {
                sol.Element.Add(this.Element[i]);
            }
            sol.Cost = this.Cost;
            return sol;
        }
        public override String ToString()
        {
            String sb = "";
            for (int i = 0; i < this.Element.Count; i++)
            {
                sb += this.Element[i].ToString() + "|";
            }
            return sb;
        }
    }
}
