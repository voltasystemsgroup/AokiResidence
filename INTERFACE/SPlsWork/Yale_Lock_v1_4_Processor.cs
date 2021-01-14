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

namespace UserModule_YALE_LOCK_V1_4_PROCESSOR
{
    public class UserModuleClass_YALE_LOCK_V1_4_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LOCK;
        Crestron.Logos.SplusObjects.DigitalInput UNLOCK;
        Crestron.Logos.SplusObjects.DigitalInput SELECTED_USER_DELETE;
        Crestron.Logos.SplusObjects.DigitalInput GET_CONFIGURATION;
        Crestron.Logos.SplusObjects.DigitalInput GET_BATTERY_LEVEL;
        Crestron.Logos.SplusObjects.DigitalInput GET_PRODUCT_INFO;
        Crestron.Logos.SplusObjects.DigitalInput SET_RELOCK_TIME_UP;
        Crestron.Logos.SplusObjects.DigitalInput SET_RELOCK_TIME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput SET_WRONG_CODE_LIMIT_UP;
        Crestron.Logos.SplusObjects.DigitalInput SET_WRONG_CODE_LIMIT_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput SET_SHUT_DOWN_TIME_UP;
        Crestron.Logos.SplusObjects.DigitalInput SET_SHUT_DOWN_TIME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput SEND_PARAMETERS_UPDATE;
        Crestron.Logos.SplusObjects.DigitalInput SELECTED_USER_ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput SELECTED_USER_DISABLE;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR_USER_SETTINGS;
        Crestron.Logos.SplusObjects.StringInput TO_MODULE_USER_NUMBER;
        Crestron.Logos.SplusObjects.StringInput TO_MODULE_USER_PIN;
        Crestron.Logos.SplusObjects.StringInput TO_MODULE_USER_NAME;
        Crestron.Logos.SplusObjects.DigitalInput TO_MODULE_SET_USER_PIN;
        Crestron.Logos.SplusObjects.DigitalInput TO_MODULE_USER_DELETE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_SILENT_MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_AUTO_RELOCK_MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_LANGUAGE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_OPERATING_MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_ONE_TOUCH_LOCKING_MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_PRIVACY_MODE_BUTTON_MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SET_INSIDE_COVER_LED_MODE;
        Crestron.Logos.SplusObjects.AnalogInput SET_RELOCK_TIME_IN;
        Crestron.Logos.SplusObjects.AnalogInput SET_WRONG_CODE_LIMIT_IN;
        Crestron.Logos.SplusObjects.AnalogInput SET_SHUT_DOWN_TIME_IN;
        Crestron.Logos.SplusObjects.StringInput FROM_LOCK;
        Crestron.Logos.SplusObjects.StringInput USER_NUMBER_TEXT_IN;
        Crestron.Logos.SplusObjects.StringInput USER_NAME_TEXT_IN;
        Crestron.Logos.SplusObjects.StringInput USER_PIN_TEXT_IN;
        Crestron.Logos.SplusObjects.DigitalOutput IS_UNLOCKED;
        Crestron.Logos.SplusObjects.DigitalOutput IS_LOCKED;
        Crestron.Logos.SplusObjects.StringOutput BATTERY_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput BATTERY_LEVEL_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput LOCKED_REASON_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput LOCKED_SLOT_NUM_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput UNLOCKED_REASON_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput UNLOCKED_SLOT_NUM_VAL;
        Crestron.Logos.SplusObjects.AnalogOutput SILENT_MODE_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput AUTO_RELOCK_STATUS;
        Crestron.Logos.SplusObjects.StringOutput AUTO_RELOCK_TIME_TEXT;
        Crestron.Logos.SplusObjects.StringOutput WRONG_CODE_LIMIT_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput LANGUAGE_STATUS;
        Crestron.Logos.SplusObjects.StringOutput SHUT_DOWN_TIME_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput OPERATING_MODE_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput LOOP_TEST_MODE_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput ONE_TOUCH_LOCKING_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput PRIVACY_MODE_BUTTON_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput INSIDE_COVER_LED_STATUS;
        Crestron.Logos.SplusObjects.StringOutput LOCK_PRODUCT_ID_TEXT;
        Crestron.Logos.SplusObjects.StringOutput LOCK_FIRMWARE_VERSION_TEXT;
        Crestron.Logos.SplusObjects.DigitalOutput MASTER_PIN_CODE_WAS_CHANGED;
        Crestron.Logos.SplusObjects.DigitalOutput SHOWING_PIN;
        Crestron.Logos.SplusObjects.DigitalOutput HIDING_PIN;
        Crestron.Logos.SplusObjects.AnalogOutput ALARM_STATUS;
        Crestron.Logos.SplusObjects.StringOutput SLOT_NUM_TEXT;
        Crestron.Logos.SplusObjects.StringOutput PIN_TEXT;
        Crestron.Logos.SplusObjects.StringOutput LOCK_EVENT_TEXT;
        Crestron.Logos.SplusObjects.StringOutput USER_EVENT_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ALARM_EVENT_TEXT;
        Crestron.Logos.SplusObjects.StringOutput LOCK_TYPE_TEXT;
        Crestron.Logos.SplusObjects.DigitalOutput PARAMETER_CHANGED;
        Crestron.Logos.SplusObjects.StringOutput CURRENT_STATUS_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ALARM_STATUS_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TO_LOCK;
        Crestron.Logos.SplusObjects.DigitalOutput PARAMETER_REPORT;
        Crestron.Logos.SplusObjects.DigitalOutput LOCK_STATUS_UPDATED;
        Crestron.Logos.SplusObjects.StringOutput USER_NUMBER_TEXT_OUT;
        Crestron.Logos.SplusObjects.StringOutput USER_NAME_TEXT_OUT;
        Crestron.Logos.SplusObjects.StringOutput USER_PIN_TEXT_OUT;
        Crestron.Logos.SplusObjects.DigitalOutput USER_IS_ENABLED;
        Crestron.Logos.SplusObjects.DigitalOutput USER_IS_DISABLED;
        StringParameter LOCK_NAME;
        private void UPDATE_PIN_TEXT (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SPINTEMP;
            SPINTEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 179;
            if ( Functions.TestForTrue  ( ( SHOWING_PIN  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 180;
                PIN_TEXT  .UpdateValue ( _SplusNVRAM.SPIN  ) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 183;
                Functions.ClearBuffer ( SPINTEMP ) ; 
                __context__.SourceCodeLine = 184;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( _SplusNVRAM.SPIN ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 186;
                    SPINTEMP  .UpdateValue ( SPINTEMP + "*"  ) ; 
                    __context__.SourceCodeLine = 184;
                    } 
                
                __context__.SourceCodeLine = 188;
                PIN_TEXT  .UpdateValue ( SPINTEMP  ) ; 
                } 
            
            
            }
            
        private void LOCKEVENT (  SplusExecutionContext __context__, ushort ILOCKSTATUS , ushort ILOCKCAUSE , ushort ILOCKSLOTNUM ) 
            { 
            CrestronString STEXTTOSEND;
            STEXTTOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 196;
            LOCK_STATUS_UPDATED  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 197;
            LOCK_STATUS_UPDATED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 199;
            Functions.ClearBuffer ( STEXTTOSEND ) ; 
            __context__.SourceCodeLine = 201;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKSTATUS == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 203;
                MakeString ( STEXTTOSEND , "Locked") ; 
                __context__.SourceCodeLine = 204;
                CURRENT_STATUS_TEXT  .UpdateValue ( "Locked"  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 206;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKSTATUS == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 208;
                    MakeString ( STEXTTOSEND , "Unlocked") ; 
                    __context__.SourceCodeLine = 209;
                    CURRENT_STATUS_TEXT  .UpdateValue ( "Unlocked"  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 213;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 215;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 216;
                    MakeString ( STEXTTOSEND , "{0} remotely", STEXTTOSEND ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 217;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 2))  ) ) 
                        {
                        __context__.SourceCodeLine = 218;
                        MakeString ( STEXTTOSEND , "{0} by key or thumbturn", STEXTTOSEND ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 219;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 3))  ) ) 
                            {
                            __context__.SourceCodeLine = 220;
                            MakeString ( STEXTTOSEND , "{0} by schedule", STEXTTOSEND ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 221;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 4))  ) ) 
                                { 
                                __context__.SourceCodeLine = 223;
                                if ( Functions.TestForTrue  ( ( Functions.Length( _SplusNVRAM.SUSERNAME[ ILOCKSLOTNUM ] ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 224;
                                    MakeString ( STEXTTOSEND , "{0} by {1}", STEXTTOSEND , _SplusNVRAM.SUSERNAME [ ILOCKSLOTNUM ] ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 226;
                                    MakeString ( STEXTTOSEND , "{0} by User ID {1:d}", STEXTTOSEND , (short)ILOCKSLOTNUM) ; 
                                    }
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 228;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 5))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 229;
                                    MakeString ( STEXTTOSEND , "{0} by one-touch", STEXTTOSEND ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 230;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOCKCAUSE == 6))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 231;
                                        MakeString ( STEXTTOSEND , "{0} by auto-relock", STEXTTOSEND ) ; 
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 233;
                LOCK_EVENT_TEXT  .UpdateValue ( LOCK_NAME + ": " + STEXTTOSEND  ) ; 
                } 
            
            
            }
            
        private void USEREVENT (  SplusExecutionContext __context__, ushort ITYPE , ushort ISLOTVALUE , ushort ISTATUS , CrestronString SPINCODE ) 
            { 
            CrestronString STEXTTOSEND;
            STEXTTOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 243;
            Functions.ClearBuffer ( STEXTTOSEND ) ; 
            __context__.SourceCodeLine = 244;
            if ( Functions.TestForTrue  ( ( Functions.Length( _SplusNVRAM.SUSERNAME[ ISLOTVALUE ] ))  ) ) 
                {
                __context__.SourceCodeLine = 245;
                MakeString ( STEXTTOSEND , "{0}", _SplusNVRAM.SUSERNAME [ ISLOTVALUE ] ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 247;
                MakeString ( STEXTTOSEND , "User {0:d}", (short)ISLOTVALUE) ; 
                }
            
            __context__.SourceCodeLine = 249;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 2))  ) ) 
                {
                __context__.SourceCodeLine = 250;
                MakeString ( STEXTTOSEND , "{0} settings were cleared", STEXTTOSEND ) ; 
                }
            
            __context__.SourceCodeLine = 251;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 4))  ) ) 
                {
                __context__.SourceCodeLine = 252;
                MakeString ( STEXTTOSEND , "{0} PIN fail - duplicate PIN", STEXTTOSEND ) ; 
                }
            
            __context__.SourceCodeLine = 254;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATUS == 1))  ) ) 
                {
                __context__.SourceCodeLine = 255;
                MakeString ( STEXTTOSEND , "{0} is enabled", STEXTTOSEND ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 256;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATUS == 3))  ) ) 
                    {
                    __context__.SourceCodeLine = 257;
                    MakeString ( STEXTTOSEND , "{0} is disabled", STEXTTOSEND ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 259;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ITYPE != 4) ) && Functions.TestForTrue ( Functions.BoolToInt (ITYPE != 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 261;
                Functions.ClearBuffer ( _SplusNVRAM.SPINTEXT ) ; 
                __context__.SourceCodeLine = 262;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SPINCODE != "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 264;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)8; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 266;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SPINCODE , (int)( 1 ) ) == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 267;
                            break ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 269;
                            MakeString ( _SplusNVRAM.SPINTEXT , "{0}{1}", _SplusNVRAM.SPINTEXT , Functions.Chr (  (int) ( Functions.GetC( SPINCODE ) ) ) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 264;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 273;
                    MakeString ( STEXTTOSEND , "{0} no PIN assigned", STEXTTOSEND ) ; 
                    }
                
                __context__.SourceCodeLine = 275;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISLOTVALUE == _SplusNVRAM.IUSERNUMBERIN))  ) ) 
                    { 
                    __context__.SourceCodeLine = 277;
                    USER_NUMBER_TEXT_OUT  .UpdateValue ( Functions.ItoA (  (int) ( ISLOTVALUE ) )  ) ; 
                    __context__.SourceCodeLine = 278;
                    if ( Functions.TestForTrue  ( ( Functions.Length( _SplusNVRAM.SUSERNAME[ ISLOTVALUE ] ))  ) ) 
                        {
                        __context__.SourceCodeLine = 279;
                        USER_NAME_TEXT_OUT  .UpdateValue ( _SplusNVRAM.SUSERNAME [ ISLOTVALUE ]  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 281;
                        USER_NAME_TEXT_OUT  .UpdateValue ( "User ID " + Functions.ItoA (  (int) ( ISLOTVALUE ) )  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 282;
                    if ( Functions.TestForTrue  ( ( Functions.Length( _SplusNVRAM.SPINTEXT ))  ) ) 
                        {
                        __context__.SourceCodeLine = 283;
                        USER_PIN_TEXT_OUT  .UpdateValue ( _SplusNVRAM.SPINTEXT  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 285;
                        USER_PIN_TEXT_OUT  .UpdateValue ( "None Assigned"  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 286;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATUS == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 288;
                        USER_IS_DISABLED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 289;
                        USER_IS_ENABLED  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 291;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATUS == 3))  ) ) 
                            { 
                            __context__.SourceCodeLine = 293;
                            USER_IS_ENABLED  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 294;
                            USER_IS_DISABLED  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 298;
            USER_EVENT_TEXT  .UpdateValue ( LOCK_NAME + ": " + STEXTTOSEND  ) ; 
            
            }
            
        private void ALARMEVENT (  SplusExecutionContext __context__, ushort ITYPE ) 
            { 
            CrestronString STEXTTOSEND;
            STEXTTOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 306;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 308;
                ALARM_STATUS_TEXT  .UpdateValue ( "Alarm Cleared"  ) ; 
                __context__.SourceCodeLine = 309;
                MakeString ( STEXTTOSEND , "") ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 313;
                ALARM_STATUS_TEXT  .UpdateValue ( "Alarm Notice"  ) ; 
                __context__.SourceCodeLine = 315;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 9))  ) ) 
                    {
                    __context__.SourceCodeLine = 316;
                    MakeString ( STEXTTOSEND , "Deadbolt jammed") ; 
                    }
                
                __context__.SourceCodeLine = 317;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 48))  ) ) 
                    {
                    __context__.SourceCodeLine = 318;
                    MakeString ( STEXTTOSEND , "Lock reset to factory defaults") ; 
                    }
                
                __context__.SourceCodeLine = 319;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 128))  ) ) 
                    {
                    __context__.SourceCodeLine = 320;
                    MakeString ( STEXTTOSEND , "RF module power cycled") ; 
                    }
                
                __context__.SourceCodeLine = 321;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 162))  ) ) 
                    {
                    __context__.SourceCodeLine = 322;
                    MakeString ( STEXTTOSEND , "Keypad attempt limit reached") ; 
                    }
                
                __context__.SourceCodeLine = 323;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 163))  ) ) 
                    {
                    __context__.SourceCodeLine = 324;
                    MakeString ( STEXTTOSEND , "Outside cover removed") ; 
                    }
                
                __context__.SourceCodeLine = 325;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 167))  ) ) 
                    {
                    __context__.SourceCodeLine = 326;
                    MakeString ( STEXTTOSEND , "Low battery") ; 
                    }
                
                __context__.SourceCodeLine = 327;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 168))  ) ) 
                    {
                    __context__.SourceCodeLine = 328;
                    MakeString ( STEXTTOSEND , "Critical battery") ; 
                    }
                
                __context__.SourceCodeLine = 329;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITYPE == 169))  ) ) 
                    {
                    __context__.SourceCodeLine = 330;
                    MakeString ( STEXTTOSEND , "Battery too low to operate lock") ; 
                    }
                
                __context__.SourceCodeLine = 331;
                ALARM_EVENT_TEXT  .UpdateValue ( LOCK_NAME + ": " + STEXTTOSEND  ) ; 
                } 
            
            
            }
            
        private void VALUEINCREMENT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 337;
            _SplusNVRAM.IDELAY = (ushort) ( 25 ) ; 
            __context__.SourceCodeLine = 338;
            CreateWait ( "INCREMENT1" , 300 , INCREMENT1_Callback ) ;
            __context__.SourceCodeLine = 340;
            CreateWait ( "INCREMENT2" , 600 , INCREMENT2_Callback ) ;
            
            }
            
        public void INCREMENT1_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            {
            __context__.SourceCodeLine = 339;
            _SplusNVRAM.IDELAY = (ushort) ( 10 ) ; 
            }
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    public void INCREMENT2_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            {
            __context__.SourceCodeLine = 341;
            _SplusNVRAM.IDELAY = (ushort) ( 1 ) ; 
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void CANCELVALUEINCREMENT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 346;
    CancelWait ( "INCREMENT1" ) ; 
    __context__.SourceCodeLine = 347;
    CancelWait ( "INCREMENT2" ) ; 
    
    }
    
private void GETUSERNUMBERSTATUS (  SplusExecutionContext __context__, ushort INUMBER ) 
    { 
    
    __context__.SourceCodeLine = 352;
    MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0015\u0001{1}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( INUMBER ) ) ) ; 
    __context__.SourceCodeLine = 353;
    TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
    
    }
    
private void SETPIN (  SplusExecutionContext __context__, CrestronString SPIN ) 
    { 
    ushort A = 0;
    
    CrestronString SPINFORMATTED;
    SPINFORMATTED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    
    
    __context__.SourceCodeLine = 361;
    Functions.ClearBuffer ( SPINFORMATTED ) ; 
    __context__.SourceCodeLine = 362;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)(8 - Functions.Length( SPIN )); 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 364;
        MakeString ( SPINFORMATTED , "{0}{1}", SPINFORMATTED , "\u0000" ) ; 
        __context__.SourceCodeLine = 362;
        } 
    
    __context__.SourceCodeLine = 366;
    MakeString ( SPINFORMATTED , "{0}{1}", SPIN , SPINFORMATTED ) ; 
    __context__.SourceCodeLine = 367;
    MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0012\u000A{1}\u0001{2}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( _SplusNVRAM.IUSERNUMBERIN ) ) , SPINFORMATTED ) ; 
    __context__.SourceCodeLine = 368;
    TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
    
    }
    
private void DELETEUSER (  SplusExecutionContext __context__, ushort INUMBER ) 
    { 
    
    __context__.SourceCodeLine = 373;
    MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0013\u0001{1}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( INUMBER ) ) ) ; 
    __context__.SourceCodeLine = 374;
    TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
    
    }
    
private void ENABLEUSER (  SplusExecutionContext __context__, ushort INUMBER ) 
    { 
    
    __context__.SourceCodeLine = 379;
    MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0016\u0002{1}\u0001", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( INUMBER ) ) ) ; 
    __context__.SourceCodeLine = 380;
    TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
    
    }
    
private void DISABLEUSER (  SplusExecutionContext __context__, ushort INUMBER ) 
    { 
    
    __context__.SourceCodeLine = 385;
    MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0016\u0002{1}\u0003", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( INUMBER ) ) ) ; 
    __context__.SourceCodeLine = 386;
    TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
    
    }
    
object FROM_LOCK_OnChange_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 401;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IPROCESSFROMLOCK == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 403;
            _SplusNVRAM.IPROCESSFROMLOCK = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 405;
            _SplusNVRAM.IPACKET = (ushort) ( Byte( FROM_LOCK , (int)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 406;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IPACKET == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 408;
                _SplusNVRAM.IPACKET = (ushort) ( Byte( FROM_LOCK , (int)( 2 ) ) ) ; 
                __context__.SourceCodeLine = 409;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IPACKET == 255))  ) ) 
                    { 
                    __context__.SourceCodeLine = 411;
                    IS_UNLOCKED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 412;
                    IS_LOCKED  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 413;
                    _SplusNVRAM.ILOCKSTATUS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 414;
                    UNLOCKED_REASON_VAL  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 415;
                    LOCKEVENT (  __context__ , (ushort)( _SplusNVRAM.ILOCKSTATUS ), (ushort)( 0 ), (ushort)( 0 )) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 417;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IPACKET == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 419;
                        IS_LOCKED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 420;
                        IS_UNLOCKED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 421;
                        _SplusNVRAM.ILOCKSTATUS = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 422;
                        LOCKED_REASON_VAL  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 423;
                        LOCKEVENT (  __context__ , (ushort)( _SplusNVRAM.ILOCKSTATUS ), (ushort)( 0 ), (ushort)( 0 )) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 428;
                        IS_LOCKED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 429;
                        IS_UNLOCKED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 430;
                        _SplusNVRAM.ILOCKSTATUS = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 431;
                        LOCKEVENT (  __context__ , (ushort)( _SplusNVRAM.ILOCKSTATUS ), (ushort)( 0 ), (ushort)( 0 )) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 434;
                BATTERY_LEVEL_VAL  .Value = (ushort) ( Byte( FROM_LOCK , (int)( 3 ) ) ) ; 
                __context__.SourceCodeLine = 435;
                BATTERY_LEVEL_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( Byte( FROM_LOCK , (int)( 3 ) ) ) ) + "%"  ) ; 
                __context__.SourceCodeLine = 436;
                _SplusNVRAM.IEVENT = (ushort) ( Byte( FROM_LOCK , (int)( 4 ) ) ) ; 
                __context__.SourceCodeLine = 437;
                _SplusNVRAM.IPACKET = (ushort) ( Byte( FROM_LOCK , (int)( 5 ) ) ) ; 
                __context__.SourceCodeLine = 438;
                _SplusNVRAM.SPARAMETERS  .UpdateValue ( Functions.Mid ( FROM_LOCK ,  (int) ( 6 ) ,  (int) ( _SplusNVRAM.IPACKET ) )  ) ; 
                __context__.SourceCodeLine = 439;
                _SplusNVRAM.STRASH  .UpdateValue ( Functions.Remove ( (_SplusNVRAM.IPACKET + 5), FROM_LOCK )  ) ; 
                __context__.SourceCodeLine = 440;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 442;
                    MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 443;
                    IS_UNLOCKED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 444;
                    IS_LOCKED  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 445;
                    _SplusNVRAM.ILOCKSTATUS = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 446;
                    LOCKED_REASON_VAL  .Value = (ushort) ( Byte( _SplusNVRAM.SPARAMETERS , (int)( 1 ) ) ) ; 
                    __context__.SourceCodeLine = 447;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOCKED_REASON_VAL  .Value == 4))  ) ) 
                        {
                        __context__.SourceCodeLine = 448;
                        LOCKED_SLOT_NUM_VAL  .Value = (ushort) ( Byte( _SplusNVRAM.SPARAMETERS , (int)( 2 ) ) ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 450;
                        LOCKED_SLOT_NUM_VAL  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 451;
                    LOCKEVENT (  __context__ , (ushort)( _SplusNVRAM.ILOCKSTATUS ), (ushort)( LOCKED_REASON_VAL  .Value ), (ushort)( LOCKED_SLOT_NUM_VAL  .Value )) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 453;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 2))  ) ) 
                        { 
                        __context__.SourceCodeLine = 455;
                        MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 456;
                        IS_LOCKED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 457;
                        IS_UNLOCKED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 458;
                        _SplusNVRAM.ILOCKSTATUS = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 459;
                        UNLOCKED_REASON_VAL  .Value = (ushort) ( Byte( _SplusNVRAM.SPARAMETERS , (int)( 1 ) ) ) ; 
                        __context__.SourceCodeLine = 460;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UNLOCKED_REASON_VAL  .Value == 4))  ) ) 
                            {
                            __context__.SourceCodeLine = 461;
                            UNLOCKED_SLOT_NUM_VAL  .Value = (ushort) ( Byte( _SplusNVRAM.SPARAMETERS , (int)( 2 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 463;
                            UNLOCKED_SLOT_NUM_VAL  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 464;
                        LOCKEVENT (  __context__ , (ushort)( _SplusNVRAM.ILOCKSTATUS ), (ushort)( UNLOCKED_REASON_VAL  .Value ), (ushort)( UNLOCKED_SLOT_NUM_VAL  .Value )) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 466;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 25))  ) ) 
                            { 
                            __context__.SourceCodeLine = 468;
                            MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 469;
                            PARAMETER_CHANGED  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 470;
                            PARAMETER_REPORT  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 471;
                            PARAMETER_REPORT  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 472;
                            while ( Functions.TestForTrue  ( ( Functions.Length( _SplusNVRAM.SPARAMETERS ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 474;
                                _SplusNVRAM.IPARAMETER = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                __context__.SourceCodeLine = 475;
                                switch ((int)_SplusNVRAM.IPARAMETER)
                                
                                    { 
                                    case 1 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 479;
                                        SILENT_MODE_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 480;
                                        break ; 
                                        } 
                                    
                                    goto case 2 ;
                                    case 2 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 484;
                                        AUTO_RELOCK_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 485;
                                        break ; 
                                        } 
                                    
                                    goto case 3 ;
                                    case 3 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 489;
                                        _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 490;
                                        AUTO_RELOCK_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ) + "s"  ) ; 
                                        __context__.SourceCodeLine = 491;
                                        break ; 
                                        } 
                                    
                                    goto case 4 ;
                                    case 4 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 495;
                                        _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 496;
                                        WRONG_CODE_LIMIT_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) )  ) ; 
                                        __context__.SourceCodeLine = 497;
                                        break ; 
                                        } 
                                    
                                    goto case 5 ;
                                    case 5 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 501;
                                        LANGUAGE_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 502;
                                        break ; 
                                        } 
                                    
                                    goto case 7 ;
                                    case 7 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 506;
                                        _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 507;
                                        SHUT_DOWN_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ) + "s"  ) ; 
                                        __context__.SourceCodeLine = 508;
                                        break ; 
                                        } 
                                    
                                    goto case 8 ;
                                    case 8 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 512;
                                        OPERATING_MODE_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 513;
                                        break ; 
                                        } 
                                    
                                    goto case 10 ;
                                    case 10 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 517;
                                        LOOP_TEST_MODE_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 518;
                                        break ; 
                                        } 
                                    
                                    goto case 11 ;
                                    case 11 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 522;
                                        ONE_TOUCH_LOCKING_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 523;
                                        break ; 
                                        } 
                                    
                                    goto case 12 ;
                                    case 12 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 527;
                                        PRIVACY_MODE_BUTTON_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 528;
                                        break ; 
                                        } 
                                    
                                    goto case 13 ;
                                    case 13 : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 532;
                                        INSIDE_COVER_LED_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 533;
                                        break ; 
                                        } 
                                    
                                    goto default;
                                    default : 
                                    
                                        { 
                                        __context__.SourceCodeLine = 537;
                                        _SplusNVRAM.STRASH  .UpdateValue ( Functions.Remove ( 1, _SplusNVRAM.SPARAMETERS )  ) ; 
                                        } 
                                    break;
                                    
                                    } 
                                    
                                
                                __context__.SourceCodeLine = 472;
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 542;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 27))  ) ) 
                                { 
                                __context__.SourceCodeLine = 544;
                                MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 545;
                                _SplusNVRAM.ILOCKTYPE = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                __context__.SourceCodeLine = 546;
                                
                                    {
                                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)_SplusNVRAM.ILOCKTYPE);
                                    
                                        { 
                                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 549;
                                            LOCK_TYPE_TEXT  .UpdateValue ( "Cap touch lever"  ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 551;
                                            LOCK_TYPE_TEXT  .UpdateValue ( "Cap touch deadbolt"  ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 553;
                                            LOCK_TYPE_TEXT  .UpdateValue ( "Keypad lever"  ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 555;
                                            LOCK_TYPE_TEXT  .UpdateValue ( "Keypad deadbolt"  ) ; 
                                            }
                                        
                                        } 
                                        
                                    }
                                    
                                
                                __context__.SourceCodeLine = 557;
                                _SplusNVRAM.SLOCKPRODUCTID  .UpdateValue ( Functions.Remove ( 4, _SplusNVRAM.SPARAMETERS )  ) ; 
                                __context__.SourceCodeLine = 558;
                                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                ushort __FN_FOREND_VAL__1 = (ushort)4; 
                                int __FN_FORSTEP_VAL__1 = (int)1; 
                                for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                                    {
                                    __context__.SourceCodeLine = 559;
                                    MakeString ( _SplusNVRAM.SLOCKPRODUCTID , "{0}{1}", _SplusNVRAM.SLOCKPRODUCTID , Functions.ItoHex (  (int) ( Functions.GetC( _SplusNVRAM.SLOCKPRODUCTID ) ) ) ) ; 
                                    __context__.SourceCodeLine = 558;
                                    }
                                
                                __context__.SourceCodeLine = 560;
                                LOCK_PRODUCT_ID_TEXT  .UpdateValue ( _SplusNVRAM.SLOCKPRODUCTID  ) ; 
                                __context__.SourceCodeLine = 561;
                                MakeString ( LOCK_FIRMWARE_VERSION_TEXT , "{0:d}.{1:d}", (short)(Byte( _SplusNVRAM.SPARAMETERS , (int)( 1 ) ) / 16), (short)Mod( Byte( _SplusNVRAM.SPARAMETERS , (int)( 1 ) ) , 16 )) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 563;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 65))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 565;
                                    MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 566;
                                    _SplusNVRAM.IADDEDSLOTNUMVAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                    __context__.SourceCodeLine = 567;
                                    _SplusNVRAM.ISLOTNUMSTATUS = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                    __context__.SourceCodeLine = 568;
                                    USEREVENT (  __context__ , (ushort)( 1 ), (ushort)( _SplusNVRAM.IADDEDSLOTNUMVAL ), (ushort)( _SplusNVRAM.ISLOTNUMSTATUS ), _SplusNVRAM.SPARAMETERS) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 570;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 66))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 572;
                                        MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                                        __context__.SourceCodeLine = 573;
                                        _SplusNVRAM.IDELETEDSLOTNUMVAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                        __context__.SourceCodeLine = 574;
                                        USEREVENT (  __context__ , (ushort)( 2 ), (ushort)( _SplusNVRAM.IDELETEDSLOTNUMVAL ), (ushort)( 0 ), "") ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 576;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 67))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 578;
                                            MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                                            __context__.SourceCodeLine = 579;
                                            _SplusNVRAM.ISLOTNUMVAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                            __context__.SourceCodeLine = 579;
                                            ; 
                                            __context__.SourceCodeLine = 580;
                                            _SplusNVRAM.IREPORTSLOTNUMVAL = (ushort) ( _SplusNVRAM.ISLOTNUMVAL ) ; 
                                            __context__.SourceCodeLine = 581;
                                            _SplusNVRAM.ISLOTNUMSTATUS = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                            __context__.SourceCodeLine = 582;
                                            USEREVENT (  __context__ , (ushort)( 3 ), (ushort)( _SplusNVRAM.IREPORTSLOTNUMVAL ), (ushort)( _SplusNVRAM.ISLOTNUMSTATUS ), _SplusNVRAM.SPARAMETERS) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 584;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 68))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 586;
                                                MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 1 ) ; 
                                                __context__.SourceCodeLine = 587;
                                                LOCK_EVENT_TEXT  .UpdateValue ( "Master PIN has been changed"  ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 589;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IEVENT == 129))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 591;
                                                    MASTER_PIN_CODE_WAS_CHANGED  .Value = (ushort) ( 0 ) ; 
                                                    __context__.SourceCodeLine = 592;
                                                    ALARM_STATUS  .Value = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                                    __context__.SourceCodeLine = 593;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ALARM_STATUS  .Value == 113))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 595;
                                                        _SplusNVRAM.IALARMSLOTNUMVAL = (ushort) ( Functions.GetC( _SplusNVRAM.SPARAMETERS ) ) ; 
                                                        __context__.SourceCodeLine = 596;
                                                        USEREVENT (  __context__ , (ushort)( 4 ), (ushort)( _SplusNVRAM.IALARMSLOTNUMVAL ), (ushort)( 0 ), "") ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 599;
                                                        ALARMEVENT (  __context__ , (ushort)( ALARM_STATUS  .Value )) ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 600;
                                                    LOCKED_REASON_VAL  .Value = (ushort) ( 0 ) ; 
                                                    __context__.SourceCodeLine = 601;
                                                    UNLOCKED_REASON_VAL  .Value = (ushort) ( 0 ) ; 
                                                    } 
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 604;
            _SplusNVRAM.IPROCESSFROMLOCK = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LOCK_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 610;
        MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0001\u0000", Functions.Chr (  (int) ( 2 ) ) ) ; 
        __context__.SourceCodeLine = 611;
        TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UNLOCK_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 616;
        MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0002\u0000", Functions.Chr (  (int) ( 2 ) ) ) ; 
        __context__.SourceCodeLine = 617;
        TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TO_MODULE_USER_NUMBER_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 622;
        _SplusNVRAM.SSLOTNUMMANAGE  .UpdateValue ( TO_MODULE_USER_NUMBER  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TO_MODULE_USER_NAME_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 627;
        _SplusNVRAM.SUSERNAMEMANAGE  .UpdateValue ( TO_MODULE_USER_NAME  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TO_MODULE_USER_PIN_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 633;
        _SplusNVRAM.SPINMANAGE  .UpdateValue ( TO_MODULE_USER_PIN  ) ; 
        __context__.SourceCodeLine = 634;
        Functions.ClearBuffer ( _SplusNVRAM.SPINSENDMANAGE ) ; 
        __context__.SourceCodeLine = 635;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)(8 - Functions.Length( _SplusNVRAM.SPINMANAGE )); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 637;
            MakeString ( _SplusNVRAM.SPINSENDMANAGE , "{0}{1}", _SplusNVRAM.SPINSENDMANAGE , "\u0000" ) ; 
            __context__.SourceCodeLine = 635;
            } 
        
        __context__.SourceCodeLine = 639;
        MakeString ( _SplusNVRAM.SPINSENDMANAGE , "{0}{1}", _SplusNVRAM.SPINMANAGE , _SplusNVRAM.SPINSENDMANAGE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TO_MODULE_SET_USER_PIN_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 644;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) < 251 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( _SplusNVRAM.SPINMANAGE ) > 3 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 646;
            MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0012\u000A{1}\u0001{2}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) ) ) , _SplusNVRAM.SPINSENDMANAGE ) ; 
            __context__.SourceCodeLine = 647;
            TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
            __context__.SourceCodeLine = 648;
            _SplusNVRAM.SUSERNAME [ Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) ]  .UpdateValue ( _SplusNVRAM.SUSERNAMEMANAGE  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TO_MODULE_USER_DELETE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 654;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) < 251 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 656;
            MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0013\u0001{1}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) ) ) ) ; 
            __context__.SourceCodeLine = 657;
            TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
            __context__.SourceCodeLine = 658;
            Functions.ClearBuffer ( _SplusNVRAM.SUSERNAME [ Functions.Atoi( _SplusNVRAM.SSLOTNUMMANAGE ) ] ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_CONFIGURATION_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 664;
        MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0019\u0000", Functions.Chr (  (int) ( 2 ) ) ) ; 
        __context__.SourceCodeLine = 665;
        TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_BATTERY_LEVEL_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 670;
        MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u001A\u0000", Functions.Chr (  (int) ( 2 ) ) ) ; 
        __context__.SourceCodeLine = 671;
        TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_PRODUCT_INFO_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 676;
        MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u001B\u0000", Functions.Chr (  (int) ( 2 ) ) ) ; 
        __context__.SourceCodeLine = 677;
        TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_SILENT_MODE_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 682;
        _SplusNVRAM.IPARAMETERFLAG [ 1] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 683;
        SILENT_MODE_STATUS  .Value = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 684;
        _SplusNVRAM.IPARAMETERVALUE [ 1] = (ushort) ( SILENT_MODE_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 685;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_AUTO_RELOCK_MODE_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 690;
        _SplusNVRAM.IPARAMETERFLAG [ 2] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 691;
        
            {
            int __SPLS_TMPVAR__SWTCH_2__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 694;
                    AUTO_RELOCK_STATUS  .Value = (ushort) ( 255 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 696;
                    AUTO_RELOCK_STATUS  .Value = (ushort) ( 0 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 698;
        _SplusNVRAM.IPARAMETERVALUE [ 2] = (ushort) ( AUTO_RELOCK_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 699;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_RELOCK_TIME_UP_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 704;
        _SplusNVRAM.IPARAMETERFLAG [ 3] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 705;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 706;
        CANCELVALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 707;
        VALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 708;
        while ( Functions.TestForTrue  ( ( SET_RELOCK_TIME_UP  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 710;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL > 255 ))  ) ) 
                {
                __context__.SourceCodeLine = 711;
                _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( 255 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 712;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL < 255 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 713;
                    _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( (_SplusNVRAM.AUTO_RELOCK_TIME_VAL + 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 714;
            AUTO_RELOCK_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ) + "s"  ) ; 
            __context__.SourceCodeLine = 715;
            Functions.Delay (  (int) ( _SplusNVRAM.IDELAY ) ) ; 
            __context__.SourceCodeLine = 708;
            } 
        
        __context__.SourceCodeLine = 717;
        _SplusNVRAM.IPARAMETERVALUE [ 3] = (ushort) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_RELOCK_TIME_DOWN_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 722;
        _SplusNVRAM.IPARAMETERFLAG [ 3] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 723;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 724;
        CANCELVALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 725;
        VALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 726;
        while ( Functions.TestForTrue  ( ( SET_RELOCK_TIME_DOWN  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 728;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL < 5 ))  ) ) 
                {
                __context__.SourceCodeLine = 729;
                _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( 5 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 730;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL > 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 731;
                    _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( (_SplusNVRAM.AUTO_RELOCK_TIME_VAL - 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 732;
            AUTO_RELOCK_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ) + "s"  ) ; 
            __context__.SourceCodeLine = 733;
            Functions.Delay (  (int) ( _SplusNVRAM.IDELAY ) ) ; 
            __context__.SourceCodeLine = 726;
            } 
        
        __context__.SourceCodeLine = 735;
        _SplusNVRAM.IPARAMETERVALUE [ 3] = (ushort) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_RELOCK_TIME_IN_OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 740;
        _SplusNVRAM.IPARAMETERFLAG [ 3] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 741;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 742;
        _SplusNVRAM.AUTO_RELOCK_TIME_VAL = (ushort) ( SET_RELOCK_TIME_IN  .UshortValue ) ; 
        __context__.SourceCodeLine = 743;
        AUTO_RELOCK_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ) + "s"  ) ; 
        __context__.SourceCodeLine = 744;
        _SplusNVRAM.IPARAMETERVALUE [ 3] = (ushort) ( _SplusNVRAM.AUTO_RELOCK_TIME_VAL ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_WRONG_CODE_LIMIT_UP_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 749;
        _SplusNVRAM.IPARAMETERFLAG [ 4] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 750;
        while ( Functions.TestForTrue  ( ( SET_WRONG_CODE_LIMIT_UP  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 752;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL > 7 ))  ) ) 
                {
                __context__.SourceCodeLine = 753;
                _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( 7 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 754;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL < 7 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 755;
                    _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( (_SplusNVRAM.WRONG_CODE_LIMIT_VAL + 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 756;
            WRONG_CODE_LIMIT_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) )  ) ; 
            __context__.SourceCodeLine = 757;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 750;
            } 
        
        __context__.SourceCodeLine = 759;
        _SplusNVRAM.IPARAMETERVALUE [ 4] = (ushort) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) ; 
        __context__.SourceCodeLine = 760;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_WRONG_CODE_LIMIT_DOWN_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 765;
        _SplusNVRAM.IPARAMETERFLAG [ 4] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 766;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 767;
        while ( Functions.TestForTrue  ( ( SET_WRONG_CODE_LIMIT_DOWN  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 769;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL < 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 770;
                _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 771;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL > 1 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 772;
                    _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( (_SplusNVRAM.WRONG_CODE_LIMIT_VAL - 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 773;
            WRONG_CODE_LIMIT_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) )  ) ; 
            __context__.SourceCodeLine = 774;
            Functions.Delay (  (int) ( 20 ) ) ; 
            __context__.SourceCodeLine = 767;
            } 
        
        __context__.SourceCodeLine = 776;
        _SplusNVRAM.IPARAMETERVALUE [ 4] = (ushort) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_WRONG_CODE_LIMIT_IN_OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 782;
        _SplusNVRAM.IPARAMETERFLAG [ 4] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 783;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 784;
        _SplusNVRAM.WRONG_CODE_LIMIT_VAL = (ushort) ( SET_WRONG_CODE_LIMIT_IN  .UshortValue ) ; 
        __context__.SourceCodeLine = 785;
        WRONG_CODE_LIMIT_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) )  ) ; 
        __context__.SourceCodeLine = 786;
        _SplusNVRAM.IPARAMETERVALUE [ 4] = (ushort) ( _SplusNVRAM.WRONG_CODE_LIMIT_VAL ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_LANGUAGE_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 791;
        _SplusNVRAM.IPARAMETERFLAG [ 5] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 792;
        LANGUAGE_STATUS  .Value = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 793;
        _SplusNVRAM.IPARAMETERVALUE [ 5] = (ushort) ( LANGUAGE_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 794;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_SHUT_DOWN_TIME_UP_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 799;
        _SplusNVRAM.IPARAMETERFLAG [ 7] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 800;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 801;
        CANCELVALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 802;
        VALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 803;
        while ( Functions.TestForTrue  ( ( SET_SHUT_DOWN_TIME_UP  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 805;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE > 255 ))  ) ) 
                {
                __context__.SourceCodeLine = 806;
                _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( 255 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 807;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE < 255 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 808;
                    _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( (_SplusNVRAM.SHUT_DOWN_TIME_VALUE + 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 809;
            SHUT_DOWN_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ) + "s"  ) ; 
            __context__.SourceCodeLine = 810;
            Functions.Delay (  (int) ( _SplusNVRAM.IDELAY ) ) ; 
            __context__.SourceCodeLine = 803;
            } 
        
        __context__.SourceCodeLine = 812;
        _SplusNVRAM.IPARAMETERVALUE [ 7] = (ushort) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_SHUT_DOWN_TIME_DOWN_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 817;
        _SplusNVRAM.IPARAMETERFLAG [ 7] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 818;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 819;
        CANCELVALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 820;
        VALUEINCREMENT (  __context__  ) ; 
        __context__.SourceCodeLine = 821;
        while ( Functions.TestForTrue  ( ( SET_SHUT_DOWN_TIME_DOWN  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 823;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE < 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 824;
                _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 825;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE > 1 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 826;
                    _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( (_SplusNVRAM.SHUT_DOWN_TIME_VALUE - 1) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 827;
            SHUT_DOWN_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ) + "s"  ) ; 
            __context__.SourceCodeLine = 828;
            Functions.Delay (  (int) ( _SplusNVRAM.IDELAY ) ) ; 
            __context__.SourceCodeLine = 821;
            } 
        
        __context__.SourceCodeLine = 830;
        _SplusNVRAM.IPARAMETERVALUE [ 7] = (ushort) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_SHUT_DOWN_TIME_IN_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 835;
        _SplusNVRAM.IPARAMETERFLAG [ 7] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 836;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 837;
        _SplusNVRAM.SHUT_DOWN_TIME_VALUE = (ushort) ( SET_SHUT_DOWN_TIME_IN  .UshortValue ) ; 
        __context__.SourceCodeLine = 838;
        SHUT_DOWN_TIME_TEXT  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ) + "s"  ) ; 
        __context__.SourceCodeLine = 839;
        _SplusNVRAM.IPARAMETERVALUE [ 7] = (ushort) ( _SplusNVRAM.SHUT_DOWN_TIME_VALUE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_OPERATING_MODE_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 844;
        _SplusNVRAM.IPARAMETERFLAG [ 8] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 845;
        
            {
            int __SPLS_TMPVAR__SWTCH_3__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 848;
                    OPERATING_MODE_STATUS  .Value = (ushort) ( 0 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 850;
                    OPERATING_MODE_STATUS  .Value = (ushort) ( 1 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 852;
                    OPERATING_MODE_STATUS  .Value = (ushort) ( 2 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 854;
                    OPERATING_MODE_STATUS  .Value = (ushort) ( 3 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 856;
        _SplusNVRAM.IPARAMETERVALUE [ 8] = (ushort) ( OPERATING_MODE_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 857;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_ONE_TOUCH_LOCKING_MODE_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 862;
        _SplusNVRAM.IPARAMETERFLAG [ 11] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 863;
        
            {
            int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 866;
                    ONE_TOUCH_LOCKING_STATUS  .Value = (ushort) ( 255 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 868;
                    ONE_TOUCH_LOCKING_STATUS  .Value = (ushort) ( 0 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 870;
        _SplusNVRAM.IPARAMETERVALUE [ 11] = (ushort) ( ONE_TOUCH_LOCKING_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 871;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_PRIVACY_MODE_BUTTON_MODE_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 876;
        _SplusNVRAM.IPARAMETERFLAG [ 12] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 877;
        
            {
            int __SPLS_TMPVAR__SWTCH_5__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 880;
                    PRIVACY_MODE_BUTTON_STATUS  .Value = (ushort) ( 255 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 882;
                    PRIVACY_MODE_BUTTON_STATUS  .Value = (ushort) ( 0 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 884;
        _SplusNVRAM.IPARAMETERVALUE [ 12] = (ushort) ( PRIVACY_MODE_BUTTON_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 885;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_INSIDE_COVER_LED_MODE_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 890;
        _SplusNVRAM.IPARAMETERFLAG [ 13] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 891;
        
            {
            int __SPLS_TMPVAR__SWTCH_6__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 894;
                    INSIDE_COVER_LED_STATUS  .Value = (ushort) ( 255 ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 896;
                    INSIDE_COVER_LED_STATUS  .Value = (ushort) ( 0 ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 898;
        _SplusNVRAM.IPARAMETERVALUE [ 13] = (ushort) ( INSIDE_COVER_LED_STATUS  .Value ) ; 
        __context__.SourceCodeLine = 899;
        PARAMETER_CHANGED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SEND_PARAMETERS_UPDATE_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 908;
        Functions.ClearBuffer ( _SplusNVRAM.SSETPARAMETERDATA ) ; 
        __context__.SourceCodeLine = 909;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PARAMETER_CHANGED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 911;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)13; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 913;
                if ( Functions.TestForTrue  ( ( _SplusNVRAM.IPARAMETERFLAG[ A ])  ) ) 
                    {
                    __context__.SourceCodeLine = 914;
                    MakeString ( _SplusNVRAM.SSETPARAMETERDATA , "{0}{1}{2}", _SplusNVRAM.SSETPARAMETERDATA , Functions.Chr (  (int) ( A ) ) , Functions.Chr (  (int) ( _SplusNVRAM.IPARAMETERVALUE[ A ] ) ) ) ; 
                    }
                
                __context__.SourceCodeLine = 915;
                _SplusNVRAM.IPARAMETERFLAG [ A] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 911;
                } 
            
            __context__.SourceCodeLine = 918;
            MakeString ( _SplusNVRAM.SSTRINGTOSEND , "{0}\u0000\u0000\u0018{1}{2}", Functions.Chr (  (int) ( 2 ) ) , Functions.Chr (  (int) ( Functions.Length( _SplusNVRAM.SSETPARAMETERDATA ) ) ) , _SplusNVRAM.SSETPARAMETERDATA ) ; 
            __context__.SourceCodeLine = 919;
            TO_LOCK  .UpdateValue ( _SplusNVRAM.SSTRINGTOSEND  ) ; 
            __context__.SourceCodeLine = 920;
            PARAMETER_CHANGED  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object USER_NUMBER_TEXT_IN_OnChange_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort A = 0;
        
        ushort IINVALID = 0;
        
        
        __context__.SourceCodeLine = 929;
        IINVALID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 930;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( USER_NUMBER_TEXT_IN ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 932;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Byte( USER_NUMBER_TEXT_IN , (int)( A ) ) < 48 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( Byte( USER_NUMBER_TEXT_IN , (int)( A ) ) > 57 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 934;
                IINVALID = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 935;
                break ; 
                } 
            
            __context__.SourceCodeLine = 930;
            } 
        
        __context__.SourceCodeLine = 938;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINVALID == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 940;
            USER_EVENT_TEXT  .UpdateValue ( "PIN must be a number"  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 942;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( USER_NUMBER_TEXT_IN ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Atoi( USER_NUMBER_TEXT_IN ) <= 20 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 944;
                _SplusNVRAM.IUSERNUMBERIN = (ushort) ( Functions.Atoi( USER_NUMBER_TEXT_IN ) ) ; 
                __context__.SourceCodeLine = 945;
                GETUSERNUMBERSTATUS (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 948;
                USER_EVENT_TEXT  .UpdateValue ( "Please select a User ID between 1 and " + Functions.ItoA (  (int) ( 20 ) )  ) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object USER_NAME_TEXT_IN_OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 953;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IUSERNUMBERIN != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 955;
            _SplusNVRAM.SUSERNAME [ _SplusNVRAM.IUSERNUMBERIN ]  .UpdateValue ( USER_NAME_TEXT_IN  ) ; 
            __context__.SourceCodeLine = 956;
            GETUSERNUMBERSTATUS (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object USER_PIN_TEXT_IN_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IINVALID = 0;
        
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 965;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IUSERNUMBERIN != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 967;
            IINVALID = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 968;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( USER_PIN_TEXT_IN ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 970;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Byte( USER_PIN_TEXT_IN , (int)( A ) ) < 48 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( Byte( USER_PIN_TEXT_IN , (int)( A ) ) > 57 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 972;
                    IINVALID = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 973;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 968;
                } 
            
            __context__.SourceCodeLine = 976;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( USER_PIN_TEXT_IN ) > 8 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( USER_PIN_TEXT_IN ) < 4 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 977;
                IINVALID = (ushort) ( 1 ) ; 
                }
            
            __context__.SourceCodeLine = 978;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IINVALID == 1))  ) ) 
                {
                __context__.SourceCodeLine = 979;
                USER_EVENT_TEXT  .UpdateValue ( "PIN must have 4-8 digits"  ) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 982;
                SETPIN (  __context__ , USER_PIN_TEXT_IN) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTED_USER_DELETE_OnPush_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 989;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IUSERNUMBERIN != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 991;
            Functions.ClearBuffer ( _SplusNVRAM.SUSERNAME [ _SplusNVRAM.IUSERNUMBERIN ] ) ; 
            __context__.SourceCodeLine = 992;
            DELETEUSER (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            __context__.SourceCodeLine = 993;
            GETUSERNUMBERSTATUS (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTED_USER_ENABLE_OnPush_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 999;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IUSERNUMBERIN != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1001;
            ENABLEUSER (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            __context__.SourceCodeLine = 1002;
            GETUSERNUMBERSTATUS (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECTED_USER_DISABLE_OnPush_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1008;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IUSERNUMBERIN != 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1010;
            DISABLEUSER (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            __context__.SourceCodeLine = 1011;
            GETUSERNUMBERSTATUS (  __context__ , (ushort)( _SplusNVRAM.IUSERNUMBERIN )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_USER_SETTINGS_OnPush_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1017;
        _SplusNVRAM.IUSERNUMBERIN = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1018;
        USER_NUMBER_TEXT_OUT  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 1019;
        USER_NAME_TEXT_OUT  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 1020;
        USER_PIN_TEXT_OUT  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 1021;
        USER_IS_DISABLED  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1022;
        USER_IS_ENABLED  .Value = (ushort) ( 0 ) ; 
        
        
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
        
        __context__.SourceCodeLine = 1036;
        _SplusNVRAM.IPROCESSFROMLOCK = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.IPARAMETERFLAG  = new ushort[ 14 ];
    _SplusNVRAM.IPARAMETERVALUE  = new ushort[ 14 ];
    _SplusNVRAM.SPARAMETERS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 33, this );
    _SplusNVRAM.SSTRINGTOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 33, this );
    _SplusNVRAM.SSLOTNUM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    _SplusNVRAM.SPIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SPINSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SSETPARAMETERDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 23, this );
    _SplusNVRAM.STRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 53, this );
    _SplusNVRAM.SPINTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SLOCKPRODUCTID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SSLOTNUMHOLD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    _SplusNVRAM.SSLOTNUMMANAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    _SplusNVRAM.SPINMANAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SPINSENDMANAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.SUSERNAMEMANAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    _SplusNVRAM.SUSERNAME  = new CrestronString[ 251 ];
    for( uint i = 0; i < 251; i++ )
        _SplusNVRAM.SUSERNAME [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    LOCK = new Crestron.Logos.SplusObjects.DigitalInput( LOCK__DigitalInput__, this );
    m_DigitalInputList.Add( LOCK__DigitalInput__, LOCK );
    
    UNLOCK = new Crestron.Logos.SplusObjects.DigitalInput( UNLOCK__DigitalInput__, this );
    m_DigitalInputList.Add( UNLOCK__DigitalInput__, UNLOCK );
    
    SELECTED_USER_DELETE = new Crestron.Logos.SplusObjects.DigitalInput( SELECTED_USER_DELETE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTED_USER_DELETE__DigitalInput__, SELECTED_USER_DELETE );
    
    GET_CONFIGURATION = new Crestron.Logos.SplusObjects.DigitalInput( GET_CONFIGURATION__DigitalInput__, this );
    m_DigitalInputList.Add( GET_CONFIGURATION__DigitalInput__, GET_CONFIGURATION );
    
    GET_BATTERY_LEVEL = new Crestron.Logos.SplusObjects.DigitalInput( GET_BATTERY_LEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( GET_BATTERY_LEVEL__DigitalInput__, GET_BATTERY_LEVEL );
    
    GET_PRODUCT_INFO = new Crestron.Logos.SplusObjects.DigitalInput( GET_PRODUCT_INFO__DigitalInput__, this );
    m_DigitalInputList.Add( GET_PRODUCT_INFO__DigitalInput__, GET_PRODUCT_INFO );
    
    SET_RELOCK_TIME_UP = new Crestron.Logos.SplusObjects.DigitalInput( SET_RELOCK_TIME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( SET_RELOCK_TIME_UP__DigitalInput__, SET_RELOCK_TIME_UP );
    
    SET_RELOCK_TIME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( SET_RELOCK_TIME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( SET_RELOCK_TIME_DOWN__DigitalInput__, SET_RELOCK_TIME_DOWN );
    
    SET_WRONG_CODE_LIMIT_UP = new Crestron.Logos.SplusObjects.DigitalInput( SET_WRONG_CODE_LIMIT_UP__DigitalInput__, this );
    m_DigitalInputList.Add( SET_WRONG_CODE_LIMIT_UP__DigitalInput__, SET_WRONG_CODE_LIMIT_UP );
    
    SET_WRONG_CODE_LIMIT_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( SET_WRONG_CODE_LIMIT_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( SET_WRONG_CODE_LIMIT_DOWN__DigitalInput__, SET_WRONG_CODE_LIMIT_DOWN );
    
    SET_SHUT_DOWN_TIME_UP = new Crestron.Logos.SplusObjects.DigitalInput( SET_SHUT_DOWN_TIME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( SET_SHUT_DOWN_TIME_UP__DigitalInput__, SET_SHUT_DOWN_TIME_UP );
    
    SET_SHUT_DOWN_TIME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( SET_SHUT_DOWN_TIME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( SET_SHUT_DOWN_TIME_DOWN__DigitalInput__, SET_SHUT_DOWN_TIME_DOWN );
    
    SEND_PARAMETERS_UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( SEND_PARAMETERS_UPDATE__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_PARAMETERS_UPDATE__DigitalInput__, SEND_PARAMETERS_UPDATE );
    
    SELECTED_USER_ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( SELECTED_USER_ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTED_USER_ENABLE__DigitalInput__, SELECTED_USER_ENABLE );
    
    SELECTED_USER_DISABLE = new Crestron.Logos.SplusObjects.DigitalInput( SELECTED_USER_DISABLE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECTED_USER_DISABLE__DigitalInput__, SELECTED_USER_DISABLE );
    
    CLEAR_USER_SETTINGS = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR_USER_SETTINGS__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR_USER_SETTINGS__DigitalInput__, CLEAR_USER_SETTINGS );
    
    TO_MODULE_SET_USER_PIN = new Crestron.Logos.SplusObjects.DigitalInput( TO_MODULE_SET_USER_PIN__DigitalInput__, this );
    m_DigitalInputList.Add( TO_MODULE_SET_USER_PIN__DigitalInput__, TO_MODULE_SET_USER_PIN );
    
    TO_MODULE_USER_DELETE = new Crestron.Logos.SplusObjects.DigitalInput( TO_MODULE_USER_DELETE__DigitalInput__, this );
    m_DigitalInputList.Add( TO_MODULE_USER_DELETE__DigitalInput__, TO_MODULE_USER_DELETE );
    
    SET_SILENT_MODE = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SET_SILENT_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_SILENT_MODE__DigitalInput__ + i, SET_SILENT_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_SILENT_MODE__DigitalInput__ + i, SET_SILENT_MODE[i+1] );
    }
    
    SET_AUTO_RELOCK_MODE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SET_AUTO_RELOCK_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_AUTO_RELOCK_MODE__DigitalInput__ + i, SET_AUTO_RELOCK_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_AUTO_RELOCK_MODE__DigitalInput__ + i, SET_AUTO_RELOCK_MODE[i+1] );
    }
    
    SET_LANGUAGE = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SET_LANGUAGE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_LANGUAGE__DigitalInput__ + i, SET_LANGUAGE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_LANGUAGE__DigitalInput__ + i, SET_LANGUAGE[i+1] );
    }
    
    SET_OPERATING_MODE = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SET_OPERATING_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_OPERATING_MODE__DigitalInput__ + i, SET_OPERATING_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_OPERATING_MODE__DigitalInput__ + i, SET_OPERATING_MODE[i+1] );
    }
    
    SET_ONE_TOUCH_LOCKING_MODE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SET_ONE_TOUCH_LOCKING_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_ONE_TOUCH_LOCKING_MODE__DigitalInput__ + i, SET_ONE_TOUCH_LOCKING_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_ONE_TOUCH_LOCKING_MODE__DigitalInput__ + i, SET_ONE_TOUCH_LOCKING_MODE[i+1] );
    }
    
    SET_PRIVACY_MODE_BUTTON_MODE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SET_PRIVACY_MODE_BUTTON_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_PRIVACY_MODE_BUTTON_MODE__DigitalInput__ + i, SET_PRIVACY_MODE_BUTTON_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_PRIVACY_MODE_BUTTON_MODE__DigitalInput__ + i, SET_PRIVACY_MODE_BUTTON_MODE[i+1] );
    }
    
    SET_INSIDE_COVER_LED_MODE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        SET_INSIDE_COVER_LED_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SET_INSIDE_COVER_LED_MODE__DigitalInput__ + i, SET_INSIDE_COVER_LED_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( SET_INSIDE_COVER_LED_MODE__DigitalInput__ + i, SET_INSIDE_COVER_LED_MODE[i+1] );
    }
    
    IS_UNLOCKED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_UNLOCKED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_UNLOCKED__DigitalOutput__, IS_UNLOCKED );
    
    IS_LOCKED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_LOCKED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_LOCKED__DigitalOutput__, IS_LOCKED );
    
    MASTER_PIN_CODE_WAS_CHANGED = new Crestron.Logos.SplusObjects.DigitalOutput( MASTER_PIN_CODE_WAS_CHANGED__DigitalOutput__, this );
    m_DigitalOutputList.Add( MASTER_PIN_CODE_WAS_CHANGED__DigitalOutput__, MASTER_PIN_CODE_WAS_CHANGED );
    
    SHOWING_PIN = new Crestron.Logos.SplusObjects.DigitalOutput( SHOWING_PIN__DigitalOutput__, this );
    m_DigitalOutputList.Add( SHOWING_PIN__DigitalOutput__, SHOWING_PIN );
    
    HIDING_PIN = new Crestron.Logos.SplusObjects.DigitalOutput( HIDING_PIN__DigitalOutput__, this );
    m_DigitalOutputList.Add( HIDING_PIN__DigitalOutput__, HIDING_PIN );
    
    PARAMETER_CHANGED = new Crestron.Logos.SplusObjects.DigitalOutput( PARAMETER_CHANGED__DigitalOutput__, this );
    m_DigitalOutputList.Add( PARAMETER_CHANGED__DigitalOutput__, PARAMETER_CHANGED );
    
    PARAMETER_REPORT = new Crestron.Logos.SplusObjects.DigitalOutput( PARAMETER_REPORT__DigitalOutput__, this );
    m_DigitalOutputList.Add( PARAMETER_REPORT__DigitalOutput__, PARAMETER_REPORT );
    
    LOCK_STATUS_UPDATED = new Crestron.Logos.SplusObjects.DigitalOutput( LOCK_STATUS_UPDATED__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOCK_STATUS_UPDATED__DigitalOutput__, LOCK_STATUS_UPDATED );
    
    USER_IS_ENABLED = new Crestron.Logos.SplusObjects.DigitalOutput( USER_IS_ENABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( USER_IS_ENABLED__DigitalOutput__, USER_IS_ENABLED );
    
    USER_IS_DISABLED = new Crestron.Logos.SplusObjects.DigitalOutput( USER_IS_DISABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( USER_IS_DISABLED__DigitalOutput__, USER_IS_DISABLED );
    
    SET_RELOCK_TIME_IN = new Crestron.Logos.SplusObjects.AnalogInput( SET_RELOCK_TIME_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SET_RELOCK_TIME_IN__AnalogSerialInput__, SET_RELOCK_TIME_IN );
    
    SET_WRONG_CODE_LIMIT_IN = new Crestron.Logos.SplusObjects.AnalogInput( SET_WRONG_CODE_LIMIT_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SET_WRONG_CODE_LIMIT_IN__AnalogSerialInput__, SET_WRONG_CODE_LIMIT_IN );
    
    SET_SHUT_DOWN_TIME_IN = new Crestron.Logos.SplusObjects.AnalogInput( SET_SHUT_DOWN_TIME_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SET_SHUT_DOWN_TIME_IN__AnalogSerialInput__, SET_SHUT_DOWN_TIME_IN );
    
    BATTERY_LEVEL_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( BATTERY_LEVEL_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( BATTERY_LEVEL_VAL__AnalogSerialOutput__, BATTERY_LEVEL_VAL );
    
    LOCKED_REASON_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( LOCKED_REASON_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LOCKED_REASON_VAL__AnalogSerialOutput__, LOCKED_REASON_VAL );
    
    LOCKED_SLOT_NUM_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( LOCKED_SLOT_NUM_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LOCKED_SLOT_NUM_VAL__AnalogSerialOutput__, LOCKED_SLOT_NUM_VAL );
    
    UNLOCKED_REASON_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( UNLOCKED_REASON_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( UNLOCKED_REASON_VAL__AnalogSerialOutput__, UNLOCKED_REASON_VAL );
    
    UNLOCKED_SLOT_NUM_VAL = new Crestron.Logos.SplusObjects.AnalogOutput( UNLOCKED_SLOT_NUM_VAL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( UNLOCKED_SLOT_NUM_VAL__AnalogSerialOutput__, UNLOCKED_SLOT_NUM_VAL );
    
    SILENT_MODE_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( SILENT_MODE_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SILENT_MODE_STATUS__AnalogSerialOutput__, SILENT_MODE_STATUS );
    
    AUTO_RELOCK_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( AUTO_RELOCK_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AUTO_RELOCK_STATUS__AnalogSerialOutput__, AUTO_RELOCK_STATUS );
    
    LANGUAGE_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( LANGUAGE_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LANGUAGE_STATUS__AnalogSerialOutput__, LANGUAGE_STATUS );
    
    OPERATING_MODE_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( OPERATING_MODE_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( OPERATING_MODE_STATUS__AnalogSerialOutput__, OPERATING_MODE_STATUS );
    
    LOOP_TEST_MODE_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( LOOP_TEST_MODE_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LOOP_TEST_MODE_STATUS__AnalogSerialOutput__, LOOP_TEST_MODE_STATUS );
    
    ONE_TOUCH_LOCKING_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( ONE_TOUCH_LOCKING_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ONE_TOUCH_LOCKING_STATUS__AnalogSerialOutput__, ONE_TOUCH_LOCKING_STATUS );
    
    PRIVACY_MODE_BUTTON_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( PRIVACY_MODE_BUTTON_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( PRIVACY_MODE_BUTTON_STATUS__AnalogSerialOutput__, PRIVACY_MODE_BUTTON_STATUS );
    
    INSIDE_COVER_LED_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( INSIDE_COVER_LED_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( INSIDE_COVER_LED_STATUS__AnalogSerialOutput__, INSIDE_COVER_LED_STATUS );
    
    ALARM_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( ALARM_STATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ALARM_STATUS__AnalogSerialOutput__, ALARM_STATUS );
    
    TO_MODULE_USER_NUMBER = new Crestron.Logos.SplusObjects.StringInput( TO_MODULE_USER_NUMBER__AnalogSerialInput__, 3, this );
    m_StringInputList.Add( TO_MODULE_USER_NUMBER__AnalogSerialInput__, TO_MODULE_USER_NUMBER );
    
    TO_MODULE_USER_PIN = new Crestron.Logos.SplusObjects.StringInput( TO_MODULE_USER_PIN__AnalogSerialInput__, 8, this );
    m_StringInputList.Add( TO_MODULE_USER_PIN__AnalogSerialInput__, TO_MODULE_USER_PIN );
    
    TO_MODULE_USER_NAME = new Crestron.Logos.SplusObjects.StringInput( TO_MODULE_USER_NAME__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TO_MODULE_USER_NAME__AnalogSerialInput__, TO_MODULE_USER_NAME );
    
    FROM_LOCK = new Crestron.Logos.SplusObjects.StringInput( FROM_LOCK__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( FROM_LOCK__AnalogSerialInput__, FROM_LOCK );
    
    USER_NUMBER_TEXT_IN = new Crestron.Logos.SplusObjects.StringInput( USER_NUMBER_TEXT_IN__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( USER_NUMBER_TEXT_IN__AnalogSerialInput__, USER_NUMBER_TEXT_IN );
    
    USER_NAME_TEXT_IN = new Crestron.Logos.SplusObjects.StringInput( USER_NAME_TEXT_IN__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( USER_NAME_TEXT_IN__AnalogSerialInput__, USER_NAME_TEXT_IN );
    
    USER_PIN_TEXT_IN = new Crestron.Logos.SplusObjects.StringInput( USER_PIN_TEXT_IN__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( USER_PIN_TEXT_IN__AnalogSerialInput__, USER_PIN_TEXT_IN );
    
    BATTERY_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( BATTERY_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( BATTERY_LEVEL_TEXT__AnalogSerialOutput__, BATTERY_LEVEL_TEXT );
    
    AUTO_RELOCK_TIME_TEXT = new Crestron.Logos.SplusObjects.StringOutput( AUTO_RELOCK_TIME_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUTO_RELOCK_TIME_TEXT__AnalogSerialOutput__, AUTO_RELOCK_TIME_TEXT );
    
    WRONG_CODE_LIMIT_TEXT = new Crestron.Logos.SplusObjects.StringOutput( WRONG_CODE_LIMIT_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( WRONG_CODE_LIMIT_TEXT__AnalogSerialOutput__, WRONG_CODE_LIMIT_TEXT );
    
    SHUT_DOWN_TIME_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SHUT_DOWN_TIME_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SHUT_DOWN_TIME_TEXT__AnalogSerialOutput__, SHUT_DOWN_TIME_TEXT );
    
    LOCK_PRODUCT_ID_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LOCK_PRODUCT_ID_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LOCK_PRODUCT_ID_TEXT__AnalogSerialOutput__, LOCK_PRODUCT_ID_TEXT );
    
    LOCK_FIRMWARE_VERSION_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LOCK_FIRMWARE_VERSION_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LOCK_FIRMWARE_VERSION_TEXT__AnalogSerialOutput__, LOCK_FIRMWARE_VERSION_TEXT );
    
    SLOT_NUM_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SLOT_NUM_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SLOT_NUM_TEXT__AnalogSerialOutput__, SLOT_NUM_TEXT );
    
    PIN_TEXT = new Crestron.Logos.SplusObjects.StringOutput( PIN_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( PIN_TEXT__AnalogSerialOutput__, PIN_TEXT );
    
    LOCK_EVENT_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LOCK_EVENT_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LOCK_EVENT_TEXT__AnalogSerialOutput__, LOCK_EVENT_TEXT );
    
    USER_EVENT_TEXT = new Crestron.Logos.SplusObjects.StringOutput( USER_EVENT_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( USER_EVENT_TEXT__AnalogSerialOutput__, USER_EVENT_TEXT );
    
    ALARM_EVENT_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ALARM_EVENT_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ALARM_EVENT_TEXT__AnalogSerialOutput__, ALARM_EVENT_TEXT );
    
    LOCK_TYPE_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LOCK_TYPE_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LOCK_TYPE_TEXT__AnalogSerialOutput__, LOCK_TYPE_TEXT );
    
    CURRENT_STATUS_TEXT = new Crestron.Logos.SplusObjects.StringOutput( CURRENT_STATUS_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CURRENT_STATUS_TEXT__AnalogSerialOutput__, CURRENT_STATUS_TEXT );
    
    ALARM_STATUS_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ALARM_STATUS_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ALARM_STATUS_TEXT__AnalogSerialOutput__, ALARM_STATUS_TEXT );
    
    TO_LOCK = new Crestron.Logos.SplusObjects.StringOutput( TO_LOCK__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_LOCK__AnalogSerialOutput__, TO_LOCK );
    
    USER_NUMBER_TEXT_OUT = new Crestron.Logos.SplusObjects.StringOutput( USER_NUMBER_TEXT_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( USER_NUMBER_TEXT_OUT__AnalogSerialOutput__, USER_NUMBER_TEXT_OUT );
    
    USER_NAME_TEXT_OUT = new Crestron.Logos.SplusObjects.StringOutput( USER_NAME_TEXT_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( USER_NAME_TEXT_OUT__AnalogSerialOutput__, USER_NAME_TEXT_OUT );
    
    USER_PIN_TEXT_OUT = new Crestron.Logos.SplusObjects.StringOutput( USER_PIN_TEXT_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( USER_PIN_TEXT_OUT__AnalogSerialOutput__, USER_PIN_TEXT_OUT );
    
    LOCK_NAME = new StringParameter( LOCK_NAME__Parameter__, this );
    m_ParameterList.Add( LOCK_NAME__Parameter__, LOCK_NAME );
    
    INCREMENT1_Callback = new WaitFunction( INCREMENT1_CallbackFn );
    INCREMENT2_Callback = new WaitFunction( INCREMENT2_CallbackFn );
    
    FROM_LOCK.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_LOCK_OnChange_0, false ) );
    LOCK.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOCK_OnPush_1, false ) );
    UNLOCK.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNLOCK_OnPush_2, false ) );
    TO_MODULE_USER_NUMBER.OnSerialChange.Add( new InputChangeHandlerWrapper( TO_MODULE_USER_NUMBER_OnChange_3, false ) );
    TO_MODULE_USER_NAME.OnSerialChange.Add( new InputChangeHandlerWrapper( TO_MODULE_USER_NAME_OnChange_4, false ) );
    TO_MODULE_USER_PIN.OnSerialChange.Add( new InputChangeHandlerWrapper( TO_MODULE_USER_PIN_OnChange_5, false ) );
    TO_MODULE_SET_USER_PIN.OnDigitalPush.Add( new InputChangeHandlerWrapper( TO_MODULE_SET_USER_PIN_OnPush_6, false ) );
    TO_MODULE_USER_DELETE.OnDigitalPush.Add( new InputChangeHandlerWrapper( TO_MODULE_USER_DELETE_OnPush_7, false ) );
    GET_CONFIGURATION.OnDigitalPush.Add( new InputChangeHandlerWrapper( GET_CONFIGURATION_OnPush_8, false ) );
    GET_BATTERY_LEVEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( GET_BATTERY_LEVEL_OnPush_9, false ) );
    GET_PRODUCT_INFO.OnDigitalPush.Add( new InputChangeHandlerWrapper( GET_PRODUCT_INFO_OnPush_10, false ) );
    for( uint i = 0; i < 3; i++ )
        SET_SILENT_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_SILENT_MODE_OnPush_11, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SET_AUTO_RELOCK_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_AUTO_RELOCK_MODE_OnPush_12, false ) );
        
    SET_RELOCK_TIME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_RELOCK_TIME_UP_OnPush_13, true ) );
    SET_RELOCK_TIME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_RELOCK_TIME_DOWN_OnPush_14, true ) );
    SET_RELOCK_TIME_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( SET_RELOCK_TIME_IN_OnChange_15, false ) );
    SET_WRONG_CODE_LIMIT_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_WRONG_CODE_LIMIT_UP_OnPush_16, true ) );
    SET_WRONG_CODE_LIMIT_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_WRONG_CODE_LIMIT_DOWN_OnPush_17, true ) );
    SET_WRONG_CODE_LIMIT_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( SET_WRONG_CODE_LIMIT_IN_OnChange_18, false ) );
    for( uint i = 0; i < 3; i++ )
        SET_LANGUAGE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_LANGUAGE_OnPush_19, false ) );
        
    SET_SHUT_DOWN_TIME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_SHUT_DOWN_TIME_UP_OnPush_20, true ) );
    SET_SHUT_DOWN_TIME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_SHUT_DOWN_TIME_DOWN_OnPush_21, true ) );
    SET_SHUT_DOWN_TIME_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( SET_SHUT_DOWN_TIME_IN_OnChange_22, false ) );
    for( uint i = 0; i < 3; i++ )
        SET_OPERATING_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_OPERATING_MODE_OnPush_23, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SET_ONE_TOUCH_LOCKING_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_ONE_TOUCH_LOCKING_MODE_OnPush_24, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SET_PRIVACY_MODE_BUTTON_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_PRIVACY_MODE_BUTTON_MODE_OnPush_25, false ) );
        
    for( uint i = 0; i < 2; i++ )
        SET_INSIDE_COVER_LED_MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SET_INSIDE_COVER_LED_MODE_OnPush_26, false ) );
        
    SEND_PARAMETERS_UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_PARAMETERS_UPDATE_OnPush_27, false ) );
    USER_NUMBER_TEXT_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( USER_NUMBER_TEXT_IN_OnChange_28, false ) );
    USER_NAME_TEXT_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( USER_NAME_TEXT_IN_OnChange_29, false ) );
    USER_PIN_TEXT_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( USER_PIN_TEXT_IN_OnChange_30, false ) );
    SELECTED_USER_DELETE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTED_USER_DELETE_OnPush_31, false ) );
    SELECTED_USER_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTED_USER_ENABLE_OnPush_32, false ) );
    SELECTED_USER_DISABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTED_USER_DISABLE_OnPush_33, false ) );
    CLEAR_USER_SETTINGS.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_USER_SETTINGS_OnPush_34, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_YALE_LOCK_V1_4_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction INCREMENT1_Callback;
private WaitFunction INCREMENT2_Callback;


const uint LOCK__DigitalInput__ = 0;
const uint UNLOCK__DigitalInput__ = 1;
const uint SELECTED_USER_DELETE__DigitalInput__ = 2;
const uint GET_CONFIGURATION__DigitalInput__ = 3;
const uint GET_BATTERY_LEVEL__DigitalInput__ = 4;
const uint GET_PRODUCT_INFO__DigitalInput__ = 5;
const uint SET_RELOCK_TIME_UP__DigitalInput__ = 6;
const uint SET_RELOCK_TIME_DOWN__DigitalInput__ = 7;
const uint SET_WRONG_CODE_LIMIT_UP__DigitalInput__ = 8;
const uint SET_WRONG_CODE_LIMIT_DOWN__DigitalInput__ = 9;
const uint SET_SHUT_DOWN_TIME_UP__DigitalInput__ = 10;
const uint SET_SHUT_DOWN_TIME_DOWN__DigitalInput__ = 11;
const uint SEND_PARAMETERS_UPDATE__DigitalInput__ = 12;
const uint SELECTED_USER_ENABLE__DigitalInput__ = 13;
const uint SELECTED_USER_DISABLE__DigitalInput__ = 14;
const uint CLEAR_USER_SETTINGS__DigitalInput__ = 15;
const uint TO_MODULE_USER_NUMBER__AnalogSerialInput__ = 0;
const uint TO_MODULE_USER_PIN__AnalogSerialInput__ = 1;
const uint TO_MODULE_USER_NAME__AnalogSerialInput__ = 2;
const uint TO_MODULE_SET_USER_PIN__DigitalInput__ = 16;
const uint TO_MODULE_USER_DELETE__DigitalInput__ = 17;
const uint SET_SILENT_MODE__DigitalInput__ = 18;
const uint SET_AUTO_RELOCK_MODE__DigitalInput__ = 21;
const uint SET_LANGUAGE__DigitalInput__ = 23;
const uint SET_OPERATING_MODE__DigitalInput__ = 26;
const uint SET_ONE_TOUCH_LOCKING_MODE__DigitalInput__ = 29;
const uint SET_PRIVACY_MODE_BUTTON_MODE__DigitalInput__ = 31;
const uint SET_INSIDE_COVER_LED_MODE__DigitalInput__ = 33;
const uint SET_RELOCK_TIME_IN__AnalogSerialInput__ = 3;
const uint SET_WRONG_CODE_LIMIT_IN__AnalogSerialInput__ = 4;
const uint SET_SHUT_DOWN_TIME_IN__AnalogSerialInput__ = 5;
const uint FROM_LOCK__AnalogSerialInput__ = 6;
const uint USER_NUMBER_TEXT_IN__AnalogSerialInput__ = 7;
const uint USER_NAME_TEXT_IN__AnalogSerialInput__ = 8;
const uint USER_PIN_TEXT_IN__AnalogSerialInput__ = 9;
const uint IS_UNLOCKED__DigitalOutput__ = 0;
const uint IS_LOCKED__DigitalOutput__ = 1;
const uint BATTERY_LEVEL_TEXT__AnalogSerialOutput__ = 0;
const uint BATTERY_LEVEL_VAL__AnalogSerialOutput__ = 1;
const uint LOCKED_REASON_VAL__AnalogSerialOutput__ = 2;
const uint LOCKED_SLOT_NUM_VAL__AnalogSerialOutput__ = 3;
const uint UNLOCKED_REASON_VAL__AnalogSerialOutput__ = 4;
const uint UNLOCKED_SLOT_NUM_VAL__AnalogSerialOutput__ = 5;
const uint SILENT_MODE_STATUS__AnalogSerialOutput__ = 6;
const uint AUTO_RELOCK_STATUS__AnalogSerialOutput__ = 7;
const uint AUTO_RELOCK_TIME_TEXT__AnalogSerialOutput__ = 8;
const uint WRONG_CODE_LIMIT_TEXT__AnalogSerialOutput__ = 9;
const uint LANGUAGE_STATUS__AnalogSerialOutput__ = 10;
const uint SHUT_DOWN_TIME_TEXT__AnalogSerialOutput__ = 11;
const uint OPERATING_MODE_STATUS__AnalogSerialOutput__ = 12;
const uint LOOP_TEST_MODE_STATUS__AnalogSerialOutput__ = 13;
const uint ONE_TOUCH_LOCKING_STATUS__AnalogSerialOutput__ = 14;
const uint PRIVACY_MODE_BUTTON_STATUS__AnalogSerialOutput__ = 15;
const uint INSIDE_COVER_LED_STATUS__AnalogSerialOutput__ = 16;
const uint LOCK_PRODUCT_ID_TEXT__AnalogSerialOutput__ = 17;
const uint LOCK_FIRMWARE_VERSION_TEXT__AnalogSerialOutput__ = 18;
const uint MASTER_PIN_CODE_WAS_CHANGED__DigitalOutput__ = 2;
const uint SHOWING_PIN__DigitalOutput__ = 3;
const uint HIDING_PIN__DigitalOutput__ = 4;
const uint ALARM_STATUS__AnalogSerialOutput__ = 19;
const uint SLOT_NUM_TEXT__AnalogSerialOutput__ = 20;
const uint PIN_TEXT__AnalogSerialOutput__ = 21;
const uint LOCK_EVENT_TEXT__AnalogSerialOutput__ = 22;
const uint USER_EVENT_TEXT__AnalogSerialOutput__ = 23;
const uint ALARM_EVENT_TEXT__AnalogSerialOutput__ = 24;
const uint LOCK_TYPE_TEXT__AnalogSerialOutput__ = 25;
const uint PARAMETER_CHANGED__DigitalOutput__ = 5;
const uint CURRENT_STATUS_TEXT__AnalogSerialOutput__ = 26;
const uint ALARM_STATUS_TEXT__AnalogSerialOutput__ = 27;
const uint TO_LOCK__AnalogSerialOutput__ = 28;
const uint PARAMETER_REPORT__DigitalOutput__ = 6;
const uint LOCK_STATUS_UPDATED__DigitalOutput__ = 7;
const uint USER_NUMBER_TEXT_OUT__AnalogSerialOutput__ = 29;
const uint USER_NAME_TEXT_OUT__AnalogSerialOutput__ = 30;
const uint USER_PIN_TEXT_OUT__AnalogSerialOutput__ = 31;
const uint USER_IS_ENABLED__DigitalOutput__ = 8;
const uint USER_IS_DISABLED__DigitalOutput__ = 9;
const uint LOCK_NAME__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort IPACKET = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort IEVENT = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort IPARAMETER = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort ISLOT_ENABLE = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort [] IPARAMETERFLAG;
            [SplusStructAttribute(5, false, true)]
            public ushort [] IPARAMETERVALUE;
            [SplusStructAttribute(6, false, true)]
            public ushort ISLOTNUMENDIS = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort ILOCKSTATUS = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort AUTO_RELOCK_TIME_VAL = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort WRONG_CODE_LIMIT_VAL = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort SHUT_DOWN_TIME_VALUE = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort ILOCKTYPE = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort IPROCESSFROMLOCK = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort IDELAY = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort IUSERNUMBERIN = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort ISLOTNUMVAL = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort ISLOTNUMSTATUS = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort IADDEDSLOTNUMVAL = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort IDELETEDSLOTNUMVAL = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort IREPORTSLOTNUMVAL = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort IALARMSLOTNUMVAL = 0;
            [SplusStructAttribute(21, false, true)]
            public CrestronString SPARAMETERS;
            [SplusStructAttribute(22, false, true)]
            public CrestronString SSTRINGTOSEND;
            [SplusStructAttribute(23, false, true)]
            public CrestronString SSLOTNUM;
            [SplusStructAttribute(24, false, true)]
            public CrestronString SPIN;
            [SplusStructAttribute(25, false, true)]
            public CrestronString SPINSEND;
            [SplusStructAttribute(26, false, true)]
            public CrestronString SSETPARAMETERDATA;
            [SplusStructAttribute(27, false, true)]
            public CrestronString STRASH;
            [SplusStructAttribute(28, false, true)]
            public CrestronString SPINTEXT;
            [SplusStructAttribute(29, false, true)]
            public CrestronString SLOCKPRODUCTID;
            [SplusStructAttribute(30, false, true)]
            public CrestronString SSLOTNUMHOLD;
            [SplusStructAttribute(31, false, true)]
            public CrestronString SSLOTNUMMANAGE;
            [SplusStructAttribute(32, false, true)]
            public CrestronString SPINMANAGE;
            [SplusStructAttribute(33, false, true)]
            public CrestronString SPINSENDMANAGE;
            [SplusStructAttribute(34, false, true)]
            public CrestronString SUSERNAMEMANAGE;
            [SplusStructAttribute(35, false, true)]
            public CrestronString [] SUSERNAME;
            
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
