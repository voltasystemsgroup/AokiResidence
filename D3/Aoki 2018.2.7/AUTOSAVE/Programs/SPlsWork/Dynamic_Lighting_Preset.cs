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

namespace CrestronModule_DYNAMIC_LIGHTING_PRESET
{
    public class CrestronModuleClass_DYNAMIC_LIGHTING_PRESET : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RECALL;
        Crestron.Logos.SplusObjects.DigitalInput FAST_RECALL;
        Crestron.Logos.SplusObjects.DigitalInput FADE_OFF;
        Crestron.Logos.SplusObjects.DigitalInput FAST_OFF;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.DigitalInput REVERT;
        Crestron.Logos.SplusObjects.DigitalInput UPDATE_FB;
        Crestron.Logos.SplusObjects.BufferInput COMMAND__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ANY_ON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ALL_ON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput AT_SCENE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput RAISE_LOADS;
        Crestron.Logos.SplusObjects.DigitalOutput LOWER_LOADS;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput RECALLING_SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput TURNING_OFF_SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput RECALL_OK;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_OK;
        Crestron.Logos.SplusObjects.DigitalOutput SAVE_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput REVERT_OK;
        Crestron.Logos.SplusObjects.DigitalOutput REVERT_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLE_BUFFER;
        Crestron.Logos.SplusObjects.StringOutput RESPONSE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput FIRE_RAMP;
        Crestron.Logos.SplusObjects.DigitalInput PRESET_BUSY;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LOAD_IN_SCENE;
        Crestron.Logos.SplusObjects.AnalogOutput RESPONSEID;
        Crestron.Logos.SplusObjects.AnalogOutput UPPERWORDFADETIME;
        Crestron.Logos.SplusObjects.AnalogOutput LOWERWORDFADETIME;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> TARGET_LEVELS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CURRENT_LEVELS;
        LOAD_SETTING [] LOAD_SETTINGS;
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        UIntParameter SCENE_ID;
        UIntParameter FADE_TIME;
        UIntParameter OFF_TIME;
        InOutArray<StringParameter> LOAD_PROPERTY;
        ushort G_TOTAL_LOADS = 0;
        CrestronString G_OLDSCENEFILENAME__DOLLAR__;
        CrestronString G_SCENEFILENAME__DOLLAR__;
        CrestronString G_LOADS_FILE__DOLLAR__;
        CrestronString G_SCENENAME;
        ushort G_ROOMID = 0;
        ushort G_SEMAPHORE = 0;
        ushort G_FAST_RECALLING = 0;
        ushort G_RECALLING = 0;
        ushort G_FAST_OFFING = 0;
        ushort G_OFFING = 0;
        ushort G_COMMAND_HANDLER = 0;
        ushort G_FILE_SEMAPHORE = 0;
        CrestronString G_SCENES_FILE__DOLLAR__;
        uint G_FADE_TIME = 0;
        uint G_OFF_TIME = 0;
        CrestronString G_LASTSAVEDTIME;
        CrestronString G_LASTSAVEDDATE;
        CrestronString STOREDCOMMANDSTRING;
        FILE_INFO G_FILEINFO;
        ushort G_FILELOADED = 0;
        private void STOP_RAMP (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 257;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 259;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ I ].LOADEXCLUDED == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 260;
                    StopRamp ( CURRENT_LEVELS [ I] ) ; 
                    }
                
                __context__.SourceCodeLine = 257;
                } 
            
            
            }
            
        private void UPDATE_FB_LOOP (  SplusExecutionContext __context__ ) 
            { 
            RAMP_INFO RI;
            RI  = new RAMP_INFO();
            RI .PopulateDefaults();
            
            ushort COMPAREVALUE = 0;
            
            ushort SETTINGVALUE = 0;
            
            ushort INDEX = 0;
            
            ushort ANY_ON = 0;
            ushort ALL_ON = 0;
            ushort AT_SCENE = 0;
            
            
            __context__.SourceCodeLine = 276;
            ANY_ON = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 277;
            ALL_ON = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 278;
            AT_SCENE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 280;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 283;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 285;
                    COMPAREVALUE = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                    __context__.SourceCodeLine = 286;
                    
                    __context__.SourceCodeLine = 291;
                    SETTINGVALUE = (ushort) ( LOAD_SETTINGS[ INDEX ].LLEVEL ) ; 
                    __context__.SourceCodeLine = 295;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.High( (ushort) SETTINGVALUE ) != Functions.High( (ushort) COMPAREVALUE )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 298;
                        AT_SCENE = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 302;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 0 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 304;
                        ANY_ON = (ushort) ( 1 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 306;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREVALUE == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 308;
                        ALL_ON = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 310;
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 316;
                    
                    __context__.SourceCodeLine = 321;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 323;
                        switch ((int)LOAD_SETTINGS[ INDEX ].LLEVEL)
                        
                            { 
                            case -3 : 
                            
                                { 
                                __context__.SourceCodeLine = 329;
                                COMPAREVALUE = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 331;
                                
                                __context__.SourceCodeLine = 336;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (65535 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 339;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 343;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 345;
                                    ANY_ON = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 347;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREVALUE == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 349;
                                    ALL_ON = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 350;
                                break ; 
                                } 
                            
                            goto case -4 ;
                            case -4 : 
                            
                                { 
                                __context__.SourceCodeLine = 355;
                                COMPAREVALUE = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                                __context__.SourceCodeLine = 357;
                                
                                __context__.SourceCodeLine = 361;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (0 != COMPAREVALUE))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 363;
                                    AT_SCENE = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 365;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPAREVALUE > 0 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 366;
                                    ANY_ON = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 367;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREVALUE == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 368;
                                    ALL_ON = (ushort) ( 0 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 369;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 373;
                    
                    } 
                
                __context__.SourceCodeLine = 280;
                } 
            
            __context__.SourceCodeLine = 380;
            AT_SCENE_FB  .Value = (ushort) ( AT_SCENE ) ; 
            __context__.SourceCodeLine = 381;
            ANY_ON_FB  .Value = (ushort) ( ANY_ON ) ; 
            __context__.SourceCodeLine = 382;
            ALL_ON_FB  .Value = (ushort) ( ALL_ON ) ; 
            
            }
            
        private void SENDRAMP (  SplusExecutionContext __context__, ushort IOUTPUTNUMBER , ushort FADETIME , int RAMPVALUE ) 
            { 
            ushort IRESULT = 0;
            
            
            __context__.SourceCodeLine = 392;
            UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 393;
            LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADETIME ) ) ) ; 
            __context__.SourceCodeLine = 398;
            TARGET_LEVELS [ IOUTPUTNUMBER]  .Value = (ushort) ( RAMPVALUE ) ; 
            
            }
            
        private short COMPAREFILEDATEANDTIME (  SplusExecutionContext __context__, FILE_INFO FIFILE1 , FILE_INFO FIFILE2 ) 
            { 
            
            __context__.SourceCodeLine = 409;
            
            __context__.SourceCodeLine = 422;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate > FIFILE2.iDate ))  ) ) 
                {
                __context__.SourceCodeLine = 423;
                return (short)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 424;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate < FIFILE2.iDate ))  ) ) 
                    {
                    __context__.SourceCodeLine = 425;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 428;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime > FIFILE2.iTime ))  ) ) 
                        {
                        __context__.SourceCodeLine = 429;
                        return (short)( 1) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 430;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime < FIFILE2.iTime ))  ) ) 
                            {
                            __context__.SourceCodeLine = 431;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 433;
                            return (short)( 0) ; 
                            }
                        
                        }
                    
                    } 
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void RECALLPRESET (  SplusExecutionContext __context__,  ushort FASTRECALL ) 
            { 
            ushort INDEX = 0;
            
            ushort FADEVALUE = 0;
            
            
            __context__.SourceCodeLine = 447;
            if ( Functions.TestForTrue  ( ( FASTRECALL)  ) ) 
                { 
                __context__.SourceCodeLine = 449;
                G_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 450;
                G_RECALLING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 451;
                G_FAST_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 452;
                G_FAST_RECALLING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 453;
                FADEVALUE = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 457;
                G_FAST_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 458;
                G_FAST_RECALLING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 459;
                G_OFFING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 460;
                G_RECALLING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 461;
                FADEVALUE = (ushort) ( G_FADE_TIME ) ; 
                } 
            
            __context__.SourceCodeLine = 463;
            STOP_RAMP (  __context__  ) ; 
            __context__.SourceCodeLine = 464;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 466;
            UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADEVALUE ) ) ) ; 
            __context__.SourceCodeLine = 467;
            LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADEVALUE ) ) ) ; 
            __context__.SourceCodeLine = 468;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 470;
            
            __context__.SourceCodeLine = 476;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 486;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_FAST_RECALLING == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_RECALLING == 0) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 487;
                    return ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 488;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( FASTRECALL ) && Functions.TestForTrue ( Functions.BoolToInt (G_FAST_RECALLING == 0) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 489;
                        return ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 490;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (FASTRECALL == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_RECALLING == 0) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 491;
                            return ; 
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 493;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0) )) ) ) && Functions.TestForTrue ( LOAD_SETTINGS[ INDEX ].DIMMABLE )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 494;
                    SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( FADEVALUE ), (int)( LOAD_SETTINGS[ INDEX ].LLEVEL )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 495;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].DIMMABLE == 0) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 496;
                        SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( 0 ), (int)( 65535 )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 497;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].DIMMABLE == 0) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 498;
                            SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( 0 ), (int)( 0 )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 499;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 502;
                                switch ((int)LOAD_SETTINGS[ INDEX ].LLEVEL)
                                
                                    { 
                                    case -3 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 516;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 518;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].DIMMABLE == 0))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 519;
                                                SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( 0 ), (int)( 65535 )) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 521;
                                                SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( FADEVALUE ), (int)( LOAD_SETTINGS[ INDEX ].LLEVEL )) ; 
                                                }
                                            
                                            } 
                                        
                                        __context__.SourceCodeLine = 523;
                                        break ; 
                                        } 
                                    
                                    goto case -4 ;
                                    case -4 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 528;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 530;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].DIMMABLE == 0))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 531;
                                                SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( 0 ), (int)( 0 )) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 533;
                                                SENDRAMP (  __context__ , (ushort)( INDEX ), (ushort)( FADEVALUE ), (int)( LOAD_SETTINGS[ INDEX ].LLEVEL )) ; 
                                                }
                                            
                                            } 
                                        
                                        __context__.SourceCodeLine = 535;
                                        break ; 
                                        } 
                                    
                                    break;
                                    } 
                                    
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 539;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 541;
                                    TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 476;
                } 
            
            __context__.SourceCodeLine = 546;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 547;
            FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 548;
            FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 549;
            UPDATE_FB_LOOP (  __context__  ) ; 
            __context__.SourceCodeLine = 551;
            G_RECALLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 552;
            G_FAST_RECALLING = (ushort) ( 0 ) ; 
            
            }
            
        private ushort RAMPINPROGRESS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            RAMP_INFO RAMPDATA;
            RAMPDATA  = new RAMP_INFO();
            RAMPDATA .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 567;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 570;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IsRamping( CURRENT_LEVELS[ I ] ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 573;
                    GetRampInfo ( CURRENT_LEVELS [ I] ,  ref RAMPDATA ) ; 
                    __context__.SourceCodeLine = 577;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RAMPDATA.rampIdentifier == LOAD_SETTINGS[ I ].LRAMPID))  ) ) 
                        { 
                        __context__.SourceCodeLine = 579;
                        return (ushort)( 1) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 567;
                } 
            
            __context__.SourceCodeLine = 583;
            return (ushort)( 0) ; 
            
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
            
            int LLEVEL = 0;
            int LOAD_PRESET_VALUE = 0;
            
            
            __context__.SourceCodeLine = 604;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 605;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 604;
                }
            
            __context__.SourceCodeLine = 606;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 608;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (StartFileOperations() != 0))  ) ) 
                {
                __context__.SourceCodeLine = 608;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 608;
                }
            
            __context__.SourceCodeLine = 610;
            FILEOPERATIONSTATUS = (short) ( FindFirst( G_OLDSCENEFILENAME__DOLLAR__ , ref G_FILEINFO ) ) ; 
            __context__.SourceCodeLine = 611;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 613;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEOPERATIONSTATUS == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 616;
                IFILEHANDLE = (short) ( FileOpen( G_OLDSCENEFILENAME__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 618;
                I = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 620;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 622;
                    TEMP  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 624;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "File Version\t" ) ) ) ; 
                    __context__.SourceCodeLine = 625;
                    FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( 7 ) ) ; 
                    __context__.SourceCodeLine = 627;
                    
                    __context__.SourceCodeLine = 632;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.CompareStrings( TEMP , "v1.0.00" ) == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 634;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMP ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 635;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Date\t" ) ) ) ; 
                        __context__.SourceCodeLine = 636;
                        
                        __context__.SourceCodeLine = 639;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDDATE ,  (ushort) ( 10 ) ) ; 
                        __context__.SourceCodeLine = 640;
                        
                        __context__.SourceCodeLine = 643;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        __context__.SourceCodeLine = 644;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "Modified Time\t" ) ) ) ; 
                        __context__.SourceCodeLine = 645;
                        
                        __context__.SourceCodeLine = 648;
                        FileRead (  (short) ( IFILEHANDLE ) , G_LASTSAVEDTIME ,  (ushort) ( 8 ) ) ; 
                        __context__.SourceCodeLine = 649;
                        
                        __context__.SourceCodeLine = 652;
                        FileRead (  (short) ( IFILEHANDLE ) , TEMPSTRING ,  (ushort) ( Functions.Length( "\u000D\u000A" ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 659;
                    ILOADCOUNT = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 662;
                    READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                    __context__.SourceCodeLine = 663;
                    
                    __context__.SourceCodeLine = 669;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 672;
                        SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                        __context__.SourceCodeLine = 673;
                        BBUFFERDONE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 676;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOADCOUNT == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 679;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                            __context__.SourceCodeLine = 680;
                            G_FADE_TIME = (uint) ( Functions.Atol( SLINE ) ) ; 
                            __context__.SourceCodeLine = 683;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                            __context__.SourceCodeLine = 684;
                            G_OFF_TIME = (uint) ( Functions.Atol( SLINE ) ) ; 
                            __context__.SourceCodeLine = 687;
                            SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF )  ) ; 
                            __context__.SourceCodeLine = 688;
                            SLINE  .UpdateValue ( ""  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 691;
                        
                        __context__.SourceCodeLine = 696;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (BBUFFERDONE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( ILOADCOUNT <= G_TOTAL_LOADS ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 699;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "\r\n" , SREADBUF , 1 ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SLINE ) == 0) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 701;
                                SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                __context__.SourceCodeLine = 703;
                                
                                __context__.SourceCodeLine = 707;
                                LOAD_SETTINGS [ ILOADCOUNT] . LOADID = (ushort) ( Functions.Atoi( SLINE ) ) ; 
                                __context__.SourceCodeLine = 711;
                                
                                __context__.SourceCodeLine = 715;
                                TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                __context__.SourceCodeLine = 719;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\t" , SLINE , 1 ) > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 721;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 722;
                                    if ( Functions.TestForTrue  ( ( LOAD_SETTINGS[ ILOADCOUNT ].DIMMABLE)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 724;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atol( TEMPSTRING ) > 0 ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 725;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( Functions.Atol( TEMPSTRING ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 727;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 728;
                                        LOAD_SETTINGS [ ILOADCOUNT] . LOADEXCLUDED = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 732;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPSTRING == "on\t"))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 733;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 65535 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 735;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 736;
                                        LOAD_SETTINGS [ ILOADCOUNT] . LOADEXCLUDED = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    __context__.SourceCodeLine = 738;
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 744;
                                    TEMPSTRING  .UpdateValue ( Functions.Remove ( "\r\n" , SLINE , 1)  ) ; 
                                    __context__.SourceCodeLine = 754;
                                    if ( Functions.TestForTrue  ( ( LOAD_SETTINGS[ ILOADCOUNT ].DIMMABLE)  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 756;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atol( TEMPSTRING ) > 0 ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 757;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( Functions.Atol( TEMPSTRING ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 759;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 760;
                                        LOAD_SETTINGS [ ILOADCOUNT] . LOADEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 764;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "on" , TEMPSTRING , 1 ) > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 766;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 65535 ) ; 
                                            __context__.SourceCodeLine = 767;
                                            
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 772;
                                            LOAD_SETTINGS [ ILOADCOUNT] . LLEVEL = (int) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 773;
                                        LOAD_SETTINGS [ ILOADCOUNT] . LOADEXCLUDED = (ushort) ( 0 ) ; 
                                        } 
                                    
                                    __context__.SourceCodeLine = 775;
                                    
                                    } 
                                
                                __context__.SourceCodeLine = 780;
                                if ( Functions.TestForTrue  ( ( LOAD_SETTINGS[ ILOADCOUNT ].LOADEXCLUDED)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 781;
                                    LOAD_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 783;
                                    LOAD_IN_SCENE [ ILOADCOUNT]  .Value = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 785;
                                
                                __context__.SourceCodeLine = 790;
                                ILOADCOUNT = (ushort) ( (ILOADCOUNT + 1) ) ; 
                                __context__.SourceCodeLine = 791;
                                SLINE  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 699;
                                } 
                            
                            __context__.SourceCodeLine = 793;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SLINE ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 795;
                                SLINE  .UpdateValue ( SLINE + Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                                __context__.SourceCodeLine = 796;
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 802;
                                SLINE  .UpdateValue ( SREADBUF  ) ; 
                                __context__.SourceCodeLine = 803;
                                BBUFFERDONE = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 804;
                                
                                } 
                            
                            __context__.SourceCodeLine = 810;
                            READSIZE = (ushort) ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ) ) ; 
                            __context__.SourceCodeLine = 811;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( READSIZE > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 813;
                                
                                __context__.SourceCodeLine = 816;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SLINE ) > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 818;
                                    SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                                    __context__.SourceCodeLine = 819;
                                    SLINE  .UpdateValue ( ""  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 822;
                                BBUFFERDONE = (ushort) ( 0 ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 696;
                            } 
                        
                        __context__.SourceCodeLine = 669;
                        } 
                    
                    __context__.SourceCodeLine = 826;
                    FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                    __context__.SourceCodeLine = 827;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 828;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt (StartFileOperations() != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 828;
                        Functions.Delay (  (int) ( 100 ) ) ; 
                        __context__.SourceCodeLine = 828;
                        }
                    
                    __context__.SourceCodeLine = 829;
                    FILEOPERATIONSTATUS = (short) ( FileDelete( G_OLDSCENEFILENAME__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 832;
                    IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) ((1 | 256) | 32768) ) ) ; 
                    __context__.SourceCodeLine = 833;
                    WriteString (  (short) ( IFILEHANDLE ) , "v1.0.00" ) ; 
                    __context__.SourceCodeLine = 834;
                    WriteLongInteger (  (short) ( IFILEHANDLE ) ,  (uint) ( G_FADE_TIME ) ) ; 
                    __context__.SourceCodeLine = 835;
                    WriteLongInteger (  (short) ( IFILEHANDLE ) ,  (uint) ( G_OFF_TIME ) ) ; 
                    __context__.SourceCodeLine = 836;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        {
                        __context__.SourceCodeLine = 837;
                        WriteStructure (  (short) ( IFILEHANDLE ) , LOAD_SETTINGS [ INDEX] ) ; 
                        __context__.SourceCodeLine = 836;
                        }
                    
                    __context__.SourceCodeLine = 838;
                    FileClose (  (short) ( IFILEHANDLE ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 843;
                    GenerateUserWarning ( "\r\nError Opening File for Scene: {0:d}, {1:d}", (int)SCENE_ID  .Value, (int)IFILEHANDLE) ; 
                    __context__.SourceCodeLine = 844;
                    
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 855;
                
                __context__.SourceCodeLine = 858;
                FILEOPERATIONSTATUS = (short) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref G_FILEINFO ) ) ; 
                __context__.SourceCodeLine = 859;
                FindClose ( ) ; 
                __context__.SourceCodeLine = 861;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEOPERATIONSTATUS == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 863;
                    IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) (0 | 32768) ) ) ; 
                    __context__.SourceCodeLine = 864;
                    ReadString (  (short) ( IFILEHANDLE ) ,  ref TEMPSTRING ) ; 
                    __context__.SourceCodeLine = 865;
                    ReadLongInteger (  (short) ( IFILEHANDLE ) ,  ref G_FADE_TIME) ; 
                    __context__.SourceCodeLine = 866;
                    ReadLongInteger (  (short) ( IFILEHANDLE ) ,  ref G_OFF_TIME) ; 
                    __context__.SourceCodeLine = 867;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)G_TOTAL_LOADS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( INDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__2) && (INDEX  <= __FN_FOREND_VAL__2) ) : ( (INDEX  <= __FN_FORSTART_VAL__2) && (INDEX  >= __FN_FOREND_VAL__2) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                        {
                        __context__.SourceCodeLine = 868;
                        ReadStructure (  (short) ( IFILEHANDLE ) , LOAD_SETTINGS [ INDEX] ) ; 
                        __context__.SourceCodeLine = 867;
                        }
                    
                    __context__.SourceCodeLine = 869;
                    FileClose (  (short) ( IFILEHANDLE ) ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 873;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 874;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 875;
            return (ushort)( 0) ; 
            
            }
            
        private void SENDRESPONSE (  SplusExecutionContext __context__, ushort INDEX , ushort TYPE , CrestronString RESPONSE ) 
            { 
            
            __context__.SourceCodeLine = 882;
            RESPONSEID  .Value = (ushort) ( INDEX ) ; 
            __context__.SourceCodeLine = 884;
            RESPONSE__DOLLAR__  .UpdateValue ( "/" + Functions.Chr (  (int) ( (Byte( STOREDCOMMANDSTRING , (int)( 5 ) ) | 128) ) ) + Functions.Chr (  (int) ( Byte( STOREDCOMMANDSTRING , (int)( (5 + 1) ) ) ) ) + Functions.Chr (  (int) ( TYPE ) ) + RESPONSE + "\\"  ) ; 
            __context__.SourceCodeLine = 885;
            RESPONSEID  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void SENDSCENELOADRESPONSE (  SplusExecutionContext __context__, ushort INDEX , ushort TYPE , CrestronString RESPONSE ) 
            { 
            
            __context__.SourceCodeLine = 892;
            RESPONSEID  .Value = (ushort) ( INDEX ) ; 
            __context__.SourceCodeLine = 894;
            RESPONSE__DOLLAR__  .UpdateValue ( "/" + Functions.Chr (  (int) ( Byte( STOREDCOMMANDSTRING , (int)( 5 ) ) ) ) + Functions.Chr (  (int) ( Byte( STOREDCOMMANDSTRING , (int)( (5 + 1) ) ) ) ) + Functions.Chr (  (int) ( TYPE ) ) + RESPONSE + "\\"  ) ; 
            __context__.SourceCodeLine = 895;
            RESPONSEID  .Value = (ushort) ( 0 ) ; 
            
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
            ushort INDEX = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString TYPE;
            TYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 907;
            FLAG = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 910;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 913;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ I ].LLEVEL != -1) ) || Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ I ].LLEVEL != -2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_LEVELS[ I ] .Value > 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 915;
                    FLAG = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 916;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 910;
                } 
            
            __context__.SourceCodeLine = 920;
            if ( Functions.TestForTrue  ( ( FLAG)  ) ) 
                {
                __context__.SourceCodeLine = 921;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 923;
            while ( Functions.TestForTrue  ( ( G_FILE_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 924;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 923;
                }
            
            __context__.SourceCodeLine = 925;
            G_FILE_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 927;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (StartFileOperations() != 0))  ) ) 
                {
                __context__.SourceCodeLine = 927;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 927;
                }
            
            __context__.SourceCodeLine = 928;
            FILEEXISTFLAG = (ushort) ( FindFirst( G_SCENEFILENAME__DOLLAR__ , ref FILEINFO ) ) ; 
            __context__.SourceCodeLine = 929;
            IFILEHANDLE = (short) ( FileOpen( G_SCENEFILENAME__DOLLAR__ ,(ushort) ((1 | 256) | 32768) ) ) ; 
            __context__.SourceCodeLine = 931;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 933;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEEXISTFLAG != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 935;
                    G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
                    __context__.SourceCodeLine = 936;
                    G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
                    } 
                
                __context__.SourceCodeLine = 939;
                WriteString (  (short) ( IFILEHANDLE ) , "v1.0.00" ) ; 
                __context__.SourceCodeLine = 940;
                WriteLongInteger (  (short) ( IFILEHANDLE ) ,  (uint) ( G_FADE_TIME ) ) ; 
                __context__.SourceCodeLine = 941;
                WriteLongInteger (  (short) ( IFILEHANDLE ) ,  (uint) ( G_OFF_TIME ) ) ; 
                __context__.SourceCodeLine = 942;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)G_TOTAL_LOADS; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( INDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__2) && (INDEX  <= __FN_FOREND_VAL__2) ) : ( (INDEX  <= __FN_FORSTART_VAL__2) && (INDEX  >= __FN_FOREND_VAL__2) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 944;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL != -1) ) || Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL != -2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_LEVELS[ I ] .Value > 0 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 946;
                        LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                        __context__.SourceCodeLine = 947;
                        
                        } 
                    
                    __context__.SourceCodeLine = 951;
                    WriteStructure (  (short) ( IFILEHANDLE ) , LOAD_SETTINGS [ INDEX] ) ; 
                    __context__.SourceCodeLine = 942;
                    } 
                
                __context__.SourceCodeLine = 953;
                FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                __context__.SourceCodeLine = 956;
                
                __context__.SourceCodeLine = 959;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEOPERATIONSTATUS >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 961;
                    
                    __context__.SourceCodeLine = 965;
                    SAVE_OK  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 966;
                    SAVE_OK  .Value = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 970;
                    
                    __context__.SourceCodeLine = 973;
                    SAVE_ERROR  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 974;
                    SAVE_ERROR  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 977;
                    GenerateUserError ( "\r\nError Saving Scene File for Scene #{0:d}, {1:d}", (int)SCENE_ID  .Value, (int)FILEOPERATIONSTATUS) ; 
                    __context__.SourceCodeLine = 978;
                    
                    __context__.SourceCodeLine = 981;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 982;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 983;
                    return (ushort)( 1) ; 
                    } 
                
                __context__.SourceCodeLine = 986;
                FILEOPERATIONSTATUS = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 990;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 993;
                    GenerateUserError ( "\r\nError Opening Scene File for Scene #{0:d} for saving", (int)SCENE_ID  .Value) ; 
                    __context__.SourceCodeLine = 994;
                    
                    __context__.SourceCodeLine = 997;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 998;
                    G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 999;
                    return (ushort)( 1) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 1002;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1003;
            G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1004;
            UPDATE_FB_LOOP (  __context__  ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort SETSCENENAME (  SplusExecutionContext __context__, ushort SCENEID , CrestronString NEWSCENENAME ) 
            { 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort GETSCENEINFO (  SplusExecutionContext __context__, ushort SCENEID ) 
            { 
            short IFILEHANDLE = 0;
            
            ushort ATTEMPTCOUNTER = 0;
            
            ushort LINECOUNTER = 0;
            
            ushort BBUFFERDONE = 0;
            
            ushort BSCENENOTFOUND = 0;
            
            CrestronString SREADBUF;
            SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 612, this );
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            
            __context__.SourceCodeLine = 1022;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (StartFileOperations() != 0))  ) ) 
                {
                __context__.SourceCodeLine = 1022;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 1022;
                }
            
            __context__.SourceCodeLine = 1023;
            IFILEHANDLE = (short) ( FileOpen( G_SCENES_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1024;
            ATTEMPTCOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1025;
            BSCENENOTFOUND = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1026;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1028;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 1029;
                IFILEHANDLE = (short) ( FileOpen( G_SCENES_FILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                __context__.SourceCodeLine = 1030;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ATTEMPTCOUNTER > 5 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IFILEHANDLE < 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1032;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 1033;
                    return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 1035;
                ATTEMPTCOUNTER = (ushort) ( (ATTEMPTCOUNTER + 1) ) ; 
                __context__.SourceCodeLine = 1026;
                } 
            
            __context__.SourceCodeLine = 1038;
            BBUFFERDONE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1039;
            LINECOUNTER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1040;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1042;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LINECOUNTER == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1044;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 1045;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 1046;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 1047;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    } 
                
                __context__.SourceCodeLine = 1050;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (BBUFFERDONE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1052;
                    SLINE  .UpdateValue ( Functions.Remove ( "\r\n" , SREADBUF , 1)  ) ; 
                    __context__.SourceCodeLine = 1053;
                    
                    __context__.SourceCodeLine = 1056;
                    LINECOUNTER = (ushort) ( (LINECOUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 1057;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 1058;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1059;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( SLINE , (int)( Functions.Find( "\t" , SLINE ) ) ) ) == SCENE_ID  .Value))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1062;
                            TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                            __context__.SourceCodeLine = 1065;
                            G_ROOMID = (ushort) ( Functions.Atoi( Functions.Left( SLINE , (int)( Functions.Find( "\t" , SLINE ) ) ) ) ) ; 
                            __context__.SourceCodeLine = 1067;
                            TEMPSTRING  .UpdateValue ( Functions.Remove ( "\t" , SLINE , 1)  ) ; 
                            __context__.SourceCodeLine = 1069;
                            G_SCENENAME  .UpdateValue ( Functions.Left ( SLINE ,  (int) ( (Functions.Length( SLINE ) - 1) ) )  ) ; 
                            __context__.SourceCodeLine = 1070;
                            BSCENENOTFOUND = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 1071;
                            
                            __context__.SourceCodeLine = 1074;
                            FileClose (  (short) ( IFILEHANDLE ) ) ; 
                            __context__.SourceCodeLine = 1075;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 1076;
                            return (ushort)( 0) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 1050;
                    } 
                
                __context__.SourceCodeLine = 1040;
                } 
            
            __context__.SourceCodeLine = 1080;
            if ( Functions.TestForTrue  ( ( BSCENENOTFOUND)  ) ) 
                { 
                __context__.SourceCodeLine = 1082;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 1083;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 1084;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void LOAD_PARAMETER (  SplusExecutionContext __context__ ) 
            { 
            ushort INDEX = 0;
            
            int LLEVEL = 0;
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString LOADPROPERTY;
            LOADPROPERTY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 1097;
            
            __context__.SourceCodeLine = 1101;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1104;
                LOADPROPERTY  .UpdateValue ( LOAD_PROPERTY [ INDEX ]  ) ; 
                __context__.SourceCodeLine = 1106;
                LOAD_SETTINGS [ INDEX] . LOADID = (ushort) ( Functions.Atoi( LOADPROPERTY ) ) ; 
                __context__.SourceCodeLine = 1109;
                SLINE  .UpdateValue ( Functions.Remove ( "," , LOADPROPERTY )  ) ; 
                __context__.SourceCodeLine = 1110;
                LLEVEL = (int) ( Functions.Atol( LOADPROPERTY ) ) ; 
                __context__.SourceCodeLine = 1114;
                
                __context__.SourceCodeLine = 1120;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LLEVEL >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1122;
                    
                    __context__.SourceCodeLine = 1127;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xd"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1129;
                        LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( -1 ) ; 
                        __context__.SourceCodeLine = 1130;
                        LOAD_SETTINGS [ INDEX] . DIMMABLE = (short) ( 1 ) ; 
                        __context__.SourceCodeLine = 1131;
                        LOAD_SETTINGS [ INDEX] . LOADEXCLUDED = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1133;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "xn"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1135;
                            LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( -2 ) ; 
                            __context__.SourceCodeLine = 1136;
                            LOAD_SETTINGS [ INDEX] . DIMMABLE = (short) ( 0 ) ; 
                            __context__.SourceCodeLine = 1137;
                            LOAD_SETTINGS [ INDEX] . LOADEXCLUDED = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1140;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "on"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1142;
                                LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( 65535 ) ; 
                                __context__.SourceCodeLine = 1143;
                                LOAD_SETTINGS [ INDEX] . DIMMABLE = (short) ( 0 ) ; 
                                __context__.SourceCodeLine = 1144;
                                LOAD_SETTINGS [ INDEX] . LOADEXCLUDED = (ushort) ( 0 ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1147;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOADPROPERTY == "off"))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1149;
                                    LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( 0 ) ; 
                                    __context__.SourceCodeLine = 1150;
                                    LOAD_SETTINGS [ INDEX] . DIMMABLE = (short) ( 0 ) ; 
                                    __context__.SourceCodeLine = 1151;
                                    LOAD_SETTINGS [ INDEX] . LOADEXCLUDED = (ushort) ( 0 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 1156;
                                    LOAD_SETTINGS [ INDEX] . LLEVEL = (int) ( LLEVEL ) ; 
                                    __context__.SourceCodeLine = 1157;
                                    LOAD_SETTINGS [ INDEX] . DIMMABLE = (short) ( 1 ) ; 
                                    __context__.SourceCodeLine = 1158;
                                    LOAD_SETTINGS [ INDEX] . LOADEXCLUDED = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 1159;
                                    
                                    __context__.SourceCodeLine = 1161;
                                    ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1164;
                if ( Functions.TestForTrue  ( ( LOAD_SETTINGS[ INDEX ].LOADEXCLUDED)  ) ) 
                    {
                    __context__.SourceCodeLine = 1165;
                    LOAD_IN_SCENE [ INDEX]  .Value = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1167;
                    LOAD_IN_SCENE [ INDEX]  .Value = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 1101;
                } 
            
            __context__.SourceCodeLine = 1169;
            G_FADE_TIME = (uint) ( FADE_TIME  .Value ) ; 
            __context__.SourceCodeLine = 1170;
            G_OFF_TIME = (uint) ( OFF_TIME  .Value ) ; 
            __context__.SourceCodeLine = 1171;
            
            
            }
            
        private void COMMANDHANDLER (  SplusExecutionContext __context__ ) 
            { 
            ushort LOADNUM = 0;
            
            ushort ROUTINGID = 0;
            
            int FADETIME = 0;
            
            ushort INDEX = 0;
            
            ushort CMD = 0;
            
            ushort FUNCTIONRETURNVALUE = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString LEVELINFO;
            LEVELINFO  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            
            __context__.SourceCodeLine = 1188;
            
            __context__.SourceCodeLine = 1191;
            switch ((int)Byte( STOREDCOMMANDSTRING , (int)( 5 ) ))
            
                { 
                case 81 : 
                
                    { 
                    __context__.SourceCodeLine = 1195;
                    
                    __context__.SourceCodeLine = 1198;
                    LOAD_PARAMETER (  __context__  ) ; 
                    __context__.SourceCodeLine = 1199;
                    LOAD_FILE (  __context__  ) ; 
                    __context__.SourceCodeLine = 1200;
                    G_FILELOADED = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1201;
                    UPDATE_FB_LOOP (  __context__  ) ; 
                    __context__.SourceCodeLine = 1202;
                    TEMPSTRING  .UpdateValue ( Functions.Chr (  (int) ( 82 ) )  ) ; 
                    __context__.SourceCodeLine = 1203;
                    SENDSCENELOADRESPONSE (  __context__ , (ushort)( Functions.Atoi( STOREDCOMMANDSTRING ) ), (ushort)( 52 ), TEMPSTRING) ; 
                    __context__.SourceCodeLine = 1205;
                    break ; 
                    } 
                
                break;
                } 
                
            
            
            }
            
        object COMMAND__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 1223;
                
                __context__.SourceCodeLine = 1226;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( COMMAND__DOLLAR__ ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1228;
                    
                    __context__.SourceCodeLine = 1232;
                    STOREDCOMMANDSTRING  .UpdateValue ( Functions.Remove ( "\\" , COMMAND__DOLLAR__ , 1)  ) ; 
                    __context__.SourceCodeLine = 1233;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1235;
                        while ( Functions.TestForTrue  ( ( G_COMMAND_HANDLER)  ) ) 
                            {
                            __context__.SourceCodeLine = 1236;
                            Functions.Delay (  (int) ( 200 ) ) ; 
                            __context__.SourceCodeLine = 1235;
                            }
                        
                        __context__.SourceCodeLine = 1237;
                        G_COMMAND_HANDLER = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 1238;
                        COMMANDHANDLER (  __context__  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1240;
                    G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object FADE_OFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort INDEX = 0;
            ushort FASTOFF = 0;
            ushort STATUS = 0;
            ushort IRESULT = 0;
            
            RAMP_INFO RAMPDATA;
            RAMPDATA  = new RAMP_INFO();
            RAMPDATA .PopulateDefaults();
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 1294;
            TURNING_OFF_SCENE  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1295;
            BUSY_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1313;
            if ( Functions.TestForTrue  ( ( G_OFFING)  ) ) 
                {
                __context__.SourceCodeLine = 1314;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1315;
            G_RECALLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1316;
            G_FAST_RECALLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1317;
            G_FAST_OFFING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1318;
            G_OFFING = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1320;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 1321;
            if ( Functions.TestForTrue  ( ( Functions.Not( PRESET_BUSY  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 1323;
                UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( OFF_TIME  .Value ) ) ) ; 
                __context__.SourceCodeLine = 1324;
                LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( OFF_TIME  .Value ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1328;
                UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1329;
                LOWERWORDFADETIME  .Value = (ushort) ( 50 ) ; 
                } 
            
            __context__.SourceCodeLine = 1334;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1336;
                if ( Functions.TestForTrue  ( ( G_OFFING)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1338;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL == -3) ) || Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL == -4) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1340;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 1341;
                            TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1343;
                            TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1345;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1347;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                                {
                                __context__.SourceCodeLine = 1348;
                                TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1350;
                                TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                                }
                            
                            } 
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1354;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 1334;
                } 
            
            __context__.SourceCodeLine = 1357;
            STOP_RAMP (  __context__  ) ; 
            __context__.SourceCodeLine = 1359;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 1360;
            FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1361;
            FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1362;
            UPDATE_FB_LOOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1364;
            G_OFFING = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FAST_OFF_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INDEX = 0;
        ushort FASTOFF = 0;
        ushort IRESULT = 0;
        
        FILE_INFO FILEINFO;
        FILEINFO  = new FILE_INFO();
        FILEINFO .PopulateDefaults();
        
        RAMP_INFO RAMPDATA;
        RAMPDATA  = new RAMP_INFO();
        RAMPDATA .PopulateDefaults();
        
        
        __context__.SourceCodeLine = 1372;
        TURNING_OFF_SCENE  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1373;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1386;
        if ( Functions.TestForTrue  ( ( G_FAST_OFFING)  ) ) 
            { 
            __context__.SourceCodeLine = 1388;
            return  this ; 
            } 
        
        __context__.SourceCodeLine = 1390;
        STOP_RAMP (  __context__  ) ; 
        __context__.SourceCodeLine = 1391;
        G_FAST_OFFING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1392;
        G_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1393;
        G_RECALLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1394;
        G_FAST_RECALLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1396;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1398;
        UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1399;
        LOWERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1401;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1403;
            if ( Functions.TestForTrue  ( ( G_FAST_OFFING)  ) ) 
                { 
                __context__.SourceCodeLine = 1405;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL == -3) ) || Functions.TestForTrue ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LLEVEL == -4) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1407;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 1408;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1410;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1412;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1414;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 1415;
                            TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1417;
                            TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                            }
                        
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1421;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1401;
            } 
        
        __context__.SourceCodeLine = 1424;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1425;
        FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1426;
        FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1428;
        G_FAST_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1429;
        UPDATE_FB_LOOP (  __context__  ) ; 
        __context__.SourceCodeLine = 1430;
        G_OFFING = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RECALL_OnPush_3 ( Object __EventInfo__ )

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
        
        
        __context__.SourceCodeLine = 1457;
        if ( Functions.TestForTrue  ( ( G_RECALLING)  ) ) 
            {
            __context__.SourceCodeLine = 1458;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1459;
        G_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1460;
        G_FAST_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1461;
        G_FAST_RECALLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1462;
        G_RECALLING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1465;
        RECALLING_SCENE  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1466;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1468;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1469;
        if ( Functions.TestForTrue  ( ( Functions.Not( PRESET_BUSY  .Value ))  ) ) 
            { 
            __context__.SourceCodeLine = 1471;
            UPPERWORDFADETIME  .Value = (ushort) ( Functions.HighWord( (uint)( FADE_TIME  .Value ) ) ) ; 
            __context__.SourceCodeLine = 1472;
            LOWERWORDFADETIME  .Value = (ushort) ( Functions.LowWord( (uint)( FADE_TIME  .Value ) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1476;
            UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1477;
            LOWERWORDFADETIME  .Value = (ushort) ( 50 ) ; 
            } 
        
        __context__.SourceCodeLine = 1483;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1493;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_RECALLING == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1494;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1496;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1499;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 1500;
                    TARGET_LEVELS [ INDEX]  .Value = (ushort) ( LOAD_SETTINGS[ INDEX ].LLEVEL ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1502;
                    TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1509;
                switch ((int)LOAD_SETTINGS[ INDEX ].LLEVEL)
                
                    { 
                    case -1 : 
                    case -2 : 
                    
                        { 
                        __context__.SourceCodeLine = 1515;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                        __context__.SourceCodeLine = 1516;
                        break ; 
                        } 
                    
                    goto case -3 ;
                    case -3 : 
                    
                        { 
                        __context__.SourceCodeLine = 1521;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 65535 ) ; 
                        __context__.SourceCodeLine = 1522;
                        break ; 
                        } 
                    
                    goto case -4 ;
                    case -4 : 
                    
                        { 
                        __context__.SourceCodeLine = 1527;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1528;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                } 
            
            __context__.SourceCodeLine = 1483;
            } 
        
        __context__.SourceCodeLine = 1533;
        STOP_RAMP (  __context__  ) ; 
        __context__.SourceCodeLine = 1535;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1536;
        FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1537;
        FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1539;
        UPDATE_FB_LOOP (  __context__  ) ; 
        __context__.SourceCodeLine = 1540;
        RECALL_OK  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1541;
        RECALL_OK  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1542;
        G_RECALLING = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FAST_RECALL_OnPush_4 ( Object __EventInfo__ )

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
        
        
        __context__.SourceCodeLine = 1569;
        if ( Functions.TestForTrue  ( ( G_FAST_RECALLING)  ) ) 
            { 
            __context__.SourceCodeLine = 1572;
            return  this ; 
            } 
        
        __context__.SourceCodeLine = 1574;
        STOP_RAMP (  __context__  ) ; 
        __context__.SourceCodeLine = 1577;
        G_FAST_RECALLING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1578;
        G_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1579;
        G_RECALLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1580;
        G_FAST_OFFING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1581;
        FADEVALUE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1583;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1585;
        RECALLING_SCENE  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1586;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1587;
        UPPERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1588;
        LOWERWORDFADETIME  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1593;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_TOTAL_LOADS; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1603;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_RECALLING == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1604;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1606;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOAD_SETTINGS[ INDEX ].LLEVEL >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1608;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOAD_SETTINGS[ INDEX ].LOADEXCLUDED == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 1609;
                    TARGET_LEVELS [ INDEX]  .Value = (ushort) ( LOAD_SETTINGS[ INDEX ].LLEVEL ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1611;
                    TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1617;
                switch ((int)LOAD_SETTINGS[ INDEX ].LLEVEL)
                
                    { 
                    case -1 : 
                    case -2 : 
                    
                        { 
                        __context__.SourceCodeLine = 1623;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( CURRENT_LEVELS[ INDEX ] .Value ) ; 
                        __context__.SourceCodeLine = 1624;
                        break ; 
                        } 
                    
                    goto case -3 ;
                    case -3 : 
                    
                        { 
                        __context__.SourceCodeLine = 1629;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 65535 ) ; 
                        __context__.SourceCodeLine = 1630;
                        break ; 
                        } 
                    
                    goto case -4 ;
                    case -4 : 
                    
                        { 
                        __context__.SourceCodeLine = 1635;
                        TARGET_LEVELS [ INDEX]  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1636;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                } 
            
            __context__.SourceCodeLine = 1593;
            } 
        
        __context__.SourceCodeLine = 1642;
        ENABLE_BUFFER  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1643;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1644;
        FIRE_RAMP  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1645;
        FIRE_RAMP  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1647;
        UPDATE_FB_LOOP (  __context__  ) ; 
        __context__.SourceCodeLine = 1648;
        RECALL_OK  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1649;
        RECALL_OK  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1650;
        G_FAST_RECALLING = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1659;
        BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1661;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 1662;
        SAVESCENE (  __context__  ) ; 
        __context__.SourceCodeLine = 1664;
        BUSY_FB  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REVERT_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1669;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt (StartFileOperations() != 0))  ) ) 
            {
            __context__.SourceCodeLine = 1669;
            Functions.Delay (  (int) ( 100 ) ) ; 
            __context__.SourceCodeLine = 1669;
            }
        
        __context__.SourceCodeLine = 1671;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileDelete( G_SCENEFILENAME__DOLLAR__ ) != 0))  ) ) 
            {
            __context__.SourceCodeLine = 1672;
            Functions.Pulse ( 50, REVERT_ERROR ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1674;
            Functions.Pulse ( 50, REVERT_OK ) ; 
            }
        
        __context__.SourceCodeLine = 1676;
        EndFileOperations ( ) ; 
        __context__.SourceCodeLine = 1677;
        LOAD_PARAMETER (  __context__  ) ; 
        __context__.SourceCodeLine = 1678;
        UPDATE_FB_LOOP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UPDATE_FB_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1683;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_FILELOADED == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1684;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 1685;
        if ( Functions.TestForTrue  ( ( TURNING_OFF_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1686;
            TURNING_OFF_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1687;
        if ( Functions.TestForTrue  ( ( RECALLING_SCENE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 1688;
            RECALLING_SCENE  .Value = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 1689;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SEMAPHORE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1691;
            
            __context__.SourceCodeLine = 1694;
            G_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1695;
            
            __context__.SourceCodeLine = 1698;
            UPDATE_FB_LOOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1699;
            if ( Functions.TestForTrue  ( ( BUSY_FB  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 1700;
                BUSY_FB  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 1701;
            G_SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1702;
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PATH__DOLLAR___OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1711;
        G_OLDSCENEFILENAME__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "scene_" + Functions.LtoA (  (int) ( SCENE_ID  .Value ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 1712;
        G_SCENEFILENAME__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "BinaryScene_" + Functions.LtoA (  (int) ( SCENE_ID  .Value ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 1713;
        G_SCENES_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "SCENES.dat"  ) ; 
        __context__.SourceCodeLine = 1714;
        G_LOADS_FILE__DOLLAR__  .UpdateValue ( PATH__DOLLAR__ + "Loads.dat"  ) ; 
        __context__.SourceCodeLine = 1715;
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
    ushort FILEEXISTFLAG = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1742;
        G_COMMAND_HANDLER = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1744;
        
        __context__.SourceCodeLine = 1749;
        G_TOTAL_LOADS = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1750;
        G_FILELOADED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1752;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 500 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1754;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( CURRENT_LEVELS[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 1756;
                G_TOTAL_LOADS = (ushort) ( I ) ; 
                __context__.SourceCodeLine = 1757;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1752;
            } 
        
        __context__.SourceCodeLine = 1760;
        Functions.ResizeArray (  ref LOAD_SETTINGS , (int)G_TOTAL_LOADS, null ) ; 
        __context__.SourceCodeLine = 1761;
        
        __context__.SourceCodeLine = 1765;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1767;
        G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1768;
        G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1769;
        G_FILE_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1770;
        G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_OLDSCENEFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_SCENEFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_LOADS_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_SCENENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_SCENES_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
    G_LASTSAVEDTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    G_LASTSAVEDDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    STOREDCOMMANDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
    G_FILEINFO  = new FILE_INFO();
    G_FILEINFO .PopulateDefaults();
    LOAD_SETTINGS  = new LOAD_SETTING[ 2 ];
    for( uint i = 0; i < 2; i++ )
    {
        LOAD_SETTINGS [i] = new LOAD_SETTING( this, true );
        LOAD_SETTINGS [i].PopulateCustomAttributeList( false );
        
    }
    
    RECALL = new Crestron.Logos.SplusObjects.DigitalInput( RECALL__DigitalInput__, this );
    m_DigitalInputList.Add( RECALL__DigitalInput__, RECALL );
    
    FAST_RECALL = new Crestron.Logos.SplusObjects.DigitalInput( FAST_RECALL__DigitalInput__, this );
    m_DigitalInputList.Add( FAST_RECALL__DigitalInput__, FAST_RECALL );
    
    FADE_OFF = new Crestron.Logos.SplusObjects.DigitalInput( FADE_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( FADE_OFF__DigitalInput__, FADE_OFF );
    
    FAST_OFF = new Crestron.Logos.SplusObjects.DigitalInput( FAST_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( FAST_OFF__DigitalInput__, FAST_OFF );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    REVERT = new Crestron.Logos.SplusObjects.DigitalInput( REVERT__DigitalInput__, this );
    m_DigitalInputList.Add( REVERT__DigitalInput__, REVERT );
    
    UPDATE_FB = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE_FB__DigitalInput__, this );
    m_DigitalInputList.Add( UPDATE_FB__DigitalInput__, UPDATE_FB );
    
    PRESET_BUSY = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_BUSY__DigitalInput__, this );
    m_DigitalInputList.Add( PRESET_BUSY__DigitalInput__, PRESET_BUSY );
    
    ANY_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ANY_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ANY_ON_FB__DigitalOutput__, ANY_ON_FB );
    
    ALL_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ALL_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ALL_ON_FB__DigitalOutput__, ALL_ON_FB );
    
    AT_SCENE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( AT_SCENE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( AT_SCENE_FB__DigitalOutput__, AT_SCENE_FB );
    
    RAISE_LOADS = new Crestron.Logos.SplusObjects.DigitalOutput( RAISE_LOADS__DigitalOutput__, this );
    m_DigitalOutputList.Add( RAISE_LOADS__DigitalOutput__, RAISE_LOADS );
    
    LOWER_LOADS = new Crestron.Logos.SplusObjects.DigitalOutput( LOWER_LOADS__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOWER_LOADS__DigitalOutput__, LOWER_LOADS );
    
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
    
    LOAD_IN_SCENE = new InOutArray<DigitalOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        LOAD_IN_SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LOAD_IN_SCENE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LOAD_IN_SCENE__DigitalOutput__ + i, LOAD_IN_SCENE[i+1] );
    }
    
    RESPONSEID = new Crestron.Logos.SplusObjects.AnalogOutput( RESPONSEID__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RESPONSEID__AnalogSerialOutput__, RESPONSEID );
    
    UPPERWORDFADETIME = new Crestron.Logos.SplusObjects.AnalogOutput( UPPERWORDFADETIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( UPPERWORDFADETIME__AnalogSerialOutput__, UPPERWORDFADETIME );
    
    LOWERWORDFADETIME = new Crestron.Logos.SplusObjects.AnalogOutput( LOWERWORDFADETIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LOWERWORDFADETIME__AnalogSerialOutput__, LOWERWORDFADETIME );
    
    TARGET_LEVELS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        TARGET_LEVELS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( TARGET_LEVELS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( TARGET_LEVELS__AnalogSerialOutput__ + i, TARGET_LEVELS[i+1] );
    }
    
    CURRENT_LEVELS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        CURRENT_LEVELS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_LEVELS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CURRENT_LEVELS__AnalogSerialOutput__ + i, CURRENT_LEVELS[i+1] );
    }
    
    PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 64, this );
    m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
    
    RESPONSE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RESPONSE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( RESPONSE__DOLLAR____AnalogSerialOutput__, RESPONSE__DOLLAR__ );
    
    COMMAND__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( COMMAND__DOLLAR____AnalogSerialInput__, 512, this );
    m_StringInputList.Add( COMMAND__DOLLAR____AnalogSerialInput__, COMMAND__DOLLAR__ );
    
    SCENE_ID = new UIntParameter( SCENE_ID__Parameter__, this );
    m_ParameterList.Add( SCENE_ID__Parameter__, SCENE_ID );
    
    FADE_TIME = new UIntParameter( FADE_TIME__Parameter__, this );
    m_ParameterList.Add( FADE_TIME__Parameter__, FADE_TIME );
    
    OFF_TIME = new UIntParameter( OFF_TIME__Parameter__, this );
    m_ParameterList.Add( OFF_TIME__Parameter__, OFF_TIME );
    
    LOAD_PROPERTY = new InOutArray<StringParameter>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        LOAD_PROPERTY[i+1] = new StringParameter( LOAD_PROPERTY__Parameter__ + i, LOAD_PROPERTY__Parameter__, this );
        m_ParameterList.Add( LOAD_PROPERTY__Parameter__ + i, LOAD_PROPERTY[i+1] );
    }
    
    
    COMMAND__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( COMMAND__DOLLAR___OnChange_0, false ) );
    FADE_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( FADE_OFF_OnPush_1, false ) );
    FAST_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( FAST_OFF_OnPush_2, false ) );
    RECALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALL_OnPush_3, false ) );
    FAST_RECALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( FAST_RECALL_OnPush_4, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_5, false ) );
    REVERT.OnDigitalPush.Add( new InputChangeHandlerWrapper( REVERT_OnPush_6, false ) );
    UPDATE_FB.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_FB_OnPush_7, false ) );
    PATH__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( PATH__DOLLAR___OnChange_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_DYNAMIC_LIGHTING_PRESET ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RECALL__DigitalInput__ = 0;
const uint FAST_RECALL__DigitalInput__ = 1;
const uint FADE_OFF__DigitalInput__ = 2;
const uint FAST_OFF__DigitalInput__ = 3;
const uint SAVE__DigitalInput__ = 4;
const uint REVERT__DigitalInput__ = 5;
const uint UPDATE_FB__DigitalInput__ = 6;
const uint COMMAND__DOLLAR____AnalogSerialInput__ = 0;
const uint ANY_ON_FB__DigitalOutput__ = 0;
const uint ALL_ON_FB__DigitalOutput__ = 1;
const uint AT_SCENE_FB__DigitalOutput__ = 2;
const uint RAISE_LOADS__DigitalOutput__ = 3;
const uint LOWER_LOADS__DigitalOutput__ = 4;
const uint BUSY_FB__DigitalOutput__ = 5;
const uint RECALLING_SCENE__DigitalOutput__ = 6;
const uint TURNING_OFF_SCENE__DigitalOutput__ = 7;
const uint RECALL_OK__DigitalOutput__ = 8;
const uint SAVE_OK__DigitalOutput__ = 9;
const uint SAVE_ERROR__DigitalOutput__ = 10;
const uint REVERT_OK__DigitalOutput__ = 11;
const uint REVERT_ERROR__DigitalOutput__ = 12;
const uint ENABLE_BUFFER__DigitalOutput__ = 13;
const uint RESPONSE__DOLLAR____AnalogSerialOutput__ = 0;
const uint FIRE_RAMP__DigitalOutput__ = 14;
const uint PRESET_BUSY__DigitalInput__ = 7;
const uint LOAD_IN_SCENE__DigitalOutput__ = 15;
const uint RESPONSEID__AnalogSerialOutput__ = 1;
const uint UPPERWORDFADETIME__AnalogSerialOutput__ = 2;
const uint LOWERWORDFADETIME__AnalogSerialOutput__ = 3;
const uint TARGET_LEVELS__AnalogSerialOutput__ = 4;
const uint CURRENT_LEVELS__AnalogSerialOutput__ = 504;
const uint PATH__DOLLAR____AnalogSerialInput__ = 1;
const uint SCENE_ID__Parameter__ = 10;
const uint FADE_TIME__Parameter__ = 11;
const uint OFF_TIME__Parameter__ = 12;
const uint LOAD_PROPERTY__Parameter__ = 13;

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
