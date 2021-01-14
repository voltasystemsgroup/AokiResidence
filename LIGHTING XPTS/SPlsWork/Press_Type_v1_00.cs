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

namespace UserModule_PRESS_TYPE_V1_00
{
    public class UserModuleClass_PRESS_TYPE_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        Crestron.Logos.SplusObjects.DigitalInput PRESS;
        Crestron.Logos.SplusObjects.DigitalInput PRESS_N_RELEASE_IN;
        Crestron.Logos.SplusObjects.DigitalInput PRESS_N_HOLD_IN;
        Crestron.Logos.SplusObjects.DigitalInput DOUBLE_PRESS_IN;
        Crestron.Logos.SplusObjects.AnalogInput PULSE_TIME;
        Crestron.Logos.SplusObjects.AnalogInput DOUBLE_PRESS_WAIT;
        Crestron.Logos.SplusObjects.AnalogInput PRESS_N_HOLD_WAIT;
        Crestron.Logos.SplusObjects.DigitalOutput PRESS_N_RELEASE;
        Crestron.Logos.SplusObjects.DigitalOutput PRESS_N_HOLD;
        Crestron.Logos.SplusObjects.DigitalOutput DOUBLE_PRESS;
        ushort NFIRSTPRESS = 0;
        ushort NINDOUBLEPRESSWAIT = 0;
        ushort NINPRESSNHOLDWAIT = 0;
        private void STARTWAITS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 30;
            NINPRESSNHOLDWAIT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 31;
            CreateWait ( "WPRESSNHOLDWAIT" , PRESS_N_HOLD_WAIT  .UshortValue , WPRESSNHOLDWAIT_Callback ) ;
            __context__.SourceCodeLine = 41;
            NINDOUBLEPRESSWAIT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 42;
            CreateWait ( "WDOUBLEPRESSWAIT" , DOUBLE_PRESS_WAIT  .UshortValue , WDOUBLEPRESSWAIT_Callback ) ;
            
            }
            
        public void WPRESSNHOLDWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 33;
            NINPRESSNHOLDWAIT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 34;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( NFIRSTPRESS ) && Functions.TestForTrue ( PRESS  .Value )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 36;
                NFIRSTPRESS = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 37;
                PRESS_N_HOLD  .Value = (ushort) ( 1 ) ; 
                } 
            
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    public void WDOUBLEPRESSWAIT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 44;
            NINDOUBLEPRESSWAIT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 45;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( NFIRSTPRESS ) && Functions.TestForTrue ( Functions.Not( PRESS  .Value ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 47;
                NFIRSTPRESS = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 48;
                Functions.Pulse ( PULSE_TIME  .UshortValue, PRESS_N_RELEASE ) ; 
                } 
            
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object PRESS_N_RELEASE_IN_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 55;
        CancelWait ( "WPRESSNHOLDWAIT" ) ; 
        __context__.SourceCodeLine = 56;
        NINPRESSNHOLDWAIT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 57;
        CancelWait ( "WDOUBLEPRESSWAIT" ) ; 
        __context__.SourceCodeLine = 58;
        NINDOUBLEPRESSWAIT = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRESS_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 63;
        if ( Functions.TestForTrue  ( ( NFIRSTPRESS)  ) ) 
            { 
            __context__.SourceCodeLine = 65;
            NFIRSTPRESS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 66;
            if ( Functions.TestForTrue  ( ( NINDOUBLEPRESSWAIT)  ) ) 
                { 
                __context__.SourceCodeLine = 68;
                Functions.Pulse ( PULSE_TIME  .UshortValue, DOUBLE_PRESS ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 73;
            NFIRSTPRESS = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 74;
            STARTWAITS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRESS_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 80;
        if ( Functions.TestForTrue  ( ( PRESS_N_HOLD  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 82;
            PRESS_N_HOLD  .Value = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 86;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( NFIRSTPRESS ) && Functions.TestForTrue ( NINPRESSNHOLDWAIT )) ) ) && Functions.TestForTrue ( Functions.Not( NINDOUBLEPRESSWAIT ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 88;
                NFIRSTPRESS = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 89;
                Functions.Pulse ( PULSE_TIME  .UshortValue, PRESS_N_RELEASE ) ; 
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
        
        __context__.SourceCodeLine = 103;
        NFIRSTPRESS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 104;
        NINDOUBLEPRESSWAIT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 105;
        NINPRESSNHOLDWAIT = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    PRESS = new Crestron.Logos.SplusObjects.DigitalInput( PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( PRESS__DigitalInput__, PRESS );
    
    PRESS_N_RELEASE_IN = new Crestron.Logos.SplusObjects.DigitalInput( PRESS_N_RELEASE_IN__DigitalInput__, this );
    m_DigitalInputList.Add( PRESS_N_RELEASE_IN__DigitalInput__, PRESS_N_RELEASE_IN );
    
    PRESS_N_HOLD_IN = new Crestron.Logos.SplusObjects.DigitalInput( PRESS_N_HOLD_IN__DigitalInput__, this );
    m_DigitalInputList.Add( PRESS_N_HOLD_IN__DigitalInput__, PRESS_N_HOLD_IN );
    
    DOUBLE_PRESS_IN = new Crestron.Logos.SplusObjects.DigitalInput( DOUBLE_PRESS_IN__DigitalInput__, this );
    m_DigitalInputList.Add( DOUBLE_PRESS_IN__DigitalInput__, DOUBLE_PRESS_IN );
    
    PRESS_N_RELEASE = new Crestron.Logos.SplusObjects.DigitalOutput( PRESS_N_RELEASE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESS_N_RELEASE__DigitalOutput__, PRESS_N_RELEASE );
    
    PRESS_N_HOLD = new Crestron.Logos.SplusObjects.DigitalOutput( PRESS_N_HOLD__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESS_N_HOLD__DigitalOutput__, PRESS_N_HOLD );
    
    DOUBLE_PRESS = new Crestron.Logos.SplusObjects.DigitalOutput( DOUBLE_PRESS__DigitalOutput__, this );
    m_DigitalOutputList.Add( DOUBLE_PRESS__DigitalOutput__, DOUBLE_PRESS );
    
    PULSE_TIME = new Crestron.Logos.SplusObjects.AnalogInput( PULSE_TIME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PULSE_TIME__AnalogSerialInput__, PULSE_TIME );
    
    DOUBLE_PRESS_WAIT = new Crestron.Logos.SplusObjects.AnalogInput( DOUBLE_PRESS_WAIT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DOUBLE_PRESS_WAIT__AnalogSerialInput__, DOUBLE_PRESS_WAIT );
    
    PRESS_N_HOLD_WAIT = new Crestron.Logos.SplusObjects.AnalogInput( PRESS_N_HOLD_WAIT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PRESS_N_HOLD_WAIT__AnalogSerialInput__, PRESS_N_HOLD_WAIT );
    
    WPRESSNHOLDWAIT_Callback = new WaitFunction( WPRESSNHOLDWAIT_CallbackFn );
    WDOUBLEPRESSWAIT_Callback = new WaitFunction( WDOUBLEPRESSWAIT_CallbackFn );
    
    PRESS_N_RELEASE_IN.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESS_N_RELEASE_IN_OnPush_0, false ) );
    PRESS_N_HOLD_IN.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESS_N_RELEASE_IN_OnPush_0, false ) );
    DOUBLE_PRESS_IN.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESS_N_RELEASE_IN_OnPush_0, false ) );
    PRESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESS_OnPush_1, false ) );
    PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( PRESS_OnRelease_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PRESS_TYPE_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WPRESSNHOLDWAIT_Callback;
private WaitFunction WDOUBLEPRESSWAIT_Callback;


const uint PRESS__DigitalInput__ = 0;
const uint PRESS_N_RELEASE_IN__DigitalInput__ = 1;
const uint PRESS_N_HOLD_IN__DigitalInput__ = 2;
const uint DOUBLE_PRESS_IN__DigitalInput__ = 3;
const uint PULSE_TIME__AnalogSerialInput__ = 0;
const uint DOUBLE_PRESS_WAIT__AnalogSerialInput__ = 1;
const uint PRESS_N_HOLD_WAIT__AnalogSerialInput__ = 2;
const uint PRESS_N_RELEASE__DigitalOutput__ = 0;
const uint PRESS_N_HOLD__DigitalOutput__ = 1;
const uint DOUBLE_PRESS__DigitalOutput__ = 2;

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
