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

namespace UserModule_AUX_SOURCE___TIMEOUT_V1_00
{
    public class UserModuleClass_AUX_SOURCE___TIMEOUT_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        Crestron.Logos.SplusObjects.DigitalInput AUX_TRIGGER;
        Crestron.Logos.SplusObjects.AnalogInput SRC_INDEX_IN;
        Crestron.Logos.SplusObjects.AnalogInput AUX_FROM_OFF_ENABLED;
        Crestron.Logos.SplusObjects.AnalogInput AUX_SRC_INDEX;
        Crestron.Logos.SplusObjects.AnalogInput TIMEOUT_TIME_FROM_OFF;
        Crestron.Logos.SplusObjects.AnalogInput TIMEOUT_TIME_FROM_ON;
        Crestron.Logos.SplusObjects.AnalogOutput SRC_INDEX_OUT;
        ushort GNSRCINDEX = 0;
        ushort GNINAUX = 0;
        object AUX_TRIGGER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 18;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( AUX_FROM_OFF_ENABLED  .UshortValue ) || Functions.TestForTrue ( GNSRCINDEX )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 20;
                    GNINAUX = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 21;
                    SRC_INDEX_OUT  .Value = (ushort) ( AUX_SRC_INDEX  .UshortValue ) ; 
                    __context__.SourceCodeLine = 23;
                    if ( Functions.TestForTrue  ( ( GNSRCINDEX)  ) ) 
                        { 
                        __context__.SourceCodeLine = 25;
                        CreateWait ( "WTIMEOUTFROMON" , TIMEOUT_TIME_FROM_ON  .UshortValue , WTIMEOUTFROMON_Callback ) ;
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 33;
                        CreateWait ( "WTIMEOUTFROMOFF" , TIMEOUT_TIME_FROM_OFF  .UshortValue , WTIMEOUTFROMOFF_Callback ) ;
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void WTIMEOUTFROMON_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 27;
            SRC_INDEX_OUT  .Value = (ushort) ( GNSRCINDEX ) ; 
            __context__.SourceCodeLine = 28;
            GNINAUX = (ushort) ( 0 ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
public void WTIMEOUTFROMOFF_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 35;
            SRC_INDEX_OUT  .Value = (ushort) ( GNSRCINDEX ) ; 
            __context__.SourceCodeLine = 36;
            GNINAUX = (ushort) ( 0 ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object SRC_INDEX_IN_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 45;
        if ( Functions.TestForTrue  ( ( Functions.Not( GNINAUX ))  ) ) 
            { 
            __context__.SourceCodeLine = 47;
            GNSRCINDEX = (ushort) ( SRC_INDEX_IN  .UshortValue ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 51;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRC_INDEX_IN  .UshortValue != AUX_SRC_INDEX  .UshortValue))  ) ) 
                { 
                __context__.SourceCodeLine = 53;
                CancelWait ( "WTIMEOUTFROMON" ) ; 
                __context__.SourceCodeLine = 54;
                CancelWait ( "WTIMEOUTFROMOFF" ) ; 
                __context__.SourceCodeLine = 55;
                GNINAUX = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 56;
                GNSRCINDEX = (ushort) ( SRC_INDEX_IN  .UshortValue ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 65;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 66;
        GNSRCINDEX = (ushort) ( SRC_INDEX_IN  .UshortValue ) ; 
        __context__.SourceCodeLine = 67;
        GNINAUX = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    AUX_TRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( AUX_TRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( AUX_TRIGGER__DigitalInput__, AUX_TRIGGER );
    
    SRC_INDEX_IN = new Crestron.Logos.SplusObjects.AnalogInput( SRC_INDEX_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SRC_INDEX_IN__AnalogSerialInput__, SRC_INDEX_IN );
    
    AUX_FROM_OFF_ENABLED = new Crestron.Logos.SplusObjects.AnalogInput( AUX_FROM_OFF_ENABLED__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUX_FROM_OFF_ENABLED__AnalogSerialInput__, AUX_FROM_OFF_ENABLED );
    
    AUX_SRC_INDEX = new Crestron.Logos.SplusObjects.AnalogInput( AUX_SRC_INDEX__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUX_SRC_INDEX__AnalogSerialInput__, AUX_SRC_INDEX );
    
    TIMEOUT_TIME_FROM_OFF = new Crestron.Logos.SplusObjects.AnalogInput( TIMEOUT_TIME_FROM_OFF__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TIMEOUT_TIME_FROM_OFF__AnalogSerialInput__, TIMEOUT_TIME_FROM_OFF );
    
    TIMEOUT_TIME_FROM_ON = new Crestron.Logos.SplusObjects.AnalogInput( TIMEOUT_TIME_FROM_ON__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TIMEOUT_TIME_FROM_ON__AnalogSerialInput__, TIMEOUT_TIME_FROM_ON );
    
    SRC_INDEX_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( SRC_INDEX_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SRC_INDEX_OUT__AnalogSerialOutput__, SRC_INDEX_OUT );
    
    WTIMEOUTFROMON_Callback = new WaitFunction( WTIMEOUTFROMON_CallbackFn );
    WTIMEOUTFROMOFF_Callback = new WaitFunction( WTIMEOUTFROMOFF_CallbackFn );
    
    AUX_TRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUX_TRIGGER_OnPush_0, false ) );
    SRC_INDEX_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( SRC_INDEX_IN_OnChange_1, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_AUX_SOURCE___TIMEOUT_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WTIMEOUTFROMON_Callback;
private WaitFunction WTIMEOUTFROMOFF_Callback;


const uint AUX_TRIGGER__DigitalInput__ = 0;
const uint SRC_INDEX_IN__AnalogSerialInput__ = 0;
const uint AUX_FROM_OFF_ENABLED__AnalogSerialInput__ = 1;
const uint AUX_SRC_INDEX__AnalogSerialInput__ = 2;
const uint TIMEOUT_TIME_FROM_OFF__AnalogSerialInput__ = 3;
const uint TIMEOUT_TIME_FROM_ON__AnalogSerialInput__ = 4;
const uint SRC_INDEX_OUT__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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
