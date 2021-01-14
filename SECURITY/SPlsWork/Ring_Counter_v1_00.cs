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

namespace UserModule_RING_COUNTER_V1_00
{
    public class UserModuleClass_RING_COUNTER_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput RESET;
        Crestron.Logos.SplusObjects.DigitalInput PREVIOUS;
        Crestron.Logos.SplusObjects.DigitalInput NEXT;
        Crestron.Logos.SplusObjects.AnalogInput FORCE;
        Crestron.Logos.SplusObjects.AnalogInput RANGE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OUT;
        UShortParameter WRAP_AROUND;
        UShortParameter START_POS;
        ushort GNINITCOMPLETE = 0;
        ushort GNOUTPUT = 0;
        ushort GNLASTOUTPUT = 0;
        private void UPDATEOUTPUT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 38;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GNLASTOUTPUT != GNOUTPUT))  ) ) 
                { 
                __context__.SourceCodeLine = 40;
                if ( Functions.TestForTrue  ( ( GNLASTOUTPUT)  ) ) 
                    { 
                    __context__.SourceCodeLine = 42;
                    OUT [ GNLASTOUTPUT]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 44;
                    if ( Functions.TestForTrue  ( ( GNOUTPUT)  ) ) 
                        { 
                        __context__.SourceCodeLine = 46;
                        OUT [ GNOUTPUT]  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    } 
                
                } 
            
            
            }
            
        private void RESETRC (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 54;
            if ( Functions.TestForTrue  ( ( START_POS  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 56;
                GNLASTOUTPUT = (ushort) ( GNOUTPUT ) ; 
                __context__.SourceCodeLine = 57;
                GNOUTPUT = (ushort) ( START_POS  .Value ) ; 
                __context__.SourceCodeLine = 58;
                UPDATEOUTPUT (  __context__  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 62;
                GNLASTOUTPUT = (ushort) ( GNOUTPUT ) ; 
                __context__.SourceCodeLine = 63;
                GNOUTPUT = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 64;
                UPDATEOUTPUT (  __context__  ) ; 
                } 
            
            
            }
            
        object NEXT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort NOUTOFRANGE = 0;
                
                
                __context__.SourceCodeLine = 72;
                NOUTOFRANGE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 74;
                if ( Functions.TestForTrue  ( ( GNOUTPUT)  ) ) 
                    { 
                    __context__.SourceCodeLine = 76;
                    GNLASTOUTPUT = (ushort) ( GNOUTPUT ) ; 
                    __context__.SourceCodeLine = 77;
                    GNOUTPUT = (ushort) ( (GNOUTPUT + 1) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 81;
                    GNLASTOUTPUT = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 82;
                    GNOUTPUT = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 85;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GNOUTPUT > RANGE  .UshortValue ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 87;
                    if ( Functions.TestForTrue  ( ( WRAP_AROUND  .Value)  ) ) 
                        { 
                        __context__.SourceCodeLine = 89;
                        GNLASTOUTPUT = (ushort) ( RANGE  .UshortValue ) ; 
                        __context__.SourceCodeLine = 90;
                        GNOUTPUT = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 94;
                        NOUTOFRANGE = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 95;
                        GNOUTPUT = (ushort) ( GNLASTOUTPUT ) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 99;
                if ( Functions.TestForTrue  ( ( Functions.Not( NOUTOFRANGE ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 101;
                    UPDATEOUTPUT (  __context__  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PREVIOUS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort NOUTOFRANGE = 0;
            
            
            __context__.SourceCodeLine = 109;
            NOUTOFRANGE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 111;
            if ( Functions.TestForTrue  ( ( GNOUTPUT)  ) ) 
                { 
                __context__.SourceCodeLine = 113;
                GNLASTOUTPUT = (ushort) ( GNOUTPUT ) ; 
                __context__.SourceCodeLine = 114;
                GNOUTPUT = (ushort) ( (GNOUTPUT - 1) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 118;
                GNLASTOUTPUT = (ushort) ( RANGE  .UshortValue ) ; 
                __context__.SourceCodeLine = 119;
                GNOUTPUT = (ushort) ( RANGE  .UshortValue ) ; 
                } 
            
            __context__.SourceCodeLine = 122;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GNOUTPUT == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 124;
                if ( Functions.TestForTrue  ( ( WRAP_AROUND  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 126;
                    GNLASTOUTPUT = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 127;
                    GNOUTPUT = (ushort) ( RANGE  .UshortValue ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 131;
                    NOUTOFRANGE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 132;
                    GNOUTPUT = (ushort) ( GNLASTOUTPUT ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 136;
            if ( Functions.TestForTrue  ( ( Functions.Not( NOUTOFRANGE ))  ) ) 
                { 
                __context__.SourceCodeLine = 138;
                UPDATEOUTPUT (  __context__  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RESET_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 144;
        RESETRC (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FORCE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 149;
        if ( Functions.TestForTrue  ( ( GNINITCOMPLETE)  ) ) 
            { 
            __context__.SourceCodeLine = 151;
            GNLASTOUTPUT = (ushort) ( GNOUTPUT ) ; 
            __context__.SourceCodeLine = 152;
            GNOUTPUT = (ushort) ( FORCE  .UshortValue ) ; 
            __context__.SourceCodeLine = 153;
            UPDATEOUTPUT (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RANGE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 159;
        if ( Functions.TestForTrue  ( ( GNINITCOMPLETE)  ) ) 
            { 
            __context__.SourceCodeLine = 161;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GNOUTPUT > RANGE  .UshortValue ))  ) ) 
                { 
                __context__.SourceCodeLine = 163;
                RESETRC (  __context__  ) ; 
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
        
        __context__.SourceCodeLine = 171;
        GNINITCOMPLETE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 172;
        GNINITCOMPLETE = (ushort) ( Functions.Not( WaitForInitializationComplete() ) ) ; 
        __context__.SourceCodeLine = 174;
        GNLASTOUTPUT = (ushort) ( START_POS  .Value ) ; 
        __context__.SourceCodeLine = 175;
        GNOUTPUT = (ushort) ( START_POS  .Value ) ; 
        __context__.SourceCodeLine = 176;
        UPDATEOUTPUT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    RESET = new Crestron.Logos.SplusObjects.DigitalInput( RESET__DigitalInput__, this );
    m_DigitalInputList.Add( RESET__DigitalInput__, RESET );
    
    PREVIOUS = new Crestron.Logos.SplusObjects.DigitalInput( PREVIOUS__DigitalInput__, this );
    m_DigitalInputList.Add( PREVIOUS__DigitalInput__, PREVIOUS );
    
    NEXT = new Crestron.Logos.SplusObjects.DigitalInput( NEXT__DigitalInput__, this );
    m_DigitalInputList.Add( NEXT__DigitalInput__, NEXT );
    
    OUT = new InOutArray<DigitalOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( OUT__DigitalOutput__ + i, OUT[i+1] );
    }
    
    FORCE = new Crestron.Logos.SplusObjects.AnalogInput( FORCE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FORCE__AnalogSerialInput__, FORCE );
    
    RANGE = new Crestron.Logos.SplusObjects.AnalogInput( RANGE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RANGE__AnalogSerialInput__, RANGE );
    
    WRAP_AROUND = new UShortParameter( WRAP_AROUND__Parameter__, this );
    m_ParameterList.Add( WRAP_AROUND__Parameter__, WRAP_AROUND );
    
    START_POS = new UShortParameter( START_POS__Parameter__, this );
    m_ParameterList.Add( START_POS__Parameter__, START_POS );
    
    
    NEXT.OnDigitalPush.Add( new InputChangeHandlerWrapper( NEXT_OnPush_0, false ) );
    PREVIOUS.OnDigitalPush.Add( new InputChangeHandlerWrapper( PREVIOUS_OnPush_1, false ) );
    RESET.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESET_OnPush_2, false ) );
    FORCE.OnAnalogChange.Add( new InputChangeHandlerWrapper( FORCE_OnChange_3, false ) );
    RANGE.OnAnalogChange.Add( new InputChangeHandlerWrapper( RANGE_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_RING_COUNTER_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RESET__DigitalInput__ = 0;
const uint PREVIOUS__DigitalInput__ = 1;
const uint NEXT__DigitalInput__ = 2;
const uint FORCE__AnalogSerialInput__ = 0;
const uint RANGE__AnalogSerialInput__ = 1;
const uint OUT__DigitalOutput__ = 0;
const uint WRAP_AROUND__Parameter__ = 10;
const uint START_POS__Parameter__ = 11;

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
