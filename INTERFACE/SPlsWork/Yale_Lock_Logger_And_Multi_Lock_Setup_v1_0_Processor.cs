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

namespace CrestronModule_YALE_LOCK_LOGGER_AND_MULTI_LOCK_SETUP_V1_0_PROCESSOR
{
    public class CrestronModuleClass_YALE_LOCK_LOGGER_AND_MULTI_LOCK_SETUP_V1_0_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SETUP_UPDATE_LOCKS;
        Crestron.Logos.SplusObjects.DigitalInput SETUP_CANCEL_UPDATE;
        Crestron.Logos.SplusObjects.DigitalInput SETUP_STORE_CURRENT_LIST;
        Crestron.Logos.SplusObjects.DigitalInput SETUP_RECOVER_STORED_LIST;
        Crestron.Logos.SplusObjects.DigitalInput SETUP_REFRESH_LIST;
        Crestron.Logos.SplusObjects.DigitalInput LOG_DATE_TIME_FORMAT_12HR;
        Crestron.Logos.SplusObjects.DigitalInput LOG_CLEAR_LIST;
        Crestron.Logos.SplusObjects.DigitalInput LOG_REFRESH_LIST;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SETUP_SELECT_FIELD;
        Crestron.Logos.SplusObjects.AnalogInput LOG_OUTPUT_LIST_SIZE;
        Crestron.Logos.SplusObjects.StringInput LOG_EVENTS_TEXT_IN;
        Crestron.Logos.SplusObjects.StringInput SETUP_KEYBOARD_TEXT_IN;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_IS_UPDATING;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_UPDATING_COMPLETE;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_USER_NAME_OR_PIN_MISSING;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_UPDATE_CANCELLED;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_CURRENT_LIST_STORED;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_DUPLICATE_PIN;
        Crestron.Logos.SplusObjects.DigitalOutput SETUP_INVALID_PIN_LENGTH;
        Crestron.Logos.SplusObjects.DigitalOutput TO_LOCK_SET_USER_PIN;
        Crestron.Logos.SplusObjects.DigitalOutput TO_LOCK_USER_DELETE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SETUP_FIELD_SELECTED;
        Crestron.Logos.SplusObjects.AnalogOutput SETUP_FIELD_SELECTED_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput SETUP_UPDATING_PROGRESS_GAUGE;
        Crestron.Logos.SplusObjects.StringOutput SETUP_TEXT_OUT;
        Crestron.Logos.SplusObjects.StringOutput TO_LOCK_USER_NUMBER;
        Crestron.Logos.SplusObjects.StringOutput TO_LOCK_USER_NAME;
        Crestron.Logos.SplusObjects.StringOutput TO_LOCK_USER_PIN;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LOG_LIST_ITEM;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SETUP_USER_NUMBER;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SETUP_USER_NAME_TEXT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SETUP_USER_PIN_TEXT;
        USERENTRY ONEENTRY;
        USERENTRY [] ENTRY;
        ushort IQUELIMIT = 0;
        ushort IFIELD = 0;
        ushort IUSERSELECT = 0;
        ushort IUSERNAMEPINMISSING = 0;
        ushort ICANCEL = 0;
        CrestronString GSTEXT;
        ushort IQUEINDEX = 0;
        CrestronString SBBOOTED;
        CrestronString [] SQUEITEM;
        private CrestronString DATETIME (  SplusExecutionContext __context__, ushort IFORMAT ) 
            { 
            CrestronString SDATETIME;
            CrestronString SAMPM;
            SDATETIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            SAMPM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            ushort IHOUR = 0;
            ushort IMIN = 0;
            ushort ISEC = 0;
            
            
            __context__.SourceCodeLine = 155;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFORMAT == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 157;
                SDATETIME  .UpdateValue ( Functions.Date (  (int) ( 4 ) ) + " "  ) ; 
                __context__.SourceCodeLine = 159;
                IHOUR = (ushort) ( Functions.GetHourNum() ) ; 
                __context__.SourceCodeLine = 160;
                IMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
                __context__.SourceCodeLine = 161;
                ISEC = (ushort) ( Functions.GetSecondsNum() ) ; 
                __context__.SourceCodeLine = 163;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IHOUR == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 165;
                    SAMPM  .UpdateValue ( "AM"  ) ; 
                    __context__.SourceCodeLine = 167;
                    SDATETIME  .UpdateValue ( SDATETIME + "12:"  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 169;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHOUR < 12 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 171;
                        SAMPM  .UpdateValue ( "AM"  ) ; 
                        __context__.SourceCodeLine = 173;
                        SDATETIME  .UpdateValue ( SDATETIME + Functions.ItoA (  (int) ( IHOUR ) ) + ":"  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 177;
                        SAMPM  .UpdateValue ( "PM"  ) ; 
                        __context__.SourceCodeLine = 179;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IHOUR > 12 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 180;
                            IHOUR = (ushort) ( (IHOUR - 12) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 182;
                        SDATETIME  .UpdateValue ( SDATETIME + Functions.ItoA (  (int) ( IHOUR ) ) + ":"  ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 185;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMIN < 10 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 186;
                    SDATETIME  .UpdateValue ( SDATETIME + "0" + Functions.ItoA (  (int) ( IMIN ) ) + ":"  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 188;
                    SDATETIME  .UpdateValue ( SDATETIME + Functions.ItoA (  (int) ( IMIN ) ) + ":"  ) ; 
                    }
                
                __context__.SourceCodeLine = 190;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISEC < 10 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 191;
                    SDATETIME  .UpdateValue ( SDATETIME + "0" + Functions.ItoA (  (int) ( ISEC ) ) + " " + SAMPM  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 193;
                    SDATETIME  .UpdateValue ( SDATETIME + Functions.ItoA (  (int) ( ISEC ) ) + " " + SAMPM  ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 196;
                SDATETIME  .UpdateValue ( Functions.Date (  (int) ( 4 ) ) + " " + Functions.Time ( )  ) ; 
                }
            
            __context__.SourceCodeLine = 198;
            return ( SDATETIME ) ; 
            
            }
            
        private void ADDITEM (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 206;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IQUEINDEX < IQUELIMIT ))  ) ) 
                { 
                __context__.SourceCodeLine = 208;
                IQUEINDEX = (ushort) ( (IQUEINDEX + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 211;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IQUEINDEX > 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 213;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( IQUEINDEX ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)2; 
                int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 215;
                    SQUEITEM [ I ]  .UpdateValue ( SQUEITEM [ (I - 1) ]  ) ; 
                    __context__.SourceCodeLine = 216;
                    LOG_LIST_ITEM [ I]  .UpdateValue ( SQUEITEM [ (I - 1) ]  ) ; 
                    __context__.SourceCodeLine = 213;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 220;
            if ( Functions.TestForTrue  ( ( LOG_DATE_TIME_FORMAT_12HR  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 221;
                SQUEITEM [ 1 ]  .UpdateValue ( DATETIME (  __context__ , (ushort)( 1 )) + " : " + DATA  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 223;
                SQUEITEM [ 1 ]  .UpdateValue ( DATETIME (  __context__ , (ushort)( 0 )) + " : " + DATA  ) ; 
                }
            
            __context__.SourceCodeLine = 225;
            LOG_LIST_ITEM [ 1]  .UpdateValue ( SQUEITEM [ 1 ]  ) ; 
            
            }
            
        private void REFRESHLOG (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 231;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)IQUELIMIT; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 232;
                LOG_LIST_ITEM [ I]  .UpdateValue ( SQUEITEM [ I ]  ) ; 
                __context__.SourceCodeLine = 231;
                }
            
            
            }
            
        private void REFRESH (  SplusExecutionContext __context__ ) 
            { 
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 238;
            if ( Functions.TestForTrue  ( ( Functions.Not( SETUP_IS_UPDATING  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 240;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)20; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 242;
                    SETUP_USER_NUMBER [ A]  .UpdateValue ( Functions.ItoA (  (int) ( A ) )  ) ; 
                    __context__.SourceCodeLine = 243;
                    SETUP_USER_NAME_TEXT [ A]  .UpdateValue ( ENTRY [ A] . USERNAME  ) ; 
                    __context__.SourceCodeLine = 244;
                    SETUP_USER_PIN_TEXT [ A]  .UpdateValue ( ENTRY [ A] . PIN  ) ; 
                    __context__.SourceCodeLine = 240;
                    } 
                
                } 
            
            
            }
            
        private void LOGSTORECURRENTLIST (  SplusExecutionContext __context__ ) 
            { 
            short NFILEHANDLE = 0;
            
            CrestronString SBUF;
            SBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 257;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 258;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CheckForDisk() == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 260;
                NFILEHANDLE = (short) ( FileDelete( "\\CF0\\UserLog.txt" ) ) ; 
                __context__.SourceCodeLine = 261;
                NFILEHANDLE = (short) ( FileOpen( "\\CF0\\UserLog.txt" ,(ushort) ((256 | 1) | 16384) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 265;
                NFILEHANDLE = (short) ( FileDelete( "\\NVRAM\\UserLog.txt" ) ) ; 
                __context__.SourceCodeLine = 266;
                NFILEHANDLE = (short) ( FileOpen( "\\NVRAM\\UserLog.txt" ,(ushort) ((256 | 1) | 16384) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 268;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 270;
                SBUF  .UpdateValue ( Functions.ItoA (  (int) ( IQUEINDEX ) ) + "\r\n"  ) ; 
                __context__.SourceCodeLine = 271;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileWrite( (short)( NFILEHANDLE ) , SBUF , (ushort)( Functions.Length( SBUF ) ) ) > 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 271;
                    ; 
                    }
                
                __context__.SourceCodeLine = 272;
                /* Trace( "Written to file: {0}\r\n", SBUF ) */ ; 
                __context__.SourceCodeLine = 274;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 276;
                    SBUF  .UpdateValue ( SQUEITEM [ A ] + "\r\n"  ) ; 
                    __context__.SourceCodeLine = 277;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileWrite( (short)( NFILEHANDLE ) , SBUF , (ushort)( Functions.Length( SBUF ) ) ) > 0 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 277;
                        ; 
                        }
                    
                    __context__.SourceCodeLine = 278;
                    /* Trace( "Written to file: {0}\r\n", SBUF ) */ ; 
                    __context__.SourceCodeLine = 274;
                    } 
                
                __context__.SourceCodeLine = 281;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( NFILEHANDLE ) ) == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 283;
                    SETUP_CURRENT_LIST_STORED  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 284;
                    SETUP_CURRENT_LIST_STORED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 286;
                    /* Trace( "File Closed\r\n") */ ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 289;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 290;
            /* Trace( "Write Done:\r\n") */ ; 
            
            }
            
        private void LOGRECOVERSTOREDLIST (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SLOG;
            SLOG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            CrestronString SFILEREAD;
            SFILEREAD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10000, this );
            
            short NFILEHANDLE = 0;
            
            CrestronString SFROMFILE;
            SFROMFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10000, this );
            
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 302;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 304;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CheckForDisk() == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 306;
                NFILEHANDLE = (short) ( FileOpen( "\\CF0\\UserLog.txt" ,(ushort) (0 | 16384) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 310;
                NFILEHANDLE = (short) ( FileOpen( "\\NVRAM\\UserLog.txt" ,(ushort) (0 | 16384) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 312;
            /* Trace( "nFileHandle:{0:d}\r\n", (short)NFILEHANDLE) */ ; 
            __context__.SourceCodeLine = 313;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 316;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileRead( (short)( NFILEHANDLE ) , SFROMFILE , (ushort)( 10000 ) ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 318;
                    SFILEREAD  .UpdateValue ( SFROMFILE  ) ; 
                    __context__.SourceCodeLine = 316;
                    } 
                
                __context__.SourceCodeLine = 320;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( NFILEHANDLE ) ) != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 321;
                    /* Trace( "error closing file\r\n") */ ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 323;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 324;
            /* Trace( "sFromFile:{0}\r\n", SFILEREAD ) */ ; 
            __context__.SourceCodeLine = 326;
            SLOG  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SFILEREAD )  ) ; 
            __context__.SourceCodeLine = 327;
            /* Trace( "sLog[{0:d}]:{1}\r\n", (short)A, SLOG ) */ ; 
            __context__.SourceCodeLine = 328;
            IQUEINDEX = (ushort) ( Functions.Atoi( SLOG ) ) ; 
            __context__.SourceCodeLine = 330;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 332;
                SLOG  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SFILEREAD )  ) ; 
                __context__.SourceCodeLine = 333;
                /* Trace( "sLog[{0:d}]:{1}\r\n", (short)A, SLOG ) */ ; 
                __context__.SourceCodeLine = 334;
                SQUEITEM [ A ]  .UpdateValue ( Functions.Left ( SLOG ,  (int) ( (Functions.Length( SLOG ) - 2) ) )  ) ; 
                __context__.SourceCodeLine = 330;
                } 
            
            
            }
            
        object LOG_CLEAR_LIST_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 350;
                IQUEINDEX = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 352;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)IQUELIMIT; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 354;
                    SQUEITEM [ I ]  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 355;
                    LOG_LIST_ITEM [ I]  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 352;
                    } 
                
                __context__.SourceCodeLine = 357;
                LOGSTORECURRENTLIST (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object LOG_EVENTS_TEXT_IN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString STEMPDATA;
            STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 364;
            if ( Functions.TestForTrue  ( ( Functions.Length( LOG_EVENTS_TEXT_IN ))  ) ) 
                { 
                __context__.SourceCodeLine = 366;
                STEMPDATA  .UpdateValue ( LOG_EVENTS_TEXT_IN  ) ; 
                __context__.SourceCodeLine = 367;
                ADDITEM (  __context__ , STEMPDATA) ; 
                __context__.SourceCodeLine = 368;
                LOGSTORECURRENTLIST (  __context__  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object LOG_REFRESH_LIST_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 374;
        LOGRECOVERSTOREDLIST (  __context__  ) ; 
        __context__.SourceCodeLine = 375;
        REFRESHLOG (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_SELECT_FIELD_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 381;
        if ( Functions.TestForTrue  ( ( Functions.Not( SETUP_IS_UPDATING  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 383;
            IFIELD = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 384;
            if ( Functions.TestForTrue  ( ( Mod( IFIELD , 2 ))  ) ) 
                {
                __context__.SourceCodeLine = 385;
                GSTEXT  .UpdateValue ( ENTRY [ ((IFIELD / 2) + 1)] . USERNAME  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 387;
                GSTEXT  .UpdateValue ( ENTRY [ (IFIELD / 2)] . PIN  ) ; 
                }
            
            __context__.SourceCodeLine = 388;
            SETUP_TEXT_OUT  .UpdateValue ( GSTEXT  ) ; 
            __context__.SourceCodeLine = 389;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 391;
                SETUP_FIELD_SELECTED [ A]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 389;
                } 
            
            __context__.SourceCodeLine = 393;
            SETUP_FIELD_SELECTED [ IFIELD]  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_SELECT_FIELD_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 399;
        if ( Functions.TestForTrue  ( ( Mod( IFIELD , 2 ))  ) ) 
            {
            __context__.SourceCodeLine = 400;
            SETUP_FIELD_SELECTED_VAL  .Value = (ushort) ( (IFIELD + ((IFIELD + 1) / 2)) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 402;
            SETUP_FIELD_SELECTED_VAL  .Value = (ushort) ( (IFIELD + (IFIELD / 2)) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_KEYBOARD_TEXT_IN_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        ushort IDUPLICATE = 0;
        
        ushort IINVALIDLENGTH = 0;
        
        
        __context__.SourceCodeLine = 411;
        GSTEXT  .UpdateValue ( SETUP_KEYBOARD_TEXT_IN  ) ; 
        __context__.SourceCodeLine = 412;
        IDUPLICATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 413;
        IINVALIDLENGTH = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 414;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IFIELD , 2 ) == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 416;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 2 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)2; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 418;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (GSTEXT == ENTRY[ (A / 2) ].PIN) ) && Functions.TestForTrue ( Functions.Length( GSTEXT ) )) ) ) && Functions.TestForTrue ( Functions.Length( ENTRY[ (A / 2) ].PIN ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 420;
                    IDUPLICATE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 421;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 416;
                } 
            
            __context__.SourceCodeLine = 424;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( GSTEXT ) > 8 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( GSTEXT ) < 4 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( GSTEXT ) > 0 ) )) ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 426;
                IINVALIDLENGTH = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 428;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( SETUP_IS_UPDATING  .Value ) ) && Functions.TestForTrue ( Functions.Not( IDUPLICATE ) )) ) ) && Functions.TestForTrue ( Functions.Not( IINVALIDLENGTH ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 430;
                ENTRY [ (IFIELD / 2)] . PIN  .UpdateValue ( GSTEXT  ) ; 
                } 
            
            __context__.SourceCodeLine = 432;
            if ( Functions.TestForTrue  ( ( IDUPLICATE)  ) ) 
                { 
                __context__.SourceCodeLine = 434;
                SETUP_DUPLICATE_PIN  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 435;
                SETUP_DUPLICATE_PIN  .Value = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 438;
            if ( Functions.TestForTrue  ( ( IINVALIDLENGTH)  ) ) 
                { 
                __context__.SourceCodeLine = 440;
                SETUP_INVALID_PIN_LENGTH  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 441;
                SETUP_INVALID_PIN_LENGTH  .Value = (ushort) ( 0 ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 446;
            if ( Functions.TestForTrue  ( ( Functions.Not( SETUP_IS_UPDATING  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 448;
                ENTRY [ ((IFIELD / 2) + 1)] . USERNAME  .UpdateValue ( GSTEXT  ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 451;
        REFRESH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_UPDATE_LOCKS_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        ushort B = 0;
        
        ushort C = 0;
        
        ushort IDUPLICATE = 0;
        
        ushort IINVALIDLENGTH = 0;
        
        
        __context__.SourceCodeLine = 462;
        IDUPLICATE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 463;
        IINVALIDLENGTH = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 464;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 2 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)40; 
        int __FN_FORSTEP_VAL__1 = (int)2; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 466;
            B = (ushort) ( (A + 2) ) ; 
            __context__.SourceCodeLine = 467;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( B ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)40; 
            int __FN_FORSTEP_VAL__2 = (int)2; 
            for ( C  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (C  >= __FN_FORSTART_VAL__2) && (C  <= __FN_FOREND_VAL__2) ) : ( (C  <= __FN_FORSTART_VAL__2) && (C  >= __FN_FOREND_VAL__2) ) ; C  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 469;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ENTRY[ (A / 2) ].PIN == ENTRY[ (C / 2) ].PIN) ) && Functions.TestForTrue ( Functions.Length( ENTRY[ (A / 2) ].PIN ) )) ) ) && Functions.TestForTrue ( Functions.Length( ENTRY[ (C / 2) ].PIN ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 471;
                    IDUPLICATE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 472;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 467;
                } 
            
            __context__.SourceCodeLine = 475;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( ENTRY[ (A / 2) ].PIN ) > 8 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( ENTRY[ (A / 2) ].PIN ) < 4 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( ENTRY[ (A / 2) ].PIN ) > 0 ) )) ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 477;
                IINVALIDLENGTH = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 478;
                break ; 
                } 
            
            __context__.SourceCodeLine = 480;
            if ( Functions.TestForTrue  ( ( IDUPLICATE)  ) ) 
                { 
                __context__.SourceCodeLine = 482;
                SETUP_DUPLICATE_PIN  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 483;
                SETUP_DUPLICATE_PIN  .Value = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 486;
            if ( Functions.TestForTrue  ( ( IINVALIDLENGTH)  ) ) 
                { 
                __context__.SourceCodeLine = 488;
                SETUP_INVALID_PIN_LENGTH  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 489;
                SETUP_INVALID_PIN_LENGTH  .Value = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 464;
            } 
        
        __context__.SourceCodeLine = 492;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IDUPLICATE ) ) && Functions.TestForTrue ( Functions.Not( IINVALIDLENGTH ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 494;
            IUSERNAMEPINMISSING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 495;
            IFIELD = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 496;
            SETUP_FIELD_SELECTED_VAL  .Value = (ushort) ( IFIELD ) ; 
            __context__.SourceCodeLine = 497;
            ICANCEL = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 498;
            SETUP_TEXT_OUT  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 499;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)40; 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (A  >= __FN_FORSTART_VAL__3) && (A  <= __FN_FOREND_VAL__3) ) : ( (A  <= __FN_FORSTART_VAL__3) && (A  >= __FN_FOREND_VAL__3) ) ; A  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 501;
                SETUP_FIELD_SELECTED [ A]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 499;
                } 
            
            __context__.SourceCodeLine = 504;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)20; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (A  >= __FN_FORSTART_VAL__4) && (A  <= __FN_FOREND_VAL__4) ) : ( (A  <= __FN_FORSTART_VAL__4) && (A  >= __FN_FOREND_VAL__4) ) ; A  += (ushort)__FN_FORSTEP_VAL__4) 
                { 
                __context__.SourceCodeLine = 506;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( ENTRY[ A ].PIN ) == 0) ) && Functions.TestForTrue ( Functions.Length( ENTRY[ A ].USERNAME ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Length( ENTRY[ A ].PIN ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( ENTRY[ A ].USERNAME ) == 0) )) ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 508;
                    IUSERNAMEPINMISSING = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 509;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 504;
                } 
            
            __context__.SourceCodeLine = 512;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IUSERNAMEPINMISSING == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 514;
                SETUP_USER_NAME_OR_PIN_MISSING  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 515;
                SETUP_USER_NAME_OR_PIN_MISSING  .Value = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 519;
                SETUP_IS_UPDATING  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 520;
                ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__5 = (ushort)20; 
                int __FN_FORSTEP_VAL__5 = (int)1; 
                for ( A  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (A  >= __FN_FORSTART_VAL__5) && (A  <= __FN_FOREND_VAL__5) ) : ( (A  <= __FN_FORSTART_VAL__5) && (A  >= __FN_FOREND_VAL__5) ) ; A  += (ushort)__FN_FORSTEP_VAL__5) 
                    { 
                    __context__.SourceCodeLine = 522;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICANCEL == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 524;
                        SETUP_IS_UPDATING  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 525;
                        SETUP_UPDATE_CANCELLED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 526;
                        SETUP_UPDATE_CANCELLED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 527;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 529;
                    SETUP_UPDATING_PROGRESS_GAUGE  .Value = (ushort) ( ((A * 65535) / (20 * 2)) ) ; 
                    __context__.SourceCodeLine = 530;
                    TO_LOCK_USER_NUMBER  .UpdateValue ( Functions.ItoA (  (int) ( A ) )  ) ; 
                    __context__.SourceCodeLine = 532;
                    TO_LOCK_USER_DELETE  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 533;
                    TO_LOCK_USER_DELETE  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 534;
                    Functions.Delay (  (int) ( 500 ) ) ; 
                    __context__.SourceCodeLine = 520;
                    } 
                
                __context__.SourceCodeLine = 536;
                ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__6 = (ushort)20; 
                int __FN_FORSTEP_VAL__6 = (int)1; 
                for ( A  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (A  >= __FN_FORSTART_VAL__6) && (A  <= __FN_FOREND_VAL__6) ) : ( (A  <= __FN_FORSTART_VAL__6) && (A  >= __FN_FOREND_VAL__6) ) ; A  += (ushort)__FN_FORSTEP_VAL__6) 
                    { 
                    __context__.SourceCodeLine = 538;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICANCEL == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 540;
                        SETUP_IS_UPDATING  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 541;
                        SETUP_UPDATE_CANCELLED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 542;
                        SETUP_UPDATE_CANCELLED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 543;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 545;
                    SETUP_UPDATING_PROGRESS_GAUGE  .Value = (ushort) ( (((A + 20) * 65535) / (20 * 2)) ) ; 
                    __context__.SourceCodeLine = 546;
                    if ( Functions.TestForTrue  ( ( Functions.Length( ENTRY[ A ].PIN ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 548;
                        TO_LOCK_USER_NUMBER  .UpdateValue ( Functions.ItoA (  (int) ( A ) )  ) ; 
                        __context__.SourceCodeLine = 549;
                        TO_LOCK_USER_PIN  .UpdateValue ( ENTRY [ A] . PIN  ) ; 
                        __context__.SourceCodeLine = 550;
                        TO_LOCK_USER_NAME  .UpdateValue ( ENTRY [ A] . USERNAME  ) ; 
                        __context__.SourceCodeLine = 551;
                        TO_LOCK_SET_USER_PIN  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 552;
                        TO_LOCK_SET_USER_PIN  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 553;
                        Functions.Delay (  (int) ( 460 ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 555;
                    Functions.Delay (  (int) ( 40 ) ) ; 
                    __context__.SourceCodeLine = 536;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 558;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( ICANCEL ) ) && Functions.TestForTrue ( Functions.Not( IUSERNAMEPINMISSING ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 560;
                SETUP_UPDATING_COMPLETE  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 561;
                SETUP_UPDATING_COMPLETE  .Value = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 563;
            SETUP_IS_UPDATING  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 564;
            SETUP_UPDATING_PROGRESS_GAUGE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 565;
            ICANCEL = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_CANCEL_UPDATE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 571;
        if ( Functions.TestForTrue  ( ( SETUP_IS_UPDATING  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 572;
            ICANCEL = (ushort) ( 1 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_REFRESH_LIST_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 577;
        REFRESH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_RECOVER_STORED_LIST_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString SNAME;
        SNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        CrestronString SPIN;
        SPIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        CrestronString SFILEREAD;
        SFILEREAD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        short NFILEHANDLE = 0;
        
        CrestronString SFROMFILE;
        SFROMFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 590;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 592;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CheckForDisk() == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 594;
            NFILEHANDLE = (short) ( FileOpen( "\\CF0\\UserInfo.txt" ,(ushort) (0 | 16384) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 598;
            NFILEHANDLE = (short) ( FileOpen( "\\NVRAM\\UserInfo.txt" ,(ushort) (0 | 16384) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 600;
        /* Trace( "nFileHandle:{0:d}\r\n", (short)NFILEHANDLE) */ ; 
        __context__.SourceCodeLine = 601;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 604;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileRead( (short)( NFILEHANDLE ) , SFROMFILE , (ushort)( 1000 ) ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 606;
                SFILEREAD  .UpdateValue ( SFROMFILE  ) ; 
                __context__.SourceCodeLine = 604;
                } 
            
            __context__.SourceCodeLine = 608;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( NFILEHANDLE ) ) != 0))  ) ) 
                {
                __context__.SourceCodeLine = 609;
                /* Trace( "error closing file\r\n") */ ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 611;
        EndFileOperations ( ) ; 
        __context__.SourceCodeLine = 612;
        /* Trace( "sFromFile:{0}\r\n", SFILEREAD ) */ ; 
        __context__.SourceCodeLine = 614;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 616;
            SNAME  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SFILEREAD )  ) ; 
            __context__.SourceCodeLine = 617;
            SPIN  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SFILEREAD )  ) ; 
            __context__.SourceCodeLine = 618;
            /* Trace( "sNAME[{0:d}]:{1}\r\n", (short)A, SNAME ) */ ; 
            __context__.SourceCodeLine = 619;
            /* Trace( "sPIN[{0:d}]:{1}\r\n", (short)A, SPIN ) */ ; 
            __context__.SourceCodeLine = 620;
            ENTRY [ A] . USERNAME  .UpdateValue ( Functions.Left ( SNAME ,  (int) ( (Functions.Length( SNAME ) - 2) ) )  ) ; 
            __context__.SourceCodeLine = 621;
            ENTRY [ A] . PIN  .UpdateValue ( Functions.Left ( SPIN ,  (int) ( (Functions.Length( SPIN ) - 2) ) )  ) ; 
            __context__.SourceCodeLine = 614;
            } 
        
        __context__.SourceCodeLine = 624;
        REFRESH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SETUP_STORE_CURRENT_LIST_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short NFILEHANDLE = 0;
        
        CrestronString SBUF;
        SBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 637;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 638;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CheckForDisk() == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 640;
            NFILEHANDLE = (short) ( FileDelete( "\\CF0\\UserInfo.txt" ) ) ; 
            __context__.SourceCodeLine = 641;
            NFILEHANDLE = (short) ( FileOpen( "\\CF0\\UserInfo.txt" ,(ushort) ((256 | 1) | 16384) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 645;
            NFILEHANDLE = (short) ( FileDelete( "\\NVRAM\\UserInfo.txt" ) ) ; 
            __context__.SourceCodeLine = 646;
            NFILEHANDLE = (short) ( FileOpen( "\\NVRAM\\UserInfo.txt" ,(ushort) ((256 | 1) | 16384) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 648;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE >= 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 650;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)20; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 652;
                SBUF  .UpdateValue ( ENTRY [ A] . USERNAME + "\r\n"  ) ; 
                __context__.SourceCodeLine = 653;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileWrite( (short)( NFILEHANDLE ) , SBUF , (ushort)( Functions.Length( SBUF ) ) ) > 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 653;
                    ; 
                    }
                
                __context__.SourceCodeLine = 654;
                /* Trace( "Written to file: {0}\r\n", SBUF ) */ ; 
                __context__.SourceCodeLine = 655;
                SBUF  .UpdateValue ( ENTRY [ A] . PIN + "\r\n"  ) ; 
                __context__.SourceCodeLine = 656;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileWrite( (short)( NFILEHANDLE ) , SBUF , (ushort)( Functions.Length( SBUF ) ) ) > 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 656;
                    ; 
                    }
                
                __context__.SourceCodeLine = 657;
                /* Trace( "Written to file: {0}\r\n", SBUF ) */ ; 
                __context__.SourceCodeLine = 650;
                } 
            
            __context__.SourceCodeLine = 660;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileClose( (short)( NFILEHANDLE ) ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 662;
                SETUP_CURRENT_LIST_STORED  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 663;
                SETUP_CURRENT_LIST_STORED  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 665;
                /* Trace( "File Closed\r\n") */ ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 668;
        EndFileOperations ( ) ; 
        __context__.SourceCodeLine = 669;
        /* Trace( "Write Done:\r\n") */ ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    ushort A = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 683;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 685;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOG_OUTPUT_LIST_SIZE  .UshortValue < 50 ))  ) ) 
            {
            __context__.SourceCodeLine = 686;
            IQUELIMIT = (ushort) ( LOG_OUTPUT_LIST_SIZE  .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 688;
            IQUELIMIT = (ushort) ( 50 ) ; 
            }
        
        __context__.SourceCodeLine = 690;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SBBOOTED != "YES"))  ) ) 
            { 
            __context__.SourceCodeLine = 692;
            IQUEINDEX = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 694;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 696;
                SQUEITEM [ I ]  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 694;
                } 
            
            __context__.SourceCodeLine = 699;
            SBBOOTED  .UpdateValue ( "YES"  ) ; 
            } 
        
        __context__.SourceCodeLine = 702;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_0__" , 100 , __SPLS_TMPVAR__WAITLABEL_0___Callback ) ;
        __context__.SourceCodeLine = 707;
        SETUP_IS_UPDATING  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 708;
        ICANCEL = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_0___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 704;
            LOGRECOVERSTOREDLIST (  __context__  ) ; 
            __context__.SourceCodeLine = 705;
            REFRESHLOG (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    GSTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    SBBOOTED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    SQUEITEM  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SQUEITEM [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    ONEENTRY  = new USERENTRY( this, true );
    ONEENTRY .PopulateCustomAttributeList( false );
    ENTRY  = new USERENTRY[ 21 ];
    for( uint i = 0; i < 21; i++ )
    {
        ENTRY [i] = new USERENTRY( this, true );
        ENTRY [i].PopulateCustomAttributeList( false );
        
    }
    
    SETUP_UPDATE_LOCKS = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_UPDATE_LOCKS__DigitalInput__, this );
    m_DigitalInputList.Add( SETUP_UPDATE_LOCKS__DigitalInput__, SETUP_UPDATE_LOCKS );
    
    SETUP_CANCEL_UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_CANCEL_UPDATE__DigitalInput__, this );
    m_DigitalInputList.Add( SETUP_CANCEL_UPDATE__DigitalInput__, SETUP_CANCEL_UPDATE );
    
    SETUP_STORE_CURRENT_LIST = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_STORE_CURRENT_LIST__DigitalInput__, this );
    m_DigitalInputList.Add( SETUP_STORE_CURRENT_LIST__DigitalInput__, SETUP_STORE_CURRENT_LIST );
    
    SETUP_RECOVER_STORED_LIST = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_RECOVER_STORED_LIST__DigitalInput__, this );
    m_DigitalInputList.Add( SETUP_RECOVER_STORED_LIST__DigitalInput__, SETUP_RECOVER_STORED_LIST );
    
    SETUP_REFRESH_LIST = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_REFRESH_LIST__DigitalInput__, this );
    m_DigitalInputList.Add( SETUP_REFRESH_LIST__DigitalInput__, SETUP_REFRESH_LIST );
    
    LOG_DATE_TIME_FORMAT_12HR = new Crestron.Logos.SplusObjects.DigitalInput( LOG_DATE_TIME_FORMAT_12HR__DigitalInput__, this );
    m_DigitalInputList.Add( LOG_DATE_TIME_FORMAT_12HR__DigitalInput__, LOG_DATE_TIME_FORMAT_12HR );
    
    LOG_CLEAR_LIST = new Crestron.Logos.SplusObjects.DigitalInput( LOG_CLEAR_LIST__DigitalInput__, this );
    m_DigitalInputList.Add( LOG_CLEAR_LIST__DigitalInput__, LOG_CLEAR_LIST );
    
    LOG_REFRESH_LIST = new Crestron.Logos.SplusObjects.DigitalInput( LOG_REFRESH_LIST__DigitalInput__, this );
    m_DigitalInputList.Add( LOG_REFRESH_LIST__DigitalInput__, LOG_REFRESH_LIST );
    
    SETUP_SELECT_FIELD = new InOutArray<DigitalInput>( 40, this );
    for( uint i = 0; i < 40; i++ )
    {
        SETUP_SELECT_FIELD[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SETUP_SELECT_FIELD__DigitalInput__ + i, SETUP_SELECT_FIELD__DigitalInput__, this );
        m_DigitalInputList.Add( SETUP_SELECT_FIELD__DigitalInput__ + i, SETUP_SELECT_FIELD[i+1] );
    }
    
    SETUP_IS_UPDATING = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_IS_UPDATING__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_IS_UPDATING__DigitalOutput__, SETUP_IS_UPDATING );
    
    SETUP_UPDATING_COMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_UPDATING_COMPLETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_UPDATING_COMPLETE__DigitalOutput__, SETUP_UPDATING_COMPLETE );
    
    SETUP_USER_NAME_OR_PIN_MISSING = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_USER_NAME_OR_PIN_MISSING__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_USER_NAME_OR_PIN_MISSING__DigitalOutput__, SETUP_USER_NAME_OR_PIN_MISSING );
    
    SETUP_UPDATE_CANCELLED = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_UPDATE_CANCELLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_UPDATE_CANCELLED__DigitalOutput__, SETUP_UPDATE_CANCELLED );
    
    SETUP_CURRENT_LIST_STORED = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_CURRENT_LIST_STORED__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_CURRENT_LIST_STORED__DigitalOutput__, SETUP_CURRENT_LIST_STORED );
    
    SETUP_DUPLICATE_PIN = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_DUPLICATE_PIN__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_DUPLICATE_PIN__DigitalOutput__, SETUP_DUPLICATE_PIN );
    
    SETUP_INVALID_PIN_LENGTH = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_INVALID_PIN_LENGTH__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETUP_INVALID_PIN_LENGTH__DigitalOutput__, SETUP_INVALID_PIN_LENGTH );
    
    TO_LOCK_SET_USER_PIN = new Crestron.Logos.SplusObjects.DigitalOutput( TO_LOCK_SET_USER_PIN__DigitalOutput__, this );
    m_DigitalOutputList.Add( TO_LOCK_SET_USER_PIN__DigitalOutput__, TO_LOCK_SET_USER_PIN );
    
    TO_LOCK_USER_DELETE = new Crestron.Logos.SplusObjects.DigitalOutput( TO_LOCK_USER_DELETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( TO_LOCK_USER_DELETE__DigitalOutput__, TO_LOCK_USER_DELETE );
    
    SETUP_FIELD_SELECTED = new InOutArray<DigitalOutput>( 40, this );
    for( uint i = 0; i < 40; i++ )
    {
        SETUP_FIELD_SELECTED[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SETUP_FIELD_SELECTED__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SETUP_FIELD_SELECTED__DigitalOutput__ + i, SETUP_FIELD_SELECTED[i+1] );
    }
    
    LOG_OUTPUT_LIST_SIZE = new Crestron.Logos.SplusObjects.AnalogInput( LOG_OUTPUT_LIST_SIZE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LOG_OUTPUT_LIST_SIZE__AnalogSerialInput__, LOG_OUTPUT_LIST_SIZE );
    
    SETUP_FIELD_SELECTED_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( SETUP_FIELD_SELECTED_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SETUP_FIELD_SELECTED_VAL__AnalogSerialOutput__, SETUP_FIELD_SELECTED_VAL );
    
    SETUP_UPDATING_PROGRESS_GAUGE = new Crestron.Logos.SplusObjects.AnalogOutput( SETUP_UPDATING_PROGRESS_GAUGE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SETUP_UPDATING_PROGRESS_GAUGE__AnalogSerialOutput__, SETUP_UPDATING_PROGRESS_GAUGE );
    
    LOG_EVENTS_TEXT_IN = new Crestron.Logos.SplusObjects.StringInput( LOG_EVENTS_TEXT_IN__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( LOG_EVENTS_TEXT_IN__AnalogSerialInput__, LOG_EVENTS_TEXT_IN );
    
    SETUP_KEYBOARD_TEXT_IN = new Crestron.Logos.SplusObjects.StringInput( SETUP_KEYBOARD_TEXT_IN__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( SETUP_KEYBOARD_TEXT_IN__AnalogSerialInput__, SETUP_KEYBOARD_TEXT_IN );
    
    SETUP_TEXT_OUT = new Crestron.Logos.SplusObjects.StringOutput( SETUP_TEXT_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SETUP_TEXT_OUT__AnalogSerialOutput__, SETUP_TEXT_OUT );
    
    TO_LOCK_USER_NUMBER = new Crestron.Logos.SplusObjects.StringOutput( TO_LOCK_USER_NUMBER__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_LOCK_USER_NUMBER__AnalogSerialOutput__, TO_LOCK_USER_NUMBER );
    
    TO_LOCK_USER_NAME = new Crestron.Logos.SplusObjects.StringOutput( TO_LOCK_USER_NAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_LOCK_USER_NAME__AnalogSerialOutput__, TO_LOCK_USER_NAME );
    
    TO_LOCK_USER_PIN = new Crestron.Logos.SplusObjects.StringOutput( TO_LOCK_USER_PIN__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_LOCK_USER_PIN__AnalogSerialOutput__, TO_LOCK_USER_PIN );
    
    LOG_LIST_ITEM = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LOG_LIST_ITEM[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LOG_LIST_ITEM__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LOG_LIST_ITEM__AnalogSerialOutput__ + i, LOG_LIST_ITEM[i+1] );
    }
    
    SETUP_USER_NUMBER = new InOutArray<StringOutput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        SETUP_USER_NUMBER[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SETUP_USER_NUMBER__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SETUP_USER_NUMBER__AnalogSerialOutput__ + i, SETUP_USER_NUMBER[i+1] );
    }
    
    SETUP_USER_NAME_TEXT = new InOutArray<StringOutput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        SETUP_USER_NAME_TEXT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SETUP_USER_NAME_TEXT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SETUP_USER_NAME_TEXT__AnalogSerialOutput__ + i, SETUP_USER_NAME_TEXT[i+1] );
    }
    
    SETUP_USER_PIN_TEXT = new InOutArray<StringOutput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        SETUP_USER_PIN_TEXT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SETUP_USER_PIN_TEXT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SETUP_USER_PIN_TEXT__AnalogSerialOutput__ + i, SETUP_USER_PIN_TEXT[i+1] );
    }
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    LOG_CLEAR_LIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOG_CLEAR_LIST_OnPush_0, false ) );
    LOG_EVENTS_TEXT_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( LOG_EVENTS_TEXT_IN_OnChange_1, false ) );
    LOG_REFRESH_LIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOG_REFRESH_LIST_OnPush_2, false ) );
    for( uint i = 0; i < 40; i++ )
        SETUP_SELECT_FIELD[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_SELECT_FIELD_OnPush_3, false ) );
        
    for( uint i = 0; i < 40; i++ )
        SETUP_SELECT_FIELD[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( SETUP_SELECT_FIELD_OnRelease_4, false ) );
        
    SETUP_KEYBOARD_TEXT_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( SETUP_KEYBOARD_TEXT_IN_OnChange_5, false ) );
    SETUP_UPDATE_LOCKS.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_UPDATE_LOCKS_OnPush_6, true ) );
    SETUP_CANCEL_UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_CANCEL_UPDATE_OnPush_7, false ) );
    SETUP_REFRESH_LIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_REFRESH_LIST_OnPush_8, false ) );
    SETUP_RECOVER_STORED_LIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_RECOVER_STORED_LIST_OnPush_9, true ) );
    SETUP_STORE_CURRENT_LIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETUP_STORE_CURRENT_LIST_OnPush_10, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_YALE_LOCK_LOGGER_AND_MULTI_LOCK_SETUP_V1_0_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint SETUP_UPDATE_LOCKS__DigitalInput__ = 0;
const uint SETUP_CANCEL_UPDATE__DigitalInput__ = 1;
const uint SETUP_STORE_CURRENT_LIST__DigitalInput__ = 2;
const uint SETUP_RECOVER_STORED_LIST__DigitalInput__ = 3;
const uint SETUP_REFRESH_LIST__DigitalInput__ = 4;
const uint LOG_DATE_TIME_FORMAT_12HR__DigitalInput__ = 5;
const uint LOG_CLEAR_LIST__DigitalInput__ = 6;
const uint LOG_REFRESH_LIST__DigitalInput__ = 7;
const uint SETUP_SELECT_FIELD__DigitalInput__ = 8;
const uint LOG_OUTPUT_LIST_SIZE__AnalogSerialInput__ = 0;
const uint LOG_EVENTS_TEXT_IN__AnalogSerialInput__ = 1;
const uint SETUP_KEYBOARD_TEXT_IN__AnalogSerialInput__ = 2;
const uint SETUP_IS_UPDATING__DigitalOutput__ = 0;
const uint SETUP_UPDATING_COMPLETE__DigitalOutput__ = 1;
const uint SETUP_USER_NAME_OR_PIN_MISSING__DigitalOutput__ = 2;
const uint SETUP_UPDATE_CANCELLED__DigitalOutput__ = 3;
const uint SETUP_CURRENT_LIST_STORED__DigitalOutput__ = 4;
const uint SETUP_DUPLICATE_PIN__DigitalOutput__ = 5;
const uint SETUP_INVALID_PIN_LENGTH__DigitalOutput__ = 6;
const uint TO_LOCK_SET_USER_PIN__DigitalOutput__ = 7;
const uint TO_LOCK_USER_DELETE__DigitalOutput__ = 8;
const uint SETUP_FIELD_SELECTED__DigitalOutput__ = 9;
const uint SETUP_FIELD_SELECTED_VAL__AnalogSerialOutput__ = 0;
const uint SETUP_UPDATING_PROGRESS_GAUGE__AnalogSerialOutput__ = 1;
const uint SETUP_TEXT_OUT__AnalogSerialOutput__ = 2;
const uint TO_LOCK_USER_NUMBER__AnalogSerialOutput__ = 3;
const uint TO_LOCK_USER_NAME__AnalogSerialOutput__ = 4;
const uint TO_LOCK_USER_PIN__AnalogSerialOutput__ = 5;
const uint LOG_LIST_ITEM__AnalogSerialOutput__ = 6;
const uint SETUP_USER_NUMBER__AnalogSerialOutput__ = 56;
const uint SETUP_USER_NAME_TEXT__AnalogSerialOutput__ = 76;
const uint SETUP_USER_PIN_TEXT__AnalogSerialOutput__ = 96;

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
public class USERENTRY : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  USERNAME;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ENABLE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  PIN;
    
    
    public USERENTRY( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        USERNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        PIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, Owner );
        
        
    }
    
}

}
