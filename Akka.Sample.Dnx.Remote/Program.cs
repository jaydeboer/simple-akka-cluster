using Akka.Actor;
using Akka.Sample.Dnx.Shared.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akka.Sample.Dnx.Remote
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var system = ActorSystem.Create("sample-system");
			var actor = system.ActorOf(Props.Create(() => new StationActor()));
			actor.Tell(new StationActor.IncrementMessage());

			Console.Read();
		}
    }
}
