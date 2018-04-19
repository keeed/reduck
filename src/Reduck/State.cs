using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Reduck
{
    public class State
    {
        protected ConcurrentDictionary<string, object> Storage = new ConcurrentDictionary<string, object>();

        public void Update(string key, object value)
        {
            Storage.AddOrUpdate(
                key,
                value,
                (existingKey, oldvalue) => value);
        }
    }
}