using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
using Akka.Sample.Dnx.Shared;
using Akka.Sample.Dnx.Shared.Actors;
using System;

namespace Akka.Sample.Dnx.Remote
{
	public class Program
    {
        public static void Main(string[] args)
        {
			var system = ActorSystem.Create("sample-system");
			var actor = system.ActorOf(Props.Create(() => new StationActor()));

			var mediator = DistributedPubSub.Get(system).Mediator;

			Console.ReadKey();

			mediator.Tell(new Publish(Topics.StationStatSynchonization, new StationActor.IncrementMessage()));

			Console.Read();
		}
    }
}
