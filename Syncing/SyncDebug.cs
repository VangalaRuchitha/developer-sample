using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
           var tasks = items.Select(async i =>

            {
             return await Task.Run(() => i);

            });
            return Task.WhenAll(tasks).Result.ToList(); // waits for all

        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            int partitionSize = itemsToInitialize.Count / 3;
            var partitions = new List<List<int>>
    {
        itemsToInitialize.Take(partitionSize).ToList(),
        itemsToInitialize.Skip(partitionSize).Take(partitionSize).ToList(),
        itemsToInitialize.Skip(2 * partitionSize).ToList()
    };

            var threads = partitions.Select(partition =>
                new Thread(() =>
                {
                    foreach (var item in partition)
                    {
                        concurrentDictionary.TryAdd(item, getItem(item));
                    }
                }))
                .ToList();

            foreach (var thread in threads)
                thread.Start();
            foreach (var thread in threads)
                thread.Join();
            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
