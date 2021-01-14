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

namespace CrestronModule_DYNAMIC_SHADE_PRESET_V1_02
{
    public class CrestronModuleClass_DYNAMIC_SHADE_PRESET_V1_02 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RECALL;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.DigitalInput REVERT;
        Crestron.Logos.SplusObjects.DigitalInput UPDATE_FB;
        Crestron.Logos.SplusObjects.DigitalInput PRESET_BUSY;
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ANY_OPEN_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ALL_OPEN_FB;
        Crestron.Logos.SplusObjects.DigitalOutput AT_SCENE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput RECALLING_SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput TURNING_OFF_SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput RECALL_OK;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_OK;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput REVERT_OK;
        Crestron.Logos.SplusObjects.DigitalOutput REVERT_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLE_BUFFER;
        Crestron.Logos.SplusObjects.DigitalOutput FIRE_RAMP;
        Crestron.Logos.SplusObjects.DigitalOutput PRESET_MOVING;
        Crestron.Logos.SplusObjects.DigitalOutput PRESET_OPENING;
        Crestron.Logos.SplusObjects.DigitalOutput PRESET_CLOSING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHADE_IN_SCENE;
        Crestron.Logos.SplusObjects.AnalogOutput RESPONSEID;
        Crestron.Logos.SplusObjects.AnalogOutput UPPERWORDFADETIME;
        Crestron.Logos.SplusObjects.AnalogOutput LOWERWORDFADETIME;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> TARGET_POSITIONS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CURRENT_POSITIONS;
        SHADE_SETTING [] SHADE_SETTINGS;
        UIntParameter SCENE_ID;
        UIntParameter FADE_TIME;
        UIntParameter OFF_TIME;
        InOutArray<StringParameter> SHADE_PROPERTY;
        ushort G_TOTAL_SHADES = 0;
        ushort G_SHADES_MOVING = 0;
        CrestronString G_SCENEFILENAME__DOLLAR__;
        CrestronString G_LOADS_FILE__DOLLAR__;
        CrestronString G_SCENENAME;
        ushort G_ROOMID = 0;
        ushort G_SEMAPHORE = 0;
        ushort G_FAST_RECALLING = 0;
        ushort G_RECALLING = 0;
        ushort G_FAST_OFFING = 0;
        ushort G_OFFING = 0;
        ushort G_FILE_SEMAPHORE = 0;
        CrestronString G_SCENES_FILE__DOLLAR__;
        uint G_FADE_TIME = 0;
        uint G_OFF_TIME = 0;
        CrestronString G_LASTSAVEDTIME;
        CrestronString G_LASTSAVEDDATE;
        FILE_INFO G_FILEINFO;
        ushort G_FILELOADED = 0;
        ushort G_LAST_DIRECTION_UP = 0;
        ushort G_LAST_DIRECTION_DOWN = 0;
        ushort [] G_PREVIOUS_LEVELS;
        ushort [] SHADE_MOVING;
        private void STOP_RAMP (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            
            }
            
        private void UPDATE_FB_LOOP (  SplusExecutionContext __context__ ) 
            { 
            RAMP_INFO RI;
            RI  = new RAMP_INFO();
            RI .PopulateDefaults();
            
            ushort COMPAREVALUE = 0;
            
            ushort SETTINGVALUE = 0;
            
            ushort INDEX = 0;
            
            ushort ANY_OPEN = 0;
            ushort ALL_OPEN = 0;
            ushort AT_SCENE = 0;
            
            
            __context__.SourceCodeLine = 220;
            ANY_OPEN = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 221;
            ALL_OPEN = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 222;
            AT_SCENE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 224;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 227;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( SHADE_SETTINGS[ INDEX ].LPOS >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 229;
                    COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                    __context__.SourceCodeLine = 230;
                    
                    __context__.SourceCodeLine = 235;
                    SETTINGVALUE = (ushort) ( SHADE_SETTINGS[ INDEX ].LPOS ) ; 
                    __context__.SourceCodeLine = 239;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( (SETTINGVALUE - COMPAREVALUE) ) > 1024 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 242;
                        AT_SCENE = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 246;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 655 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 249;
                        ANY_OPEN = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 253;
                        ALL_OPEN = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 255;
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 261;
                    
                    __context__.SourceCodeLine = 266;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 268;
                        switch ((int)SHADE_SETTINGS[ INDEX ].LPOS)
                        
                            { 
                            case -3 : 
                            
                                { 
                                __context__.SourceCodeLine = 279;
                                COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 281;
                                
                                __context__.SourceCodeLine = 286;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (65535 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 289;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 293;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 655 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 295;
                                    ANY_OPEN = (ushort) ( 1 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 299;
                                    ALL_OPEN = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 300;
                                break ; 
                                } 
                            
                            goto case -4 ;
                            case -4 : 
                            
                                { 
                                __context__.SourceCodeLine = 310;
                                COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 312;
                                
                                __context__.SourceCodeLine = 316;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (0 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 318;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 320;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 321;
                                    ANY_OPEN = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 322;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREVALUE == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 323;
                                    ALL_OPEN = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 324;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 328;
                    
                    } 
                
                __context__.SourceCodeLine = 224;
                } 
            
            __context__.SourceCodeLine = 334;
            if ( Functions.TestForTrue  ( ( BUSY_FB  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 335;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 339;
            AT_SCENE_FB  .Value = (ushort) ( AT_SCENE ) ; 
            __context__.SourceCodeLine = 340;
            ANY_OPEN_FB  .Value = (ushort) ( ANY_OPEN ) ; 
            __context__.SourceCodeLine = 341;
            ALL_OPEN_FB  .Value = (ushort) ( ALL_OPEN ) ; 
            
            }
            
        private void SENDRAMP (  SplusExecutionContext __context__, ushort IOUTPUTNUMBER , ushort FADETIME , int RAMPVALUE ) 
            { 
            ushort IRESULT = 0;
            
            
            __context__.SourceCodeLine = 351;
            UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 352;
            LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 357;
            TARGET_POSITIONS [ IOUTPUTNUMBER]  .Value = (ushort) ( RAMPVALUE ) ; 
            
            }
            
        private short COMPAREFILEDATEANDTIME (  SplusExecutionContext __context__, FILE_INFO FIFILE1 , FILE_INFO FIFILE2 ) 
            { 
            
            __context__.SourceCodeLine = 368;
            
            __context__.SourceCodeLine = 381;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate > FIFILE2.iDate ))  ) ) 
                {
                __context__.SourceCodeLine = 382;
                return (short)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 383;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate < FIFILE2.iDate ))  ) ) 
                    {
                    __context__.SourceCodeLine = 384;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 387;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime > FIFILE2.iTime ))  ) ) 
                        {
                        __context__.SourceCodeLine = 388;
                        return (short)( 1) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 389;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime < FIFILE2.iTime ))  ) ) 
                            {
                            __context__.SourceCodeLine = 390;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 392;
                            return (short)( 0) ; 
                            }
                        
                        }
                    
                    } 
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort RAMPINPROGRESS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            RAMP_INFO RAMPDATA;
            RAMPDATA  = new RAMP_INFO();
            RAMPDATA .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 407;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 410;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IsRamping( CURRENT_POSITIONS[ I ] ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 413;
                    GetRampInfo ( CURRENT_POSITIONS [ I] ,  ref RAMPDATA ) ; 
                    __context__.SourceCodeLine = 417;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RAMPDATA.rampIdentifier == SHADE_SETTINGS[ I ].LRAMPID))  ) ) 
                        { 
                        __context__.SourceCodeLine = 419;
                        return (ushort)( 1) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 407;
                } 
            
            __context__.SourceCodeLine = 423;
            return (ushort)( 0) ; 
            
            }
            
        private ushort GETLOADSINFO (  SplusExecutionContext __context__, ushort LOAD_NUMBER , ushort CIRCUITID ) 
            { 
            short IFILEHANDLE = 0;
            
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
            
            
            __context__.SourceCodeLine = 442;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 443;
            IFILEHANDLE = (short) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 444;
            ATTEMPTCOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 445;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 447;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 448;
                IFILEHANDLE = (short) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 449;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ATTEMPTCOUNTER > 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 451;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 452;
                    return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 454;
                ATTEMPTCOUNTER = (ushort) ( (ATTEMPTCOUNTER + 1) ) ; 
                __context__.SourceCodeLine = 445;
                } 
            
            __context__.SourceCodeLine = 457;
            BBUFFERDONE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 458;
            BLOADNOTFOUND = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 459;
            LINECOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 460;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 463;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LINECOUNTER == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 465;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 466;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 467;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 468;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 469;
                    SLINE  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 472;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (BBUFFERDONE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 474;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "\r\n" , SREADBUF , 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 476;
                        if ( Functions.TestForTrue  ( ( Functions.Length( SLINE ))  ) ) 
                            {
                            __context__.SourceCodeLine = 477;
                            SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 479;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 483;
                        SLINE  .UpdateValue ( SREADBUF  ) ; 
                        __context__.SourceCodeLine = 484;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 487;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 488;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 489;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( SLINE ) == SHADE_SETTINGS[ LOAD_NUMBER ].SHADEID))  ) ) 
                            { 
                            __context__.SourceCodeLine = 491;
                            ISTART = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 492;
                            ILEN = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 493;
                            
                            __context__.SourceCodeLine = 498;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 499;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 502;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 503;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 506;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 507;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 508;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "True" , TEMPSTRING , 1 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 509;
                                SHADE_SETTINGS [ LOAD_NUMBER] . DIMMABLE = (short) ( 1 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 511;
                                SHADE_SETTINGS [ LOAD_NUMBER] . DIMMABLE = (short) ( 1 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 513;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 514;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 517;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 518;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 521;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 522;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 525;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 526;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\t" , SLINE , ILEN ) > ILEN ))  ) ) 
                                {
                                __context__.SourceCodeLine = 527;
                                TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                                }
                            
                            __context__.SourceCodeLine = 530;
                            BLOADNOTFOUND = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 531;
                            
                            __context__.SourceCodeLine = 534;
                            FileClose (  (short) ( IFILEHANDLE ) ) ; 
                            __context__.SourceCodeLine = 535;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 536;
                            return (ushort)( 0) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 538;
                    SLINE  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 539;
                    LINECOUNTER = (ushort) ( (LINECOUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 472;
                    } 
                
                __context__.SourceCodeLine = 460;
                } 
            
            __context__.SourceCodeLine = 542;
            if ( Functions.TestForTrue  ( ( BLOADNOTFOUND)  ) ) 
                { 
                __context__.SourceCodeLine = 544;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 545;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 546;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 548;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 549;
            EndFileOperations ( ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort LOAD_FILE (  SplusExecutionContext __context__ ) 
            { 
            short FILEOPERATIONSTATUS = 0;
            short IFILEHANDLE = 0;
            short IUPDATEDFILEHANDLE = 0;
            
            ushort I = 0;
            ushort INDEX = 0;
            ushort COUNTER = 0;
            ushort BBUFFERDONE = 0;
            ushort ILOADCOUNT = 0;
            
            CrestronString TEMP;
            TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 7, this );
            
            CrestronString LOADPROPERTY;
            LOADPROPERTY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString SREADBUF;
            SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 612, this );
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString UPDATEDSCENEFILENAME__DOLLAR__;
            UPDATEDSCENEFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 104, this );
            
            ushort READSIZE = 0;
            
            ushort INCLUDED = 0;
            
            int LPOS = 0;
            int LOAD_PRESET_VALUE = 0;
            
            
            __context__.SourceCodeLine = 570;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 571;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 570;
                }
            
            __context__.SourceCodeLine = 572;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 574;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 576;
            FILEOPERATIONSTATUS = (short) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref G_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 578;
            
            __context__.SourceCodeLine = 583;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEOPERATIONSTATUS != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 586;
                
                __context__.SourceCodeLine = 590;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 593;
                    LOADPROPERTY  .UpdateValue ( SHADE_PROPERTY [ INDEX ]  ) ; 
                    __context__.SourceCodeLine = 595;
                    SHADE_SETTINGS [ INDEX] . SHADEID = (ushort) ( Functions.Atoi( LOADPROPERTY ) ) ; 
                    __context__.SourceCodeLine = 598;
                    UPDATEDSCENEFILENAME__DOLLAR__  .UpdateValue ( Functions.Remove ( "," , LOADPROPERTY )  ) ; 
                    __context__.SourceCodeLine = 599;
                    LPOS = (int) ( Functions.Atol( LOADPROPERTY ) ) ; 
                    __context__.SourceCodeLine = 601;
                    GETLOADSINFO (  __context__ , (ushort)( INDEX ), (ushort)( SHADE_SETTINGS[ INDEX ].SHADEID )) ; 
                    __context__.SourceCodeLine = 603;
                    
                    __context__.SourceCodeLine = 609;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LPOS >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 611;
                        
                        __context__.SourceCodeLine = 616;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xd"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 618;
                            SHADE_SETTINGS [ INDEX] . LPOS = (int) ( -1 ) ; 
                            __context__.SourceCodeLine = 619;
                            SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 621;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xn"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 623;
                                SHADE_SETTINGS [ INDEX] . LPOS = (int) ( -2 ) ; 
                                __context__.SourceCodeLine = 624;
                                SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 627;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "on"))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 629;
                                    SHADE_SETTINGS [ INDEX] . LPOS = (int) ( 65535 ) ; 
                                    __context__.SourceCodeLine = 630;
                                    SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 633;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "off"))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 635;
                                        SHADE_SETTINGS [ INDEX] . LPOS = (int) ( 0 ) ; 
                                        __context__.SourceCodeLine = 636;
                                        SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 641;
                                        SHADE_SETTINGS [ INDEX] . LPOS = (int) ( LPOS ) ; 
                                        __context__.SourceCodeLine = 642;
                                        SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 643;
                                        
                                        __context__.SourceCodeLine = 645;
                                        ; 
                                        } 
                                    
                                    }
                                
                                }
                            
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 648;
                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED)  ) ) 
                        {
                        __context__.SourceCodeLine = 649;
                        SHADE_IN_SCENE [ INDEX]  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 651;
                        SHADE_IN_SCENE [ INDEX]  .Value = (ushort) ( 1 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 590;
                    } 
                
                __context__.SourceCodeLine = 653;
                G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
                __context__.SourceCodeLine = 654;
                G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
                __context__.SourceCodeLine = 655;
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 662;
                IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 664;
                I = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 666;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 668;
                    TEMP  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 670;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                    __context__.SourceCodeLine = 671;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( 7 ) ) ; 
                    __context__.SourceCodeLine = 673;
                    
                    __context__.SourceCodeLine = 678;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.CompareStrings( TEMP , "v1.0.00" ) == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 680;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 681;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                        __context__.SourceCodeLine = 682;
                        
                        __context__.SourceCodeLine = 685;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDDATE ,  (ushort) ( 10 ) ) ; 
                        __context__.SourceCodeLine = 686;
                        
                        __context__.SourceCodeLine = 689;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 690;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                        __context__.SourceCodeLine = 691;
                        
                        __context__.SourceCodeLine = 694;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDTIME ,  (ushort) ( 8 ) ) ; 
                        __context__.SourceCodeLine = 695;
                        
                        __context__.SourceCodeLine = 698;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 705;
                    ILOADCOUNT = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 708;
                    READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                    __context__.SourceCodeLine = 709;
                    
                    __context__.SourceCodeLine = 715;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 718;
                        SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                        __context__.SourceCodeLine = 719;
                        BBUFFERDONE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 722;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOADCOUNT == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 733;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                            __context__.SourceCodeLine = 734;
                            SLINE  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 737;
                        
                        __context__.SourceCodeLine = 742;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (BBUFFERDONE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOADCOUNT <= G_TOTAL_SHADES ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 745;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "\r\n" , SREADBUF , 1 ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SLINE ) == 0) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 747;
                                SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                __context__.SourceCodeLine = 749;
                                
                                __context__.SourceCodeLine = 753;
                                SHADE_SETTINGS [ ILOADCOUNT] . SHADEID = (ushort) ( Functions.Atoi( SLINE ) ) ; 
                                __context__.SourceCodeLine = 755;
                                GETLOADSINFO (  __context__ , (ushort)( ILOADCOUNT ), (ushort)( SHADE_SETTINGS[ ILOADCOUNT ].SHADEID )) ; 
                                __context__.SourceCodeLine = 757;
                                
                                __context__.SourceCodeLine = 761;
                                TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                __context__.SourceCodeLine = 765;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\t" , SLINE , 1 ) > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 767;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 768;
                                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ ILOADCOUNT ].DIMMABLE)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 770;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atol( TEMPSTRING ) > 0 ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 771;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( Functions.Atol( TEMPSTRING ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 773;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 774;
                                        SHADE_SETTINGS [ ILOADCOUNT] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 778;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPSTRING == "on\t"))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 779;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 65535 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 781;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 782;
                                        SHADE_SETTINGS [ ILOADCOUNT] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 787;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\r\n" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 797;
                                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ ILOADCOUNT ].DIMMABLE)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 799;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atol( TEMPSTRING ) > 0 ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 800;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( Functions.Atol( TEMPSTRING ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 802;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 803;
                                        SHADE_SETTINGS [ ILOADCOUNT] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 807;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPSTRING == "on\t"))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 808;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 65535 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 810;
                                            SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 811;
                                        SHADE_SETTINGS [ ILOADCOUNT] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 815;
                                if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ ILOADCOUNT ].SHADEEXCLUDED)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 816;
                                    SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 818;
                                    SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 820;
                                
                                __context__.SourceCodeLine = 824;
                                ILOADCOUNT = (ushort) ( (ILOADCOUNT + 1) ) ; 
                                __context__.SourceCodeLine = 825;
                                SLINE  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 745;
                                } 
                            
                            __context__.SourceCodeLine = 827;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SLINE ) > 0 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 828;
                                SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                }
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 831;
                                SLINE  .UpdateValue ( SREADBUF  ) ; 
                                __context__.SourceCodeLine = 832;
                                BBUFFERDONE = (ushort) ( 1 ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 836;
                            READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                            __context__.SourceCodeLine = 837;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 838;
                                BBUFFERDONE = (ushort) ( 0 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 742;
                            } 
                        
                        __context__.SourceCodeLine = 715;
                        } 
                    
                    __context__.SourceCodeLine = 843;
                    FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 848;
                    GenerateUserWarning ( "\r\nError Opening File for Scene: {0:d}", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 849;
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 857;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 858;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 859;
            return (ushort)( 0) ; 
            
            }
            
        private ushort SAVESCENE (  SplusExecutionContext __context__ ) 
            { 
            short FILEOPERATIONSTATUS = 0;
            short IFILEHANDLE = 0;
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            ushort I = 0;
            ushort FLAG = 0;
            ushort FILEEXISTFLAG = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString TYPE;
            TYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 872;
            FLAG = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 875;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 878;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ I ].LPOS != -1) ) || Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ I ].LPOS != -2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_POSITIONS[ I ] .Value >= 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 880;
                    FLAG = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 881;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 875;
                } 
            
            __context__.SourceCodeLine = 885;
            if ( Functions.TestForTrue  ( ( FLAG)  ) ) 
                {
                __context__.SourceCodeLine = 886;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 888;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 889;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 888;
                }
            
            __context__.SourceCodeLine = 890;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 892;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 893;
            FILEEXISTFLAG = (ushort) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 894;
            IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) ((1 | 256) | 16384) ) ) ; 
            __context__.SourceCodeLine = 896;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 898;
                FileWrite (  (short) ( IFILEHANDLE ) , "File Version\t" ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                __context__.SourceCodeLine = 899;
                FileWrite (  (short) ( IFILEHANDLE ) , "v1.0.00" ,  (ushort) ( 7 ) ) ; 
                __context__.SourceCodeLine = 900;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 901;
                FileWrite (  (short) ( IFILEHANDLE ) , "Modified Date\t" ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                __context__.SourceCodeLine = 902;
                FileWrite (  (short) ( IFILEHANDLE ) , Functions.Date (  (int) ( 1 ) ) ,  (ushort) ( 10 ) ) ; 
                __context__.SourceCodeLine = 903;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 904;
                FileWrite (  (short) ( IFILEHANDLE ) , "Modified Time\t" ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                __context__.SourceCodeLine = 905;
                FileWrite (  (short) ( IFILEHANDLE ) , Functions.Time ( ) ,  (ushort) ( 8 ) ) ; 
                __context__.SourceCodeLine = 906;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 908;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEEXISTFLAG != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 910;
                    G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
                    __context__.SourceCodeLine = 911;
                    G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
                    } 
                
                __context__.SourceCodeLine = 917;
                FileWrite (  (short) ( IFILEHANDLE ) , "Load ID\tTarget Level\u000D\u000A" ,  (ushort) ( Functions.Length( "Load ID\tTarget Level\u000D\u000A" ) ) ) ; 
                __context__.SourceCodeLine = 919;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 922;
                    SHADE_SETTINGS [ I] . LPOS = (int) ( CURRENT_POSITIONS[ I ] .Value ) ; 
                    __context__.SourceCodeLine = 924;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ I ].SHADEEXCLUDED == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 925;
                        MakeString ( TEMPSTRING , "{0:d}\t{1:d}\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)CURRENT_POSITIONS[ I ] .Value) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 927;
                        MakeString ( TEMPSTRING , "{0:d}\t{1:d}\txd\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)SHADE_SETTINGS[ I ].LPOS) ; 
                        }
                    
                    __context__.SourceCodeLine = 928;
                    
                    __context__.SourceCodeLine = 931;
                    FILEOPERATIONSTATUS = (short) ( FileWrite( (short)( IFILEHANDLE ) , TEMPSTRING , (ushort)( Functions.Length( TEMPSTRING ) ) ) ) ; 
                    __context__.SourceCodeLine = 933;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 935;
                        
                        __context__.SourceCodeLine = 938;
                        SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 939;
                        SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 942;
                        GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}", (int)SCENE_ID  .Value) ; 
                        __context__.SourceCodeLine = 943;
                        
                        __context__.SourceCodeLine = 946;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 947;
                        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 948;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 919;
                    } 
                
                __context__.SourceCodeLine = 953;
                
                __context__.SourceCodeLine = 956;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 958;
                    
                    __context__.SourceCodeLine = 962;
                    SAVE_OK  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 963;
                    SAVE_OK  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 967;
                    
                    __context__.SourceCodeLine = 970;
                    SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 971;
                    SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 974;
                    GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 975;
                    
                    __context__.SourceCodeLine = 978;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 979;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 980;
                    return (ushort)( 1) ; 
                    } 
                
                __context__.SourceCodeLine = 983;
                FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 987;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 990;
                    GenerateUserError ( "\r\nError Opening Scene File for Scene #{0:d} for saving", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 991;
                    
                    __context__.SourceCodeLine = 994;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 995;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 996;
                    return (ushort)( 1) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 999;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1000;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1001;
            UPDATE_FB_LOOP (  __context__  ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort SETSCENENAME (  SplusExecutionContext __context__, ushort SCENEID , CrestronString NEWSCENENAME ) 
            { 
            
            
            return 0; // default return value (none specified in module)
            }
            
        object RECALL_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort FADEVALUE = 0;
                ushort INDEX = 0;
                ushort IRESULT = 0;
                
                FILE_INFO FILEINFO;
                FILEINFO  = new FILE_INFO();
                FILEINFO .PopulateDefaults();
                
                RAMP_INFO RAMPDATA;
                RAMPDATA  = new RAMP_INFO();
                RAMPDATA .PopulateDefaults();
                
                
                __context__.SourceCodeLine = 1186;
                if ( Functions.TestForTrue  ( ( G_RECALLING)  ) ) 
                    {
                    __context__.SourceCodeLine = 1187;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 1188;
                G_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1189;
                G_FAST_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1190;
                G_FAST_RECALLING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1191;
                G_RECALLING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1194;
                RECALLING_SCENE  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1195;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AT_SCENE_FB  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1196;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1199;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 1200;
                if ( Functions.TestForTrue  ( ( Functions.Not( PRESET_BUSY  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1202;
                    UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADE_TIME  .Value ) ) ) ; 
                    __context__.SourceCodeLine = 1203;
                    LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADE_TIME  .Value ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1207;
                    UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1208;
                    LOWERWORDFADETIME  .Value = (ushort) ( 50 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1214;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1224;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_RECALLING == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 1225;
                        Functions.TerminateEvent (); 
                        }
                    
                    __context__.SourceCodeLine = 1227;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SHADE_SETTINGS[ INDEX ].LPOS >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1230;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 1231;
                            TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( SHADE_SETTINGS[ INDEX ].LPOS ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1233;
                            TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1240;
                        switch ((int)SHADE_SETTINGS[ INDEX ].LPOS)
                        
                            { 
                            case -1 : 
                            case -2 : 
                            
                                { 
                                __context__.SourceCodeLine = 1246;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 1247;
                                break ; 
                                } 
                            
                            goto case -3 ;
                            case -3 : 
                            
                                { 
                                __context__.SourceCodeLine = 1252;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( 65535 ) ; 
                                __context__.SourceCodeLine = 1253;
                                break ; 
                                } 
                            
                            goto case -4 ;
                            case -4 : 
                            
                                { 
                                __context__.SourceCodeLine = 1258;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 1259;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 1214;
                    } 
                
                __context__.SourceCodeLine = 1264;
                STOP_RAMP (  __context__  ) ; 
                __context__.SourceCodeLine = 1266;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 1267;
                FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1268;
                FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1270;
                UPDATE_FB_LOOP (  __context__  ) ; 
                __context__.SourceCodeLine = 1271;
                RECALL_OK  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1272;
                RECALL_OK  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1273;
                G_RECALLING = (ushort) ( 0 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SAVE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 1278;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1280;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 1281;
            SAVESCENE (  __context__  ) ; 
            __context__.SourceCodeLine = 1283;
            BUSY_FB  .Value = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object REVERT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1288;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 1290;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileDelete( G_SCENEFILENAME__DOLLAR__ ) != 0))  ) ) 
            {
            __context__.SourceCodeLine = 1291;
            Functions.Pulse ( 50, REVERT_ERROR ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1293;
            Functions.Pulse ( 50, REVERT_OK ) ; 
            }
        
        __context__.SourceCodeLine = 1295;
        EndFileOperations ( ) ; 
        __context__.SourceCodeLine = 1296;
        LOAD_FILE (  __context__  ) ; 
        __context__.SourceCodeLine = 1297;
        UPDATE_FB_LOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UPDATE_FB_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1302;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_FILELOADED == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1303;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 1304;
        if ( Functions.TestForTrue  ( ( TURNING_OFF_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1305;
            TURNING_OFF_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1306;
        if ( Functions.TestForTrue  ( ( RECALLING_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1307;
            RECALLING_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1308;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SEMAPHORE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1310;
            
            __context__.SourceCodeLine = 1313;
            G_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1314;
            
            __context__.SourceCodeLine = 1317;
            UPDATE_FB_LOOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1320;
            G_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1321;
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PATH__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1330;
        G_SCENEFILENAME__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "shade_" + Functions.LtoA (  (int) ( SCENE_ID  .Value ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 1331;
        G_SCENES_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "SCENES.dat"  ) ; 
        __context__.SourceCodeLine = 1332;
        G_LOADS_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "Loads.dat"  ) ; 
        __context__.SourceCodeLine = 1333;
        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    FILE_INFO FILEINFO;
    FILEINFO  = new FILE_INFO();
    FILEINFO .PopulateDefaults();
    
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1361;
        
        __context__.SourceCodeLine = 1366;
        G_TOTAL_SHADES = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1367;
        G_FILELOADED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1368;
        G_SHADES_MOVING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1371;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 500 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1373;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( CURRENT_POSITIONS[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 1375;
                G_TOTAL_SHADES = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 1376;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1371;
            } 
        
        __context__.SourceCodeLine = 1380;
        Functions.SetArray (  ref G_PREVIOUS_LEVELS , (ushort)0) ; 
        __context__.SourceCodeLine = 1382;
        
        __context__.SourceCodeLine = 1386;
        Functions.ResizeArray (  ref SHADE_SETTINGS , (int)G_TOTAL_SHADES, null ) ; 
        __context__.SourceCodeLine = 1387;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1389;
        G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1390;
        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1391;
        LOAD_FILE (  __context__  ) ; 
        __context__.SourceCodeLine = 1392;
        G_FILELOADED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1395;
        UPDATE_FB_LOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_PREVIOUS_LEVELS  = new ushort[ 501 ];
    SHADE_MOVING  = new ushort[ 501 ];
    G_SCENEFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_LOADS_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_SCENENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_SCENES_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_LASTSAVEDTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    G_LASTSAVEDDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    G_FILEINFO  = new FILE_INFO();
    G_FILEINFO .PopulateDefaults();
    SHADE_SETTINGS  = new SHADE_SETTING[ 2 ];
    for( uint i = 0; i < 2; i++ )
    {
        SHADE_SETTINGS [i] = new SHADE_SETTING( this, true );
        SHADE_SETTINGS [i].PopulateCustomAttributeList( false );
        
    }
    
    RECALL = new Crestron.Logos.SplusObjects.DigitalInput( RECALL__DigitalInput__, this );
    m_DigitalInputList.Add( RECALL__DigitalInput__, RECALL );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    REVERT = new Crestron.Logos.SplusObjects.DigitalInput( REVERT__DigitalInput__, this );
    m_DigitalInputList.Add( REVERT__DigitalInput__, REVERT );
    
    UPDATE_FB = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE_FB__DigitalInput__, this );
    m_DigitalInputList.Add( UPDATE_FB__DigitalInput__, UPDATE_FB );
    
    PRESET_BUSY = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_BUSY__DigitalInput__, this );
    m_DigitalInputList.Add( PRESET_BUSY__DigitalInput__, PRESET_BUSY );
    
    ANY_OPEN_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ANY_OPEN_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ANY_OPEN_FB__DigitalOutput__, ANY_OPEN_FB );
    
    ALL_OPEN_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ALL_OPEN_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ALL_OPEN_FB__DigitalOutput__, ALL_OPEN_FB );
    
    AT_SCENE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( AT_SCENE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( AT_SCENE_FB__DigitalOutput__, AT_SCENE_FB );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    RECALLING_SCENE = new Crestron.Logos.SplusObjects.DigitalOutput( RECALLING_SCENE__DigitalOutput__, this );
    m_DigitalOutputList.Add( RECALLING_SCENE__DigitalOutput__, RECALLING_SCENE );
    
    TURNING_OFF_SCENE = new Crestron.Logos.SplusObjects.DigitalOutput( TURNING_OFF_SCENE__DigitalOutput__, this );
    m_DigitalOutputList.Add( TURNING_OFF_SCENE__DigitalOutput__, TURNING_OFF_SCENE );
    
    RECALL_OK = new Crestron.Logos.SplusObjects.DigitalOutput( RECALL_OK__DigitalOutput__, this );
    m_DigitalOutputList.Add( RECALL_OK__DigitalOutput__, RECALL_OK );
    
    SAVE_OK = new Crestron.Logos.SplusObjects.DigitalOutput( SAVE_OK__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVE_OK__DigitalOutput__, SAVE_OK );
    
    SAVE_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( SAVE_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVE_ERROR__DigitalOutput__, SAVE_ERROR );
    
    REVERT_OK = new Crestron.Logos.SplusObjects.DigitalOutput( REVERT_OK__DigitalOutput__, this );
    m_DigitalOutputList.Add( REVERT_OK__DigitalOutput__, REVERT_OK );
    
    REVERT_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( REVERT_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( REVERT_ERROR__DigitalOutput__, REVERT_ERROR );
    
    ENABLE_BUFFER = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLE_BUFFER__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLE_BUFFER__DigitalOutput__, ENABLE_BUFFER );
    
    FIRE_RAMP = new Crestron.Logos.SplusObjects.DigitalOutput( FIRE_RAMP__DigitalOutput__, this );
    m_DigitalOutputList.Add( FIRE_RAMP__DigitalOutput__, FIRE_RAMP );
    
    PRESET_MOVING = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_MOVING__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESET_MOVING__DigitalOutput__, PRESET_MOVING );
    
    PRESET_OPENING = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_OPENING__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESET_OPENING__DigitalOutput__, PRESET_OPENING );
    
    PRESET_CLOSING = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_CLOSING__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESET_CLOSING__DigitalOutput__, PRESET_CLOSING );
    
    SHADE_IN_SCENE = new InOutArray<DigitalOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        SHADE_IN_SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHADE_IN_SCENE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHADE_IN_SCENE__DigitalOutput__ + i, SHADE_IN_SCENE[i+1] );
    }
    
    RESPONSEID = new Crestron.Logos.SplusObjects.AnalogOutput( RESPONSEID__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RESPONSEID__AnalogSerialOutput__, RESPONSEID );
    
    UPPERWORDFADETIME = new Crestron.Logos.SplusObjects.AnalogOutput( UPPERWORDFADETIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( UPPERWORDFADETIME__AnalogSerialOutput__, UPPERWORDFADETIME );
    
    LOWERWORDFADETIME = new Crestron.Logos.SplusObjects.AnalogOutput( LOWERWORDFADETIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LOWERWORDFADETIME__AnalogSerialOutput__, LOWERWORDFADETIME );
    
    TARGET_POSITIONS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        TARGET_POSITIONS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( TARGET_POSITIONS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( TARGET_POSITIONS__AnalogSerialOutput__ + i, TARGET_POSITIONS[i+1] );
    }
    
    CURRENT_POSITIONS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        CURRENT_POSITIONS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_POSITIONS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CURRENT_POSITIONS__AnalogSerialOutput__ + i, CURRENT_POSITIONS[i+1] );
    }
    
    PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 64, this );
    m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
    
    SCENE_ID = new UIntParameter( SCENE_ID__Parameter__, this );
    m_ParameterList.Add( SCENE_ID__Parameter__, SCENE_ID );
    
    FADE_TIME = new UIntParameter( FADE_TIME__Parameter__, this );
    m_ParameterList.Add( FADE_TIME__Parameter__, FADE_TIME );
    
    OFF_TIME = new UIntParameter( OFF_TIME__Parameter__, this );
    m_ParameterList.Add( OFF_TIME__Parameter__, OFF_TIME );
    
    SHADE_PROPERTY = new InOutArray<StringParameter>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        SHADE_PROPERTY[i+1] = new StringParameter( SHADE_PROPERTY__Parameter__ + i, SHADE_PROPERTY__Parameter__, this );
        m_ParameterList.Add( SHADE_PROPERTY__Parameter__ + i, SHADE_PROPERTY[i+1] );
    }
    
    
    RECALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALL_OnPush_0, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_1, false ) );
    REVERT.OnDigitalPush.Add( new InputChangeHandlerWrapper( REVERT_OnPush_2, false ) );
    UPDATE_FB.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_FB_OnPush_3, false ) );
    PATH__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( PATH__DOLLAR___OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_DYNAMIC_SHADE_PRESET_V1_02 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RECALL__DigitalInput__ = 0;
const uint SAVE__DigitalInput__ = 1;
const uint REVERT__DigitalInput__ = 2;
const uint UPDATE_FB__DigitalInput__ = 3;
const uint PRESET_BUSY__DigitalInput__ = 4;
const uint PATH__DOLLAR____AnalogSerialInput__ = 0;
const uint ANY_OPEN_FB__DigitalOutput__ = 0;
const uint ALL_OPEN_FB__DigitalOutput__ = 1;
const uint AT_SCENE_FB__DigitalOutput__ = 2;
const uint BUSY_FB__DigitalOutput__ = 3;
const uint RECALLING_SCENE__DigitalOutput__ = 4;
const uint TURNING_OFF_SCENE__DigitalOutput__ = 5;
const uint RECALL_OK__DigitalOutput__ = 6;
const uint SAVE_OK__DigitalOutput__ = 7;
const uint SAVE_ERROR__DigitalOutput__ = 8;
const uint REVERT_OK__DigitalOutput__ = 9;
const uint REVERT_ERROR__DigitalOutput__ = 10;
const uint ENABLE_BUFFER__DigitalOutput__ = 11;
const uint FIRE_RAMP__DigitalOutput__ = 12;
const uint PRESET_MOVING__DigitalOutput__ = 13;
const uint PRESET_OPENING__DigitalOutput__ = 14;
const uint PRESET_CLOSING__DigitalOutput__ = 15;
const uint SHADE_IN_SCENE__DigitalOutput__ = 16;
const uint RESPONSEID__AnalogSerialOutput__ = 0;
const uint UPPERWORDFADETIME__AnalogSerialOutput__ = 1;
const uint LOWERWORDFADETIME__AnalogSerialOutput__ = 2;
const uint TARGET_POSITIONS__AnalogSerialOutput__ = 3;
const uint CURRENT_POSITIONS__AnalogSerialOutput__ = 503;
const uint SCENE_ID__Parameter__ = 10;
const uint FADE_TIME__Parameter__ = 11;
const uint OFF_TIME__Parameter__ = 12;
const uint SHADE_PROPERTY__Parameter__ = 13;

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
public class SHADE_SETTING : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public int  LPOS = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  SHADEID = 0;
    
    [SplusStructAttribute(2, false, false)]
    public short  DIMMABLE = 0;
    
    [SplusStructAttribute(3, false, false)]
    public uint  LRAMPID = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  SHADEEXCLUDED = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  PARENTRMID = 0;
    
    
    public SHADE_SETTING( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
