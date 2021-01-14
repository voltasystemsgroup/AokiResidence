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

namespace CrestronModule_SCENE_CONCAT
{
    public class CrestronModuleClass_SCENE_CONCAT : SplusObject
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
                ushort POS = 0;
                
                CrestronString SREADDATA;
                SREADDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
                
                CrestronString SREADFILENAME;
                CrestronString TYPE;
                SREADFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
                TYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
                
                FILE_INFO FI;
                FI  = new FILE_INFO();
                FI .PopulateDefaults();
                
                ushort IFILECOUNT = 0;
                
                uint TEMPFADETIME = 0;
                uint TEMPOFFTIME = 0;
                
                LOAD_SETTING TEMPLOADSETTING;
                TEMPLOADSETTING  = new LOAD_SETTING( this, true );
                TEMPLOADSETTING .PopulateCustomAttributeList( false );
                
                
                __context__.SourceCodeLine = 42;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 44;
                FileDelete ( WRITE_FILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 46;
                IFILEHANDLEWRITE = (short) ( FileOpen( WRITE_FILENAME__DOLLAR__ ,(ushort) ((256 | 1) | 16384) ) ) ; 
                __context__.SourceCodeLine = 48;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLEWRITE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 50;
                    IRESULT = (short) ( SetCurrentDirectory( READ_PATH__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 52;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRESULT < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 54;
                        RESPONSE_MSG__DOLLAR__  .UpdateValue ( "ERROR\r\n>"  ) ; 
                        __context__.SourceCodeLine = 55;
                        Functions.TerminateEvent (); 
                        } 
                    
                    __context__.SourceCodeLine = 58;
                    IFILECOUNT = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 60;
                    IFINDRESULT = (short) ( FindFirst( "BinaryScene_*.dat" , ref FI ) ) ; 
                    __context__.SourceCodeLine = 62;
                    while ( Functions.TestForTrue  ( ( Functions.Not( IFINDRESULT ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 64;
                        SREADFILENAME  .UpdateValue ( FI .  Name  ) ; 
                        __context__.SourceCodeLine = 65;
                        IFILEHANDLEREAD = (short) ( FileOpen( SREADFILENAME ,(ushort) (0 | 32768) ) ) ; 
                        __context__.SourceCodeLine = 66;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLEREAD >= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 69;
                            IFILECOUNT = (ushort) ( (IFILECOUNT + 1) ) ; 
                            __context__.SourceCodeLine = 70;
                            POS = (ushort) ( (Functions.Find( "_" , FI.Name , 1 ) + 1) ) ; 
                            __context__.SourceCodeLine = 71;
                            SREADDATA  .UpdateValue ( Functions.Mid ( FI .  Name ,  (int) ( POS ) ,  (int) ( ((Functions.Length( FI.Name ) - POS) - 3) ) )  ) ; 
                            __context__.SourceCodeLine = 72;
                            SREADDATA  .UpdateValue ( "[scene_" + SREADDATA + ".dat]\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 73;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 74;
                            ReadString (  (short) ( IFILEHANDLEREAD ) ,  ref SREADDATA ) ; 
                            __context__.SourceCodeLine = 75;
                            SREADDATA  .UpdateValue ( "File Version\t" + SREADDATA + "\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 76;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 77;
                            SREADDATA  .UpdateValue ( "Modified Date\t" + Functions.ItoA (  (int) ( FI.iDate ) ) + "\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 78;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 79;
                            SREADDATA  .UpdateValue ( "Modified Time\t" + Functions.ItoA (  (int) ( FI.iTime ) ) + "\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 80;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 82;
                            ReadLongInteger (  (short) ( IFILEHANDLEREAD ) ,  ref TEMPFADETIME) ; 
                            __context__.SourceCodeLine = 83;
                            SREADDATA  .UpdateValue ( "Scene Fade Time\t" + Functions.LtoA (  (int) ( TEMPFADETIME ) ) + "\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 84;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 86;
                            ReadLongInteger (  (short) ( IFILEHANDLEREAD ) ,  ref TEMPOFFTIME) ; 
                            __context__.SourceCodeLine = 87;
                            SREADDATA  .UpdateValue ( "Scene Off Time\t" + Functions.LtoA (  (int) ( TEMPOFFTIME ) ) + "\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 88;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 89;
                            SREADDATA  .UpdateValue ( "Load ID\tTarget Level\u000D\u000A"  ) ; 
                            __context__.SourceCodeLine = 90;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                            __context__.SourceCodeLine = 92;
                            while ( Functions.TestForTrue  ( ( Functions.Not( FileEOF( (short)( IFILEHANDLEREAD ) ) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 94;
                                ReadStructure (  (short) ( IFILEHANDLEREAD ) , TEMPLOADSETTING ) ; 
                                __context__.SourceCodeLine = 96;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( TEMPLOADSETTING.LLEVEL >= 0 ) ) && Functions.TestForTrue ( TEMPLOADSETTING.DIMMABLE )) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 98;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPLOADSETTING.LOADEXCLUDED == 0))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 99;
                                        MakeString ( SREADDATA , "{0:d}\t{1:d}\u000D\u000A", (int)TEMPLOADSETTING.LOADID, (int)TEMPLOADSETTING.LLEVEL) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 101;
                                        MakeString ( SREADDATA , "{0:d}\t{1:d}\txd\u000D\u000A", (int)TEMPLOADSETTING.LOADID, (int)TEMPLOADSETTING.LLEVEL) ; 
                                        }
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 108;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPLOADSETTING.LOADEXCLUDED == 0))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 110;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.LLEVEL == -3) ) || Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.LLEVEL == -4) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.DIMMABLE == 0) )) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 112;
                                            TYPE  .UpdateValue ( "on"  ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 114;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.LLEVEL == -3) ) || Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.LLEVEL == -4) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (TEMPLOADSETTING.DIMMABLE == 0) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 116;
                                                TYPE  .UpdateValue ( "off"  ) ; 
                                                } 
                                            
                                            }
                                        
                                        } 
                                    
                                    __context__.SourceCodeLine = 120;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPLOADSETTING.LOADEXCLUDED == 1))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 121;
                                        MakeString ( SREADDATA , "{0:d}\t{1}\txn\u000D\u000A", (int)TEMPLOADSETTING.LOADID, TYPE ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 123;
                                        MakeString ( SREADDATA , "{0:d}\t{1}\u000D\u000A", (int)TEMPLOADSETTING.LOADID, TYPE ) ; 
                                        }
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 125;
                                FileWrite (  (short) ( IFILEHANDLEWRITE ) , SREADDATA ,  (ushort) ( Functions.Length( SREADDATA ) ) ) ; 
                                __context__.SourceCodeLine = 92;
                                } 
                            
                            __context__.SourceCodeLine = 127;
                            FileWrite (  (short) ( IFILEHANDLEWRITE ) , "\u000D\u000A" ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                            __context__.SourceCodeLine = 128;
                            IRESULT = (short) ( FileClose( (short)( IFILEHANDLEREAD ) ) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 131;
                        IFINDRESULT = (short) ( FindNext( ref FI ) ) ; 
                        __context__.SourceCodeLine = 62;
                        } 
                    
                    __context__.SourceCodeLine = 135;
                    IRESULT = (short) ( FileClose( (short)( IFILEHANDLEWRITE ) ) ) ; 
                    __context__.SourceCodeLine = 137;
                    RESPONSE_MSG__DOLLAR__  .UpdateValue ( "OK " + Functions.ItoA (  (int) ( IFILECOUNT ) ) + "\r\n>"  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 141;
                    RESPONSE_MSG__DOLLAR__  .UpdateValue ( "ERROR\r\n>"  ) ; 
                    }
                
                __context__.SourceCodeLine = 143;
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
    
    public CrestronModuleClass_SCENE_CONCAT ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
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

[SplusStructAttribute(-1, true, false)]
public class LOAD_SETTING : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public int  LLEVEL = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  LOADID = 0;
    
    [SplusStructAttribute(2, false, false)]
    public short  DIMMABLE = 0;
    
    [SplusStructAttribute(3, false, false)]
    public uint  LRAMPID = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  LOADEXCLUDED = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  PARENTRMID = 0;
    
    
    public LOAD_SETTING( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
