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

namespace CrestronModule_TMSG2
{
    public class CrestronModuleClass_TMSG2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput TIMESTAMP;
        Crestron.Logos.SplusObjects.DigitalInput DATESTAMP;
        Crestron.Logos.SplusObjects.StringInput MESSAGE__DOLLAR__;
        object MESSAGE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 25;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( TIMESTAMP  .Value ) ) && Functions.TestForTrue ( Functions.Not( DATESTAMP  .Value ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 26;
                    Print( "{0}\r\n", MESSAGE__DOLLAR__ ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 27;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( TIMESTAMP  .Value ) && Functions.TestForTrue ( DATESTAMP  .Value )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 28;
                        Print( "{0} ({1}, {2})\r\n", MESSAGE__DOLLAR__ , Functions.Date (  (int) ( 1 ) ) , Functions.Time ( ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 29;
                        if ( Functions.TestForTrue  ( ( TIMESTAMP  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 30;
                            Print( "{0} ({1})\r\n", MESSAGE__DOLLAR__ , Functions.Time ( ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 32;
                            Print( "{0} ({1})\r\n", MESSAGE__DOLLAR__ , Functions.Date (  (int) ( 1 ) ) ) ; 
                            }
                        
                        }
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        TIMESTAMP = new Crestron.Logos.SplusObjects.DigitalInput( TIMESTAMP__DigitalInput__, this );
        m_DigitalInputList.Add( TIMESTAMP__DigitalInput__, TIMESTAMP );
        
        DATESTAMP = new Crestron.Logos.SplusObjects.DigitalInput( DATESTAMP__DigitalInput__, this );
        m_DigitalInputList.Add( DATESTAMP__DigitalInput__, DATESTAMP );
        
        MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( MESSAGE__DOLLAR____AnalogSerialInput__, 255, this );
        m_StringInputList.Add( MESSAGE__DOLLAR____AnalogSerialInput__, MESSAGE__DOLLAR__ );
        
        
        MESSAGE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( MESSAGE__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_TMSG2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TIMESTAMP__DigitalInput__ = 0;
    const uint DATESTAMP__DigitalInput__ = 1;
    const uint MESSAGE__DOLLAR____AnalogSerialInput__ = 0;
    
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
