#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.RAEtherNetIP;
using FTOptix.Modbus;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.NativeUI;
using FTOptix.Alarm;
using FTOptix.WebUI;
using FTOptix.MicroController;
using FTOptix.DataLogger;
using FTOptix.Store;
using FTOptix.SQLiteStore;
using FTOptix.System;
#endregion

public class ApplicationHeartbeat : BaseNetLogic
{
      public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        var heartbeatRateVarible = Project.Current.GetVariable("NetLogic/ApplicationHeartbeat/HeartbeatRate");
        myPeriodicTask = new PeriodicTask(ToggleVarible, heartbeatRateVarible.Value, LogicObject);
        myPeriodicTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        myPeriodicTask.Dispose();
    }

    private void ToggleVarible()
    {
        var heartbeatVariable = Project.Current.GetVariable("NetLogic/ApplicationHeartbeat/Heartbeat");

        heartbeatVariable.Value = !heartbeatVariable.Value;


    }
    private PeriodicTask myPeriodicTask;
}
