using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverenceTest
{
    public static class Server
    {
        private static ReaderWriterLockSlim LockBarrier = new ReaderWriterLockSlim();
        private static int count = 0;

        public static int GetCount()
        {
            LockBarrier.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                LockBarrier.ExitReadLock(); 
            }
        }

        public static void AddToCount(int value)
        {
            LockBarrier.EnterWriteLock();
            try
            {
                count += value;
            }
            finally 
            {
                LockBarrier.ExitWriteLock();
            }
        }
    }
}
