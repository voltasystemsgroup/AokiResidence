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

namespace CrestronModule_CONCAT_FILES
{
    public class CrestronModuleClass_CONCAT_FILES : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONCAT;
        Crestron.Logos.SplusObjects.StringInput READ_PATH__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput READ_WILDCARD__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput WRITE_FILENAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput RESPONSE_MSG__DOLLAR__;
        object CONCAT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                short IRESULT = 0;
                short IFINDRESULT = 0;
                short IFILEHANDLEWRITE = 0;
                short IFILEHANDLEREAD = 0;
                
                ushort I = 0;
                ushort ILEVEL = 0;
                
                CrestronString SWRITEDATA;
                SWRITEDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
                
                CrestronString SREADFILENAME;
                SREADFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
                
                FILE_INFO FI;
                FI  = new FILE_INFO();
                FI .PopulateDefaults();
                
                ushort IFILECOUNT = 0;
                
                
                __context__.SourceCodeLine = 23;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 25;
                FileDelete ( WRITE_FILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 27;
                IFILEHANDLEWRITE = (short) ( FileOpen( WRITE_FILENAME__DOLLAR__ ,(ushort) ((256 | 1) | 16384) ) ) ; 
                __context__.SourceCodeLine = 29;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLEWRITE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 31;
                    IRESULT = (short) ( SetCurrentDirectory( READ_PATH__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 33;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRESULT < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 35;
                        RESPONSE_MSG__DOLLAR__  .UpdateValue ( "ERROR\r\n>"  ) ; 
                        __context__.SourceCodeLine = 36;
                        Functions.TerminateEvent (); 
                        } 
                    
                    __context__.SourceCodeLine = 39;
                    IFILECOUNT = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 41;
                    IFINDRESULT = (short) ( FindFirst( READ_WILDCARD__DOLLAR__ , ref FI ) ) ; 
                    __context__.SourceCodeLine = 43;
                    while ( Functions.TestForTrue  ( ( Functions.Not( IFINDRESULT ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 45;
                        SREADFILENAME  .UpdateValue ( FI .  Name  ) ; 
                        __context__.SourceCodeLine = 46;
                        IFILEHANDLEREAD = (short) ( FileOpen( SREADFILENAME ,(ushort) (0 | 32768) ) ) ; 
                        __context__.SourceCodeLine = 48;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLEREAD >= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 51;
                            IFILECOUNT = (ushort) ( (IFILECOUNT + 1) ) ; 
                            __context__.SourceCodeLine = 53;
                            SWRITEDATA  .UpdateValue ( "[" + FI .  Name + "]"  ) ; 
                            __context__.SourceCodeLine = 54;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SWRITEDATA ,  (ushort) ( Functions.Length( SWRITEDATA ) ) ) ; 
                            __context__.SourceCodeLine = 55;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , "\u000D\u000A" ,  (ushort) ( 2 ) ) ; 
                            __context__.SourceCodeLine = 57;
                            I = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 59;
                            while ( Functions.TestForTrue  ( ( Functions.Not( FileEOF( (short)( IFILEHANDLEREAD ) ) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 61;
                                IRESULT = (short) ( ReadInteger( (short)( IFILEHANDLEREAD ) , ref ILEVEL ) ) ; 
                                __context__.SourceCodeLine = 63;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRESULT > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 65;
                                    SWRITEDATA  .UpdateValue ( Functions.ItoA (  (int) ( ILEVEL ) ) + "\u000D\u000A"  ) ; 
                                    __context__.SourceCodeLine = 66;
                                    FileWrite (  (short) ( IFILEHANDLEWRITE ) , SWRITEDATA ,  (ushort) ( Functions.Length( SWRITEDATA ) ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 70;
                                    break ; 
                                    } 
                                
                                __context__.SourceCodeLine = 59;
                                } 
                            
                            __context__.SourceCodeLine = 74;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , "\u000D\u000A" ,  (ushort) ( 2 ) ) ; 
                            __context__.SourceCodeLine = 75;
                            IRESULT = (short) ( FileClose( (short)( IFILEHANDLEREAD ) ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 78;
                        IFINDRESULT = (short) ( FindNext( ref FI ) ) ; 
                        __context__.SourceCodeLine = 43;
                        } 
                    
                    __context__.SourceCodeLine = 82;
                    IRESULT = (short) ( FileClose( (short)( IFILEHANDLEWRITE ) ) ) ; 
                    __context__.SourceCodeLine = 84;
                    RESPONSE_MSG__DOLLAR__  .UpdateValue ( "OK " + Functions.ItoA (  (int) ( IFILECOUNT ) ) + "\r\n>"  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 88;
                    RESPONSE_MSG__DOLLAR__  .UpdateValue ( "ERROR\r\n>"  ) ; 
                    }
                
                __context__.SourceCodeLine = 90;
                EndFileOperations ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CONCAT = new Crestron.Logos.SplusObjects.DigitalInput( CONCAT__DigitalInput__, this );
        m_DigitalInputList.Add( CONCAT__DigitalInput__, CONCAT );
        
        READ_PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( READ_PATH__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( READ_PATH__DOLLAR____AnalogSerialInput__, READ_PATH__DOLLAR__ );
        
        READ_WILDCARD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( READ_WILDCARD__DOLLAR____AnalogSerialInput__, 32, this );
        m_StringInputList.Add( READ_WILDCARD__DOLLAR____AnalogSerialInput__, READ_WILDCARD__DOLLAR__ );
        
        WRITE_FILENAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( WRITE_FILENAME__DOLLAR____AnalogSerialInput__, 32, this );
        m_StringInputList.Add( WRITE_FILENAME__DOLLAR____AnalogSerialInput__, WRITE_FILENAME__DOLLAR__ );
        
        RESPONSE_MSG__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RESPONSE_MSG__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( RESPONSE_MSG__DOLLAR____AnalogSerialOutput__, RESPONSE_MSG__DOLLAR__ );
        
        
        CONCAT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONCAT_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_CONCAT_FILES ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CONCAT__DigitalInput__ = 0;
    const uint READ_PATH__DOLLAR____AnalogSerialInput__ = 0;
    const uint READ_WILDCARD__DOLLAR____AnalogSerialInput__ = 1;
    const uint WRITE_FILENAME__DOLLAR____AnalogSerialInput__ = 2;
    const uint RESPONSE_MSG__DOLLAR____AnalogSerialOutput__ = 0;
    
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
