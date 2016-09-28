namespace PogoTools
{

	public interface IPRSingleton
	{
		void Initialize();
	}

	public abstract class PRSingleton<T> : IPRSingleton
		where T : IPRSingleton, new()
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new T();
					instance.Initialize();
				}
				return instance;
			}
		}

		public abstract void Initialize();
	}
}