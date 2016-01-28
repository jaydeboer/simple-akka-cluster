using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akka.Sample.Dnx.Shared.Actors
{
    public class StationActor : ReceiveActor
    {
		public StationActor()
		{
			Receive<IncrementMessage>(message => ReceivedIncrementMessage());
		}

		private int _counter = 0;

		private void ReceivedIncrementMessage()
		{
			Console.WriteLine($"Message {_counter} received.");
			_counter++;
		}

		public class IncrementMessage
		{

		}
    }
}
