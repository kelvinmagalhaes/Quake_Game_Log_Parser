using System.Linq;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    public class ExtractMeansDeath
    {
        public static bool MeansDeathRound(ref List<string> groupy, ref List<Deaths> meanDeaths)
        {
            var aux = new HashSet<string>(groupy);
            foreach (var item in aux)
            {
                meanDeaths.Add(new Deaths
                {
                    Mean = item,
                    value = groupy.FindAll(s => s.Equals(item)).Count
                });
            }
            meanDeaths = meanDeaths.OrderByDescending(x => x.value).ToList();

            if (meanDeaths.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
