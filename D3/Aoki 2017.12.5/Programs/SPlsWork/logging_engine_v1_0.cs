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

namespace CrestronModule_LOGGING_ENGINE_V1_0
{
    public class CrestronModuleClass_LOGGING_ENGINE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        CrestronString G_FILENAME;
        CrestronString G_ARCHIVEFILE;
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput CMD_ARGS;
        Crestron.Logos.SplusObjects.StringInput LOGEVENT;
        Crestron.Logos.SplusObjects.DigitalInput SCHEDSTARTLOG;
        Crestron.Logos.SplusObjects.DigitalInput SCHEDSTOPLOG;
        Crestron.Logos.SplusObjects.DigitalInput EXEC_CMD;
        Crestron.Logos.SplusObjects.DigitalOutput SCHEDULER_LOGSTATE;
        Crestron.Logos.SplusObjects.BufferInput DISKSPACE;
        Crestron.Logos.SplusObjects.StringOutput DISKCOMMAND;
        Crestron.Logos.SplusObjects.DigitalInput NEWPROGLOAD;
        EVENTSTRUCT [] G_LOGDATA;
        ushort G_INEXTLOGINDEX = 0;
        ushort G_BLOGOVERFLOW = 0;
        private short CYCLELOG (  SplusExecutionContext __context__, short IFILEHANDLE ) 
            { 
            short IARCHHANDLE = 0;
            short COUNT = 0;
            
            CrestronString READBUF;
            READBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
            
            
            __context__.SourceCodeLine = 65;
            FileDelete ( G_ARCHIVEFILE ) ; 
            __context__.SourceCodeLine = 68;
            FileSeek (  (short) ( IFILEHANDLE ) ,  (uint) ( 0 ) ,  (ushort) ( 0 ) ) ; 
            __context__.SourceCodeLine = 70;
            IARCHHANDLE = (short) ( FileOpen( G_ARCHIVEFILE ,(ushort) ((256 | 1) | 16384) ) ) ; 
            __context__.SourceCodeLine = 72;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (FileEOF( (short)( IFILEHANDLE ) ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( IARCHHANDLE > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 74;
                COUNT = (short) ( FileRead( (short)( IFILEHANDLE ) , READBUF , (ushort)( 500 ) ) ) ; 
                __context__.SourceCodeLine = 75;
                FileWrite (  (short) ( IARCHHANDLE ) , READBUF ,  (ushort) ( COUNT ) ) ; 
                __context__.SourceCodeLine = 72;
                } 
            
            __context__.SourceCodeLine = 78;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 79;
            FileClose (  (short) ( IARCHHANDLE ) ) ; 
            __context__.SourceCodeLine = 81;
            FileDelete ( G_FILENAME ) ; 
            __context__.SourceCodeLine = 83;
            IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) ((256 | 1) | 16384) ) ) ; 
            __context__.SourceCodeLine = 85;
            FileWrite (  (short) ( IFILEHANDLE ) , "PREVIOUS DATA IN ARCHIVE FILE\r\n" ,  (ushort) ( 31 ) ) ; 
            __context__.SourceCodeLine = 87;
            return (short)( IFILEHANDLE) ; 
            
            }
            
        private int GETDISKSPACE (  SplusExecutionContext __context__ ) 
            { 
            uint SPACE = 0;
            
            ushort P1 = 0;
            ushort P2 = 0;
            ushort P3 = 0;
            ushort P4 = 0;
            ushort COUNT = 0;
            
            CrestronString TEMP;
            TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 250, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 110;
            DISKCOMMAND  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 111;
            DISKSPACE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 112;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 114;
            DISKCOMMAND  .UpdateValue ( "cd " + PATH__DOLLAR__ + "\r\n" + "free\r\n"  ) ; 
            __context__.SourceCodeLine = 116;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( ">" , DISKSPACE ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 119;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 6))  ) ) 
                    { 
                    __context__.SourceCodeLine = 121;
                    return (int)( Functions.ToSignedLongInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 124;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 125;
                Functions.Delay (  (int) ( 50 ) ) ; 
                __context__.SourceCodeLine = 116;
                } 
            
            __context__.SourceCodeLine = 128;
            SPACE = (uint) ( 0 ) ; 
            __context__.SourceCodeLine = 130;
            P1 = (ushort) ( Functions.Find( ">" , DISKSPACE ) ) ; 
            __context__.SourceCodeLine = 132;
            P2 = (ushort) ( Functions.Find( "bytes free on" , DISKSPACE ) ) ; 
            __context__.SourceCodeLine = 134;
            COUNT = (ushort) ( (P2 - P1) ) ; 
            __context__.SourceCodeLine = 136;
            TEMP  .UpdateValue ( Functions.Mid ( DISKSPACE ,  (int) ( P1 ) ,  (int) ( COUNT ) )  ) ; 
            __context__.SourceCodeLine = 138;
            SPACE = (uint) ( Functions.Atol( TEMP ) ) ; 
            __context__.SourceCodeLine = 140;
            P3 = (ushort) ( Functions.Find( "used\r\n" , DISKSPACE ) ) ; 
            __context__.SourceCodeLine = 142;
            P4 = (ushort) ( Functions.Find( " bytes reclaimable" , DISKSPACE ) ) ; 
            __context__.SourceCodeLine = 144;
            COUNT = (ushort) ( (P4 - P3) ) ; 
            __context__.SourceCodeLine = 146;
            TEMP  .UpdateValue ( Functions.Mid ( DISKSPACE ,  (int) ( P3 ) ,  (int) ( COUNT ) )  ) ; 
            __context__.SourceCodeLine = 148;
            SPACE = (uint) ( (SPACE + Functions.Atol( TEMP )) ) ; 
            __context__.SourceCodeLine = 150;
            return (int)( SPACE) ; 
            
            }
            
        private void WRITEEVENTSTOFILE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            short IFILEHANDLE = 0;
            short IARCHHANDLE = 0;
            
            CrestronString WRITESTR;
            CrestronString MSG;
            WRITESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 85, this );
            
            FILE_INFO FINFO;
            FINFO  = new FILE_INFO();
            FINFO .PopulateDefaults();
            
            int SPACE = 0;
            
            
            __context__.SourceCodeLine = 172;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 174;
            IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (((256 | 8) | 2) | 16384) ) ) ; 
            __context__.SourceCodeLine = 176;
            SPACE = (int) ( GETDISKSPACE( __context__ ) ) ; 
            __context__.SourceCodeLine = 178;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( SPACE > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( SPACE < 5000 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 180;
                MakeString ( MSG , "LOGGING STOPPED AT {0} ON {1}\r\nMINIMUM REQUIRED DISK SPACE: {2:d}\r\n", Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) , (short)5000) ; 
                __context__.SourceCodeLine = 181;
                Print( "{0}", MSG ) ; 
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SPACE > 85 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 184;
                    FileWrite (  (short) ( IFILEHANDLE ) , MSG ,  (ushort) ( Functions.Length( MSG ) ) ) ; 
                    }
                
                __context__.SourceCodeLine = 186;
                SCHEDULER_LOGSTATE  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 187;
                _SplusNVRAM.LOGSTATE = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 192;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(G_INEXTLOGINDEX - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 194;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileSeek( (short)( IFILEHANDLE ) , (uint)( 0 ) , (ushort)( 1 ) ) > 10000 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 196;
                        FileClose (  (short) ( IFILEHANDLE ) ) ; 
                        __context__.SourceCodeLine = 197;
                        IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (0 | 16384) ) ) ; 
                        __context__.SourceCodeLine = 198;
                        IFILEHANDLE = (short) ( CYCLELOG( __context__ , (short)( IFILEHANDLE ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 201;
                    WRITESTR  .UpdateValue ( G_LOGDATA [ I] . DATA  ) ; 
                    __context__.SourceCodeLine = 202;
                    FileWrite (  (short) ( IFILEHANDLE ) , WRITESTR ,  (ushort) ( Functions.Length( WRITESTR ) ) ) ; 
                    __context__.SourceCodeLine = 204;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 192;
                    } 
                
                __context__.SourceCodeLine = 207;
                if ( Functions.TestForTrue  ( ( G_BLOGOVERFLOW)  ) ) 
                    { 
                    __context__.SourceCodeLine = 209;
                    FileWrite (  (short) ( IFILEHANDLE ) , "ERROR: LOG OVERFLOW\r\n" ,  (ushort) ( 21 ) ) ; 
                    __context__.SourceCodeLine = 210;
                    G_BLOGOVERFLOW = (ushort) ( 0 ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 214;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 216;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 218;
            G_INEXTLOGINDEX = (ushort) ( 1 ) ; 
            
            }
            
        object LOGEVENT_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 230;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCHEDULER_LOGSTATE  .Value == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 231;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 233;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_INEXTLOGINDEX > 50 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 235;
                    G_BLOGOVERFLOW = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 236;
                    Functions.TerminateEvent (); 
                    } 
                
                __context__.SourceCodeLine = 239;
                G_LOGDATA [ G_INEXTLOGINDEX] . DATA  .UpdateValue ( LOGEVENT  ) ; 
                __context__.SourceCodeLine = 240;
                G_INEXTLOGINDEX = (ushort) ( (G_INEXTLOGINDEX + 1) ) ; 
                __context__.SourceCodeLine = 242;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_INEXTLOGINDEX > 50 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 244;
                    CancelAllWait ( ) ; 
                    __context__.SourceCodeLine = 245;
                    WRITEEVENTSTOFILE (  __context__  ) ; 
                    __context__.SourceCodeLine = 246;
                    Functions.TerminateEvent (); 
                    } 
                
                __context__.SourceCodeLine = 249;
                CreateWait ( "FILEWAIT" , 300 , FILEWAIT_Callback ) ;
                __context__.SourceCodeLine = 254;
                RetimeWait ( (int)300, "FILEWAIT" ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void FILEWAIT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 251;
            WRITEEVENTSTOFILE (  __context__  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object SCHEDSTARTLOG_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short IFILEHANDLE = 0;
        
        CrestronString MSG;
        MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        int SPACE = 0;
        
        
        __context__.SourceCodeLine = 268;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCHEDULER_LOGSTATE  .Value == 1))  ) ) 
            {
            __context__.SourceCodeLine = 269;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 271;
        SPACE = (int) ( GETDISKSPACE( __context__ ) ) ; 
        __context__.SourceCodeLine = 273;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( SPACE < 5000 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( SPACE > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 275;
            Print( "LOGGING STOPPED: MINIMUM REQUIRED DISK SPACE: {0:d}\r\n", (short)5000) ; 
            __context__.SourceCodeLine = 276;
            Functions.TerminateEvent (); 
            } 
        
        __context__.SourceCodeLine = 279;
        SCHEDULER_LOGSTATE  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 280;
        _SplusNVRAM.LOGSTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 282;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 284;
        MakeString ( MSG , "LOGGING STARTED AT {0} ON {1}\r\n", Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
        __context__.SourceCodeLine = 286;
        Print( "{0}", MSG ) ; 
        __context__.SourceCodeLine = 288;
        IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (((256 | 8) | 2) | 16384) ) ) ; 
        __context__.SourceCodeLine = 290;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileSeek( (short)( IFILEHANDLE ) , (uint)( 0 ) , (ushort)( 1 ) ) > 10000 ))  ) ) 
            { 
            __context__.SourceCodeLine = 292;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 293;
            IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 295;
            IFILEHANDLE = (short) ( CYCLELOG( __context__ , (short)( IFILEHANDLE ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 298;
        FileWrite (  (short) ( IFILEHANDLE ) , MSG ,  (ushort) ( Functions.Length( MSG ) ) ) ; 
        __context__.SourceCodeLine = 300;
        FileClose (  (short) ( IFILEHANDLE ) ) ; 
        __context__.SourceCodeLine = 302;
        EndFileOperations ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCHEDSTOPLOG_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short IFILEHANDLE = 0;
        
        CrestronString MSG;
        MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
        
        
        __context__.SourceCodeLine = 316;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCHEDULER_LOGSTATE  .Value == 0))  ) ) 
            {
            __context__.SourceCodeLine = 317;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 319;
        SCHEDULER_LOGSTATE  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 320;
        _SplusNVRAM.LOGSTATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 322;
        MakeString ( MSG , "Logging stopped at {0} on {1}\r\n", Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
        __context__.SourceCodeLine = 324;
        Print( "{0}", MSG ) ; 
        __context__.SourceCodeLine = 326;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 328;
        IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (((256 | 8) | 2) | 16384) ) ) ; 
        __context__.SourceCodeLine = 330;
        FileWrite (  (short) ( IFILEHANDLE ) , MSG ,  (ushort) ( Functions.Length( MSG ) ) ) ; 
        __context__.SourceCodeLine = 332;
        FileClose (  (short) ( IFILEHANDLE ) ) ; 
        __context__.SourceCodeLine = 334;
        EndFileOperations ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EXEC_CMD_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString READBUF;
        READBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        short IFILEHANDLE = 0;
        
        
        __context__.SourceCodeLine = 349;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CMD_ARGS == "?"))  ) ) 
            {
            __context__.SourceCodeLine = 350;
            Print( "Available Commands: DISPLAYLOG\r\n") ; 
            }
        
        __context__.SourceCodeLine = 352;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Lower( CMD_ARGS ) == "displaylog"))  ) ) 
            { 
            __context__.SourceCodeLine = 354;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 356;
            IFILEHANDLE = (short) ( FileOpen( G_FILENAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 358;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFILEHANDLE == -3024))  ) ) 
                { 
                __context__.SourceCodeLine = 360;
                Print( "Logging file not found: {0}\r\n", G_FILENAME ) ; 
                __context__.SourceCodeLine = 361;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 362;
                Functions.TerminateEvent (); 
                } 
            
            __context__.SourceCodeLine = 365;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileEOF( (short)( IFILEHANDLE ) ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 367;
                FileRead (  (short) ( IFILEHANDLE ) , READBUF ,  (ushort) ( 100 ) ) ; 
                __context__.SourceCodeLine = 368;
                Print( "{0}", READBUF ) ; 
                __context__.SourceCodeLine = 365;
                } 
            
            __context__.SourceCodeLine = 371;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 373;
            EndFileOperations ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NEWPROGLOAD_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 386;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCHEDSTARTLOG  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 388;
            _SplusNVRAM.LOGSTATE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 389;
            SCHEDULER_LOGSTATE  .Value = (ushort) ( 0 ) ; 
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
        
        __context__.SourceCodeLine = 400;
        SCHEDULER_LOGSTATE  .Value = (ushort) ( _SplusNVRAM.LOGSTATE ) ; 
        __context__.SourceCodeLine = 401;
        G_BLOGOVERFLOW = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 403;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 405;
        G_INEXTLOGINDEX = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 406;
        G_FILENAME  .UpdateValue ( PATH__DOLLAR__ + "EventScheduleLog.txt"  ) ; 
        __context__.SourceCodeLine = 407;
        G_ARCHIVEFILE  .UpdateValue ( PATH__DOLLAR__ + "EventArchive.txt"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_FILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_ARCHIVEFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_LOGDATA  = new EVENTSTRUCT[ 51 ];
    for( uint i = 0; i < 51; i++ )
    {
        G_LOGDATA [i] = new EVENTSTRUCT( this, true );
        G_LOGDATA [i].PopulateCustomAttributeList( false );
        
    }
    
    SCHEDSTARTLOG = new Crestron.Logos.SplusObjects.DigitalInput( SCHEDSTARTLOG__DigitalInput__, this );
    m_DigitalInputList.Add( SCHEDSTARTLOG__DigitalInput__, SCHEDSTARTLOG );
    
    SCHEDSTOPLOG = new Crestron.Logos.SplusObjects.DigitalInput( SCHEDSTOPLOG__DigitalInput__, this );
    m_DigitalInputList.Add( SCHEDSTOPLOG__DigitalInput__, SCHEDSTOPLOG );
    
    EXEC_CMD = new Crestron.Logos.SplusObjects.DigitalInput( EXEC_CMD__DigitalInput__, this );
    m_DigitalInputList.Add( EXEC_CMD__DigitalInput__, EXEC_CMD );
    
    NEWPROGLOAD = new Crestron.Logos.SplusObjects.DigitalInput( NEWPROGLOAD__DigitalInput__, this );
    m_DigitalInputList.Add( NEWPROGLOAD__DigitalInput__, NEWPROGLOAD );
    
    SCHEDULER_LOGSTATE = new Crestron.Logos.SplusObjects.DigitalOutput( SCHEDULER_LOGSTATE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SCHEDULER_LOGSTATE__DigitalOutput__, SCHEDULER_LOGSTATE );
    
    PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 30, this );
    m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
    
    CMD_ARGS = new Crestron.Logos.SplusObjects.StringInput( CMD_ARGS__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( CMD_ARGS__AnalogSerialInput__, CMD_ARGS );
    
    LOGEVENT = new Crestron.Logos.SplusObjects.StringInput( LOGEVENT__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( LOGEVENT__AnalogSerialInput__, LOGEVENT );
    
    DISKCOMMAND = new Crestron.Logos.SplusObjects.StringOutput( DISKCOMMAND__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DISKCOMMAND__AnalogSerialOutput__, DISKCOMMAND );
    
    DISKSPACE = new Crestron.Logos.SplusObjects.BufferInput( DISKSPACE__AnalogSerialInput__, 250, this );
    m_StringInputList.Add( DISKSPACE__AnalogSerialInput__, DISKSPACE );
    
    FILEWAIT_Callback = new WaitFunction( FILEWAIT_CallbackFn );
    
    LOGEVENT.OnSerialChange.Add( new InputChangeHandlerWrapper( LOGEVENT_OnChange_0, false ) );
    SCHEDSTARTLOG.OnDigitalPush.Add( new InputChangeHandlerWrapper( SCHEDSTARTLOG_OnPush_1, false ) );
    SCHEDSTOPLOG.OnDigitalPush.Add( new InputChangeHandlerWrapper( SCHEDSTOPLOG_OnPush_2, false ) );
    EXEC_CMD.OnDigitalPush.Add( new InputChangeHandlerWrapper( EXEC_CMD_OnPush_3, false ) );
    NEWPROGLOAD.OnDigitalPush.Add( new InputChangeHandlerWrapper( NEWPROGLOAD_OnPush_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_LOGGING_ENGINE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction FILEWAIT_Callback;


const uint PATH__DOLLAR____AnalogSerialInput__ = 0;
const uint CMD_ARGS__AnalogSerialInput__ = 1;
const uint LOGEVENT__AnalogSerialInput__ = 2;
const uint SCHEDSTARTLOG__DigitalInput__ = 0;
const uint SCHEDSTOPLOG__DigitalInput__ = 1;
const uint EXEC_CMD__DigitalInput__ = 2;
const uint SCHEDULER_LOGSTATE__DigitalOutput__ = 0;
const uint DISKSPACE__AnalogSerialInput__ = 3;
const uint DISKCOMMAND__AnalogSerialOutput__ = 0;
const uint NEWPROGLOAD__DigitalInput__ = 3;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort LOGSTATE = 0;
            
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
public class EVENTSTRUCT : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  DATA;
    
    
    public EVENTSTRUCT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        DATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, Owner );
        
        
    }
    
}

}
