using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
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
			var mediator = DistributedPubSub.Get(Context.System).Mediator;
			mediator.Tell(new Subscribe(Topics.StationStatSynchonization, Self));

			Receive<SubscribeAck>(_ => Become(Subscribed));
		}

		private void Subscribed()
		{
			Console.WriteLine("Subscribed");

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
