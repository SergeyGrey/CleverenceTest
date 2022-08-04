using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverenceTest
{
    public class AsyncCaller
    {
        private EventHandler handler; 

        public AsyncCaller(EventHandler handler)
        {
            this.handler = handler;
        }

        public bool Invoke(int msec, object sender, EventArgs args)
        {
            Task task = Task.Factory.StartNew(() => handler(sender, args));

            return task.Wait(msec);
        }
    }
}
