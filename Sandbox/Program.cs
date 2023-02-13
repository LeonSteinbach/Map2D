using System;

namespace Sandbox
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