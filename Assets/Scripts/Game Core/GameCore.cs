using System.Collections;
using System.Collections.Generic;


public class GameCore
{
	private List<IGameCoreEventListener> listeners;

	public void addListener(IGameCoreEventListener listener)
	{
		listeners.Add(listener);
	}

	public void newGame()
	{
		// TODO
	}
}