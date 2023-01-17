using dispatcher.Models;
using System.Collections.Concurrent;

namespace dispatcher.BLL
{
    public class Storage
    {
        private static readonly ConcurrentDictionary<int, Name> NameSet = new();

        public static HashSet<Name> Dispatch(List<Name> Names)
        {
            HashSet<Name> resp = new HashSet<Name>();
            HashSet<Name> temp = new HashSet<Name>();

            Names.ForEach(name =>
            {
                if (NameSet.ContainsKey(name.GetHashCode()))
                {
                    resp.Add(name);
                }
                else
                {
                    temp.Add(name);
                }
            });
            foreach(Name name in temp)
            {
                NameSet.AddOrUpdate(name.GetHashCode(), name, (h, n) =>
                {
                    return n;
                });
            }

            return resp;
        }

        public static void Remove(List<Name> Names)
        {
            foreach (Name name in Names)
            {
                NameSet.Remove(name.GetHashCode(), out Name value);
            }
        }
    }
}
