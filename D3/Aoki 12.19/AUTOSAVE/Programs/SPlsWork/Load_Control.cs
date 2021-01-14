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

namespace CrestronModule_LOAD_CONTROL
{
    public class CrestronModuleClass_LOAD_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput LOAD_CMD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput LOAD_LEVEL_INCREASING;
        Crestron.Logos.SplusObjects.DigitalInput LOAD_LEVEL_DECREASING;
        Crestron.Logos.SplusObjects.DigitalInput LOAD_LEVEL_RAMPING;
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIPTIONEXPIRED;
        Crestron.Logos.SplusObjects.DigitalOutput RAISELEVEL;
        Crestron.Logos.SplusObjects.DigitalOutput LOWERLEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput SETLEVEL;
        Crestron.Logos.SplusObjects.StringOutput RESPONSE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput LOADSUBSCRIBED;
        Crestron.Logos.SplusObjects.DigitalOutput LOADNOTSUBSCRIBED;
        Crestron.Logos.SplusObjects.AnalogOutput RESPONSEID;
        UShortParameter LOAD_NUMBER;
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        CrestronString G_LOADS_FILE__DOLLAR__;
        CrestronString G_LOADNAME;
        ushort G_LOADID = 0;
        ushort G_DIM_SETTING = 0;
        ushort G_UPPERLIMIT = 0;
        ushort G_LOWERLIMIT = 0;
        ushort G_TOTAL_WATTAGE = 0;
        short G_PARENTRM_ID = 0;
        ushort G_RAMPTIME = 0;
        ushort G_SEMAPHORE = 0;
        ushort G_COMMAND_HANDLER = 0;
        CrestronString G_LASTSAVEDTIME;
        CrestronString G_LASTSAVEDDATE;
        CrestronString STOREDCOMMANDSTRING;
        FILE_INFO G_FILEINFO;
        private void SENDRESPONSE (  SplusExecutionContext __context__, ushort INDEX , ushort TYPE , CrestronString RESPONSE ) 
            { 
            
            __context__.SourceCodeLine = 317;
            RESPONSEID  .Value = (ushort) ( INDEX ) ; 
            __context__.SourceCodeLine = 319;
            RESPONSE__DOLLAR__  .UpdateValue ( "/" + Functions.Chr (  (int) ( (Byte( STOREDCOMMANDSTRING , (int)( 5 ) ) | 128) ) ) + Functions.Chr (  (int) ( Byte( STOREDCOMMANDSTRING , (int)( (5 + 1) ) ) ) ) + Functions.Chr (  (int) ( TYPE ) ) + RESPONSE + "\\"  ) ; 
            __context__.SourceCodeLine = 320;
            RESPONSEID  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void BROADCASTRESPONSE (  SplusExecutionContext __context__, ushort TID , ushort TYPE , CrestronString RESPONSE ) 
            { 
            
            __context__.SourceCodeLine = 326;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) > 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 327;
                RESPONSE__DOLLAR__  .UpdateValue ( "/" + Functions.Chr (  (int) ( (Byte( STOREDCOMMANDSTRING , (int)( 5 ) ) | 128) ) ) + Functions.Chr (  (int) ( TID ) ) + Functions.Chr (  (int) ( TYPE ) ) + RESPONSE + "\\"  ) ; 
                }
            
            
            }
            
        private ushort GETLOADSINFO (  SplusExecutionContext __context__ ) 
            { 
            ushort IFILEHANDLE = 0;
            
            ushort ATTEMPTCOUNTER = 0;
            
            ushort LINECOUNTER = 0;
            
            ushort BBUFFERDONE = 0;
            
            ushort BLOADNOTFOUND = 0;
            
            ushort ILEN = 0;
            
            ushort ISTART = 0;
            
            CrestronString SREADBUF;
            SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 612, this );
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            
            __context__.SourceCodeLine = 343;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 344;
            IFILEHANDLE = (ushort) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 345;
            ATTEMPTCOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 346;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 348;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 349;
                IFILEHANDLE = (ushort) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 350;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ATTEMPTCOUNTER > 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 352;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 353;
                    return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 355;
                ATTEMPTCOUNTER = (ushort) ( (ATTEMPTCOUNTER + 1) ) ; 
                __context__.SourceCodeLine = 346;
                } 
            
            __context__.SourceCodeLine = 358;
            BBUFFERDONE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 359;
            BLOADNOTFOUND = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 360;
            LINECOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 361;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 364;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LINECOUNTER == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 366;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 367;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 368;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 369;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 370;
                    SLINE  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 373;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (BBUFFERDONE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 375;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "\r\n" , SREADBUF , 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 377;
                        if ( Functions.TestForTrue  ( ( Functions.Length( SLINE ))  ) ) 
                            {
                            __context__.SourceCodeLine = 378;
                            SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 380;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 384;
                        SLINE  .UpdateValue ( SREADBUF  ) ; 
                        __context__.SourceCodeLine = 385;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 388;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 389;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 390;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( SLINE ) == LOAD_NUMBER  .Value))  ) ) 
                            { 
                            __context__.SourceCodeLine = 392;
                            ISTART = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 393;
                            ILEN = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 397;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 398;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 399;
                            G_LOADNAME  .UpdateValue ( TEMPSTRING  ) ; 
                            __context__.SourceCodeLine = 401;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 402;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 403;
                            G_PARENTRM_ID = (short) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 405;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 406;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 407;
                            G_DIM_SETTING = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 409;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 410;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 411;
                            G_RAMPTIME = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 413;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 414;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 415;
                            G_UPPERLIMIT = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 417;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 418;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 419;
                            G_LOWERLIMIT = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 421;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 422;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 423;
                            G_TOTAL_WATTAGE = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
                            __context__.SourceCodeLine = 425;
                            BLOADNOTFOUND = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 426;
                            
                            __context__.SourceCodeLine = 429;
                            FileClose (  (short) ( IFILEHANDLE ) ) ; 
                            __context__.SourceCodeLine = 430;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 431;
                            return (ushort)( 0) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 433;
                    SLINE  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 434;
                    LINECOUNTER = (ushort) ( (LINECOUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 373;
                    } 
                
                __context__.SourceCodeLine = 361;
                } 
            
            __context__.SourceCodeLine = 437;
            if ( Functions.TestForTrue  ( ( BLOADNOTFOUND)  ) ) 
                { 
                __context__.SourceCodeLine = 439;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 440;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 441;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 443;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 444;
            EndFileOperations ( ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort COMMANDHANDLER (  SplusExecutionContext __context__ ) 
            { 
            ushort LOADNUM = 0;
            
            ushort ROUTINGID = 0;
            
            ushort INDEX = 0;
            
            ushort CMD = 0;
            
            ushort FUNCTIONRETURNVALUE = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            CrestronString LEVELINFO;
            LEVELINFO  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            ushort LOADLEVEL = 0;
            
            RAMP_INFO RAMPINFO;
            RAMPINFO  = new RAMP_INFO();
            RAMPINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 459;
            
            __context__.SourceCodeLine = 463;
            LOADNUM = (ushort) ( Functions.Atoi( Functions.Mid( STOREDCOMMANDSTRING , (int)( (5 + 3) ) , (int)( 5 ) ) ) ) ; 
            __context__.SourceCodeLine = 465;
            switch ((int)Byte( STOREDCOMMANDSTRING , (int)( 5 ) ))
            
                { 
                case 61 : 
                
                    { 
                    __context__.SourceCodeLine = 469;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GETLOADSINFO( __context__ ) >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 471;
                        MakeString ( TEMPSTRING , "{0:d}{1}{2}{3}{4:d}{5}{6:d1}{7}{8:d}{9}{10:d5}{11}{12:d5}{13}{14:d3}{15}{16:d5}", (short)LOADNUM, "," , G_LOADNAME , "," , (short)G_PARENTRM_ID, "," , (ushort)G_DIM_SETTING, "," , (int)G_RAMPTIME, "," , (ushort)G_UPPERLIMIT, "," , (ushort)G_LOWERLIMIT, "," , (ushort)G_TOTAL_WATTAGE, "," , (ushort)SETLEVEL  .Value) ; 
                        __context__.SourceCodeLine = 472;
                        SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 476;
                        MakeString ( TEMPSTRING , "{0:d}{1}{2}{3}{4}", (short)LOADNUM, "," , "-1" , "," , "Load Not Found" ) ; 
                        __context__.SourceCodeLine = 477;
                        SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 255 ), TEMPSTRING) ; 
                        } 
                    
                    __context__.SourceCodeLine = 479;
                    break ; 
                    } 
                
                goto case 62 ;
                case 62 : 
                
                    { 
                    __context__.SourceCodeLine = 483;
                    INDEX = (ushort) ( Functions.Find( "," , STOREDCOMMANDSTRING , 1 ) ) ; 
                    __context__.SourceCodeLine = 488;
                    RAMPINFO .  rampTargetValue = (int) ( Functions.Atoi( Functions.Mid( STOREDCOMMANDSTRING , (int)( (INDEX + 1) ) , (int)( 5 ) ) ) ) ; 
                    __context__.SourceCodeLine = 490;
                    INDEX = (ushort) ( Functions.Find( "," , STOREDCOMMANDSTRING , (INDEX + 1) ) ) ; 
                    __context__.SourceCodeLine = 492;
                    RAMPINFO .  rampTransitionTime = (uint) ( Functions.Atoi( Functions.Mid( STOREDCOMMANDSTRING , (int)( (INDEX + 1) ) , (int)( 5 ) ) ) ) ; 
                    __context__.SourceCodeLine = 493;
                    CreateRamp ( SETLEVEL ,  ref RAMPINFO ) ; 
                    __context__.SourceCodeLine = 494;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2:d}", (short)LOADNUM, "," , (short)RAMPINFO.rampTargetValue) ; 
                    __context__.SourceCodeLine = 495;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 496;
                    break ; 
                    } 
                
                goto case 63 ;
                case 63 : 
                
                    { 
                    __context__.SourceCodeLine = 500;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2:d}{3}{4:d}{5}{6:d}", (short)LOADNUM, "," , (short)((((G_RAMPTIME * (G_UPPERLIMIT - SETLEVEL  .Value)) * 100) / G_UPPERLIMIT) / 100), "," , (short)SETLEVEL  .Value, "," , (short)G_UPPERLIMIT) ; 
                    __context__.SourceCodeLine = 501;
                    RAISELEVEL  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 502;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 503;
                    break ; 
                    } 
                
                goto case 64 ;
                case 64 : 
                
                    { 
                    __context__.SourceCodeLine = 507;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2:d}{3}{4:d}{5}{6:d}", (short)LOADNUM, "," , (short)((((G_RAMPTIME * (SETLEVEL  .Value - G_LOWERLIMIT)) * 100) / SETLEVEL  .Value) / 100), "," , (short)SETLEVEL  .Value, "," , (short)G_LOWERLIMIT) ; 
                    __context__.SourceCodeLine = 508;
                    LOWERLEVEL  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 509;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 510;
                    break ; 
                    } 
                
                goto case 65 ;
                case 65 : 
                
                    { 
                    __context__.SourceCodeLine = 514;
                    RAISELEVEL  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 515;
                    LOWERLEVEL  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 516;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2:d}", (short)LOADNUM, "," , (short)SETLEVEL  .Value) ; 
                    __context__.SourceCodeLine = 517;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 518;
                    break ; 
                    } 
                
                goto case 66 ;
                case 66 : 
                
                    { 
                    __context__.SourceCodeLine = 522;
                    Print( "\r\nSubscribing to load") ; 
                    __context__.SourceCodeLine = 523;
                    LOADNOTSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 524;
                    LOADSUBSCRIBED  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 525;
                    LOADSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 526;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2:d}", (short)LOADNUM, "," , (ushort)SETLEVEL  .Value) ; 
                    __context__.SourceCodeLine = 527;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 55 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 528;
                    break ; 
                    } 
                
                goto case 67 ;
                case 67 : 
                
                    { 
                    __context__.SourceCodeLine = 532;
                    LOADSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 533;
                    LOADNOTSUBSCRIBED  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 534;
                    LOADNOTSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 535;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2}", (short)LOADNUM, "," , "\u0036" ) ; 
                    __context__.SourceCodeLine = 536;
                    SENDRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 537;
                    break ; 
                    } 
                
                break;
                } 
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        object LOAD_CMD__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 549;
                
                __context__.SourceCodeLine = 552;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( LOAD_CMD__DOLLAR__ ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 554;
                    
                    __context__.SourceCodeLine = 558;
                    while ( Functions.TestForTrue  ( ( G_COMMAND_HANDLER)  ) ) 
                        {
                        __context__.SourceCodeLine = 559;
                        Functions.ProcessLogic ( ) ; 
                        __context__.SourceCodeLine = 558;
                        }
                    
                    __context__.SourceCodeLine = 560;
                    G_COMMAND_HANDLER = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 561;
                    STOREDCOMMANDSTRING  .UpdateValue ( Functions.Remove ( "\\" , LOAD_CMD__DOLLAR__ , 1)  ) ; 
                    __context__.SourceCodeLine = 562;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 564;
                        COMMANDHANDLER (  __context__  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 566;
                    G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 552;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SUBSCRIPTIONEXPIRED_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 577;
            LOADSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 578;
            LOADNOTSUBSCRIBED  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 579;
            LOADNOTSUBSCRIBED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 580;
            MakeString ( TEMPSTRING , "{0:d}{1}{2:d}", (short)LOAD_NUMBER  .Value, "," , (ushort)SETLEVEL  .Value) ; 
            __context__.SourceCodeLine = 581;
            BROADCASTRESPONSE (  __context__ , (ushort)( 49 ), (ushort)( 55 ), TEMPSTRING) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object LOAD_LEVEL_INCREASING_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPSTRING;
        TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 587;
        if ( Functions.TestForTrue  ( ( LOADSUBSCRIBED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 589;
            MakeString ( TEMPSTRING , "{0:d}{1}{2}", (short)LOAD_NUMBER  .Value, "," , "+" ) ; 
            __context__.SourceCodeLine = 590;
            BROADCASTRESPONSE (  __context__ , (ushort)( 49 ), (ushort)( 55 ), TEMPSTRING) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LOAD_LEVEL_DECREASING_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPSTRING;
        TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 597;
        if ( Functions.TestForTrue  ( ( LOADSUBSCRIBED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 599;
            MakeString ( TEMPSTRING , "{0:d}{1}{2}", (short)LOAD_NUMBER  .Value, "," , "-" ) ; 
            __context__.SourceCodeLine = 600;
            BROADCASTRESPONSE (  __context__ , (ushort)( 49 ), (ushort)( 55 ), TEMPSTRING) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LOAD_LEVEL_RAMPING_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPSTRING;
        TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 607;
        if ( Functions.TestForTrue  ( ( LOADSUBSCRIBED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 609;
            MakeString ( TEMPSTRING , "{0:d}{1}{2:d}", (short)LOAD_NUMBER  .Value, "," , (ushort)SETLEVEL  .Value) ; 
            __context__.SourceCodeLine = 610;
            BROADCASTRESPONSE (  __context__ , (ushort)( 49 ), (ushort)( 55 ), TEMPSTRING) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PATH__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 616;
        G_LOADS_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "Loads.dat"  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 678;
        G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 679;
        G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 680;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_LOADS_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_LOADNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_LASTSAVEDTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    G_LASTSAVEDDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    STOREDCOMMANDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
    G_FILEINFO  = new FILE_INFO();
    G_FILEINFO .PopulateDefaults();
    
    LOAD_LEVEL_INCREASING = new Crestron.Logos.SplusObjects.DigitalInput( LOAD_LEVEL_INCREASING__DigitalInput__, this );
    m_DigitalInputList.Add( LOAD_LEVEL_INCREASING__DigitalInput__, LOAD_LEVEL_INCREASING );
    
    LOAD_LEVEL_DECREASING = new Crestron.Logos.SplusObjects.DigitalInput( LOAD_LEVEL_DECREASING__DigitalInput__, this );
    m_DigitalInputList.Add( LOAD_LEVEL_DECREASING__DigitalInput__, LOAD_LEVEL_DECREASING );
    
    LOAD_LEVEL_RAMPING = new Crestron.Logos.SplusObjects.DigitalInput( LOAD_LEVEL_RAMPING__DigitalInput__, this );
    m_DigitalInputList.Add( LOAD_LEVEL_RAMPING__DigitalInput__, LOAD_LEVEL_RAMPING );
    
    SUBSCRIPTIONEXPIRED = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIPTIONEXPIRED__DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIPTIONEXPIRED__DigitalInput__, SUBSCRIPTIONEXPIRED );
    
    RAISELEVEL = new Crestron.Logos.SplusObjects.DigitalOutput( RAISELEVEL__DigitalOutput__, this );
    m_DigitalOutputList.Add( RAISELEVEL__DigitalOutput__, RAISELEVEL );
    
    LOWERLEVEL = new Crestron.Logos.SplusObjects.DigitalOutput( LOWERLEVEL__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOWERLEVEL__DigitalOutput__, LOWERLEVEL );
    
    LOADSUBSCRIBED = new Crestron.Logos.SplusObjects.DigitalOutput( LOADSUBSCRIBED__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOADSUBSCRIBED__DigitalOutput__, LOADSUBSCRIBED );
    
    LOADNOTSUBSCRIBED = new Crestron.Logos.SplusObjects.DigitalOutput( LOADNOTSUBSCRIBED__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOADNOTSUBSCRIBED__DigitalOutput__, LOADNOTSUBSCRIBED );
    
    SETLEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( SETLEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SETLEVEL__AnalogSerialOutput__, SETLEVEL );
    
    RESPONSEID = new Crestron.Logos.SplusObjects.AnalogOutput( RESPONSEID__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RESPONSEID__AnalogSerialOutput__, RESPONSEID );
    
    PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 64, this );
    m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
    
    RESPONSE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RESPONSE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( RESPONSE__DOLLAR____AnalogSerialOutput__, RESPONSE__DOLLAR__ );
    
    LOAD_CMD__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( LOAD_CMD__DOLLAR____AnalogSerialInput__, 512, this );
    m_StringInputList.Add( LOAD_CMD__DOLLAR____AnalogSerialInput__, LOAD_CMD__DOLLAR__ );
    
    LOAD_NUMBER = new UShortParameter( LOAD_NUMBER__Parameter__, this );
    m_ParameterList.Add( LOAD_NUMBER__Parameter__, LOAD_NUMBER );
    
    
    LOAD_CMD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( LOAD_CMD__DOLLAR___OnChange_0, false ) );
    SUBSCRIPTIONEXPIRED.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIPTIONEXPIRED_OnPush_1, false ) );
    LOAD_LEVEL_INCREASING.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOAD_LEVEL_INCREASING_OnPush_2, false ) );
    LOAD_LEVEL_DECREASING.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOAD_LEVEL_DECREASING_OnPush_3, false ) );
    LOAD_LEVEL_RAMPING.OnDigitalRelease.Add( new InputChangeHandlerWrapper( LOAD_LEVEL_RAMPING_OnRelease_4, false ) );
    PATH__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( PATH__DOLLAR___OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_LOAD_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LOAD_CMD__DOLLAR____AnalogSerialInput__ = 0;
const uint LOAD_LEVEL_INCREASING__DigitalInput__ = 0;
const uint LOAD_LEVEL_DECREASING__DigitalInput__ = 1;
const uint LOAD_LEVEL_RAMPING__DigitalInput__ = 2;
const uint SUBSCRIPTIONEXPIRED__DigitalInput__ = 3;
const uint RAISELEVEL__DigitalOutput__ = 0;
const uint LOWERLEVEL__DigitalOutput__ = 1;
const uint SETLEVEL__AnalogSerialOutput__ = 0;
const uint RESPONSE__DOLLAR____AnalogSerialOutput__ = 1;
const uint LOADSUBSCRIBED__DigitalOutput__ = 2;
const uint LOADNOTSUBSCRIBED__DigitalOutput__ = 3;
const uint RESPONSEID__AnalogSerialOutput__ = 2;
const uint LOAD_NUMBER__Parameter__ = 10;
const uint PATH__DOLLAR____AnalogSerialInput__ = 1;

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
