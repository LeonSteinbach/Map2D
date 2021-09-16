using System;

namespace Test
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			TestGame game = new TestGame();
			game.Run();
		}
	}
}
