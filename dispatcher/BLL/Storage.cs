using dispatcher.Models;
using System.Collections.Concurrent;

namespace dispatcher.BLL
{
    public static class Storage
    {
        private static readonly ConcurrentDictionary<int, Name> NameSet = new();

        public static HashSet<Name> Dispatch(List<Name> names)
        {
            HashSet<Name> resp = new HashSet<Name>();
            HashSet<Name> temp = new HashSet<Name>();

            names.ForEach(name =>
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
                NameSet.AddOrUpdate(name.GetHashCode(), name, (h, n) => n);
            }

            return resp;
        }

        public static void Remove(List<Name> names)
        {
            foreach (Name name in names)
            {
                NameSet.Remove(name.GetHashCode(), out _);
            }
        }
    }
}
