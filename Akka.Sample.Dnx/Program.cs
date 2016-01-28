using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
using Akka.Sample.Dnx.Shared;
using Akka.Sample.Dnx.Shared.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akka.Sample.Dnx
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var system = ActorSystem.Create("sample-system");
			system.ActorOf(Props.Create(() => new StationActor()));

			Console.ReadKey();

			var mediator = DistributedPubSub.Get(system).Mediator;

			mediator.Tell(new Publish(Topics.StationStatSynchonization, new StationActor.IncrementMessage()));

            Console.Read();
        }
    }
}
