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

namespace UserModule_DATA_SELECTOR_SERIAL_V1_00
{
    public class UserModuleClass_DATA_SELECTOR_SERIAL_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DATA;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> OUTPUT_DATA_INDEX;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> OUTPUT;
        private void UPDATEOUTPUT (  SplusExecutionContext __context__, ushort NOUTPUTINDEX , ushort NDATAINDEX ) 
            { 
            
            __context__.SourceCodeLine = 15;
            OUTPUT [ NOUTPUTINDEX]  .UpdateValue ( DATA [ NDATAINDEX ]  ) ; 
            
            }
            
        object OUTPUT_DATA_INDEX_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort NOUTPUTINDEX = 0;
                ushort NDATAINDEX = 0;
                
                
                __context__.SourceCodeLine = 22;
                if ( Functions.TestForTrue  ( ( _SplusNVRAM.GNINITCOMPLETE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 24;
                    NOUTPUTINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 25;
                    NDATAINDEX = (ushort) ( OUTPUT_DATA_INDEX[ NOUTPUTINDEX ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 27;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDATAINDEX < 65 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 29;
                        UPDATEOUTPUT (  __context__ , (ushort)( NOUTPUTINDEX ), (ushort)( (NDATAINDEX + 1) )) ; 
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DATA_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort NOUTPUTDATAINDEX = 0;
            ushort NDATAINDEX = 0;
            
            
            __context__.SourceCodeLine = 39;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.GNINITCOMPLETE)  ) ) 
                { 
                __context__.SourceCodeLine = 41;
                NDATAINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 43;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)65; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( NOUTPUTDATAINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NOUTPUTDATAINDEX  >= __FN_FORSTART_VAL__1) && (NOUTPUTDATAINDEX  <= __FN_FOREND_VAL__1) ) : ( (NOUTPUTDATAINDEX  <= __FN_FORSTART_VAL__1) && (NOUTPUTDATAINDEX  >= __FN_FOREND_VAL__1) ) ; NOUTPUTDATAINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 45;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((OUTPUT_DATA_INDEX[ NOUTPUTDATAINDEX ] .UshortValue + 1) == NDATAINDEX))  ) ) 
                        { 
                        __context__.SourceCodeLine = 47;
                        UPDATEOUTPUT (  __context__ , (ushort)( NOUTPUTDATAINDEX ), (ushort)( (OUTPUT_DATA_INDEX[ NOUTPUTDATAINDEX ] .UshortValue + 1) )) ; 
                        } 
                    
                    __context__.SourceCodeLine = 43;
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
        
        __context__.SourceCodeLine = 55;
        _SplusNVRAM.GNINITCOMPLETE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 56;
        _SplusNVRAM.GNINITCOMPLETE = (ushort) ( Functions.Not( WaitForInitializationComplete() ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    OUTPUT_DATA_INDEX = new InOutArray<AnalogInput>( 65, this );
    for( uint i = 0; i < 65; i++ )
    {
        OUTPUT_DATA_INDEX[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( OUTPUT_DATA_INDEX__AnalogSerialInput__ + i, OUTPUT_DATA_INDEX__AnalogSerialInput__, this );
        m_AnalogInputList.Add( OUTPUT_DATA_INDEX__AnalogSerialInput__ + i, OUTPUT_DATA_INDEX[i+1] );
    }
    
    DATA = new InOutArray<StringInput>( 65, this );
    for( uint i = 0; i < 65; i++ )
    {
        DATA[i+1] = new Crestron.Logos.SplusObjects.StringInput( DATA__AnalogSerialInput__ + i, DATA__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( DATA__AnalogSerialInput__ + i, DATA[i+1] );
    }
    
    OUTPUT = new InOutArray<StringOutput>( 65, this );
    for( uint i = 0; i < 65; i++ )
    {
        OUTPUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( OUTPUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( OUTPUT__AnalogSerialOutput__ + i, OUTPUT[i+1] );
    }
    
    
    for( uint i = 0; i < 65; i++ )
        OUTPUT_DATA_INDEX[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( OUTPUT_DATA_INDEX_OnChange_0, false ) );
        
    for( uint i = 0; i < 65; i++ )
        DATA[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DATA_OnChange_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_DATA_SELECTOR_SERIAL_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DATA__AnalogSerialInput__ = 0;
const uint OUTPUT_DATA_INDEX__AnalogSerialInput__ = 65;
const uint OUTPUT__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort GNINITCOMPLETE = 0;
            
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
