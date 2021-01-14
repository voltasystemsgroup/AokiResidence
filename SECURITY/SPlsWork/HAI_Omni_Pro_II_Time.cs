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

namespace UserModule_HAI_OMNI_PRO_II_TIME
{
    public class UserModuleClass_HAI_OMNI_PRO_II_TIME : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.AnalogInput HOUR;
        Crestron.Logos.SplusObjects.AnalogInput MINUTE;
        Crestron.Logos.SplusObjects.AnalogInput SECOND;
        Crestron.Logos.SplusObjects.AnalogInput SUNRISE_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput SUNRISE_MINUTE;
        Crestron.Logos.SplusObjects.AnalogInput SUNSET_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput SUNSET_MINUTE;
        Crestron.Logos.SplusObjects.StringOutput COMBINED__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SUNRISE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SUNSET__DOLLAR__;
        object SECOND_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 180;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HOUR  .UshortValue == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 182;
                    MakeString ( COMBINED__DOLLAR__ , "12:{0:d2}:{1:d2} am", (ushort)MINUTE  .UshortValue, (ushort)SECOND  .UshortValue) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 184;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( HOUR  .UshortValue < 12 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 186;
                        MakeString ( COMBINED__DOLLAR__ , "{0:d}:{1:d2}:{2:d2} am", (ushort)HOUR  .UshortValue, (ushort)MINUTE  .UshortValue, (ushort)SECOND  .UshortValue) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 188;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HOUR  .UshortValue == 12))  ) ) 
                            { 
                            __context__.SourceCodeLine = 190;
                            MakeString ( COMBINED__DOLLAR__ , "{0:d}:{1:d2}:{2:d2} pm", (ushort)HOUR  .UshortValue, (ushort)MINUTE  .UshortValue, (ushort)SECOND  .UshortValue) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 194;
                            MakeString ( COMBINED__DOLLAR__ , "{0:d}:{1:d2}:{2:d2} pm", (ushort)(HOUR  .UshortValue - 12), (ushort)MINUTE  .UshortValue, (ushort)SECOND  .UshortValue) ; 
                            } 
                        
                        }
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SUNRISE_MINUTE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 201;
            MakeString ( SUNRISE__DOLLAR__ , "{0:d}:{1:d2} am", (ushort)SUNRISE_HOUR  .UshortValue, (ushort)SUNRISE_MINUTE  .UshortValue) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SUNSET_MINUTE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 208;
        MakeString ( SUNSET__DOLLAR__ , "{0:d}:{1:d2} pm", (ushort)(SUNSET_HOUR  .UshortValue - 12), (ushort)SUNSET_MINUTE  .UshortValue) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    HOUR = new Crestron.Logos.SplusObjects.AnalogInput( HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( HOUR__AnalogSerialInput__, HOUR );
    
    MINUTE = new Crestron.Logos.SplusObjects.AnalogInput( MINUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MINUTE__AnalogSerialInput__, MINUTE );
    
    SECOND = new Crestron.Logos.SplusObjects.AnalogInput( SECOND__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SECOND__AnalogSerialInput__, SECOND );
    
    SUNRISE_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( SUNRISE_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SUNRISE_HOUR__AnalogSerialInput__, SUNRISE_HOUR );
    
    SUNRISE_MINUTE = new Crestron.Logos.SplusObjects.AnalogInput( SUNRISE_MINUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SUNRISE_MINUTE__AnalogSerialInput__, SUNRISE_MINUTE );
    
    SUNSET_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( SUNSET_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SUNSET_HOUR__AnalogSerialInput__, SUNSET_HOUR );
    
    SUNSET_MINUTE = new Crestron.Logos.SplusObjects.AnalogInput( SUNSET_MINUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SUNSET_MINUTE__AnalogSerialInput__, SUNSET_MINUTE );
    
    COMBINED__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMBINED__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( COMBINED__DOLLAR____AnalogSerialOutput__, COMBINED__DOLLAR__ );
    
    SUNRISE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SUNRISE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUNRISE__DOLLAR____AnalogSerialOutput__, SUNRISE__DOLLAR__ );
    
    SUNSET__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SUNSET__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUNSET__DOLLAR____AnalogSerialOutput__, SUNSET__DOLLAR__ );
    
    
    SECOND.OnAnalogChange.Add( new InputChangeHandlerWrapper( SECOND_OnChange_0, false ) );
    SUNRISE_MINUTE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SUNRISE_MINUTE_OnChange_1, false ) );
    SUNSET_MINUTE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SUNSET_MINUTE_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_HAI_OMNI_PRO_II_TIME ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint HOUR__AnalogSerialInput__ = 0;
const uint MINUTE__AnalogSerialInput__ = 1;
const uint SECOND__AnalogSerialInput__ = 2;
const uint SUNRISE_HOUR__AnalogSerialInput__ = 3;
const uint SUNRISE_MINUTE__AnalogSerialInput__ = 4;
const uint SUNSET_HOUR__AnalogSerialInput__ = 5;
const uint SUNSET_MINUTE__AnalogSerialInput__ = 6;
const uint COMBINED__DOLLAR____AnalogSerialOutput__ = 0;
const uint SUNRISE__DOLLAR____AnalogSerialOutput__ = 1;
const uint SUNSET__DOLLAR____AnalogSerialOutput__ = 2;

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
