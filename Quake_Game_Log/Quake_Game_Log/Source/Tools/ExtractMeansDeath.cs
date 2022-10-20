using System.Linq;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Extract Means Death class
    /// </summary>
    public class ExtractMeansDeath
    {
        /// <summary>
        /// Extract means death of the round.
        /// </summary>
        /// <param name="groupy">All means death</param>
        /// <param name="meanDeaths">List means death to fill</param>
        /// <returns>true if the meanDeaths is not null.</returns>
        public static bool MeansDeathRound(ref List<string> groupy, ref List<Deaths> meanDeaths)
        {
            var aux = new HashSet<string>(groupy);
            foreach (var item in aux)
            {
                meanDeaths.Add(new Deaths
                {
                    Mean = item,
                    Value = groupy.FindAll(s => s.Equals(item)).Count
                });
            }
            meanDeaths = meanDeaths.OrderByDescending(x => x.Value).ToList();

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
