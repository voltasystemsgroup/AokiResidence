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

namespace CrestronModule_COUNTFILES
{
    public class CrestronModuleClass_COUNTFILES : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DO_SEARCH;
        Crestron.Logos.SplusObjects.StringInput SEARCH_PATH__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput FILENAME_SPEC__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput COUNT_READY;
        Crestron.Logos.SplusObjects.AnalogOutput FILE_COUNT;
        private void SETFILECOUNT (  SplusExecutionContext __context__, ushort ICOUNT ) 
            { 
            
            __context__.SourceCodeLine = 22;
            FILE_COUNT  .Value = (ushort) ( ICOUNT ) ; 
            __context__.SourceCodeLine = 23;
            Functions.Pulse ( 100, COUNT_READY ) ; 
            
            }
            
        object DO_SEARCH_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                short IRESULT = 0;
                short IFINDRESULT = 0;
                
                FILE_INFO FI;
                FI  = new FILE_INFO();
                FI .PopulateDefaults();
                
                ushort IFILECOUNT = 0;
                
                
                __context__.SourceCodeLine = 33;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 35;
                IRESULT = (short) ( SetCurrentDirectory( SEARCH_PATH__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 37;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRESULT < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 39;
                    SETFILECOUNT (  __context__ , (ushort)( 0 )) ; 
                    __context__.SourceCodeLine = 40;
                    Functions.TerminateEvent (); 
                    } 
                
                __context__.SourceCodeLine = 43;
                IFILECOUNT = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 45;
                IFINDRESULT = (short) ( FindFirst( FILENAME_SPEC__DOLLAR__ , ref FI ) ) ; 
                __context__.SourceCodeLine = 47;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFINDRESULT == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 49;
                    IFILECOUNT = (ushort) ( (IFILECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 50;
                    IFINDRESULT = (short) ( FindNext( ref FI ) ) ; 
                    __context__.SourceCodeLine = 47;
                    } 
                
                __context__.SourceCodeLine = 53;
                SETFILECOUNT (  __context__ , (ushort)( IFILECOUNT )) ; 
                __context__.SourceCodeLine = 55;
                EndFileOperations ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        DO_SEARCH = new Crestron.Logos.SplusObjects.DigitalInput( DO_SEARCH__DigitalInput__, this );
        m_DigitalInputList.Add( DO_SEARCH__DigitalInput__, DO_SEARCH );
        
        COUNT_READY = new Crestron.Logos.SplusObjects.DigitalOutput( COUNT_READY__DigitalOutput__, this );
        m_DigitalOutputList.Add( COUNT_READY__DigitalOutput__, COUNT_READY );
        
        FILE_COUNT = new Crestron.Logos.SplusObjects.AnalogOutput( FILE_COUNT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( FILE_COUNT__AnalogSerialOutput__, FILE_COUNT );
        
        SEARCH_PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SEARCH_PATH__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( SEARCH_PATH__DOLLAR____AnalogSerialInput__, SEARCH_PATH__DOLLAR__ );
        
        FILENAME_SPEC__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FILENAME_SPEC__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( FILENAME_SPEC__DOLLAR____AnalogSerialInput__, FILENAME_SPEC__DOLLAR__ );
        
        
        DO_SEARCH.OnDigitalPush.Add( new InputChangeHandlerWrapper( DO_SEARCH_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_COUNTFILES ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint DO_SEARCH__DigitalInput__ = 0;
    const uint SEARCH_PATH__DOLLAR____AnalogSerialInput__ = 0;
    const uint FILENAME_SPEC__DOLLAR____AnalogSerialInput__ = 1;
    const uint COUNT_READY__DigitalOutput__ = 0;
    const uint FILE_COUNT__AnalogSerialOutput__ = 0;
    
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
