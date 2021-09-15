using System;
using Map2D.core;

namespace Map2D
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			Map2dGame game = new Map2dGame();
			game.Run();
		}
	}
}
