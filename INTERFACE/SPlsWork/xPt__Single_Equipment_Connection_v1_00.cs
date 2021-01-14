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

namespace UserModule_XPT__SINGLE_EQUIPMENT_CONNECTION_V1_00
{
    public class UserModuleClass_XPT__SINGLE_EQUIPMENT_CONNECTION_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        Crestron.Logos.SplusObjects.AnalogInput CONNECTTO;
        Crestron.Logos.SplusObjects.DigitalOutput CONNECT;
        Crestron.Logos.SplusObjects.DigitalOutput DISCEC;
        Crestron.Logos.SplusObjects.AnalogOutput EQUIPMENTID;
        ushort GNCURRENTCONNECTION = 0;
        object CONNECTTO_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 19;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONNECTTO  .UshortValue != GNCURRENTCONNECTION))  ) ) 
                    { 
                    __context__.SourceCodeLine = 22;
                    if ( Functions.TestForTrue  ( ( GNCURRENTCONNECTION)  ) ) 
                        { 
                        __context__.SourceCodeLine = 25;
                        EQUIPMENTID  .Value = (ushort) ( GNCURRENTCONNECTION ) ; 
                        __context__.SourceCodeLine = 26;
                        Functions.Pulse ( 1, DISCEC ) ; 
                        __context__.SourceCodeLine = 27;
                        GNCURRENTCONNECTION = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 30;
                    if ( Functions.TestForTrue  ( ( CONNECTTO  .UshortValue)  ) ) 
                        { 
                        __context__.SourceCodeLine = 32;
                        EQUIPMENTID  .Value = (ushort) ( CONNECTTO  .UshortValue ) ; 
                        __context__.SourceCodeLine = 33;
                        Functions.Pulse ( 1, CONNECT ) ; 
                        __context__.SourceCodeLine = 34;
                        GNCURRENTCONNECTION = (ushort) ( CONNECTTO  .UshortValue ) ; 
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
            
            __context__.SourceCodeLine = 42;
            GNCURRENTCONNECTION = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CONNECT = new Crestron.Logos.SplusObjects.DigitalOutput( CONNECT__DigitalOutput__, this );
        m_DigitalOutputList.Add( CONNECT__DigitalOutput__, CONNECT );
        
        DISCEC = new Crestron.Logos.SplusObjects.DigitalOutput( DISCEC__DigitalOutput__, this );
        m_DigitalOutputList.Add( DISCEC__DigitalOutput__, DISCEC );
        
        CONNECTTO = new Crestron.Logos.SplusObjects.AnalogInput( CONNECTTO__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CONNECTTO__AnalogSerialInput__, CONNECTTO );
        
        EQUIPMENTID = new Crestron.Logos.SplusObjects.AnalogOutput( EQUIPMENTID__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( EQUIPMENTID__AnalogSerialOutput__, EQUIPMENTID );
        
        
        CONNECTTO.OnAnalogChange.Add( new InputChangeHandlerWrapper( CONNECTTO_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_XPT__SINGLE_EQUIPMENT_CONNECTION_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CONNECTTO__AnalogSerialInput__ = 0;
    const uint CONNECT__DigitalOutput__ = 0;
    const uint DISCEC__DigitalOutput__ = 1;
    const uint EQUIPMENTID__AnalogSerialOutput__ = 0;
    
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
