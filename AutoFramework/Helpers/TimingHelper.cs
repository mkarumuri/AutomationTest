using System;
using System.Diagnostics;

namespace AutoFramework.Helpers
{
	public class TimingHelper
	{
		public static void WaitForResult(Func<bool> conditionToWaitFor, int timeout = 90000)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (!conditionToWaitFor.Invoke())
			{
				//Console.WriteLine("...Waiting for {0}ms", stopwatch.ElapsedMilliseconds);
				if (stopwatch.ElapsedMilliseconds > timeout)
				{
					stopwatch.Stop();
					throw new TimeoutException("...Result timed out");
				}
			}
			stopwatch.Stop();
		}
	}
}
