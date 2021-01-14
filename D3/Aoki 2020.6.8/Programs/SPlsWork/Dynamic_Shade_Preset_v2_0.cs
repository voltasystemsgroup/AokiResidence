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

namespace CrestronModule_DYNAMIC_SHADE_PRESET_V2_0
{
    public class CrestronModuleClass_DYNAMIC_SHADE_PRESET_V2_0 : SplusObject
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
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> TARGET_TILTS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CURRENT_TILTS;
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
            
            
            __context__.SourceCodeLine = 165;
            ANY_OPEN = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 166;
            ALL_OPEN = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 167;
            AT_SCENE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 169;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 172;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( SHADE_SETTINGS[ INDEX ].LPOS >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 174;
                    COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                    __context__.SourceCodeLine = 175;
                    
                    __context__.SourceCodeLine = 180;
                    SETTINGVALUE = (ushort) ( SHADE_SETTINGS[ INDEX ].LPOS ) ; 
                    __context__.SourceCodeLine = 184;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( (SETTINGVALUE - COMPAREVALUE) ) > 1024 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 187;
                        AT_SCENE = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 191;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 655 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 194;
                        ANY_OPEN = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 198;
                        ALL_OPEN = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 200;
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 206;
                    
                    __context__.SourceCodeLine = 211;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 213;
                        switch ((int)SHADE_SETTINGS[ INDEX ].LPOS)
                        
                            { 
                            case -3 : 
                            
                                { 
                                __context__.SourceCodeLine = 219;
                                COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 221;
                                
                                __context__.SourceCodeLine = 226;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (65535 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 229;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 233;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 655 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 235;
                                    ANY_OPEN = (ushort) ( 1 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 239;
                                    ALL_OPEN = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 240;
                                break ; 
                                } 
                            
                            goto case -4 ;
                            case -4 : 
                            
                                { 
                                __context__.SourceCodeLine = 245;
                                COMPAREVALUE = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 247;
                                
                                __context__.SourceCodeLine = 251;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (0 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 253;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 255;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 256;
                                    ANY_OPEN = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 257;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREVALUE == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 258;
                                    ALL_OPEN = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 259;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 263;
                    
                    } 
                
                __context__.SourceCodeLine = 169;
                } 
            
            __context__.SourceCodeLine = 269;
            if ( Functions.TestForTrue  ( ( BUSY_FB  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 270;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 272;
            AT_SCENE_FB  .Value = (ushort) ( AT_SCENE ) ; 
            __context__.SourceCodeLine = 273;
            ANY_OPEN_FB  .Value = (ushort) ( ANY_OPEN ) ; 
            __context__.SourceCodeLine = 274;
            ALL_OPEN_FB  .Value = (ushort) ( ALL_OPEN ) ; 
            
            }
            
        private void SENDRAMP (  SplusExecutionContext __context__, ushort IOUTPUTNUMBER , ushort FADETIME , int RAMPVALUE ) 
            { 
            ushort IRESULT = 0;
            
            
            __context__.SourceCodeLine = 282;
            UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 283;
            LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 284;
            TARGET_POSITIONS [ IOUTPUTNUMBER]  .Value = (ushort) ( RAMPVALUE ) ; 
            
            }
            
        private short COMPAREFILEDATEANDTIME (  SplusExecutionContext __context__, FILE_INFO FIFILE1 , FILE_INFO FIFILE2 ) 
            { 
            
            __context__.SourceCodeLine = 289;
            
            __context__.SourceCodeLine = 302;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate > FIFILE2.iDate ))  ) ) 
                {
                __context__.SourceCodeLine = 303;
                return (short)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 304;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate < FIFILE2.iDate ))  ) ) 
                    {
                    __context__.SourceCodeLine = 305;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 308;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime > FIFILE2.iTime ))  ) ) 
                        {
                        __context__.SourceCodeLine = 309;
                        return (short)( 1) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 310;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime < FIFILE2.iTime ))  ) ) 
                            {
                            __context__.SourceCodeLine = 311;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 313;
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
            
            
            __context__.SourceCodeLine = 329;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 332;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IsRamping( CURRENT_POSITIONS[ I ] ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 335;
                    GetRampInfo ( CURRENT_POSITIONS [ I] ,  ref RAMPDATA ) ; 
                    __context__.SourceCodeLine = 339;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RAMPDATA.rampIdentifier == SHADE_SETTINGS[ I ].LRAMPID))  ) ) 
                        { 
                        __context__.SourceCodeLine = 341;
                        return (ushort)( 1) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 329;
                } 
            
            __context__.SourceCodeLine = 345;
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
            
            
            __context__.SourceCodeLine = 363;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 364;
            IFILEHANDLE = (short) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 365;
            ATTEMPTCOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 366;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 368;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 369;
                IFILEHANDLE = (short) ( FileOpen( G_LOADS_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 370;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ATTEMPTCOUNTER > 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 372;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 373;
                    return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 375;
                ATTEMPTCOUNTER = (ushort) ( (ATTEMPTCOUNTER + 1) ) ; 
                __context__.SourceCodeLine = 366;
                } 
            
            __context__.SourceCodeLine = 379;
            BBUFFERDONE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 380;
            BLOADNOTFOUND = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 381;
            LINECOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 382;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 385;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LINECOUNTER == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 387;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 388;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 389;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 390;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 391;
                    SLINE  .UpdateValue ( ""  ) ; 
                    } 
                
                __context__.SourceCodeLine = 394;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (BBUFFERDONE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 396;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "\r\n" , SREADBUF , 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 398;
                        if ( Functions.TestForTrue  ( ( Functions.Length( SLINE ))  ) ) 
                            {
                            __context__.SourceCodeLine = 399;
                            SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 401;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 405;
                        SLINE  .UpdateValue ( SREADBUF  ) ; 
                        __context__.SourceCodeLine = 406;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 409;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 410;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 411;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( SLINE ) == SHADE_SETTINGS[ LOAD_NUMBER ].SHADEID))  ) ) 
                            { 
                            __context__.SourceCodeLine = 413;
                            ISTART = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 414;
                            ILEN = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 415;
                            
                            __context__.SourceCodeLine = 420;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 421;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 424;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 425;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 428;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 429;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 430;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "True" , TEMPSTRING , 1 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 431;
                                SHADE_SETTINGS [ LOAD_NUMBER] . DIMMABLE = (short) ( 1 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 433;
                                SHADE_SETTINGS [ LOAD_NUMBER] . DIMMABLE = (short) ( 1 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 435;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 436;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 439;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 440;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 443;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 444;
                            TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                            __context__.SourceCodeLine = 447;
                            ILEN = (ushort) ( (Functions.Find( "\t" , SLINE , ILEN ) + 1) ) ; 
                            __context__.SourceCodeLine = 448;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\t" , SLINE , ILEN ) > ILEN ))  ) ) 
                                {
                                __context__.SourceCodeLine = 449;
                                TEMPSTRING  .UpdateValue ( Functions.Mid ( SLINE ,  (int) ( ILEN ) ,  (int) ( (Functions.Find( "\t" , SLINE , ILEN ) - ILEN) ) )  ) ; 
                                }
                            
                            __context__.SourceCodeLine = 452;
                            BLOADNOTFOUND = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 453;
                            
                            __context__.SourceCodeLine = 456;
                            FileClose (  (short) ( IFILEHANDLE ) ) ; 
                            __context__.SourceCodeLine = 457;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 458;
                            return (ushort)( 0) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 460;
                    SLINE  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 461;
                    LINECOUNTER = (ushort) ( (LINECOUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 394;
                    } 
                
                __context__.SourceCodeLine = 382;
                } 
            
            __context__.SourceCodeLine = 464;
            if ( Functions.TestForTrue  ( ( BLOADNOTFOUND)  ) ) 
                { 
                __context__.SourceCodeLine = 466;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 467;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 468;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 470;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 471;
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
            
            CrestronString TEMP2;
            TEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString TEMP;
            TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 13, this );
            
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
            int LTILT = 0;
            int LOAD_PRESET_VALUE = 0;
            
            
            __context__.SourceCodeLine = 491;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 492;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 491;
                }
            
            __context__.SourceCodeLine = 493;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 495;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 497;
            FILEOPERATIONSTATUS = (short) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref G_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 499;
            
            __context__.SourceCodeLine = 503;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEOPERATIONSTATUS != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 506;
                
                __context__.SourceCodeLine = 510;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 513;
                    LOADPROPERTY  .UpdateValue ( SHADE_PROPERTY [ INDEX ]  ) ; 
                    __context__.SourceCodeLine = 515;
                    SHADE_SETTINGS [ INDEX] . SHADEID = (ushort) ( Functions.Atoi( LOADPROPERTY ) ) ; 
                    __context__.SourceCodeLine = 518;
                    UPDATEDSCENEFILENAME__DOLLAR__  .UpdateValue ( Functions.Remove ( "," , LOADPROPERTY )  ) ; 
                    __context__.SourceCodeLine = 519;
                    TEMP2  .UpdateValue ( Functions.Remove ( "," , LOADPROPERTY )  ) ; 
                    __context__.SourceCodeLine = 520;
                    LPOS = (int) ( Functions.Atol( TEMP2 ) ) ; 
                    __context__.SourceCodeLine = 521;
                    TEMP2  .UpdateValue ( Functions.Remove ( "," , LOADPROPERTY )  ) ; 
                    __context__.SourceCodeLine = 522;
                    LTILT = (int) ( Functions.Atol( LOADPROPERTY ) ) ; 
                    __context__.SourceCodeLine = 524;
                    GETLOADSINFO (  __context__ , (ushort)( INDEX ), (ushort)( SHADE_SETTINGS[ INDEX ].SHADEID )) ; 
                    __context__.SourceCodeLine = 526;
                    
                    __context__.SourceCodeLine = 532;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LPOS >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 534;
                        
                        __context__.SourceCodeLine = 539;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xd"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 541;
                            SHADE_SETTINGS [ INDEX] . LPOS = (int) ( -1 ) ; 
                            __context__.SourceCodeLine = 542;
                            SHADE_SETTINGS [ INDEX] . LTILT = (int) ( -1 ) ; 
                            __context__.SourceCodeLine = 543;
                            SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 545;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xn"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 547;
                                SHADE_SETTINGS [ INDEX] . LPOS = (int) ( -2 ) ; 
                                __context__.SourceCodeLine = 548;
                                SHADE_SETTINGS [ INDEX] . LTILT = (int) ( -2 ) ; 
                                __context__.SourceCodeLine = 549;
                                SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 552;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "on"))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 554;
                                    SHADE_SETTINGS [ INDEX] . LPOS = (int) ( 65535 ) ; 
                                    __context__.SourceCodeLine = 555;
                                    SHADE_SETTINGS [ INDEX] . LTILT = (int) ( 0 ) ; 
                                    __context__.SourceCodeLine = 556;
                                    SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 559;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "off"))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 561;
                                        SHADE_SETTINGS [ INDEX] . LPOS = (int) ( 0 ) ; 
                                        __context__.SourceCodeLine = 562;
                                        SHADE_SETTINGS [ INDEX] . LTILT = (int) ( 0 ) ; 
                                        __context__.SourceCodeLine = 563;
                                        SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 568;
                                        SHADE_SETTINGS [ INDEX] . LPOS = (int) ( LPOS ) ; 
                                        __context__.SourceCodeLine = 569;
                                        SHADE_SETTINGS [ INDEX] . LTILT = (int) ( LTILT ) ; 
                                        __context__.SourceCodeLine = 570;
                                        SHADE_SETTINGS [ INDEX] . SHADEEXCLUDED = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 571;
                                        
                                        __context__.SourceCodeLine = 573;
                                        ; 
                                        } 
                                    
                                    }
                                
                                }
                            
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 576;
                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED)  ) ) 
                        {
                        __context__.SourceCodeLine = 577;
                        SHADE_IN_SCENE [ INDEX]  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 579;
                        SHADE_IN_SCENE [ INDEX]  .Value = (ushort) ( 1 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 510;
                    } 
                
                __context__.SourceCodeLine = 581;
                G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
                __context__.SourceCodeLine = 582;
                G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
                __context__.SourceCodeLine = 583;
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 590;
                IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) (2 | 16384) ) ) ; 
                __context__.SourceCodeLine = 592;
                I = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 594;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 596;
                    TEMP  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 598;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                    __context__.SourceCodeLine = 599;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( 13 ) ) ; 
                    __context__.SourceCodeLine = 600;
                    
                    __context__.SourceCodeLine = 605;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.CompareStrings( TEMP , "v2.0.00" ) == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 607;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 608;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                        __context__.SourceCodeLine = 609;
                        
                        __context__.SourceCodeLine = 612;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDDATE ,  (ushort) ( 10 ) ) ; 
                        __context__.SourceCodeLine = 613;
                        
                        __context__.SourceCodeLine = 616;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 617;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                        __context__.SourceCodeLine = 618;
                        
                        __context__.SourceCodeLine = 621;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDTIME ,  (ushort) ( 8 ) ) ; 
                        __context__.SourceCodeLine = 622;
                        
                        __context__.SourceCodeLine = 625;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 632;
                        ILOADCOUNT = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 634;
                        READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                        __context__.SourceCodeLine = 635;
                        
                        __context__.SourceCodeLine = 641;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 644;
                            SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                            __context__.SourceCodeLine = 645;
                            BBUFFERDONE = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 647;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOADCOUNT == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 649;
                                SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                                __context__.SourceCodeLine = 650;
                                SLINE  .UpdateValue ( ""  ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 653;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (BBUFFERDONE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOADCOUNT <= G_TOTAL_SHADES ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 656;
                                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "\r\n" , SREADBUF , 1 ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SLINE ) == 0) )) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 658;
                                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                    __context__.SourceCodeLine = 659;
                                    
                                    __context__.SourceCodeLine = 662;
                                    SHADE_SETTINGS [ ILOADCOUNT] . SHADEID = (ushort) ( Functions.Atoi( SLINE ) ) ; 
                                    __context__.SourceCodeLine = 663;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 664;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 665;
                                    SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( Functions.Atol( TEMPSTRING ) ) ; 
                                    __context__.SourceCodeLine = 666;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 667;
                                    SHADE_SETTINGS [ ILOADCOUNT] . LTILT = (int) ( Functions.Atol( SLINE ) ) ; 
                                    __context__.SourceCodeLine = 668;
                                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ ILOADCOUNT ].SHADEEXCLUDED)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 669;
                                        SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 0 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 671;
                                        SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 1 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 672;
                                    
                                    __context__.SourceCodeLine = 676;
                                    ILOADCOUNT = (ushort) ( (ILOADCOUNT + 1) ) ; 
                                    __context__.SourceCodeLine = 677;
                                    SLINE  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 656;
                                    } 
                                
                                __context__.SourceCodeLine = 679;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SLINE ) > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 680;
                                    SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                    }
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 683;
                                    SLINE  .UpdateValue ( SREADBUF  ) ; 
                                    __context__.SourceCodeLine = 684;
                                    BBUFFERDONE = (ushort) ( 1 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 686;
                                READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                                __context__.SourceCodeLine = 687;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 688;
                                    BBUFFERDONE = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 653;
                                } 
                            
                            __context__.SourceCodeLine = 641;
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 694;
                        
                        __context__.SourceCodeLine = 701;
                        ILOADCOUNT = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 704;
                        READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                        __context__.SourceCodeLine = 705;
                        
                        __context__.SourceCodeLine = 711;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 714;
                            SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                            __context__.SourceCodeLine = 715;
                            BBUFFERDONE = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 718;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOADCOUNT == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 720;
                                SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                                __context__.SourceCodeLine = 721;
                                SLINE  .UpdateValue ( ""  ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 724;
                            
                            __context__.SourceCodeLine = 729;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (BBUFFERDONE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOADCOUNT <= G_TOTAL_SHADES ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 732;
                                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "\r\n" , SREADBUF , 1 ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SLINE ) == 0) )) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 734;
                                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                    __context__.SourceCodeLine = 735;
                                    
                                    __context__.SourceCodeLine = 738;
                                    SHADE_SETTINGS [ ILOADCOUNT] . SHADEID = (ushort) ( Functions.Atoi( SLINE ) ) ; 
                                    __context__.SourceCodeLine = 739;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 740;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 742;
                                    SHADE_SETTINGS [ ILOADCOUNT] . LPOS = (int) ( Functions.Atol( SLINE ) ) ; 
                                    __context__.SourceCodeLine = 743;
                                    Print( "stored value: {0:d}", (int)SHADE_SETTINGS[ ILOADCOUNT ].LPOS) ; 
                                    __context__.SourceCodeLine = 744;
                                    SHADE_SETTINGS [ ILOADCOUNT] . LTILT = (int) ( 0 ) ; 
                                    __context__.SourceCodeLine = 745;
                                    if ( Functions.TestForTrue  ( ( SHADE_SETTINGS[ ILOADCOUNT ].SHADEEXCLUDED)  ) ) 
                                        {
                                        __context__.SourceCodeLine = 746;
                                        SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 0 ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 748;
                                        SHADE_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 1 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 749;
                                    
                                    __context__.SourceCodeLine = 753;
                                    ILOADCOUNT = (ushort) ( (ILOADCOUNT + 1) ) ; 
                                    __context__.SourceCodeLine = 754;
                                    SLINE  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 732;
                                    } 
                                
                                __context__.SourceCodeLine = 756;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SLINE ) > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 757;
                                    SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                    }
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 760;
                                    SLINE  .UpdateValue ( SREADBUF  ) ; 
                                    __context__.SourceCodeLine = 761;
                                    BBUFFERDONE = (ushort) ( 1 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 763;
                                READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                                __context__.SourceCodeLine = 764;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 765;
                                    BBUFFERDONE = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 729;
                                } 
                            
                            __context__.SourceCodeLine = 711;
                            } 
                        
                        __context__.SourceCodeLine = 769;
                        FileSeek (  (short) ( IFILEHANDLE ) ,  (uint) ( 0 ) ,  (ushort) ( 0 ) ) ; 
                        __context__.SourceCodeLine = 770;
                        FileWrite (  (short) ( IFILEHANDLE ) , "File Version\t" ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                        __context__.SourceCodeLine = 771;
                        FileWrite (  (short) ( IFILEHANDLE ) , "v2.0.00" ,  (ushort) ( 13 ) ) ; 
                        __context__.SourceCodeLine = 772;
                        FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                        __context__.SourceCodeLine = 773;
                        FileWrite (  (short) ( IFILEHANDLE ) , "Modified Date\t" ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                        __context__.SourceCodeLine = 774;
                        FileWrite (  (short) ( IFILEHANDLE ) , Functions.Date (  (int) ( 1 ) ) ,  (ushort) ( 10 ) ) ; 
                        __context__.SourceCodeLine = 775;
                        FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                        __context__.SourceCodeLine = 776;
                        FileWrite (  (short) ( IFILEHANDLE ) , "Modified Time\t" ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                        __context__.SourceCodeLine = 777;
                        FileWrite (  (short) ( IFILEHANDLE ) , Functions.Time ( ) ,  (ushort) ( 8 ) ) ; 
                        __context__.SourceCodeLine = 778;
                        FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                        __context__.SourceCodeLine = 780;
                        FileWrite (  (short) ( IFILEHANDLE ) , "Load ID\tTarget Level Target Tilt\u000D\u000A" ,  (ushort) ( Functions.Length( "Load ID\tTarget Level Target Tilt\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 781;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)G_TOTAL_SHADES; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 783;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ I ].SHADEEXCLUDED == 0))  ) ) 
                                {
                                __context__.SourceCodeLine = 784;
                                MakeString ( TEMPSTRING , "{0:d}\t{1:d}\t{2:d}\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)SHADE_SETTINGS[ I ].LPOS, (int)SHADE_SETTINGS[ I ].LTILT) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 786;
                                MakeString ( TEMPSTRING , "{0:d}\t{1:d}\t{2:d}\txd\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)SHADE_SETTINGS[ I ].LPOS, (int)SHADE_SETTINGS[ I ].LTILT) ; 
                                }
                            
                            __context__.SourceCodeLine = 787;
                            
                            __context__.SourceCodeLine = 790;
                            FILEOPERATIONSTATUS = (short) ( FileWrite( (short)( IFILEHANDLE ) , TEMPSTRING , (ushort)( Functions.Length( TEMPSTRING ) ) ) ) ; 
                            __context__.SourceCodeLine = 791;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS <= 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 793;
                                
                                __context__.SourceCodeLine = 796;
                                SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 797;
                                SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 798;
                                GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}", (int)SCENE_ID  .Value) ; 
                                __context__.SourceCodeLine = 799;
                                
                                __context__.SourceCodeLine = 802;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 781;
                            } 
                        
                        __context__.SourceCodeLine = 805;
                        FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                        __context__.SourceCodeLine = 806;
                        
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 813;
                    GenerateUserWarning ( "\r\nError Opening File for Scene: {0:d}", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 814;
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 822;
            FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
            __context__.SourceCodeLine = 823;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 824;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 825;
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
            
            
            __context__.SourceCodeLine = 837;
            FLAG = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 840;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 843;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ I ].LPOS != -1) ) || Functions.TestForTrue ( Functions.BoolToInt (SHADE_SETTINGS[ I ].LPOS != -2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_POSITIONS[ I ] .Value >= 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 845;
                    FLAG = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 846;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 840;
                } 
            
            __context__.SourceCodeLine = 850;
            if ( Functions.TestForTrue  ( ( FLAG)  ) ) 
                {
                __context__.SourceCodeLine = 851;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 853;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 854;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 853;
                }
            
            __context__.SourceCodeLine = 855;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 857;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 858;
            FILEEXISTFLAG = (ushort) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 859;
            IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) ((1 | 256) | 16384) ) ) ; 
            __context__.SourceCodeLine = 861;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 863;
                FileWrite (  (short) ( IFILEHANDLE ) , "File Version\t" ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                __context__.SourceCodeLine = 864;
                FileWrite (  (short) ( IFILEHANDLE ) , "v2.0.00" ,  (ushort) ( 13 ) ) ; 
                __context__.SourceCodeLine = 865;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 866;
                FileWrite (  (short) ( IFILEHANDLE ) , "Modified Date\t" ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                __context__.SourceCodeLine = 867;
                FileWrite (  (short) ( IFILEHANDLE ) , Functions.Date (  (int) ( 1 ) ) ,  (ushort) ( 10 ) ) ; 
                __context__.SourceCodeLine = 868;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 869;
                FileWrite (  (short) ( IFILEHANDLE ) , "Modified Time\t" ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                __context__.SourceCodeLine = 870;
                FileWrite (  (short) ( IFILEHANDLE ) , Functions.Time ( ) ,  (ushort) ( 8 ) ) ; 
                __context__.SourceCodeLine = 871;
                FileWrite (  (short) ( IFILEHANDLE ) , "\u000D\u000A" ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 873;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEEXISTFLAG != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 875;
                    G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
                    __context__.SourceCodeLine = 876;
                    G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
                    } 
                
                __context__.SourceCodeLine = 882;
                FileWrite (  (short) ( IFILEHANDLE ) , "Load ID\tTarget Level Target Tilt\u000D\u000A" ,  (ushort) ( Functions.Length( "Load ID\tTarget Level Target Tilt\u000D\u000A" ) ) ) ; 
                __context__.SourceCodeLine = 883;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 886;
                    SHADE_SETTINGS [ I] . LPOS = (int) ( CURRENT_POSITIONS[ I ] .Value ) ; 
                    __context__.SourceCodeLine = 887;
                    SHADE_SETTINGS [ I] . LTILT = (int) ( CURRENT_TILTS[ I ] .Value ) ; 
                    __context__.SourceCodeLine = 889;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ I ].SHADEEXCLUDED == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 890;
                        MakeString ( TEMPSTRING , "{0:d}\t{1:d}\t{2:d}\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)CURRENT_POSITIONS[ I ] .Value, (int)CURRENT_TILTS[ I ] .Value) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 892;
                        MakeString ( TEMPSTRING , "{0:d}\t{1:d}\t{2:d}\txd\u000D\u000A", (int)SHADE_SETTINGS[ I ].SHADEID, (int)SHADE_SETTINGS[ I ].LPOS, (int)CURRENT_TILTS[ I ] .Value) ; 
                        }
                    
                    __context__.SourceCodeLine = 893;
                    
                    __context__.SourceCodeLine = 896;
                    FILEOPERATIONSTATUS = (short) ( FileWrite( (short)( IFILEHANDLE ) , TEMPSTRING , (ushort)( Functions.Length( TEMPSTRING ) ) ) ) ; 
                    __context__.SourceCodeLine = 898;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 900;
                        
                        __context__.SourceCodeLine = 903;
                        SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 904;
                        SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 907;
                        GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}", (int)SCENE_ID  .Value) ; 
                        __context__.SourceCodeLine = 908;
                        
                        __context__.SourceCodeLine = 911;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 912;
                        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 913;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 883;
                    } 
                
                __context__.SourceCodeLine = 916;
                
                __context__.SourceCodeLine = 919;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 921;
                    
                    __context__.SourceCodeLine = 925;
                    SAVE_OK  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 926;
                    SAVE_OK  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 930;
                    
                    __context__.SourceCodeLine = 933;
                    SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 934;
                    SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 937;
                    GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 938;
                    
                    __context__.SourceCodeLine = 941;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 942;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 943;
                    return (ushort)( 1) ; 
                    } 
                
                __context__.SourceCodeLine = 946;
                FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 950;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 953;
                    GenerateUserError ( "\r\nError Opening Scene File for Scene #{0:d} for saving", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 954;
                    
                    __context__.SourceCodeLine = 957;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 958;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 959;
                    return (ushort)( 1) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 962;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 963;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 964;
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
                
                
                __context__.SourceCodeLine = 981;
                if ( Functions.TestForTrue  ( ( G_RECALLING)  ) ) 
                    {
                    __context__.SourceCodeLine = 982;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 983;
                G_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 984;
                G_FAST_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 985;
                G_FAST_RECALLING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 986;
                G_RECALLING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 989;
                RECALLING_SCENE  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 990;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (AT_SCENE_FB  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 991;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 994;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 995;
                if ( Functions.TestForTrue  ( ( Functions.Not( PRESET_BUSY  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 997;
                    UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADE_TIME  .Value ) ) ) ; 
                    __context__.SourceCodeLine = 998;
                    LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADE_TIME  .Value ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1002;
                    UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1003;
                    LOWERWORDFADETIME  .Value = (ushort) ( 50 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1006;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_SHADES; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1009;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_RECALLING == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 1010;
                        Functions.TerminateEvent (); 
                        }
                    
                    __context__.SourceCodeLine = 1012;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SHADE_SETTINGS[ INDEX ].LPOS >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1015;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHADE_SETTINGS[ INDEX ].SHADEEXCLUDED == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1017;
                            TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( SHADE_SETTINGS[ INDEX ].LPOS ) ; 
                            __context__.SourceCodeLine = 1018;
                            TARGET_TILTS [ INDEX]  .Value = (ushort) ( SHADE_SETTINGS[ INDEX ].LTILT ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1022;
                            TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                            __context__.SourceCodeLine = 1023;
                            TARGET_TILTS [ INDEX]  .Value = (ushort) ( CURRENT_TILTS[ INDEX ] .Value ) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1030;
                        switch ((int)SHADE_SETTINGS[ INDEX ].LPOS)
                        
                            { 
                            case -1 : 
                            case -2 : 
                            
                                { 
                                __context__.SourceCodeLine = 1036;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( CURRENT_POSITIONS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 1037;
                                TARGET_TILTS [ INDEX]  .Value = (ushort) ( CURRENT_TILTS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 1038;
                                break ; 
                                } 
                            
                            goto case -3 ;
                            case -3 : 
                            
                                { 
                                __context__.SourceCodeLine = 1043;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( 65535 ) ; 
                                __context__.SourceCodeLine = 1044;
                                break ; 
                                } 
                            
                            goto case -4 ;
                            case -4 : 
                            
                                { 
                                __context__.SourceCodeLine = 1049;
                                TARGET_POSITIONS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 1050;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 1006;
                    } 
                
                __context__.SourceCodeLine = 1055;
                STOP_RAMP (  __context__  ) ; 
                __context__.SourceCodeLine = 1057;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 1058;
                FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1059;
                FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1061;
                UPDATE_FB_LOOP (  __context__  ) ; 
                __context__.SourceCodeLine = 1062;
                RECALL_OK  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1063;
                RECALL_OK  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1064;
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
            
            __context__.SourceCodeLine = 1069;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1071;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 1072;
            SAVESCENE (  __context__  ) ; 
            __context__.SourceCodeLine = 1074;
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
        
        __context__.SourceCodeLine = 1079;
        StartFileOperations ( ) ; 
        __context__.SourceCodeLine = 1081;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileDelete( G_SCENEFILENAME__DOLLAR__ ) != 0))  ) ) 
            {
            __context__.SourceCodeLine = 1082;
            Functions.Pulse ( 50, REVERT_ERROR ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1084;
            Functions.Pulse ( 50, REVERT_OK ) ; 
            }
        
        __context__.SourceCodeLine = 1086;
        EndFileOperations ( ) ; 
        __context__.SourceCodeLine = 1087;
        LOAD_FILE (  __context__  ) ; 
        __context__.SourceCodeLine = 1088;
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
        
        __context__.SourceCodeLine = 1093;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_FILELOADED == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1094;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 1095;
        if ( Functions.TestForTrue  ( ( TURNING_OFF_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1096;
            TURNING_OFF_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1097;
        if ( Functions.TestForTrue  ( ( RECALLING_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1098;
            RECALLING_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1099;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SEMAPHORE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1101;
            
            __context__.SourceCodeLine = 1104;
            G_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1105;
            
            __context__.SourceCodeLine = 1108;
            UPDATE_FB_LOOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1111;
            G_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1112;
            
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
        
        __context__.SourceCodeLine = 1121;
        G_SCENEFILENAME__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "shade_" + Functions.LtoA (  (int) ( SCENE_ID  .Value ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 1122;
        G_SCENES_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "SCENES.dat"  ) ; 
        __context__.SourceCodeLine = 1123;
        G_LOADS_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "Loads.dat"  ) ; 
        __context__.SourceCodeLine = 1124;
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
        
        __context__.SourceCodeLine = 1135;
        
        __context__.SourceCodeLine = 1140;
        G_TOTAL_SHADES = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1141;
        G_FILELOADED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1142;
        G_SHADES_MOVING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1145;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 500 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1147;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( CURRENT_POSITIONS[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 1149;
                G_TOTAL_SHADES = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 1150;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1145;
            } 
        
        __context__.SourceCodeLine = 1154;
        Functions.SetArray (  ref G_PREVIOUS_LEVELS , (ushort)0) ; 
        __context__.SourceCodeLine = 1156;
        
        __context__.SourceCodeLine = 1160;
        Functions.ResizeArray (  ref SHADE_SETTINGS , (int)G_TOTAL_SHADES, null ) ; 
        __context__.SourceCodeLine = 1161;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1163;
        G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1164;
        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1165;
        LOAD_FILE (  __context__  ) ; 
        __context__.SourceCodeLine = 1166;
        G_FILELOADED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1169;
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
    
    TARGET_TILTS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        TARGET_TILTS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( TARGET_TILTS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( TARGET_TILTS__AnalogSerialOutput__ + i, TARGET_TILTS[i+1] );
    }
    
    CURRENT_TILTS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        CURRENT_TILTS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_TILTS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CURRENT_TILTS__AnalogSerialOutput__ + i, CURRENT_TILTS[i+1] );
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

public CrestronModuleClass_DYNAMIC_SHADE_PRESET_V2_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




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
const uint TARGET_TILTS__AnalogSerialOutput__ = 503;
const uint CURRENT_TILTS__AnalogSerialOutput__ = 1003;
const uint CURRENT_POSITIONS__AnalogSerialOutput__ = 1503;
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
    public int  LTILT = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  SHADEID = 0;
    
    [SplusStructAttribute(3, false, false)]
    public short  DIMMABLE = 0;
    
    [SplusStructAttribute(4, false, false)]
    public uint  LRAMPID = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  SHADEEXCLUDED = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  PARENTRMID = 0;
    
    
    public SHADE_SETTING( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
