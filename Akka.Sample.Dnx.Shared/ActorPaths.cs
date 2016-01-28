namespace Akka.Sample.Dnx.Shared
{
	/// <summary>
	/// Static helper class used to define paths to fixed-name actors
	/// (helps eliminate errors when using <see cref="ActorSelection"/>)
	/// </summary>
	public static class ActorPaths
	{
		public static readonly ActorMetaData StationActor = new ActorMetaData("station-actor", "akka://sample-system/user/station-actor");
	}

	/// <summary>
	/// Meta-data class
	/// </summary>
	public class ActorMetaData
	{
		public ActorMetaData(string name, string path)
		{
			Name = name;
			Path = path;
		}

		public string Name { get; private set; }

		public string Path { get; private set; }
	}

}
