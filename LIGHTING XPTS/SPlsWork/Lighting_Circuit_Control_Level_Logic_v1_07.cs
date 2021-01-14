using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_LIGHTING_CIRCUIT_CONTROL_LEVEL_LOGIC_V1_07
{
    public class UserModuleClass_LIGHTING_CIRCUIT_CONTROL_LEVEL_LOGIC_V1_07 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        Crestron.Logos.SplusObjects.DigitalInput ON_OFF_DOUBLE_PRESS_LEVEL_ON;
        Crestron.Logos.SplusObjects.DigitalInput ON_DOUBLE_PRESS_LEVEL_ON;
        Crestron.Logos.SplusObjects.DigitalInput ON_OFF_DOUBLE_PRESS_LEVEL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput OFF_DOUBLE_PRESS_LEVEL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput ON_OFF_PRESS_N_RELEASE_LEVEL_ON;
        Crestron.Logos.SplusObjects.DigitalInput ON_PRESS_N_RELEASE_LEVEL_ON;
        Crestron.Logos.SplusObjects.DigitalInput ON_OFF_PRESS_N_RELEASE_LEVEL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput OFF_PRESS_N_RELEASE_LEVEL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput DYNAMIC_ON_FB;
        Crestron.Logos.SplusObjects.AnalogInput LEVEL_FB;
        Crestron.Logos.SplusObjects.AnalogOutput LEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput RL_LEVEL;
        object ON_OFF_DOUBLE_PRESS_LEVEL_ON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 41;
                LEVEL  .Value = (ushort) ( 65535 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ON_OFF_DOUBLE_PRESS_LEVEL_OFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 47;
            LEVEL  .Value = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ON_OFF_PRESS_N_RELEASE_LEVEL_ON_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 53;
        if ( Functions.TestForTrue  ( ( DYNAMIC_ON_FB  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 54;
            RL_LEVEL  .Value = (ushort) ( _SplusNVRAM.NLASTONLEVEL ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 56;
            RL_LEVEL  .Value = (ushort) ( 65535 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ON_OFF_PRESS_N_RELEASE_LEVEL_OFF_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 62;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( LEVEL_FB  .UshortValue ) && Functions.TestForTrue ( DYNAMIC_ON_FB  .Value )) ))  ) ) 
            {
            __context__.SourceCodeLine = 63;
            _SplusNVRAM.NLASTONLEVEL = (ushort) ( LEVEL_FB  .UshortValue ) ; 
            }
        
        __context__.SourceCodeLine = 65;
        RL_LEVEL  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    ON_OFF_DOUBLE_PRESS_LEVEL_ON = new Crestron.Logos.SplusObjects.DigitalInput( ON_OFF_DOUBLE_PRESS_LEVEL_ON__DigitalInput__, this );
    m_DigitalInputList.Add( ON_OFF_DOUBLE_PRESS_LEVEL_ON__DigitalInput__, ON_OFF_DOUBLE_PRESS_LEVEL_ON );
    
    ON_DOUBLE_PRESS_LEVEL_ON = new Crestron.Logos.SplusObjects.DigitalInput( ON_DOUBLE_PRESS_LEVEL_ON__DigitalInput__, this );
    m_DigitalInputList.Add( ON_DOUBLE_PRESS_LEVEL_ON__DigitalInput__, ON_DOUBLE_PRESS_LEVEL_ON );
    
    ON_OFF_DOUBLE_PRESS_LEVEL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( ON_OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( ON_OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__, ON_OFF_DOUBLE_PRESS_LEVEL_OFF );
    
    OFF_DOUBLE_PRESS_LEVEL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__, OFF_DOUBLE_PRESS_LEVEL_OFF );
    
    ON_OFF_PRESS_N_RELEASE_LEVEL_ON = new Crestron.Logos.SplusObjects.DigitalInput( ON_OFF_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__, this );
    m_DigitalInputList.Add( ON_OFF_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__, ON_OFF_PRESS_N_RELEASE_LEVEL_ON );
    
    ON_PRESS_N_RELEASE_LEVEL_ON = new Crestron.Logos.SplusObjects.DigitalInput( ON_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__, this );
    m_DigitalInputList.Add( ON_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__, ON_PRESS_N_RELEASE_LEVEL_ON );
    
    ON_OFF_PRESS_N_RELEASE_LEVEL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( ON_OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( ON_OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__, ON_OFF_PRESS_N_RELEASE_LEVEL_OFF );
    
    OFF_PRESS_N_RELEASE_LEVEL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__, OFF_PRESS_N_RELEASE_LEVEL_OFF );
    
    DYNAMIC_ON_FB = new Crestron.Logos.SplusObjects.DigitalInput( DYNAMIC_ON_FB__DigitalInput__, this );
    m_DigitalInputList.Add( DYNAMIC_ON_FB__DigitalInput__, DYNAMIC_ON_FB );
    
    LEVEL_FB = new Crestron.Logos.SplusObjects.AnalogInput( LEVEL_FB__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LEVEL_FB__AnalogSerialInput__, LEVEL_FB );
    
    LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( LEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LEVEL__AnalogSerialOutput__, LEVEL );
    
    RL_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( RL_LEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RL_LEVEL__AnalogSerialOutput__, RL_LEVEL );
    
    
    ON_OFF_DOUBLE_PRESS_LEVEL_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_DOUBLE_PRESS_LEVEL_ON_OnPush_0, false ) );
    ON_DOUBLE_PRESS_LEVEL_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_DOUBLE_PRESS_LEVEL_ON_OnPush_0, false ) );
    ON_OFF_DOUBLE_PRESS_LEVEL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_DOUBLE_PRESS_LEVEL_OFF_OnPush_1, false ) );
    OFF_DOUBLE_PRESS_LEVEL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_DOUBLE_PRESS_LEVEL_OFF_OnPush_1, false ) );
    ON_OFF_PRESS_N_RELEASE_LEVEL_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_PRESS_N_RELEASE_LEVEL_ON_OnPush_2, false ) );
    ON_PRESS_N_RELEASE_LEVEL_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_PRESS_N_RELEASE_LEVEL_ON_OnPush_2, false ) );
    ON_OFF_PRESS_N_RELEASE_LEVEL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_PRESS_N_RELEASE_LEVEL_OFF_OnPush_3, false ) );
    OFF_PRESS_N_RELEASE_LEVEL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ON_OFF_PRESS_N_RELEASE_LEVEL_OFF_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_LIGHTING_CIRCUIT_CONTROL_LEVEL_LOGIC_V1_07 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ON_OFF_DOUBLE_PRESS_LEVEL_ON__DigitalInput__ = 0;
const uint ON_DOUBLE_PRESS_LEVEL_ON__DigitalInput__ = 1;
const uint ON_OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__ = 2;
const uint OFF_DOUBLE_PRESS_LEVEL_OFF__DigitalInput__ = 3;
const uint ON_OFF_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__ = 4;
const uint ON_PRESS_N_RELEASE_LEVEL_ON__DigitalInput__ = 5;
const uint ON_OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__ = 6;
const uint OFF_PRESS_N_RELEASE_LEVEL_OFF__DigitalInput__ = 7;
const uint DYNAMIC_ON_FB__DigitalInput__ = 8;
const uint LEVEL_FB__AnalogSerialInput__ = 0;
const uint LEVEL__AnalogSerialOutput__ = 0;
const uint RL_LEVEL__AnalogSerialOutput__ = 1;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort NLASTONLEVEL = 0;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
