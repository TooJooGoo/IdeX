// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System.Threading;

public class XTimer
{
    private Timer Timer;

    /// <summary>
    /// Create a timer that is intially stopped.
    /// The callback method is not called yet.
    /// </summary>
    public static XTimer CreateStoppedTimer(TimerCallback callback)
    {
        var timer = new XTimer();
        timer.Timer = new Timer(callback, null, Timeout.Infinite, Timeout.Infinite);
        return timer;
    }

    /// <summary>
    /// Starts the timer. After the given delay in milliseconds has elapsed, the callback method
    /// is called once.
    /// </summary>
    public void StartSingleEvent(int delay)
    {
        if (Timer != null)
        {
            Timer.Change(delay, Timeout.Infinite);
        }
    }

    /// <summary>
    /// Starts the timer. After the given delay in milliseconds has elapsed, the callback method
    /// is called for the first time. After period has elapsed the callback is called a second time.
    /// Again a period elapses, then the callback is called again. And so on.
    /// </summary>
    public void StartMultiEvent(int delay, int period)
    {
        if (Timer != null)
        {
            Timer.Change(delay, period);
        }
    }

    /// <summary>
    /// Stops the timer. 
    /// </summary>
    public void Stop()
    {
        if (Timer != null)
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }

    /// <summary>
    /// Discards the timer. 
    /// </summary>
    public void Discard()
    {

        if (Timer != null)
        {
            Timer.Dispose();
            Timer = null;
        }
    }
}
