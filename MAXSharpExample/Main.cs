using System;
using System.Threading;
using MAXSharp;
using System.Collections.Concurrent;

namespace MAXSharpExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ConcurrentQueue<IDeviceDiffSet> EventQueue = new ConcurrentQueue<IDeviceDiffSet>();


			String ELVMAX_Cube_IP_Adress = "192.168.178.82";
			Int32 ELVMAX_Cube_Port = 62910;

			MAXMonitoringThread ELVMax = new MAXMonitoringThread(ELVMAX_Cube_IP_Adress, // the IP Adress of the cube
			                                                     ELVMAX_Cube_Port,		// the port used by the cube
			                                                     EventQueue				// the queue in which the handling thread puts the events
			                                                     );

			Console.WriteLine("Starting ELV MAX Handling Thread...");

			// start-up the thread...
			Thread ELVMaxThread = new Thread(new ThreadStart(ELVMax.Run));                                                                                                                                                                                  
			ELVMaxThread.Start();

			// wait for successful connect...
			while(!ELVMax.connected)
			{
				Thread.Sleep(100);
			}

			// ELVMax.theHouse now contains all information about the current ELV MAX cube configuration
			// from now on the thread generates diffs to that every 10 seconds (or what you said...)

			while(true)
			{
				if (EventQueue.Count != 0)
				{
					foreach(IDeviceDiffSet _diffset in EventQueue)
					{
						// here are the diffs...

					}
				}

				Thread.Sleep(1000);
			}
		}
	}
}
