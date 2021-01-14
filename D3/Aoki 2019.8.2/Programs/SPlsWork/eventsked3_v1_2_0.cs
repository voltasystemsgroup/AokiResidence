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

namespace CrestronModule_EVENTSKED3_V1_2_0
{
    public class CrestronModuleClass_EVENTSKED3_V1_2_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput SAVE_EDIT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput REVERT_EDIT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput AUTOLOAD;
        Crestron.Logos.SplusObjects.DigitalInput LOAD;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_FIRST_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_NEXT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_PREV_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_LAST_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_UP;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_UP;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput AM;
        Crestron.Logos.SplusObjects.DigitalInput PM;
        Crestron.Logos.SplusObjects.DigitalInput SUNRISE;
        Crestron.Logos.SplusObjects.DigitalInput SUNSET;
        Crestron.Logos.SplusObjects.DigitalInput START_MONTH_UP;
        Crestron.Logos.SplusObjects.DigitalInput START_DAY_UP;
        Crestron.Logos.SplusObjects.DigitalInput START_YEAR_UP;
        Crestron.Logos.SplusObjects.DigitalInput START_MONTH_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput START_DAY_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput START_YEAR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput STOP_MONTH_UP;
        Crestron.Logos.SplusObjects.DigitalInput STOP_DAY_UP;
        Crestron.Logos.SplusObjects.DigitalInput STOP_YEAR_UP;
        Crestron.Logos.SplusObjects.DigitalInput STOP_MONTH_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput STOP_DAY_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput STOP_YEAR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput ANNUAL_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput SUSPEND;
        Crestron.Logos.SplusObjects.DigitalInput RESUME;
        Crestron.Logos.SplusObjects.DigitalInput EXECUTEMISSEDEVENTS;
        Crestron.Logos.SplusObjects.DigitalInput SUNDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput MONDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput TUESDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput WEDNESDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput THURSDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput FRIDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput SATURDAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput JAN_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput FEB_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput MAR_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput APR_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput MAY_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput JUN_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput JUL_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput AUG_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput SEP_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput OCT_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput NOV_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput DEC_ONOFF;
        Crestron.Logos.SplusObjects.DigitalInput CHANGEPERIODICTYPE;
        Crestron.Logos.SplusObjects.DigitalInput INCREASEPERIOD;
        Crestron.Logos.SplusObjects.DigitalInput DECREASEPERIOD;
        Crestron.Logos.SplusObjects.DigitalInput ADDDATE;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEMONTHUP;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEMONTHDOWN;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEDAYUP;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEDAYDOWN;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEYEARUP;
        Crestron.Logos.SplusObjects.DigitalInput BYDATEYEARDOWN;
        Crestron.Logos.SplusObjects.DigitalInput FIRSTDATE;
        Crestron.Logos.SplusObjects.DigitalInput NEXTDATE;
        Crestron.Logos.SplusObjects.DigitalInput PREVDATE;
        Crestron.Logos.SplusObjects.DigitalInput LASTDATE;
        Crestron.Logos.SplusObjects.DigitalInput DELETEDATE;
        Crestron.Logos.SplusObjects.DigitalInput FIREEVENT;
        Crestron.Logos.SplusObjects.DigitalInput LIST_EVENTS;
        Crestron.Logos.SplusObjects.StringInput CMDEVENTNAME;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_EVENT;
        Crestron.Logos.SplusObjects.AnalogInput MORNING_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput MORNING_MIN;
        Crestron.Logos.SplusObjects.AnalogInput NIGHT_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput NIGHT_MIN;
        Crestron.Logos.SplusObjects.StringInput FILENAME__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput NEWPROGLOADED;
        Crestron.Logos.SplusObjects.DigitalOutput READ_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput WRITE_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_EVENT_SUSPENDED;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_EVENT_READONLY;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_EVENT_ANNUAL;
        Crestron.Logos.SplusObjects.DigitalOutput SUNDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput MONDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput TUESDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput WEDNESDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput THURSDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput FRIDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SATURDAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput JAN_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput FEB_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput MAR_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput APR_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput MAY_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput JUN_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput JUL_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput AUG_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SEP_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput OCT_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput NOV_ONOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DEC_ONOFF_FB;
        Crestron.Logos.SplusObjects.StringOutput EVENT_BYDATE_INFO;
        Crestron.Logos.SplusObjects.StringOutput AADSSCROLLARROW__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SCHEDULER_LOG;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> EVENT_DUE;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_NUMBER;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_TIMEBASE;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_TYPE;
        Crestron.Logos.SplusObjects.AnalogOutput TOTAL_USED_EVENTS;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_START__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_STOP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_TIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput FIRED_EVENT_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PERIODIC_EVENTINFO__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput BYDATE_EVENTINFO__DOLLAR__;
        EVENTINFO [] G_EVENTS;
        EVENTINFO G_EDITEVENT;
        ushort [] G_IMONTHMASK;
        ushort [] G_IDAYOFWEEKMASK;
        ushort [] G_IDAYSINMONTH;
        ushort G_IEDITEVENT = 0;
        ushort G_IMAXUSEDEVENT = 0;
        ushort G_IBYDATEINDEX = 0;
        ushort G_IBYDATEMAXINDEX = 0;
        ushort G_IDAYNUM = 0;
        uint [] G_LDATES;
        CrestronString G_FILENAME_EVENT;
        CrestronString G_FILENAME_EDIT;
        FILE_INFO G_FIDATAFILE;
        private ushort GETBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM ) 
            { 
            
            __context__.SourceCodeLine = 306;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBITNUM > 15 ))  ) ) 
                {
                __context__.SourceCodeLine = 307;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 309;
            return (ushort)( ((ISOURCE & (1 << IBITNUM)) >> IBITNUM)) ; 
            
            }
            
        private ushort SETBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM , ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 314;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBITNUM > 15 ))  ) ) 
                {
                __context__.SourceCodeLine = 315;
                return (ushort)( ISOURCE) ; 
                }
            
            __context__.SourceCodeLine = 317;
            if ( Functions.TestForTrue  ( ( IVALUE)  ) ) 
                {
                __context__.SourceCodeLine = 318;
                return (ushort)( (ISOURCE | (1 << IBITNUM))) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 320;
                return (ushort)( (ISOURCE & Functions.OnesComplement( (1 << IBITNUM) ))) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort TOGGLEBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM ) 
            { 
            ushort IBITVALUE = 0;
            
            
            __context__.SourceCodeLine = 327;
            IBITVALUE = (ushort) ( GETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) ) ) ; 
            __context__.SourceCodeLine = 329;
            if ( Functions.TestForTrue  ( ( IBITVALUE)  ) ) 
                {
                __context__.SourceCodeLine = 330;
                return (ushort)( SETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) , (ushort)( 0 ) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 332;
                return (ushort)( SETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) , (ushort)( 1 ) )) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort ISANNUALEVENT (  SplusExecutionContext __context__, ushort IEVENTTYPE ) 
            { 
            
            __context__.SourceCodeLine = 337;
            if ( Functions.TestForTrue  ( ( (IEVENTTYPE & 256))  ) ) 
                {
                __context__.SourceCodeLine = 338;
                return (ushort)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 340;
                return (ushort)( 0) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort EVENTTYPE (  SplusExecutionContext __context__, ushort IEVENTTYPE ) 
            { 
            
            __context__.SourceCodeLine = 345;
            return (ushort)( (IEVENTTYPE & 255)) ; 
            
            }
            
        private void FREEFILE (  SplusExecutionContext __context__, CrestronString FILENAME , ushort PURPOSE ) 
            { 
            
            __context__.SourceCodeLine = 350;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PURPOSE == 1))  ) ) 
                {
                __context__.SourceCodeLine = 351;
                G_FILENAME_EVENT  .UpdateValue ( ""  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 353;
                G_FILENAME_EDIT  .UpdateValue ( ""  ) ; 
                }
            
            
            }
            
        private ushort CANUSEFILE (  SplusExecutionContext __context__, CrestronString FILENAME , ushort PURPOSE ) 
            { 
            
            __context__.SourceCodeLine = 359;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PURPOSE == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 361;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_FILENAME_EVENT != ""))  ) ) 
                    {
                    __context__.SourceCodeLine = 361;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 362;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILENAME == G_FILENAME_EDIT))  ) ) 
                    {
                    __context__.SourceCodeLine = 362;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 363;
                return (ushort)( 1) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 367;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_FILENAME_EDIT != ""))  ) ) 
                    {
                    __context__.SourceCodeLine = 367;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 368;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILENAME == G_FILENAME_EVENT))  ) ) 
                    {
                    __context__.SourceCodeLine = 368;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 369;
                return (ushort)( 1) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort USESTARTSTOPDATE (  SplusExecutionContext __context__, ushort IEVENTNUM ) 
            { 
            
            __context__.SourceCodeLine = 375;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ]._STARTDATE == 0))  ) ) 
                {
                __context__.SourceCodeLine = 375;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 378;
            return (ushort)( 1) ; 
            
            }
            
        private CrestronString GETMONTHSTRING (  SplusExecutionContext __context__, ushort IMONTH ) 
            { 
            
            __context__.SourceCodeLine = 383;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)IMONTH);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 385;
                        return ( "January" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 386;
                        return ( "February" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 387;
                        return ( "March" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 388;
                        return ( "April" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 389;
                        return ( "May" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 390;
                        return ( "June" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 391;
                        return ( "July" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 392;
                        return ( "August" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                        {
                        __context__.SourceCodeLine = 393;
                        return ( "September" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                        {
                        __context__.SourceCodeLine = 394;
                        return ( "October" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                        {
                        __context__.SourceCodeLine = 395;
                        return ( "November" ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 396;
                        return ( "December" ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            return ""; // default return value (none specified in module)
            }
            
        private void SETFEBRUARY (  SplusExecutionContext __context__, ushort IYEAR ) 
            { 
            
            __context__.SourceCodeLine = 403;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IYEAR , 4 ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 404;
                G_IDAYSINMONTH [ 2] = (ushort) ( 29 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 406;
                G_IDAYSINMONTH [ 2] = (ushort) ( 28 ) ; 
                }
            
            
            }
            
        private ushort GETYEARFROMLONG (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 412;
            return (ushort)( Mod( LDATE , 10000 )) ; 
            
            }
            
        private ushort GETDAYFROMLONG (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 417;
            return (ushort)( (Mod( LDATE , 1000000 ) / 10000)) ; 
            
            }
            
        private ushort GETMONTHFROMLONG (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 422;
            return (ushort)( (LDATE / 1000000)) ; 
            
            }
            
        private uint CREATEDATEL (  SplusExecutionContext __context__, ushort IMONTH , ushort IDAY , ushort IYEAR ) 
            { 
            
            __context__.SourceCodeLine = 427;
            return (uint)( (((IMONTH * 1000000) + (IDAY * 10000)) + IYEAR)) ; 
            
            }
            
        private ushort GETDAYOFYEARNUM (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort LCOUNT = 0;
            
            ushort ILOOP = 0;
            
            
            __context__.SourceCodeLine = 436;
            LCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 438;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( ILOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILOOP  >= __FN_FORSTART_VAL__1) && (ILOOP  <= __FN_FOREND_VAL__1) ) : ( (ILOOP  <= __FN_FORSTART_VAL__1) && (ILOOP  >= __FN_FOREND_VAL__1) ) ; ILOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 439;
                LCOUNT = (ushort) ( (LCOUNT + G_IDAYSINMONTH[ ILOOP ]) ) ; 
                __context__.SourceCodeLine = 438;
                }
            
            __context__.SourceCodeLine = 441;
            LCOUNT = (ushort) ( (LCOUNT + GETDAYFROMLONG( __context__ , (uint)( LDATE ) )) ) ; 
            __context__.SourceCodeLine = 443;
            return (ushort)( LCOUNT) ; 
            
            }
            
        private uint GETJDAY (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort PRVYEAR = 0;
            
            ushort LEAPYEAR = 0;
            
            ushort TEMPYEAR = 0;
            
            ushort TEMPMONTH = 0;
            
            ushort TEMPDAY = 0;
            
            ushort JDAY = 0;
            
            ushort LEAPS = 0;
            
            
            __context__.SourceCodeLine = 457;
            TEMPDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 458;
            TEMPMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 459;
            TEMPYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 462;
            PRVYEAR = (ushort) ( (TEMPYEAR - 1) ) ; 
            __context__.SourceCodeLine = 463;
            LEAPS = (ushort) ( ((((PRVYEAR / 4) - (PRVYEAR / 100)) + (PRVYEAR / 400)) - 484) ) ; 
            __context__.SourceCodeLine = 466;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 4 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 100 ) != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 400 ) == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 467;
                LEAPYEAR = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 469;
                LEAPYEAR = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 471;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)TEMPMONTH);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 474;
                        JDAY = (ushort) ( TEMPDAY ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 476;
                        TEMPDAY = (ushort) ( Functions.Min( TEMPDAY , (28 + LEAPYEAR) ) ) ; 
                        __context__.SourceCodeLine = 477;
                        JDAY = (ushort) ( (TEMPDAY + 31) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 480;
                        JDAY = (ushort) ( (TEMPDAY + 59) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 482;
                        TEMPDAY = (ushort) ( Functions.Min( TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 483;
                        JDAY = (ushort) ( (TEMPDAY + 90) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 486;
                        JDAY = (ushort) ( (TEMPDAY + 120) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 488;
                        TEMPDAY = (ushort) ( Functions.Min( TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 489;
                        JDAY = (ushort) ( (TEMPDAY + 151) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 492;
                        JDAY = (ushort) ( (TEMPDAY + 181) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 494;
                        JDAY = (ushort) ( (TEMPDAY + 212) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 9) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 496;
                        TEMPDAY = (ushort) ( Functions.Min( TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 497;
                        JDAY = (ushort) ( (TEMPDAY + 243) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 10) ) ) ) 
                        {
                        __context__.SourceCodeLine = 500;
                        JDAY = (ushort) ( (TEMPDAY + 273) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 11) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 502;
                        TEMPDAY = (ushort) ( Functions.Min( TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 503;
                        JDAY = (ushort) ( (TEMPDAY + 304) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 506;
                        JDAY = (ushort) ( (TEMPDAY + 334) ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 509;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LEAPYEAR == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (TEMPMONTH != 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (TEMPMONTH != 2) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 510;
                JDAY = (ushort) ( (JDAY + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 512;
            JDAY = (ushort) ( ((JDAY + ((PRVYEAR - 1996) * 365)) + LEAPS) ) ; 
            __context__.SourceCodeLine = 514;
            return (uint)( JDAY) ; 
            
            }
            
        private uint GETGDATE (  SplusExecutionContext __context__, int JDAY ) 
            { 
            int TEMPDAY = 0;
            
            int TEMPMONTH = 0;
            
            int TEMPYEAR = 0;
            
            int REMCENTS = 0;
            
            int REMQUADS = 0;
            
            int REMYEARS = 0;
            
            int LEAPYEAR = 0;
            
            
            __context__.SourceCodeLine = 531;
            TEMPMONTH = (int) ( 0 ) ; 
            __context__.SourceCodeLine = 533;
            REMCENTS = (int) ( (JDAY / 36524) ) ; 
            __context__.SourceCodeLine = 534;
            JDAY = (int) ( (JDAY - (36524 * REMCENTS)) ) ; 
            __context__.SourceCodeLine = 535;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( JDAY < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 536;
                TEMPYEAR = (int) ( (1996 + (100 * REMCENTS)) ) ; 
                __context__.SourceCodeLine = 537;
                TEMPDAY = (int) ( 365 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 540;
                REMQUADS = (int) ( (JDAY / 1461) ) ; 
                __context__.SourceCodeLine = 541;
                JDAY = (int) ( (JDAY - (1461 * REMQUADS)) ) ; 
                __context__.SourceCodeLine = 542;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( JDAY < 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 543;
                    TEMPYEAR = (int) ( ((1996 + (100 * REMCENTS)) + (4 * REMQUADS)) ) ; 
                    __context__.SourceCodeLine = 544;
                    TEMPDAY = (int) ( (365 + 1) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 547;
                    REMYEARS = (int) ( (JDAY / 365) ) ; 
                    __context__.SourceCodeLine = 548;
                    JDAY = (int) ( (JDAY - (365 * REMYEARS)) ) ; 
                    __context__.SourceCodeLine = 549;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( JDAY < 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 550;
                        TEMPYEAR = (int) ( (((1996 + (100 * REMCENTS)) + (4 * REMQUADS)) + REMYEARS) ) ; 
                        __context__.SourceCodeLine = 552;
                        TEMPDAY = (int) ( 365 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 555;
                        TEMPYEAR = (int) ( ((((1 + 1996) + (100 * REMCENTS)) + (4 * REMQUADS)) + REMYEARS) ) ; 
                        __context__.SourceCodeLine = 557;
                        TEMPDAY = (int) ( JDAY ) ; 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 564;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 4 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 100 ) != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Mod( TEMPYEAR , 400 ) == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 565;
                LEAPYEAR = (int) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 567;
                LEAPYEAR = (int) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 569;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 571;
                TEMPMONTH = (int) ( 12 ) ; 
                __context__.SourceCodeLine = 572;
                TEMPDAY = (int) ( 31 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 574;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= 31 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 576;
                    TEMPMONTH = (int) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 578;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 59) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 580;
                        TEMPMONTH = (int) ( 2 ) ; 
                        __context__.SourceCodeLine = 581;
                        TEMPDAY = (int) ( (TEMPDAY - 31) ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 583;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 90) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 585;
                            TEMPMONTH = (int) ( 3 ) ; 
                            __context__.SourceCodeLine = 586;
                            TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 59) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 588;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 120) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 590;
                                TEMPMONTH = (int) ( 4 ) ; 
                                __context__.SourceCodeLine = 591;
                                TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 90) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 593;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 151) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 595;
                                    TEMPMONTH = (int) ( 5 ) ; 
                                    __context__.SourceCodeLine = 596;
                                    TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 120) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 598;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 181) ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 600;
                                        TEMPMONTH = (int) ( 6 ) ; 
                                        __context__.SourceCodeLine = 601;
                                        TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 151) ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 603;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 212) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 605;
                                            TEMPMONTH = (int) ( 7 ) ; 
                                            __context__.SourceCodeLine = 606;
                                            TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 181) ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 608;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 243) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 610;
                                                TEMPMONTH = (int) ( 8 ) ; 
                                                __context__.SourceCodeLine = 611;
                                                TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 212) ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 613;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 273) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 615;
                                                    TEMPMONTH = (int) ( 9 ) ; 
                                                    __context__.SourceCodeLine = 616;
                                                    TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 243) ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 618;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 304) ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 620;
                                                        TEMPMONTH = (int) ( 10 ) ; 
                                                        __context__.SourceCodeLine = 621;
                                                        TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 273) ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 623;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPDAY <= (LEAPYEAR + 334) ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 625;
                                                            TEMPMONTH = (int) ( 11 ) ; 
                                                            __context__.SourceCodeLine = 626;
                                                            TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 304) ) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 630;
                                                            TEMPMONTH = (int) ( 12 ) ; 
                                                            __context__.SourceCodeLine = 631;
                                                            TEMPDAY = (int) ( ((TEMPDAY - LEAPYEAR) - 334) ) ; 
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
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 634;
            return (uint)( CREATEDATEL( __context__ , (ushort)( TEMPMONTH ) , (ushort)( TEMPDAY ) , (ushort)( TEMPYEAR ) )) ; 
            
            }
            
        private ushort GETDAYOFWEEK (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort EVENTMONTH = 0;
            
            ushort EVENTYEAR = 0;
            
            ushort EVENTDAY = 0;
            
            ushort ZELLERYEAR = 0;
            
            ushort ZELLERMONTH = 0;
            
            ushort ZELLERCENTURY = 0;
            
            short DAYOFWEEK = 0;
            
            
            __context__.SourceCodeLine = 649;
            EVENTYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 650;
            EVENTDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 651;
            EVENTMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 653;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EVENTMONTH < 3 ))  ) ) 
                { 
                __context__.SourceCodeLine = 654;
                ZELLERYEAR = (ushort) ( (EVENTYEAR - 1) ) ; 
                __context__.SourceCodeLine = 655;
                ZELLERMONTH = (ushort) ( (EVENTMONTH + 10) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 658;
                ZELLERYEAR = (ushort) ( EVENTYEAR ) ; 
                __context__.SourceCodeLine = 659;
                ZELLERMONTH = (ushort) ( (EVENTMONTH - 2) ) ; 
                } 
            
            __context__.SourceCodeLine = 662;
            ZELLERCENTURY = (ushort) ( (ZELLERYEAR / 100) ) ; 
            __context__.SourceCodeLine = 663;
            ZELLERYEAR = (ushort) ( Mod( ZELLERYEAR , 100 ) ) ; 
            __context__.SourceCodeLine = 665;
            DAYOFWEEK = (short) ( Mod( ((((((((26 * ZELLERMONTH) - 2) / 10) + EVENTDAY) + ZELLERYEAR) + (ZELLERYEAR / 4)) + (ZELLERCENTURY / 4)) - (2 * ZELLERCENTURY)) , 7 ) ) ; 
            __context__.SourceCodeLine = 668;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DAYOFWEEK < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 669;
                DAYOFWEEK = (short) ( (DAYOFWEEK + 7) ) ; 
                } 
            
            __context__.SourceCodeLine = 671;
            return (ushort)( DAYOFWEEK) ; 
            
            }
            
        private uint DECREMENTYEAR (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 677;
            LDATE = (uint) ( (LDATE - 1) ) ; 
            __context__.SourceCodeLine = 679;
            SETFEBRUARY (  __context__ , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) )) ; 
            __context__.SourceCodeLine = 680;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) > G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ))  ) ) 
                {
                __context__.SourceCodeLine = 681;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 683;
                return (uint)( LDATE) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint INCREMENTYEAR (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 688;
            LDATE = (uint) ( (LDATE + 1) ) ; 
            __context__.SourceCodeLine = 690;
            SETFEBRUARY (  __context__ , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) )) ; 
            __context__.SourceCodeLine = 691;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) > G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ))  ) ) 
                {
                __context__.SourceCodeLine = 692;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 694;
                return (uint)( LDATE) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint DECREMENTMONTH (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort ITEMPMONTH = 0;
            
            
            __context__.SourceCodeLine = 700;
            ITEMPMONTH = (ushort) ( (GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) - 1) ) ; 
            __context__.SourceCodeLine = 701;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMPMONTH < 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 702;
                ITEMPMONTH = (ushort) ( 12 ) ; 
                }
            
            __context__.SourceCodeLine = 704;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) > G_IDAYSINMONTH[ ITEMPMONTH ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 706;
                return (uint)( CREATEDATEL( __context__ , (ushort)( ITEMPMONTH ) , (ushort)( G_IDAYSINMONTH[ ITEMPMONTH ] ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 710;
                return (uint)( CREATEDATEL( __context__ , (ushort)( ITEMPMONTH ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint INCREMENTMONTH (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort ITEMPMONTH = 0;
            
            
            __context__.SourceCodeLine = 717;
            ITEMPMONTH = (ushort) ( (GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) + 1) ) ; 
            __context__.SourceCodeLine = 718;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMPMONTH > 12 ))  ) ) 
                {
                __context__.SourceCodeLine = 719;
                ITEMPMONTH = (ushort) ( 1 ) ; 
                }
            
            __context__.SourceCodeLine = 721;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) > G_IDAYSINMONTH[ ITEMPMONTH ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 723;
                return (uint)( CREATEDATEL( __context__ , (ushort)( ITEMPMONTH ) , (ushort)( G_IDAYSINMONTH[ ITEMPMONTH ] ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 727;
                return (uint)( CREATEDATEL( __context__ , (ushort)( ITEMPMONTH ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint DECREMENTDATE (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 735;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) - 1) < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 737;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 741;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( (GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) - 1) ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint INCREMENTDATE (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            
            __context__.SourceCodeLine = 747;
            SETFEBRUARY (  __context__ , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) )) ; 
            __context__.SourceCodeLine = 749;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) + 1) > G_IDAYSINMONTH[ GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 751;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( 1 ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 755;
                return (uint)( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) , (ushort)( (GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) + 1) ) , (ushort)( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort BEFOREORAFTERTODAY (  SplusExecutionContext __context__, uint LDATE ) 
            { 
            ushort IYEAR = 0;
            
            ushort IDAY = 0;
            
            ushort IMONTH = 0;
            
            
            __context__.SourceCodeLine = 766;
            IYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 767;
            IDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 768;
            IMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 770;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IYEAR > Functions.GetYearNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 770;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 771;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IYEAR < Functions.GetYearNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 771;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 773;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMONTH > Functions.GetMonthNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 773;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 774;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMONTH < Functions.GetMonthNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 774;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 776;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDAY > Functions.GetDateNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 776;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 777;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDAY < Functions.GetDateNum() ))  ) ) 
                {
                __context__.SourceCodeLine = 777;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 779;
            return (ushort)( 0) ; 
            
            }
            
        private ushort BEFOREORAFTERDATE (  SplusExecutionContext __context__, uint LDATE , uint LTESTAGAINST ) 
            { 
            ushort IYEAR = 0;
            
            ushort IDAY = 0;
            
            ushort IMONTH = 0;
            
            ushort ITESTYEAR = 0;
            
            ushort ITESTDAY = 0;
            
            ushort ITESTMONTH = 0;
            
            
            __context__.SourceCodeLine = 794;
            IYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 795;
            IDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 796;
            IMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 798;
            ITESTYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LTESTAGAINST ) ) ) ; 
            __context__.SourceCodeLine = 799;
            ITESTDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LTESTAGAINST ) ) ) ; 
            __context__.SourceCodeLine = 800;
            ITESTMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LTESTAGAINST ) ) ) ; 
            __context__.SourceCodeLine = 802;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IYEAR > ITESTYEAR ))  ) ) 
                {
                __context__.SourceCodeLine = 802;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 803;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IYEAR < ITESTYEAR ))  ) ) 
                {
                __context__.SourceCodeLine = 803;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 805;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMONTH > ITESTMONTH ))  ) ) 
                {
                __context__.SourceCodeLine = 805;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 806;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMONTH < ITESTMONTH ))  ) ) 
                {
                __context__.SourceCodeLine = 806;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 808;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDAY > ITESTDAY ))  ) ) 
                {
                __context__.SourceCodeLine = 808;
                return (ushort)( 2) ; 
                }
            
            __context__.SourceCodeLine = 809;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDAY < ITESTDAY ))  ) ) 
                {
                __context__.SourceCodeLine = 809;
                return (ushort)( 1) ; 
                }
            
            __context__.SourceCodeLine = 811;
            return (ushort)( 0) ; 
            
            }
            
        private CrestronString GETDATESTRING (  SplusExecutionContext __context__, uint LDATE , ushort IUSEYEAR ) 
            { 
            ushort IMONTH = 0;
            ushort IDAY = 0;
            ushort IYEAR = 0;
            
            CrestronString DATESTR;
            DATESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 819;
            IMONTH = (ushort) ( GETMONTHFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 820;
            IDAY = (ushort) ( GETDAYFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 821;
            IYEAR = (ushort) ( GETYEARFROMLONG( __context__ , (uint)( LDATE ) ) ) ; 
            __context__.SourceCodeLine = 823;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IYEAR == 9999) ) || Functions.TestForTrue ( Functions.BoolToInt (IYEAR == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 823;
                return ( "Unused." ) ; 
                }
            
            __context__.SourceCodeLine = 825;
            if ( Functions.TestForTrue  ( ( IUSEYEAR)  ) ) 
                { 
                __context__.SourceCodeLine = 827;
                MakeString ( DATESTR , "{0:d2} / {1:d2}", (short)IMONTH, (short)IDAY) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 831;
                MakeString ( DATESTR , "{0:d2} / {1:d2} / {2:d4}", (short)IMONTH, (short)IDAY, (short)IYEAR) ; 
                } 
            
            __context__.SourceCodeLine = 834;
            return ( DATESTR ) ; 
            
            }
            
        private void SETANNUALSTARTSTOP (  SplusExecutionContext __context__, ref uint LSTART , ref uint LSTOP ) 
            { 
            ushort ISTOPNUM = 0;
            
            ushort ISTARTNUM = 0;
            
            ushort ISTART_BOAT = 0;
            
            ushort ISTOP_BOAT = 0;
            
            ushort ISTARTSTOPRELATION = 0;
            
            
            __context__.SourceCodeLine = 851;
            LSTART = (uint) ( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LSTART ) ) ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LSTART ) ) ) , (ushort)( Functions.GetYearNum() ) ) ) ; 
            __context__.SourceCodeLine = 853;
            LSTOP = (uint) ( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LSTOP ) ) ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LSTOP ) ) ) , (ushort)( Functions.GetYearNum() ) ) ) ; 
            __context__.SourceCodeLine = 855;
            ISTARTSTOPRELATION = (ushort) ( BEFOREORAFTERDATE( __context__ , (uint)( LSTART ) , (uint)( LSTOP ) ) ) ; 
            __context__.SourceCodeLine = 856;
            ISTOP_BOAT = (ushort) ( BEFOREORAFTERTODAY( __context__ , (uint)( LSTOP ) ) ) ; 
            __context__.SourceCodeLine = 858;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTARTSTOPRELATION == 2))  ) ) 
                { 
                __context__.SourceCodeLine = 860;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTOP_BOAT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 862;
                    LSTOP = (uint) ( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LSTOP ) ) ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LSTOP ) ) ) , (ushort)( (Functions.GetYearNum() + 1) ) ) ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 864;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ISTOP_BOAT == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (ISTOP_BOAT == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 866;
                        LSTART = (uint) ( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LSTART ) ) ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LSTART ) ) ) , (ushort)( (Functions.GetYearNum() - 1) ) ) ) ; 
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 869;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTARTSTOPRELATION == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 871;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTOP_BOAT == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 873;
                        LSTOP = (uint) ( (LSTOP + 1) ) ; 
                        __context__.SourceCodeLine = 874;
                        LSTART = (uint) ( (LSTART + 1) ) ; 
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 877;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTARTSTOPRELATION == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 879;
                        LSTOP = (uint) ( (LSTOP + 1) ) ; 
                        } 
                    
                    }
                
                }
            
            
            }
            
        private void UPDATESTARTDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 885;
            EDIT_EVENT_START__DOLLAR__  .UpdateValue ( GETDATESTRING (  __context__ , (uint)( G_EDITEVENT._STARTDATE ), (ushort)( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) ))  ) ; 
            
            }
            
        private void UPDATESTOPDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 890;
            EDIT_EVENT_STOP__DOLLAR__  .UpdateValue ( GETDATESTRING (  __context__ , (uint)( G_EDITEVENT._STOPDATE ), (ushort)( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) ))  ) ; 
            
            }
            
        private ushort GETINTEGERFROMBITFIELDSTRING (  SplusExecutionContext __context__, CrestronString SBITFIELD ) 
            { 
            ushort ILEN = 0;
            
            ushort IBYTE = 0;
            
            ushort ITEMP = 0;
            
            
            __context__.SourceCodeLine = 949;
            ITEMP = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 951;
            ILEN = (ushort) ( Functions.Length( SBITFIELD ) ) ; 
            __context__.SourceCodeLine = 953;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ILEN > 16 ))  ) ) 
                {
                __context__.SourceCodeLine = 954;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                }
            
            __context__.SourceCodeLine = 956;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ILEN; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IBYTE  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IBYTE  >= __FN_FORSTART_VAL__1) && (IBYTE  <= __FN_FOREND_VAL__1) ) : ( (IBYTE  <= __FN_FORSTART_VAL__1) && (IBYTE  >= __FN_FOREND_VAL__1) ) ; IBYTE  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 958;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SBITFIELD , (int)( IBYTE ) ) == 88))  ) ) 
                    { 
                    __context__.SourceCodeLine = 960;
                    ITEMP = (ushort) ( (ITEMP + (1 << (IBYTE - 1))) ) ; 
                    } 
                
                __context__.SourceCodeLine = 956;
                } 
            
            __context__.SourceCodeLine = 964;
            return (ushort)( ITEMP) ; 
            
            }
            
        private CrestronString GETBITFIELDSTRINGFROMINTEGER (  SplusExecutionContext __context__, ushort IBITFIELD , ushort INUMBITS ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
            
            ushort IBIT = 0;
            
            
            __context__.SourceCodeLine = 987;
            STEMP  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 989;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(INUMBITS - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IBIT  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IBIT  >= __FN_FORSTART_VAL__1) && (IBIT  <= __FN_FOREND_VAL__1) ) : ( (IBIT  <= __FN_FORSTART_VAL__1) && (IBIT  >= __FN_FOREND_VAL__1) ) ; IBIT  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 991;
                if ( Functions.TestForTrue  ( ( (IBITFIELD & (1 << IBIT)))  ) ) 
                    {
                    __context__.SourceCodeLine = 992;
                    STEMP  .UpdateValue ( STEMP + Functions.Chr (  (int) ( 88 ) )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 994;
                    STEMP  .UpdateValue ( STEMP + Functions.Chr (  (int) ( 45 ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 989;
                } 
            
            __context__.SourceCodeLine = 997;
            return ( STEMP ) ; 
            
            }
            
        private void COPYEVENT (  SplusExecutionContext __context__, EVENTINFO SRC , ref EVENTINFO DEST ) 
            { 
            
            __context__.SourceCodeLine = 1017;
            DEST . NAME  .UpdateValue ( SRC . NAME  ) ; 
            __context__.SourceCodeLine = 1018;
            DEST . TIMEBASE = (ushort) ( SRC.TIMEBASE ) ; 
            __context__.SourceCodeLine = 1019;
            DEST . _TIME = (short) ( SRC._TIME ) ; 
            __context__.SourceCodeLine = 1020;
            DEST . _DATE = (uint) ( SRC._DATE ) ; 
            __context__.SourceCodeLine = 1021;
            DEST . _STARTDATE = (uint) ( SRC._STARTDATE ) ; 
            __context__.SourceCodeLine = 1022;
            DEST . _STOPDATE = (uint) ( SRC._STOPDATE ) ; 
            __context__.SourceCodeLine = 1023;
            DEST . EVENTTYPE = (ushort) ( SRC.EVENTTYPE ) ; 
            __context__.SourceCodeLine = 1024;
            DEST . SCHEDULEINFO  .UpdateValue ( SRC . SCHEDULEINFO  ) ; 
            __context__.SourceCodeLine = 1025;
            DEST . FREE = (ushort) ( SRC.FREE ) ; 
            __context__.SourceCodeLine = 1026;
            DEST . SUSPENDED = (ushort) ( SRC.SUSPENDED ) ; 
            __context__.SourceCodeLine = 1027;
            DEST . HIDDENSTATE = (ushort) ( SRC.HIDDENSTATE ) ; 
            __context__.SourceCodeLine = 1028;
            DEST . READONLY = (ushort) ( SRC.READONLY ) ; 
            __context__.SourceCodeLine = 1029;
            DEST . LASTMODIFIED  .UpdateValue ( SRC . LASTMODIFIED  ) ; 
            __context__.SourceCodeLine = 1030;
            DEST . USERDATA  .UpdateValue ( SRC . USERDATA  ) ; 
            
            }
            
        private CrestronString GETTIMESTRING (  SplusExecutionContext __context__, short ITIME , ushort ITIMEBASE ) 
            { 
            short IHOUR = 0;
            
            ushort IMIN = 0;
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 1055;
            IHOUR = (short) ( (Functions.Abs( ITIME ) / 60) ) ; 
            __context__.SourceCodeLine = 1056;
            IMIN = (ushort) ( Mod( Functions.Abs( ITIME ) , 60 ) ) ; 
            __context__.SourceCodeLine = 1058;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)ITIMEBASE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1062;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IHOUR == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 1063;
                            IHOUR = (short) ( 12 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 1064;
                        MakeString ( STIME , "{0:d}:{1:d2} AM", (ushort)IHOUR, (ushort)IMIN) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1069;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IHOUR == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 1070;
                            IHOUR = (short) ( 12 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 1071;
                        MakeString ( STIME , "{0:d}:{1:d2} PM", (ushort)IHOUR, (ushort)IMIN) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1076;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIME >= 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1077;
                            MakeString ( STIME , "Sunrise + {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1079;
                            MakeString ( STIME , "Sunrise - {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1084;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIME >= 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1085;
                            MakeString ( STIME , "Sunset + {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1087;
                            MakeString ( STIME , "Sunset - {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1091;
                        STIME  .UpdateValue ( "ERROR: Invalid time"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1095;
            return ( STIME ) ; 
            
            }
            
        private void UPDATEEDITEVENTTIME (  SplusExecutionContext __context__ ) 
            { 
            short ITIME = 0;
            
            ushort ITIMEBASE = 0;
            
            
            __context__.SourceCodeLine = 1104;
            EDIT_EVENT_TIMEBASE  .Value = (ushort) ( G_EDITEVENT.TIMEBASE ) ; 
            __context__.SourceCodeLine = 1106;
            ITIME = (short) ( G_EDITEVENT._TIME ) ; 
            __context__.SourceCodeLine = 1107;
            ITIMEBASE = (ushort) ( G_EDITEVENT.TIMEBASE ) ; 
            __context__.SourceCodeLine = 1108;
            EDIT_EVENT_TIME__DOLLAR__  .UpdateValue ( GETTIMESTRING (  __context__ , (short)( ITIME ), (ushort)( ITIMEBASE ))  ) ; 
            
            }
            
        private void PERIODIC_EXTRACTINFO (  SplusExecutionContext __context__, CrestronString STRDETAIL , ref ushort IPERIODICTYPE , ref short IPERIOD ) 
            { 
            CrestronString SDETAILS;
            SDETAILS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1136;
            SDETAILS  .UpdateValue ( STRDETAIL  ) ; 
            __context__.SourceCodeLine = 1138;
            STEMP  .UpdateValue ( Functions.Remove ( "," , SDETAILS )  ) ; 
            __context__.SourceCodeLine = 1139;
            IPERIODICTYPE = (ushort) ( Functions.Atoi( STEMP ) ) ; 
            __context__.SourceCodeLine = 1140;
            IPERIOD = (short) ( Functions.Atoi( SDETAILS ) ) ; 
            
            }
            
        private void WEEKLY_EXTRACTINFO (  SplusExecutionContext __context__, CrestronString STRDETAIL , ref ushort IVALIDDAYS , ref ushort IVALIDMONTHS ) 
            { 
            
            __context__.SourceCodeLine = 1146;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STRDETAIL ) < 20 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1148;
                Print( "ERROR: Details to short!\r\n") ; 
                __context__.SourceCodeLine = 1150;
                IVALIDDAYS = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1151;
                IVALIDMONTHS = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1155;
                IVALIDDAYS = (ushort) ( GETINTEGERFROMBITFIELDSTRING( __context__ , Functions.Mid( STRDETAIL , (int)( 1 ) , (int)( 7 ) ) ) ) ; 
                __context__.SourceCodeLine = 1156;
                IVALIDMONTHS = (ushort) ( GETINTEGERFROMBITFIELDSTRING( __context__ , Functions.Mid( STRDETAIL , (int)( 9 ) , (int)( 20 ) ) ) ) ; 
                } 
            
            
            }
            
        private void WRITEDATEARRAY (  SplusExecutionContext __context__ ) 
            { 
            short IFILEHANDLE = 0;
            
            short IERRCODE = 0;
            
            CrestronString SWRITEBUF;
            SWRITEBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1179;
            if ( Functions.TestForTrue  ( ( Functions.Not( CANUSEFILE( __context__ , G_EDITEVENT.SCHEDULEINFO , (ushort)( 2 ) ) ))  ) ) 
                {
                __context__.SourceCodeLine = 1179;
                return ; 
                }
            
            __context__.SourceCodeLine = 1181;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1183;
                Print( "ERROR: Cannot start file ops\r\n") ; 
                __context__.SourceCodeLine = 1184;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 1185;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1188;
            IFILEHANDLE = (short) ( FileOpen( G_EDITEVENT.SCHEDULEINFO ,(ushort) (((256 | 1) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 1189;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1191;
                Print( "ERROR: Cannot open/create file '{0}' for write.\r\nError Code={1:d}\r\n", G_EDITEVENT . SCHEDULEINFO , (short)IFILEHANDLE) ; 
                __context__.SourceCodeLine = 1192;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 1193;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1196;
            SWRITEBUF  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 1197;
            FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
            __context__.SourceCodeLine = 1199;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_IBYDATEMAXINDEX; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1201;
                SWRITEBUF  .UpdateValue ( Functions.LtoA (  (int) ( G_LDATES[ I ] ) ) + "\u000D\u000A"  ) ; 
                __context__.SourceCodeLine = 1202;
                FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
                __context__.SourceCodeLine = 1199;
                } 
            
            __context__.SourceCodeLine = 1205;
            IERRCODE = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
            __context__.SourceCodeLine = 1207;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1209;
                Print( "ERROR: Ending file ops.\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 1212;
            FREEFILE (  __context__ , G_EDITEVENT.SCHEDULEINFO, (ushort)( 2 )) ; 
            
            }
            
        private void LOADDATEARRAY (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SREADBUF;
            SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 682, this );
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
            
            ushort IFILEHANDLE = 0;
            
            ushort BBUFFERDONE = 0;
            
            ushort IINDEX = 0;
            
            FILE_INFO FIFILE;
            FIFILE  = new FILE_INFO();
            FIFILE .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 1224;
            if ( Functions.TestForTrue  ( ( Functions.Not( CANUSEFILE( __context__ , G_EDITEVENT.SCHEDULEINFO , (ushort)( 2 ) ) ))  ) ) 
                {
                __context__.SourceCodeLine = 1224;
                return ; 
                }
            
            __context__.SourceCodeLine = 1226;
            IINDEX = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1227;
            BBUFFERDONE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1229;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1231;
                Print( "ERROR: Cannot start file ops\r\n") ; 
                __context__.SourceCodeLine = 1232;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 1233;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1236;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FindFirst( G_EDITEVENT.SCHEDULEINFO , ref FIFILE ) != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 1238;
                Print( "ERROR: Could not find file {0}\r\n", G_EDITEVENT . SCHEDULEINFO ) ; 
                __context__.SourceCodeLine = 1239;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 1240;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1243;
            IFILEHANDLE = (ushort) ( FileOpen( G_EDITEVENT.SCHEDULEINFO ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1244;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1246;
                Print( "ERROR: Cannot open file '{0}' for read.\r\n Error Code={1:d}\r\n", G_EDITEVENT . SCHEDULEINFO , (short)IFILEHANDLE) ; 
                __context__.SourceCodeLine = 1247;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 1248;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1251;
            SLINE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 1253;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1256;
                SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                __context__.SourceCodeLine = 1257;
                BBUFFERDONE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1258;
                do 
                    { 
                    __context__.SourceCodeLine = 1260;
                    SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
                    __context__.SourceCodeLine = 1262;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SLINE ) == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (IINDEX == 100) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1263;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1266;
                        G_LDATES [ IINDEX] = (uint) ( Functions.Atol( SLINE ) ) ; 
                        __context__.SourceCodeLine = 1267;
                        IINDEX = (ushort) ( (IINDEX + 1) ) ; 
                        } 
                    
                    } 
                while (false == ( Functions.TestForTrue  ( BBUFFERDONE) )); 
                __context__.SourceCodeLine = 1271;
                if ( Functions.TestForTrue  ( ( Functions.Length( SREADBUF ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1272;
                    SLINE  .UpdateValue ( SREADBUF  ) ; 
                    }
                
                __context__.SourceCodeLine = 1253;
                } 
            
            __context__.SourceCodeLine = 1275;
            FileClose (  (short) ( IFILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 1277;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1279;
                Print( "ERROR: Ending file ops.\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 1282;
            FREEFILE (  __context__ , G_EDITEVENT.SCHEDULEINFO, (ushort)( 2 )) ; 
            __context__.SourceCodeLine = 1284;
            G_IBYDATEINDEX = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1285;
            G_IBYDATEMAXINDEX = (ushort) ( (IINDEX - 1) ) ; 
            
            }
            
        private void SETBYDATEOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1290;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_IBYDATEMAXINDEX == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1291;
                BYDATE_EVENTINFO__DOLLAR__  .UpdateValue ( "Unavailable."  ) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1294;
                if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1296;
                    BYDATE_EVENTINFO__DOLLAR__  .UpdateValue ( "(" + Functions.ItoA (  (int) ( G_IBYDATEINDEX ) ) + "/" + Functions.ItoA (  (int) ( G_IBYDATEMAXINDEX ) ) + ") Annually on " + GETMONTHSTRING (  __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) )) + " " + Functions.LtoA (  (int) ( GETDAYFROMLONG( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ) + "."  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1302;
                    BYDATE_EVENTINFO__DOLLAR__  .UpdateValue ( "(" + Functions.ItoA (  (int) ( G_IBYDATEINDEX ) ) + "/" + Functions.ItoA (  (int) ( G_IBYDATEMAXINDEX ) ) + ") " + GETMONTHSTRING (  __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) )) + " " + Functions.LtoA (  (int) ( GETDAYFROMLONG( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ) + ", " + Functions.LtoA (  (int) ( GETYEARFROMLONG( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) )  ) ; 
                    } 
                
                } 
            
            
            }
            
        private void SETPERIODICOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            ushort IPERIODICTYPE = 0;
            
            short IPERIOD = 0;
            
            CrestronString PTYPE;
            PTYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 1315;
            PERIODIC_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  IPERIODICTYPE ,   ref  IPERIOD ) ; 
            __context__.SourceCodeLine = 1317;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)IPERIODICTYPE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1321;
                        PTYPE  .UpdateValue ( "day(s)"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1325;
                        PTYPE  .UpdateValue ( "week(s)"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1329;
                        PTYPE  .UpdateValue ( "month(s)"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1333;
                        PTYPE  .UpdateValue ( "year(s)"  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 1337;
            PERIODIC_EVENTINFO__DOLLAR__  .UpdateValue ( "Event will occur every " + Functions.ItoA (  (int) ( IPERIOD ) ) + " " + PTYPE  ) ; 
            
            }
            
        private void SETWEEKLYOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            ushort ILOOP = 0;
            
            ushort IVALIDDAYS = 0;
            ushort IVALIDMONTHS = 0;
            
            
            __context__.SourceCodeLine = 1347;
            WEEKLY_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  IVALIDDAYS ,   ref  IVALIDMONTHS ) ; 
            __context__.SourceCodeLine = 1349;
            SUNDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1350;
            MONDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 1351;
            TUESDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 2 ) ) ) ; 
            __context__.SourceCodeLine = 1352;
            WEDNESDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 3 ) ) ) ; 
            __context__.SourceCodeLine = 1353;
            THURSDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 4 ) ) ) ; 
            __context__.SourceCodeLine = 1354;
            FRIDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 5 ) ) ) ; 
            __context__.SourceCodeLine = 1355;
            SATURDAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( 6 ) ) ) ; 
            __context__.SourceCodeLine = 1357;
            JAN_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 1358;
            FEB_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 1359;
            MAR_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 2 ) ) ) ; 
            __context__.SourceCodeLine = 1360;
            APR_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 3 ) ) ) ; 
            __context__.SourceCodeLine = 1361;
            MAY_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 4 ) ) ) ; 
            __context__.SourceCodeLine = 1362;
            JUN_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 5 ) ) ) ; 
            __context__.SourceCodeLine = 1363;
            JUL_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 6 ) ) ) ; 
            __context__.SourceCodeLine = 1364;
            AUG_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 7 ) ) ) ; 
            __context__.SourceCodeLine = 1365;
            SEP_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 8 ) ) ) ; 
            __context__.SourceCodeLine = 1366;
            OCT_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 9 ) ) ) ; 
            __context__.SourceCodeLine = 1367;
            NOV_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 10 ) ) ) ; 
            __context__.SourceCodeLine = 1368;
            DEC_ONOFF_FB  .Value = (ushort) ( GETBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( 11 ) ) ) ; 
            
            }
            
        private void CLEARWEEKLYOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1372;
            SUNDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1373;
            MONDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1374;
            TUESDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1375;
            WEDNESDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1376;
            THURSDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1377;
            FRIDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1378;
            SATURDAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1380;
            JAN_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1381;
            FEB_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1382;
            MAR_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1383;
            APR_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1384;
            MAY_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1385;
            JUN_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1386;
            JUL_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1387;
            AUG_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1388;
            SEP_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1389;
            OCT_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1390;
            NOV_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1391;
            DEC_ONOFF_FB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void SETTYPESPECIFICOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1397;
            EDIT_EVENT_TYPE  .Value = (ushort) ( EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) ) ; 
            __context__.SourceCodeLine = 1399;
            G_IBYDATEINDEX = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1401;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ));
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1405;
                        SETWEEKLYOUTPUTS (  __context__  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1409;
                        CLEARWEEKLYOUTPUTS (  __context__  ) ; 
                        __context__.SourceCodeLine = 1410;
                        LOADDATEARRAY (  __context__  ) ; 
                        __context__.SourceCodeLine = 1411;
                        SETBYDATEOUTPUTS (  __context__  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 1415;
                        CLEARWEEKLYOUTPUTS (  __context__  ) ; 
                        __context__.SourceCodeLine = 1416;
                        SETPERIODICOUTPUTS (  __context__  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void UPDATEEDITEVENTSUSPENDED (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1423;
            EDIT_EVENT_SUSPENDED  .Value = (ushort) ( G_EVENTS[ G_IEDITEVENT ].SUSPENDED ) ; 
            __context__.SourceCodeLine = 1424;
            
            
            }
            
        private void UPDATEEDITEVENTREADONLY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1431;
            EDIT_EVENT_READONLY  .Value = (ushort) ( G_EDITEVENT.READONLY ) ; 
            
            }
            
        private void SETEDITEVENTOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1437;
            EDIT_EVENT_NUMBER  .Value = (ushort) ( G_IEDITEVENT ) ; 
            __context__.SourceCodeLine = 1438;
            EDIT_EVENT_NAME__DOLLAR__  .UpdateValue ( G_EDITEVENT . NAME  ) ; 
            __context__.SourceCodeLine = 1439;
            EDIT_EVENT_TYPE  .Value = (ushort) ( G_EDITEVENT.EVENTTYPE ) ; 
            __context__.SourceCodeLine = 1440;
            EDIT_EVENT_ANNUAL  .Value = (ushort) ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) ) ; 
            __context__.SourceCodeLine = 1441;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT > 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT < G_IMAXUSEDEVENT ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1442;
                AADSSCROLLARROW__DOLLAR__  .UpdateValue ( "\u0004"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1443;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IEDITEVENT < G_IMAXUSEDEVENT ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1444;
                    AADSSCROLLARROW__DOLLAR__  .UpdateValue ( "\u0003"  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1445;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IEDITEVENT > 1 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1446;
                        AADSSCROLLARROW__DOLLAR__  .UpdateValue ( "\u0002"  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1448;
                        AADSSCROLLARROW__DOLLAR__  .UpdateValue ( "\u0020"  ) ; 
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1451;
            SETTYPESPECIFICOUTPUTS (  __context__  ) ; 
            __context__.SourceCodeLine = 1452;
            UPDATEEDITEVENTTIME (  __context__  ) ; 
            __context__.SourceCodeLine = 1453;
            UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
            __context__.SourceCodeLine = 1454;
            UPDATEEDITEVENTREADONLY (  __context__  ) ; 
            __context__.SourceCodeLine = 1455;
            UPDATESTARTDATE (  __context__  ) ; 
            __context__.SourceCodeLine = 1456;
            UPDATESTOPDATE (  __context__  ) ; 
            
            }
            
        private void SETEDITEVENT (  SplusExecutionContext __context__, ushort IEVENTNUM ) 
            { 
            ushort ILOOP = 0;
            
            
            __context__.SourceCodeLine = 1477;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVENTNUM < 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 1478;
                G_IEDITEVENT = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1479;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVENTNUM > G_IMAXUSEDEVENT ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1480;
                    G_IEDITEVENT = (ushort) ( G_IMAXUSEDEVENT ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1482;
                    G_IEDITEVENT = (ushort) ( IEVENTNUM ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 1484;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ G_IEDITEVENT ].FREE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 1486;
                COPYEVENT (  __context__ , G_EVENTS[ G_IEDITEVENT ],   ref  G_EDITEVENT ) ; 
                __context__.SourceCodeLine = 1488;
                SETEDITEVENTOUTPUTS (  __context__  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1493;
                Print( "ERROR: Event {0:d} is not in use or is Hidden.\r\n", (short)G_IEDITEVENT) ; 
                __context__.SourceCodeLine = 1495;
                EDIT_EVENT_NAME__DOLLAR__  .UpdateValue ( "ERROR"  ) ; 
                __context__.SourceCodeLine = 1496;
                EDIT_EVENT_TIME__DOLLAR__  .UpdateValue ( "ERROR"  ) ; 
                } 
            
            
            }
            
        private short WRITEEVENTFILE (  SplusExecutionContext __context__ ) 
            { 
            short IFILEHANDLE = 0;
            
            short IERRCODE = 0;
            
            CrestronString SWRITEBUF;
            SWRITEBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            CrestronString HIDDEN;
            HIDDEN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            CrestronString READONLY;
            READONLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1525;
            STEMP  .UpdateValue ( FILENAME__DOLLAR__  ) ; 
            __context__.SourceCodeLine = 1526;
            if ( Functions.TestForTrue  ( ( Functions.Not( CANUSEFILE( __context__ , STEMP , (ushort)( 1 ) ) ))  ) ) 
                {
                __context__.SourceCodeLine = 1526;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                }
            
            __context__.SourceCodeLine = 1527;
            STEMP  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 1529;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1531;
                Print( "ERROR: Cannot start file ops\r\n") ; 
                __context__.SourceCodeLine = 1532;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 1533;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 1536;
            IFILEHANDLE = (short) ( FileOpen( FILENAME__DOLLAR__ ,(ushort) (((256 | 1) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 1537;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1539;
                Print( "ERROR: Cannot open/create file '{0}' for write.\r\nError Code={1:d}\r\n", FILENAME__DOLLAR__ , (short)IFILEHANDLE) ; 
                __context__.SourceCodeLine = 1540;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 1541;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 1545;
            SWRITEBUF  .UpdateValue ( "#" + Functions.ItoA (  (int) ( 2 ) ) + "\u000D\u000A"  ) ; 
            __context__.SourceCodeLine = 1546;
            FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
            __context__.SourceCodeLine = 1549;
            MakeString ( SWRITEBUF , "' EVENT DATA SAVED ON {0}\r\n", Functions.Date (  (int) ( 1 ) ) ) ; 
            __context__.SourceCodeLine = 1550;
            FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
            __context__.SourceCodeLine = 1552;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1555;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1558;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1560;
                        HIDDEN  .UpdateValue ( "H"  ) ; 
                        __context__.SourceCodeLine = 1561;
                        READONLY  .UpdateValue ( ""  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1563;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].READONLY == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1565;
                            READONLY  .UpdateValue ( "R"  ) ; 
                            __context__.SourceCodeLine = 1566;
                            HIDDEN  .UpdateValue ( ""  ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1570;
                            HIDDEN  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 1571;
                            READONLY  .UpdateValue ( "W"  ) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 1575;
                    MakeString ( STIME , "{0:d}", (short)G_EVENTS[ I ]._TIME) ; 
                    __context__.SourceCodeLine = 1577;
                    SWRITEBUF  .UpdateValue ( Functions.ItoA (  (int) ( I ) ) + "," + G_EVENTS [ I] . NAME + "," + Functions.ItoA (  (int) ( G_EVENTS[ I ].EVENTTYPE ) ) + "," + Functions.LtoA (  (int) ( G_EVENTS[ I ]._STARTDATE ) ) + "," + Functions.LtoA (  (int) ( G_EVENTS[ I ]._STOPDATE ) ) + "," + Functions.ItoA (  (int) ( G_EVENTS[ I ].TIMEBASE ) ) + "," + STIME + "," + G_EVENTS [ I] . SCHEDULEINFO + "," + Functions.ItoA (  (int) ( G_EVENTS[ I ].SUSPENDED ) ) + "," + HIDDEN + READONLY + "," + G_EVENTS [ I] . LASTMODIFIED + "," + G_EVENTS [ I] . USERDATA + "\u000D\u000A"  ) ; 
                    __context__.SourceCodeLine = 1591;
                    FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 1552;
                } 
            
            __context__.SourceCodeLine = 1597;
            IERRCODE = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
            __context__.SourceCodeLine = 1598;
            
            __context__.SourceCodeLine = 1602;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRCODE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1604;
                Print( "ERROR: Closing file after write. Error code = ({0:d})\r\n", (short)IERRCODE) ; 
                } 
            
            __context__.SourceCodeLine = 1607;
            FindFirst ( FILENAME__DOLLAR__ ,  ref G_FIDATAFILE ) ; 
            __context__.SourceCodeLine = 1610;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1612;
                Print( "ERROR: Ending file ops.\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 1615;
            STEMP  .UpdateValue ( FILENAME__DOLLAR__  ) ; 
            __context__.SourceCodeLine = 1616;
            FREEFILE (  __context__ , STEMP, (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1617;
            STEMP  .UpdateValue ( ""  ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private short SAVEEVENTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1640;
            CreateWait ( "SAVEWAIT" , 500 , SAVEWAIT_Callback ) ;
            __context__.SourceCodeLine = 1644;
            RetimeWait ( (int)500, "SAVEWAIT" ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        public void SAVEWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 1642;
            WRITEEVENTFILE (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private short GETNORMALIZEDEVENTTIME (  SplusExecutionContext __context__, ushort IEVENTINDEX ) 
        { 
        ushort IBASETIME = 0;
        
        
        __context__.SourceCodeLine = 1665;
        
            {
            int __SPLS_TMPVAR__SWTCH_6__ = ((int)G_EVENTS[ IEVENTINDEX ].TIMEBASE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1669;
                    return (short)( G_EVENTS[ IEVENTINDEX ]._TIME) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1674;
                    return (short)( (G_EVENTS[ IEVENTINDEX ]._TIME + 720)) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1680;
                    IBASETIME = (ushort) ( ((MORNING_HOUR  .UshortValue * 60) + MORNING_MIN  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 1681;
                    return (short)( (IBASETIME + G_EVENTS[ IEVENTINDEX ]._TIME)) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1688;
                    IBASETIME = (ushort) ( ((NIGHT_HOUR  .UshortValue * 60) + NIGHT_MIN  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 1690;
                    return (short)( (IBASETIME + G_EVENTS[ IEVENTINDEX ]._TIME)) ; 
                    } 
                
                } 
                
            }
            
        
        
        return 0; // default return value (none specified in module)
        }
        
    private short COMPAREFILEDATEANDTIME (  SplusExecutionContext __context__, FILE_INFO FIFILE1 , FILE_INFO FIFILE2 ) 
        { 
        
        __context__.SourceCodeLine = 1716;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate > FIFILE2.iDate ))  ) ) 
            {
            __context__.SourceCodeLine = 1717;
            return (short)( 1) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1718;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate < FIFILE2.iDate ))  ) ) 
                {
                __context__.SourceCodeLine = 1719;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1722;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime > FIFILE2.iTime ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1723;
                    return (short)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1724;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime < FIFILE2.iTime ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1725;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1727;
                        return (short)( 0) ; 
                        }
                    
                    }
                
                } 
            
            }
        
        
        return 0; // default return value (none specified in module)
        }
        
    private void VALIDATEEDITEVENTTIME (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 1733;
        
            {
            int __SPLS_TMPVAR__SWTCH_7__ = ((int)G_EDITEVENT.TIMEBASE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1737;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1739;
                        G_EDITEVENT . _TIME = (short) ( (720 - Mod( Functions.Abs( G_EDITEVENT._TIME ) , 720 )) ) ; 
                        __context__.SourceCodeLine = 1740;
                        G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1743;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME >= 720 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1745;
                            G_EDITEVENT . _TIME = (short) ( Mod( G_EDITEVENT._TIME , 720 ) ) ; 
                            __context__.SourceCodeLine = 1746;
                            G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1752;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1754;
                        G_EDITEVENT . _TIME = (short) ( (720 - Mod( Functions.Abs( G_EDITEVENT._TIME ) , 720 )) ) ; 
                        __context__.SourceCodeLine = 1755;
                        G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1758;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME >= 720 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1760;
                            G_EDITEVENT . _TIME = (short) ( Mod( G_EDITEVENT._TIME , 720 ) ) ; 
                            __context__.SourceCodeLine = 1761;
                            G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1767;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( G_EDITEVENT._TIME ) > 360 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1769;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1770;
                            G_EDITEVENT . _TIME = (short) ( Functions.ToInteger( -( 360 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1772;
                            G_EDITEVENT . _TIME = (short) ( 360 ) ; 
                            }
                        
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1779;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( G_EDITEVENT._TIME ) > 360 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1781;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1782;
                            G_EDITEVENT . _TIME = (short) ( Functions.ToInteger( -( 360 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1784;
                            G_EDITEVENT . _TIME = (short) ( 360 ) ; 
                            }
                        
                        } 
                    
                    } 
                
                } 
                
            }
            
        
        
        }
        
    object HOUR_UP_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 1794;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                {
                __context__.SourceCodeLine = 1795;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1797;
            MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
            __context__.SourceCodeLine = 1799;
            G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME + 60) ) ; 
            __context__.SourceCodeLine = 1800;
            VALIDATEEDITEVENTTIME (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object HOUR_DOWN_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1805;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1806;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1808;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1810;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME - 60) ) ; 
        __context__.SourceCodeLine = 1811;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_UP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1816;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1817;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1819;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1821;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME + 1) ) ; 
        __context__.SourceCodeLine = 1822;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_DOWN_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1827;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1828;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1830;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1832;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME - 1) ) ; 
        __context__.SourceCodeLine = 1833;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AM_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1838;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1839;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1841;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1843;
        G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1844;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PM_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1849;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1850;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1852;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1854;
        G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1855;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNRISE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1860;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1861;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1863;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1865;
        G_EDITEVENT . TIMEBASE = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1866;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNSET_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1871;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1872;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1874;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1876;
        G_EDITEVENT . TIMEBASE = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 1877;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOUR_UP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1882;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1883;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1885;
        UPDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_EVENT_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1893;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( G_IEDITEVENT ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1895;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1897;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1898;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1893;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_FIRST_EVENT_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1908;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1910;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1912;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1913;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1908;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_LAST_EVENT_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1922;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( G_IMAXUSEDEVENT ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1924;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1926;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1927;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1922;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_NEXT_EVENT_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1936;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( (G_IEDITEVENT + 1) ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1938;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1939;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1940;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1936;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_PREV_EVENT_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1950;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( (G_IEDITEVENT - 1) ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1952;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1954;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1955;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1950;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVE_EDIT_EVENT_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1962;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT <= 250 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1965;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 1967;
                SETEDITEVENT (  __context__ , (ushort)( G_IEDITEVENT )) ; 
                __context__.SourceCodeLine = 1968;
                Functions.TerminateEvent (); 
                } 
            
            __context__.SourceCodeLine = 1971;
            
            __context__.SourceCodeLine = 1974;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 2))  ) ) 
                {
                __context__.SourceCodeLine = 1975;
                WRITEDATEARRAY (  __context__  ) ; 
                }
            
            __context__.SourceCodeLine = 1977;
            COPYEVENT (  __context__ , G_EDITEVENT,   ref  G_EVENTS[ G_IEDITEVENT ] ) ; 
            __context__.SourceCodeLine = 1978;
            SAVEEVENTS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUSPEND_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 1986;
        MakeString ( STEMP , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1987;
        G_EDITEVENT . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1988;
        G_EVENTS [ G_IEDITEVENT] . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1990;
        G_EDITEVENT . SUSPENDED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1991;
        G_EVENTS [ G_IEDITEVENT] . SUSPENDED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1992;
        UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
        __context__.SourceCodeLine = 1993;
        SAVEEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RESUME_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 2001;
        MakeString ( STEMP , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2002;
        G_EDITEVENT . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 2003;
        G_EVENTS [ G_IEDITEVENT] . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 2005;
        G_EDITEVENT . SUSPENDED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2006;
        G_EVENTS [ G_IEDITEVENT] . SUSPENDED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2007;
        UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
        __context__.SourceCodeLine = 2008;
        SAVEEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_DAY_UP_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2013;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2014;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2016;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2018;
        G_EDITEVENT . _STOPDATE = (uint) ( INCREMENTDATE( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_DAY_DOWN_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2023;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2024;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2026;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2028;
        G_EDITEVENT . _STOPDATE = (uint) ( DECREMENTDATE( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_MONTH_UP_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2033;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2034;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2036;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2038;
        G_EDITEVENT . _STOPDATE = (uint) ( INCREMENTMONTH( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_MONTH_DOWN_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2043;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2044;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2046;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2048;
        G_EDITEVENT . _STOPDATE = (uint) ( DECREMENTMONTH( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_YEAR_UP_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2053;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2053;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2055;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2056;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2058;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2060;
        G_EDITEVENT . _STOPDATE = (uint) ( INCREMENTYEAR( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_YEAR_DOWN_OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2065;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2065;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2067;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2068;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2070;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2072;
        G_EDITEVENT . _STOPDATE = (uint) ( DECREMENTYEAR( __context__ , (uint)( G_EDITEVENT._STOPDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_DAY_UP_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2077;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2078;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2080;
        UPDATESTOPDATE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_DAY_UP_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2085;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2086;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2088;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2090;
        G_EDITEVENT . _STARTDATE = (uint) ( INCREMENTDATE( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_DAY_DOWN_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2095;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2096;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2098;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2100;
        G_EDITEVENT . _STARTDATE = (uint) ( DECREMENTDATE( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_MONTH_UP_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2105;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2106;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2108;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2110;
        G_EDITEVENT . _STARTDATE = (uint) ( INCREMENTMONTH( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_MONTH_DOWN_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2115;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2116;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2118;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2120;
        G_EDITEVENT . _STARTDATE = (uint) ( DECREMENTMONTH( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_YEAR_UP_OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2125;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2125;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2127;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2128;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2130;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2132;
        G_EDITEVENT . _STARTDATE = (uint) ( INCREMENTYEAR( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_YEAR_DOWN_OnPush_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2137;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2137;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2139;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2140;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2142;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2144;
        G_EDITEVENT . _STARTDATE = (uint) ( DECREMENTYEAR( __context__ , (uint)( G_EDITEVENT._STARTDATE ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object START_DAY_UP_OnPush_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2149;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2150;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2152;
        UPDATESTARTDATE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ANNUAL_ONOFF_OnPush_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        uint LSTART = 0;
        uint LSTOP = 0;
        
        
        __context__.SourceCodeLine = 2173;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2174;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2176;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2178;
        G_EDITEVENT . EVENTTYPE = (ushort) ( TOGGLEBIT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) , (ushort)( 8 ) ) ) ; 
        __context__.SourceCodeLine = 2180;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2183;
            LSTART = (uint) ( G_EDITEVENT._STARTDATE ) ; 
            __context__.SourceCodeLine = 2184;
            LSTOP = (uint) ( G_EDITEVENT._STOPDATE ) ; 
            __context__.SourceCodeLine = 2185;
            SETANNUALSTARTSTOP (  __context__ ,   ref  LSTART ,   ref  LSTOP ) ; 
            __context__.SourceCodeLine = 2186;
            G_EDITEVENT . _STARTDATE = (uint) ( LSTART ) ; 
            __context__.SourceCodeLine = 2187;
            G_EDITEVENT . _STOPDATE = (uint) ( LSTOP ) ; 
            } 
        
        __context__.SourceCodeLine = 2191;
        EDIT_EVENT_ANNUAL  .Value = (ushort) ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) ) ; 
        __context__.SourceCodeLine = 2192;
        UPDATESTARTDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 2193;
        UPDATESTOPDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 2194;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 2))  ) ) 
            {
            __context__.SourceCodeLine = 2195;
            SETBYDATEOUTPUTS (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


private ushort BYDATE_EVENTOCCURSONDAY_FILE (  SplusExecutionContext __context__, ushort IEVENTNUM , uint LJTARGET ) 
    { 
    uint LTEST = 0;
    
    uint LJTEST = 0;
    
    CrestronString SREADBUF;
    SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 682, this );
    
    CrestronString SLINE;
    SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
    
    ushort IFILEHANDLE = 0;
    
    ushort BBUFFERDONE = 0;
    
    FILE_INFO FIFILE;
    FIFILE  = new FILE_INFO();
    FIFILE .PopulateDefaults();
    
    
    __context__.SourceCodeLine = 2221;
    BBUFFERDONE = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 2223;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2225;
        Print( "ERROR: Cannot start file ops\r\n") ; 
        __context__.SourceCodeLine = 2226;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2227;
        return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2230;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ].SCHEDULEINFO == "") ) || Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ].SCHEDULEINFO == " ") )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ].SCHEDULEINFO == "0") )) ))  ) ) 
        {
        __context__.SourceCodeLine = 2231;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 2233;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FindFirst( G_EVENTS[ IEVENTNUM ].SCHEDULEINFO , ref FIFILE ) != 0))  ) ) 
        { 
        __context__.SourceCodeLine = 2235;
        Print( "ERROR: Could not find file {0}\r\n", G_EVENTS [ IEVENTNUM] . SCHEDULEINFO ) ; 
        __context__.SourceCodeLine = 2236;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2237;
        return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2240;
    IFILEHANDLE = (ushort) ( FileOpen( G_EVENTS[ IEVENTNUM ].SCHEDULEINFO ,(ushort) (0 | 16384) ) ) ; 
    __context__.SourceCodeLine = 2241;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2243;
        Print( "ERROR: Cannot open file '{0}' for read.\r\n Error Code={1:d}\r\n", G_EVENTS [ IEVENTNUM] . SCHEDULEINFO , (short)IFILEHANDLE) ; 
        __context__.SourceCodeLine = 2244;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2245;
        return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2248;
    SLINE  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 2250;
    while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2253;
        SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
        __context__.SourceCodeLine = 2254;
        BBUFFERDONE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2255;
        do 
            { 
            __context__.SourceCodeLine = 2257;
            SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
            __context__.SourceCodeLine = 2259;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 2261;
                BBUFFERDONE = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 2265;
                LTEST = (uint) ( Functions.Atol( SLINE ) ) ; 
                __context__.SourceCodeLine = 2266;
                if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EVENTS[ IEVENTNUM ].EVENTTYPE ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2267;
                    LTEST = (uint) ( CREATEDATEL( __context__ , (ushort)( GETMONTHFROMLONG( __context__ , (uint)( LTEST ) ) ) , (ushort)( GETDAYFROMLONG( __context__ , (uint)( LTEST ) ) ) , (ushort)( Functions.GetYearNum() ) ) ) ; 
                    }
                
                __context__.SourceCodeLine = 2269;
                LJTEST = (uint) ( GETJDAY( __context__ , (uint)( LTEST ) ) ) ; 
                __context__.SourceCodeLine = 2271;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LJTEST == LJTARGET))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2273;
                    FileClose (  (short) ( IFILEHANDLE ) ) ; 
                    __context__.SourceCodeLine = 2274;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2276;
                        Print( "ERROR: Ending file ops.\r\n") ; 
                        } 
                    
                    __context__.SourceCodeLine = 2278;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2280;
                        Print( "ERROR: Ending file ops.\r\n") ; 
                        } 
                    
                    __context__.SourceCodeLine = 2282;
                    return (ushort)( 1) ; 
                    } 
                
                } 
            
            } 
        while (false == ( Functions.TestForTrue  ( BBUFFERDONE) )); 
        __context__.SourceCodeLine = 2287;
        if ( Functions.TestForTrue  ( ( Functions.Length( SREADBUF ))  ) ) 
            {
            __context__.SourceCodeLine = 2288;
            SLINE  .UpdateValue ( SREADBUF  ) ; 
            }
        
        __context__.SourceCodeLine = 2250;
        } 
    
    __context__.SourceCodeLine = 2291;
    FileClose (  (short) ( IFILEHANDLE ) ) ; 
    __context__.SourceCodeLine = 2292;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2294;
        Print( "ERROR: Ending file ops.\r\n") ; 
        } 
    
    __context__.SourceCodeLine = 2297;
    return (ushort)( 0) ; 
    
    }
    
private ushort WEEKLY_EVENTOCCURSONDAY (  SplusExecutionContext __context__, ushort IEVENTNUM , uint GDATE ) 
    { 
    CrestronString STRDETAILS;
    STRDETAILS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    uint LSTART = 0;
    uint LSTOP = 0;
    
    ushort IVALIDDAYS = 0;
    
    ushort IVALIDMONTHS = 0;
    
    
    __context__.SourceCodeLine = 2309;
    STRDETAILS  .UpdateValue ( G_EVENTS [ IEVENTNUM] . SCHEDULEINFO  ) ; 
    __context__.SourceCodeLine = 2310;
    WEEKLY_EXTRACTINFO (  __context__ , STRDETAILS,   ref  IVALIDDAYS ,   ref  IVALIDMONTHS ) ; 
    __context__.SourceCodeLine = 2313;
    if ( Functions.TestForTrue  ( ( USESTARTSTOPDATE( __context__ , (ushort)( IEVENTNUM ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2316;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EVENTS[ IEVENTNUM ].EVENTTYPE ) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2318;
            LSTART = (uint) ( G_EVENTS[ IEVENTNUM ]._STARTDATE ) ; 
            __context__.SourceCodeLine = 2319;
            LSTOP = (uint) ( G_EVENTS[ IEVENTNUM ]._STOPDATE ) ; 
            __context__.SourceCodeLine = 2320;
            SETANNUALSTARTSTOP (  __context__ ,   ref  LSTART ,   ref  LSTOP ) ; 
            __context__.SourceCodeLine = 2321;
            G_EVENTS [ IEVENTNUM] . _STARTDATE = (uint) ( LSTART ) ; 
            __context__.SourceCodeLine = 2322;
            G_EVENTS [ IEVENTNUM] . _STOPDATE = (uint) ( LSTOP ) ; 
            } 
        
        __context__.SourceCodeLine = 2325;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BEFOREORAFTERDATE( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STARTDATE ) , (uint)( GDATE ) ) == 2))  ) ) 
            {
            __context__.SourceCodeLine = 2326;
            return (ushort)( 0) ; 
            }
        
        __context__.SourceCodeLine = 2328;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_EVENTS[ IEVENTNUM ]._STOPDATE > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (BEFOREORAFTERDATE( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STOPDATE ) , (uint)( GDATE ) ) == 1) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 2329;
            return (ushort)( 0) ; 
            }
        
        } 
    
    __context__.SourceCodeLine = 2332;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((IVALIDMONTHS & G_IMONTHMASK[ GETMONTHFROMLONG( __context__ , (uint)( GDATE ) ) ]) == 0))  ) ) 
        {
        __context__.SourceCodeLine = 2333;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 2335;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((IVALIDDAYS & G_IDAYOFWEEKMASK[ GETDAYOFWEEK( __context__ , (uint)( GDATE ) ) ]) == 0))  ) ) 
        {
        __context__.SourceCodeLine = 2336;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 2338;
    return (ushort)( 1) ; 
    
    }
    
private ushort PERIODIC_MONTHLYDIFF (  SplusExecutionContext __context__, uint LSTART , uint LEND ) 
    { 
    ushort ITEMPMDIFF = 0;
    
    ushort ITEMPYDIFF = 0;
    
    
    __context__.SourceCodeLine = 2346;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GETDAYFROMLONG( __context__ , (uint)( LSTART ) ) == GETDAYFROMLONG( __context__ , (uint)( LEND ) )))  ) ) 
        { 
        __context__.SourceCodeLine = 2348;
        ITEMPMDIFF = (ushort) ( (GETMONTHFROMLONG( __context__ , (uint)( LEND ) ) - GETMONTHFROMLONG( __context__ , (uint)( LSTART ) )) ) ; 
        __context__.SourceCodeLine = 2349;
        ITEMPYDIFF = (ushort) ( (GETYEARFROMLONG( __context__ , (uint)( LEND ) ) - GETYEARFROMLONG( __context__ , (uint)( LSTART ) )) ) ; 
        __context__.SourceCodeLine = 2351;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMPMDIFF < 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 2353;
            ITEMPMDIFF = (ushort) ( (ITEMPMDIFF + 12) ) ; 
            __context__.SourceCodeLine = 2354;
            ITEMPYDIFF = (ushort) ( (ITEMPYDIFF - 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 2357;
        ITEMPMDIFF = (ushort) ( (ITEMPMDIFF + (ITEMPYDIFF * 12)) ) ; 
        __context__.SourceCodeLine = 2358;
        return (ushort)( ITEMPMDIFF) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 2361;
        return (ushort)( Functions.ToInteger( -( 2 ) )) ; 
        }
    
    __context__.SourceCodeLine = 2363;
    return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
    
    }
    
private ushort PERIODIC_YEARLYDIFF (  SplusExecutionContext __context__, uint LSTART , uint LEND ) 
    { 
    
    __context__.SourceCodeLine = 2368;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GETMONTHFROMLONG( __context__ , (uint)( LSTART ) ) == GETMONTHFROMLONG( __context__ , (uint)( LEND ) )))  ) ) 
        { 
        __context__.SourceCodeLine = 2370;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GETDAYFROMLONG( __context__ , (uint)( LSTART ) ) == GETDAYFROMLONG( __context__ , (uint)( LEND ) )))  ) ) 
            {
            __context__.SourceCodeLine = 2371;
            return (ushort)( (GETYEARFROMLONG( __context__ , (uint)( LEND ) ) - GETYEARFROMLONG( __context__ , (uint)( LSTART ) ))) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 2373;
            return (ushort)( Functions.ToInteger( -( 2 ) )) ; 
            }
        
        } 
    
    else 
        {
        __context__.SourceCodeLine = 2376;
        return (ushort)( Functions.ToInteger( -( 3 ) )) ; 
        }
    
    __context__.SourceCodeLine = 2378;
    return (ushort)( Functions.ToInteger( -( 4 ) )) ; 
    
    }
    
private ushort PERIODIC_EVENTOCCURSONDAY (  SplusExecutionContext __context__, ushort IEVENTNUM , uint LJTARGET ) 
    { 
    uint GDATE = 0;
    
    uint LJSTART = 0;
    
    int LDIFF = 0;
    
    uint LSTART = 0;
    uint LSTOP = 0;
    
    int IDIFF = 0;
    
    ushort IPERIODICTYPE = 0;
    
    short IPERIOD = 0;
    
    
    __context__.SourceCodeLine = 2391;
    GDATE = (uint) ( GETGDATE( __context__ , (int)( LJTARGET ) ) ) ; 
    __context__.SourceCodeLine = 2394;
    if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EVENTS[ IEVENTNUM ].EVENTTYPE ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2396;
        LSTART = (uint) ( G_EVENTS[ IEVENTNUM ]._STARTDATE ) ; 
        __context__.SourceCodeLine = 2397;
        LSTOP = (uint) ( G_EVENTS[ IEVENTNUM ]._STOPDATE ) ; 
        __context__.SourceCodeLine = 2398;
        SETANNUALSTARTSTOP (  __context__ ,   ref  LSTART ,   ref  LSTOP ) ; 
        __context__.SourceCodeLine = 2399;
        G_EVENTS [ IEVENTNUM] . _STARTDATE = (uint) ( LSTART ) ; 
        __context__.SourceCodeLine = 2400;
        G_EVENTS [ IEVENTNUM] . _STOPDATE = (uint) ( LSTOP ) ; 
        } 
    
    __context__.SourceCodeLine = 2404;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BEFOREORAFTERDATE( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STARTDATE ) , (uint)( GDATE ) ) == 2))  ) ) 
        {
        __context__.SourceCodeLine = 2404;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 2406;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ]._STOPDATE != 0))  ) ) 
        {
        __context__.SourceCodeLine = 2407;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BEFOREORAFTERDATE( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STOPDATE ) , (uint)( GDATE ) ) == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2407;
            return (ushort)( 0) ; 
            }
        
        }
    
    __context__.SourceCodeLine = 2409;
    LJSTART = (uint) ( GETJDAY( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STARTDATE ) ) ) ; 
    __context__.SourceCodeLine = 2411;
    PERIODIC_EXTRACTINFO (  __context__ , G_EVENTS[ IEVENTNUM ].SCHEDULEINFO,   ref  IPERIODICTYPE ,   ref  IPERIOD ) ; 
    __context__.SourceCodeLine = 2413;
    
        {
        int __SPLS_TMPVAR__SWTCH_8__ = ((int)IPERIODICTYPE);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 0) ) ) ) 
                { 
                __context__.SourceCodeLine = 2417;
                LDIFF = (int) ( (LJTARGET - LJSTART) ) ; 
                __context__.SourceCodeLine = 2418;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPERIOD == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2419;
                    return (ushort)( 1) ; 
                    }
                
                __context__.SourceCodeLine = 2420;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( LDIFF , IPERIOD ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2421;
                    return (ushort)( 1) ; 
                    }
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 1) ) ) ) 
                { 
                __context__.SourceCodeLine = 2425;
                LDIFF = (int) ( (LJTARGET - LJSTART) ) ; 
                __context__.SourceCodeLine = 2426;
                IPERIOD = (short) ( (7 * IPERIOD) ) ; 
                __context__.SourceCodeLine = 2427;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPERIOD == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2428;
                    return (ushort)( 1) ; 
                    }
                
                __context__.SourceCodeLine = 2429;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( LDIFF , IPERIOD ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2430;
                    return (ushort)( 1) ; 
                    }
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 2) ) ) ) 
                { 
                __context__.SourceCodeLine = 2434;
                IDIFF = (int) ( PERIODIC_MONTHLYDIFF( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STARTDATE ) , (uint)( GDATE ) ) ) ; 
                __context__.SourceCodeLine = 2435;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDIFF < 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2435;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 2436;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPERIOD == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2437;
                    return (ushort)( 1) ; 
                    }
                
                __context__.SourceCodeLine = 2438;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IDIFF , IPERIOD ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2439;
                    return (ushort)( 1) ; 
                    }
                
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_8__ == ( 3) ) ) ) 
                { 
                __context__.SourceCodeLine = 2443;
                IDIFF = (int) ( PERIODIC_YEARLYDIFF( __context__ , (uint)( G_EVENTS[ IEVENTNUM ]._STARTDATE ) , (uint)( GDATE ) ) ) ; 
                __context__.SourceCodeLine = 2444;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDIFF < 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2444;
                    return (ushort)( 0) ; 
                    }
                
                __context__.SourceCodeLine = 2445;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPERIOD == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2446;
                    return (ushort)( 1) ; 
                    }
                
                __context__.SourceCodeLine = 2447;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( IDIFF , IPERIOD ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2448;
                    return (ushort)( 1) ; 
                    }
                
                } 
            
            } 
            
        }
        
    
    __context__.SourceCodeLine = 2450;
    ; 
    __context__.SourceCodeLine = 2452;
    return (ushort)( 0) ; 
    
    }
    
private ushort EVENTOCCURSONDAY (  SplusExecutionContext __context__, ushort IEVENTNUM , uint JDAY ) 
    { 
    
    __context__.SourceCodeLine = 2460;
    
        {
        int __SPLS_TMPVAR__SWTCH_9__ = ((int)EVENTTYPE( __context__ , (ushort)( G_EVENTS[ IEVENTNUM ].EVENTTYPE ) ));
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 0) ) ) ) 
                { 
                __context__.SourceCodeLine = 2464;
                return (ushort)( WEEKLY_EVENTOCCURSONDAY( __context__ , (ushort)( IEVENTNUM ) , (uint)( GETGDATE( __context__ , (int)( JDAY ) ) ) )) ; 
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 1) ) ) ) 
                { 
                __context__.SourceCodeLine = 2468;
                return (ushort)( PERIODIC_EVENTOCCURSONDAY( __context__ , (ushort)( IEVENTNUM ) , (uint)( JDAY ) )) ; 
                } 
            
            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_9__ == ( 2) ) ) ) 
                { 
                __context__.SourceCodeLine = 2472;
                return (ushort)( BYDATE_EVENTOCCURSONDAY_FILE( __context__ , (ushort)( IEVENTNUM ) , (uint)( JDAY ) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 2476;
                
                __context__.SourceCodeLine = 2479;
                G_EVENTS [ IEVENTNUM] . FREE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 2480;
                return (ushort)( 0) ; 
                } 
            
            } 
            
        }
        
    
    
    return 0; // default return value (none specified in module)
    }
    
private void RUNSCHED (  SplusExecutionContext __context__, uint STARTINGJDAY , ushort STARTINGTIME , uint CURRENTJDAY ) 
    { 
    ushort I = 0;
    ushort INDEX = 0;
    ushort IEVTTIME = 0;
    ushort ICURRENTTIME = 0;
    ushort WORKINGINDEX = 0;
    ushort LOWESTINDEX = 0;
    ushort OFFSET = 0;
    
    ushort [,] EVENTS;
    EVENTS  = new ushort[ 251,3 ];
    
    ushort [,] TEMP;
    TEMP  = new ushort[ 3,3 ];
    
    CrestronString MSG;
    MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 2494;
    
    __context__.SourceCodeLine = 2498;
    INDEX = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 2499;
    ICURRENTTIME = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
    __context__.SourceCodeLine = 2501;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STARTINGJDAY != CURRENTJDAY))  ) ) 
        {
        __context__.SourceCodeLine = 2502;
        OFFSET = (ushort) ( 1440 ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 2504;
        OFFSET = (ushort) ( 0 ) ; 
        }
    
    __context__.SourceCodeLine = 2506;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 2508;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( G_EVENTS[ I ].SUSPENDED ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2510;
            IEVTTIME = (ushort) ( GETNORMALIZEDEVENTTIME( __context__ , (ushort)( I ) ) ) ; 
            __context__.SourceCodeLine = 2512;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STARTINGJDAY != CURRENTJDAY))  ) ) 
                { 
                __context__.SourceCodeLine = 2514;
                if ( Functions.TestForTrue  ( ( EVENTOCCURSONDAY( __context__ , (ushort)( I ) , (uint)( STARTINGJDAY ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2516;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVTTIME >= STARTINGTIME ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2518;
                        INDEX = (ushort) ( (INDEX + 1) ) ; 
                        __context__.SourceCodeLine = 2519;
                        EVENTS [ INDEX , 1] = (ushort) ( I ) ; 
                        __context__.SourceCodeLine = 2520;
                        EVENTS [ INDEX , 2] = (ushort) ( IEVTTIME ) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 2524;
                if ( Functions.TestForTrue  ( ( EVENTOCCURSONDAY( __context__ , (ushort)( I ) , (uint)( CURRENTJDAY ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2526;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVTTIME < ICURRENTTIME ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2528;
                        INDEX = (ushort) ( (INDEX + 1) ) ; 
                        __context__.SourceCodeLine = 2529;
                        EVENTS [ INDEX , 1] = (ushort) ( I ) ; 
                        __context__.SourceCodeLine = 2530;
                        EVENTS [ INDEX , 2] = (ushort) ( (IEVTTIME + OFFSET) ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 2537;
                if ( Functions.TestForTrue  ( ( EVENTOCCURSONDAY( __context__ , (ushort)( I ) , (uint)( CURRENTJDAY ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2539;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IEVTTIME < ICURRENTTIME ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IEVTTIME >= STARTINGTIME ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2541;
                        INDEX = (ushort) ( (INDEX + 1) ) ; 
                        __context__.SourceCodeLine = 2542;
                        EVENTS [ INDEX , 1] = (ushort) ( I ) ; 
                        __context__.SourceCodeLine = 2543;
                        EVENTS [ INDEX , 2] = (ushort) ( IEVTTIME ) ; 
                        } 
                    
                    } 
                
                } 
            
            } 
        
        __context__.SourceCodeLine = 2506;
        } 
    
    __context__.SourceCodeLine = 2551;
    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__2 = (ushort)INDEX; 
    int __FN_FORSTEP_VAL__2 = (int)1; 
    for ( WORKINGINDEX  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (WORKINGINDEX  >= __FN_FORSTART_VAL__2) && (WORKINGINDEX  <= __FN_FOREND_VAL__2) ) : ( (WORKINGINDEX  <= __FN_FORSTART_VAL__2) && (WORKINGINDEX  >= __FN_FOREND_VAL__2) ) ; WORKINGINDEX  += (ushort)__FN_FORSTEP_VAL__2) 
        { 
        __context__.SourceCodeLine = 2553;
        LOWESTINDEX = (ushort) ( WORKINGINDEX ) ; 
        __context__.SourceCodeLine = 2555;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( WORKINGINDEX ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)INDEX; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 2557;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EVENTS[ I , 2 ] < EVENTS[ LOWESTINDEX , 2 ] ))  ) ) 
                {
                __context__.SourceCodeLine = 2558;
                LOWESTINDEX = (ushort) ( I ) ; 
                }
            
            __context__.SourceCodeLine = 2555;
            } 
        
        __context__.SourceCodeLine = 2561;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOWESTINDEX != WORKINGINDEX))  ) ) 
            { 
            __context__.SourceCodeLine = 2563;
            TEMP [ 1 , 1] = (ushort) ( EVENTS[ WORKINGINDEX , 1 ] ) ; 
            __context__.SourceCodeLine = 2564;
            TEMP [ 1 , 2] = (ushort) ( EVENTS[ WORKINGINDEX , 2 ] ) ; 
            __context__.SourceCodeLine = 2565;
            EVENTS [ WORKINGINDEX , 1] = (ushort) ( EVENTS[ LOWESTINDEX , 1 ] ) ; 
            __context__.SourceCodeLine = 2566;
            EVENTS [ WORKINGINDEX , 2] = (ushort) ( EVENTS[ LOWESTINDEX , 2 ] ) ; 
            __context__.SourceCodeLine = 2567;
            EVENTS [ LOWESTINDEX , 1] = (ushort) ( TEMP[ 1 , 1 ] ) ; 
            __context__.SourceCodeLine = 2568;
            EVENTS [ LOWESTINDEX , 2] = (ushort) ( TEMP[ 1 , 2 ] ) ; 
            } 
        
        __context__.SourceCodeLine = 2571;
        I = (ushort) ( EVENTS[ WORKINGINDEX , 1 ] ) ; 
        __context__.SourceCodeLine = 2573;
        
        __context__.SourceCodeLine = 2577;
        Functions.Pulse ( 50, EVENT_DUE [ I] ) ; 
        __context__.SourceCodeLine = 2578;
        FIRED_EVENT_NAME__DOLLAR__  .UpdateValue ( G_EVENTS [ I] . NAME  ) ; 
        __context__.SourceCodeLine = 2580;
        MakeString ( MSG , "Firing Missed Event: '{0}' at {1} on {2}\r\n", G_EVENTS [ I] . NAME , Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
        __context__.SourceCodeLine = 2581;
        SCHEDULER_LOG  .UpdateValue ( MSG  ) ; 
        __context__.SourceCodeLine = 2551;
        } 
    
    
    }
    
private short LOADEVENTS (  SplusExecutionContext __context__ ) 
    { 
    short IFILEHANDLE = 0;
    
    short IERRCODE = 0;
    
    CrestronString SREADBUF;
    SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 682, this );
    
    CrestronString SLINE;
    SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
    
    CrestronString STEMP;
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 170, this );
    
    CrestronString CURRENTSTRG;
    CURRENTSTRG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    
    ushort IEVENTNUM = 0;
    ushort ICHUNKCOUNT = 0;
    
    ushort I = 0;
    ushort BBUFFERDONE = 0;
    ushort SEARCH_TEMP = 0;
    ushort ONESCHEDULEFIELD = 0;
    ushort LASTCHECKEDTIME = 0;
    
    uint LAST = 0;
    uint CURRENT = 0;
    uint DIFFERENCE = 0;
    
    CrestronString MSG;
    MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 60, this );
    
    
    __context__.SourceCodeLine = 2616;
    STEMP  .UpdateValue ( FILENAME__DOLLAR__  ) ; 
    __context__.SourceCodeLine = 2617;
    if ( Functions.TestForTrue  ( ( Functions.Not( CANUSEFILE( __context__ , STEMP , (ushort)( 1 ) ) ))  ) ) 
        {
        __context__.SourceCodeLine = 2617;
        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
        }
    
    __context__.SourceCodeLine = 2618;
    STEMP  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 2620;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2622;
        Print( "ERROR: Cannot start file ops\r\n") ; 
        __context__.SourceCodeLine = 2623;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2624;
        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2627;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FindFirst( FILENAME__DOLLAR__ , ref G_FIDATAFILE ) != 0))  ) ) 
        { 
        __context__.SourceCodeLine = 2629;
        Print( "ERROR: Could not find file {0}\r\n", FILENAME__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 2630;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2631;
        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2634;
    IFILEHANDLE = (short) ( FileOpen( FILENAME__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
    __context__.SourceCodeLine = 2635;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2637;
        Print( "ERROR: Cannot open file '{0}' for read.\r\n Error Code={1:d}\r\n", FILENAME__DOLLAR__ , (short)IFILEHANDLE) ; 
        __context__.SourceCodeLine = 2638;
        Functions.Pulse ( 50, READ_ERROR ) ; 
        __context__.SourceCodeLine = 2639;
        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
        } 
    
    __context__.SourceCodeLine = 2643;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)250; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 2645;
        G_EVENTS [ I] . FREE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2643;
        } 
    
    __context__.SourceCodeLine = 2648;
    SLINE  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 2649;
    ICHUNKCOUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 2651;
    while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 2655;
        SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
        __context__.SourceCodeLine = 2656;
        BBUFFERDONE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2658;
        ICHUNKCOUNT = (ushort) ( (ICHUNKCOUNT + 1) ) ; 
        __context__.SourceCodeLine = 2660;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICHUNKCOUNT == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 2662;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( SREADBUF , (int)( 1 ) ) == "#"))  ) ) 
                { 
                __context__.SourceCodeLine = 2664;
                SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
                __context__.SourceCodeLine = 2666;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( SLINE ) > 2 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2668;
                    Print( "ERROR: Schedule version is later than {0:d}\r\n", (ushort)2) ; 
                    __context__.SourceCodeLine = 2669;
                    FileClose (  (short) ( IFILEHANDLE ) ) ; 
                    __context__.SourceCodeLine = 2670;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 2672;
                    return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                    } 
                
                } 
            
            } 
        
        __context__.SourceCodeLine = 2677;
        do 
            { 
            __context__.SourceCodeLine = 2679;
            ONESCHEDULEFIELD = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 2681;
            SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
            __context__.SourceCodeLine = 2683;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 2685;
                BBUFFERDONE = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 2687;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SLINE , (int)( 1 ) ) != 39))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2689;
                    IEVENTNUM = (ushort) ( Functions.Atoi( Functions.Remove( "," , SLINE ) ) ) ; 
                    __context__.SourceCodeLine = 2691;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IEVENTNUM < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( IEVENTNUM > 250 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2693;
                        Print( "ERROR: Invalid event number. ({0:d})\r\n", (short)IEVENTNUM) ; 
                        __context__.SourceCodeLine = 2694;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 2698;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2699;
                    G_EVENTS [ IEVENTNUM] . NAME  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 2702;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2703;
                    G_EVENTS [ IEVENTNUM] . EVENTTYPE = (ushort) ( Functions.Atoi( Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 2706;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2707;
                    G_EVENTS [ IEVENTNUM] . _STARTDATE = (uint) ( Functions.Atol( Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 2710;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2711;
                    G_EVENTS [ IEVENTNUM] . _STOPDATE = (uint) ( Functions.Atol( Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 2714;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2715;
                    G_EVENTS [ IEVENTNUM] . TIMEBASE = (ushort) ( Functions.Atoi( Functions.Left( STEMP , (int)( (Functions.Length( STEMP ) - 1) ) ) ) ) ; 
                    __context__.SourceCodeLine = 2717;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2718;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( STEMP ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 2719;
                        G_EVENTS [ IEVENTNUM] . _TIME = (short) ( 0 ) ; 
                        }
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 2723;
                        G_EVENTS [ IEVENTNUM] . _TIME = (short) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 2726;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( STEMP , (int)( 1 ) ) == 45))  ) ) 
                            {
                            __context__.SourceCodeLine = 2727;
                            G_EVENTS [ IEVENTNUM] . _TIME = (short) ( Functions.ToInteger( -( G_EVENTS[ IEVENTNUM ]._TIME ) ) ) ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 2730;
                    STEMP  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 2733;
                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                    __context__.SourceCodeLine = 2735;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STEMP == ""))  ) ) 
                        {
                        __context__.SourceCodeLine = 2736;
                        STEMP  .UpdateValue ( SLINE  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 2739;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ].EVENTTYPE == 258) ) || Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ IEVENTNUM ].EVENTTYPE == 2) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2741;
                        ONESCHEDULEFIELD = (ushort) ( 1 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 2744;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ONESCHEDULEFIELD == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 2745;
                        STEMP  .UpdateValue ( STEMP + Functions.Remove ( "," , SLINE )  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 2747;
                    SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                    __context__.SourceCodeLine = 2749;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2752;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ONESCHEDULEFIELD == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 2753;
                            STEMP  .UpdateValue ( STEMP + SLINE  ) ; 
                            }
                        
                        __context__.SourceCodeLine = 2755;
                        G_EVENTS [ IEVENTNUM] . SCHEDULEINFO  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                        __context__.SourceCodeLine = 2757;
                        G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 2758;
                        G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 2759;
                        G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 2760;
                        G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 2761;
                        G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 2763;
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 2770;
                        G_EVENTS [ IEVENTNUM] . SCHEDULEINFO  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                        __context__.SourceCodeLine = 2771;
                        SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                        __context__.SourceCodeLine = 2773;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 2775;
                            STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                            __context__.SourceCodeLine = 2776;
                            G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                            __context__.SourceCodeLine = 2778;
                            G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 2779;
                            G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 2780;
                            G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 2781;
                            G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 2786;
                            STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                            __context__.SourceCodeLine = 2787;
                            G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                            __context__.SourceCodeLine = 2789;
                            SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                            __context__.SourceCodeLine = 2792;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 2794;
                                STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                __context__.SourceCodeLine = 2796;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "H" , STEMP ) ) ; 
                                __context__.SourceCodeLine = 2798;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 2799;
                                    G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 2802;
                                    G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 2804;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "R" , STEMP ) ) ; 
                                __context__.SourceCodeLine = 2806;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 2807;
                                    G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 2810;
                                    G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 2813;
                                G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 2814;
                                G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 2819;
                                STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                __context__.SourceCodeLine = 2821;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "H" , STEMP ) ) ; 
                                __context__.SourceCodeLine = 2823;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 2824;
                                    G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 2827;
                                    G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 2829;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "R" , STEMP ) ) ; 
                                __context__.SourceCodeLine = 2831;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 2832;
                                    G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 2835;
                                    G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 1 ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 2838;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                                __context__.SourceCodeLine = 2841;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 2843;
                                    STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                    __context__.SourceCodeLine = 2844;
                                    G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                                    __context__.SourceCodeLine = 2846;
                                    G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 2852;
                                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                    __context__.SourceCodeLine = 2853;
                                    G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                                    __context__.SourceCodeLine = 2855;
                                    STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                    __context__.SourceCodeLine = 2856;
                                    G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                                    } 
                                
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 2862;
                        
                        } 
                    
                    __context__.SourceCodeLine = 2868;
                    G_EVENTS [ IEVENTNUM] . FREE = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 2870;
                    
                    } 
                
                }
            
            } 
        while (false == ( Functions.TestForTrue  ( BBUFFERDONE) )); 
        __context__.SourceCodeLine = 2879;
        if ( Functions.TestForTrue  ( ( Functions.Length( SREADBUF ))  ) ) 
            {
            __context__.SourceCodeLine = 2880;
            SLINE  .UpdateValue ( SREADBUF  ) ; 
            }
        
        __context__.SourceCodeLine = 2651;
        } 
    
    __context__.SourceCodeLine = 2884;
    IERRCODE = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
    __context__.SourceCodeLine = 2885;
    
    __context__.SourceCodeLine = 2889;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRCODE < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2891;
        Print( "ERROR: Closing file after read. Error code = {0:d}\r\n", (short)IERRCODE) ; 
        } 
    
    __context__.SourceCodeLine = 2894;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 2896;
        Print( "ERROR: Ending file ops.\r\n") ; 
        } 
    
    __context__.SourceCodeLine = 2899;
    STEMP  .UpdateValue ( FILENAME__DOLLAR__  ) ; 
    __context__.SourceCodeLine = 2900;
    FREEFILE (  __context__ , STEMP, (ushort)( 1 )) ; 
    __context__.SourceCodeLine = 2901;
    STEMP  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 2904;
    ushort __FN_FORSTART_VAL__2 = (ushort) ( 250 ) ;
    ushort __FN_FOREND_VAL__2 = (ushort)0; 
    int __FN_FORSTEP_VAL__2 = (int)Functions.ToLongInteger( -( 1 ) ); 
    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
        { 
        __context__.SourceCodeLine = 2906;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 2908;
            G_IMAXUSEDEVENT = (ushort) ( I ) ; 
            __context__.SourceCodeLine = 2909;
            TOTAL_USED_EVENTS  .Value = (ushort) ( G_IMAXUSEDEVENT ) ; 
            __context__.SourceCodeLine = 2910;
            break ; 
            } 
        
        __context__.SourceCodeLine = 2904;
        } 
    
    __context__.SourceCodeLine = 2914;
    ushort __FN_FORSTART_VAL__3 = (ushort) ( G_IEDITEVENT ) ;
    ushort __FN_FOREND_VAL__3 = (ushort)G_IMAXUSEDEVENT; 
    int __FN_FORSTEP_VAL__3 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
        { 
        __context__.SourceCodeLine = 2916;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 2918;
            SETEDITEVENT (  __context__ , (ushort)( I )) ; 
            __context__.SourceCodeLine = 2919;
            break ; 
            } 
        
        __context__.SourceCodeLine = 2914;
        } 
    
    __context__.SourceCodeLine = 2923;
    
    __context__.SourceCodeLine = 2927;
    MakeString ( MSG , "Scheduler File Loaded at {0} on {1}\r\n", Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
    __context__.SourceCodeLine = 2929;
    SCHEDULER_LOG  .UpdateValue ( MSG  ) ; 
    __context__.SourceCodeLine = 2931;
    if ( Functions.TestForTrue  ( ( EXECUTEMISSEDEVENTS  .Value)  ) ) 
        { 
        __context__.SourceCodeLine = 2934;
        I = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
        __context__.SourceCodeLine = 2936;
        MakeString ( CURRENTSTRG , "{0:d4}{1:d2}{2:d2}{3:d4}", (short)I, (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum()) ; 
        __context__.SourceCodeLine = 2937;
        CURRENT = (uint) ( GETJDAY( __context__ , (uint)( Functions.Atol( Functions.Right( CURRENTSTRG , (int)( 8 ) ) ) ) ) ) ; 
        __context__.SourceCodeLine = 2940;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.LASTCHECKED == ""))  ) ) 
            {
            __context__.SourceCodeLine = 2941;
            RUNSCHED (  __context__ , (uint)( (CURRENT - 1) ), (ushort)( I ), (uint)( CURRENT )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 2946;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.LASTCHECKED != CURRENTSTRG))  ) ) 
                { 
                __context__.SourceCodeLine = 2948;
                LASTCHECKEDTIME = (ushort) ( Functions.Atoi( Functions.Left( _SplusNVRAM.LASTCHECKED , (int)( 4 ) ) ) ) ; 
                __context__.SourceCodeLine = 2949;
                LAST = (uint) ( GETJDAY( __context__ , (uint)( Functions.Atol( Functions.Right( _SplusNVRAM.LASTCHECKED , (int)( 8 ) ) ) ) ) ) ; 
                __context__.SourceCodeLine = 2950;
                DIFFERENCE = (uint) ( (CURRENT - LAST) ) ; 
                __context__.SourceCodeLine = 2952;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( DIFFERENCE > 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (I - LASTCHECKEDTIME) > 0 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 2953;
                    RUNSCHED (  __context__ , (uint)( (CURRENT - 1) ), (ushort)( I ), (uint)( CURRENT )) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 2956;
                    RUNSCHED (  __context__ , (uint)( LAST ), (ushort)( LASTCHECKEDTIME ), (uint)( CURRENT )) ; 
                    }
                
                } 
            
            } 
        
        } 
    
    
    return 0; // default return value (none specified in module)
    }
    
object LOAD_OnPush_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2965;
        LOADEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVE_OnPush_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2970;
        SAVEEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ADDDATE_OnPush_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2978;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2979;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2981;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 2983;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEMAXINDEX < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 2985;
            G_IBYDATEMAXINDEX = (ushort) ( (G_IBYDATEMAXINDEX + 1) ) ; 
            __context__.SourceCodeLine = 2986;
            G_LDATES [ G_IBYDATEMAXINDEX] = (uint) ( CREATEDATEL( __context__ , (ushort)( Functions.GetMonthNum() ) , (ushort)( Functions.GetDateNum() ) , (ushort)( Functions.GetYearNum() ) ) ) ; 
            __context__.SourceCodeLine = 2988;
            G_IBYDATEINDEX = (ushort) ( G_IBYDATEMAXINDEX ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DELETEDATE_OnPush_35 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ILOOP = 0;
        
        
        __context__.SourceCodeLine = 2996;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 2997;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 2999;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3001;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_IBYDATEMAXINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_IBYDATEINDEX > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_IBYDATEINDEX <= G_IBYDATEMAXINDEX ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 3003;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEMAXINDEX > 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 3004;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( G_IBYDATEINDEX ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(G_IBYDATEMAXINDEX - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( ILOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ILOOP  >= __FN_FORSTART_VAL__1) && (ILOOP  <= __FN_FOREND_VAL__1) ) : ( (ILOOP  <= __FN_FORSTART_VAL__1) && (ILOOP  >= __FN_FOREND_VAL__1) ) ; ILOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                    {
                    __context__.SourceCodeLine = 3005;
                    G_LDATES [ ILOOP] = (uint) ( G_LDATES[ (ILOOP + 1) ] ) ; 
                    __context__.SourceCodeLine = 3004;
                    }
                
                }
            
            __context__.SourceCodeLine = 3007;
            G_IBYDATEMAXINDEX = (ushort) ( (G_IBYDATEMAXINDEX - 1) ) ; 
            __context__.SourceCodeLine = 3008;
            G_IBYDATEINDEX = (ushort) ( (G_IBYDATEINDEX - 1) ) ; 
            __context__.SourceCodeLine = 3010;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEMAXINDEX > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 3011;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEINDEX < 1 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 3012;
                    G_IBYDATEINDEX = (ushort) ( 1 ) ; 
                    }
                
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIRSTDATE_OnPush_36 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3018;
        G_IBYDATEINDEX = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NEXTDATE_OnPush_37 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3023;
        G_IBYDATEINDEX = (ushort) ( (G_IBYDATEINDEX + 1) ) ; 
        __context__.SourceCodeLine = 3024;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEINDEX > G_IBYDATEMAXINDEX ))  ) ) 
            {
            __context__.SourceCodeLine = 3025;
            G_IBYDATEINDEX = (ushort) ( 1 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PREVDATE_OnPush_38 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3030;
        G_IBYDATEINDEX = (ushort) ( (G_IBYDATEINDEX - 1) ) ; 
        __context__.SourceCodeLine = 3031;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_IBYDATEINDEX < 1 ))  ) ) 
            {
            __context__.SourceCodeLine = 3032;
            G_IBYDATEINDEX = (ushort) ( G_IBYDATEMAXINDEX ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LASTDATE_OnPush_39 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3037;
        G_IBYDATEINDEX = (ushort) ( G_IBYDATEMAXINDEX ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEMONTHUP_OnPush_40 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3042;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3043;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3045;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3047;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( INCREMENTMONTH( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEMONTHDOWN_OnPush_41 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3052;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3053;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3055;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3057;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( DECREMENTMONTH( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEDAYUP_OnPush_42 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3062;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3063;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3065;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3067;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( INCREMENTDATE( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEDAYDOWN_OnPush_43 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3072;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3073;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3075;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3077;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( DECREMENTDATE( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEYEARUP_OnPush_44 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3082;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3083;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3085;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3087;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 3087;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 3088;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( INCREMENTYEAR( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEYEARDOWN_OnPush_45 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3093;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3094;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3096;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3098;
        if ( Functions.TestForTrue  ( ( ISANNUALEVENT( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ))  ) ) 
            {
            __context__.SourceCodeLine = 3098;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 3099;
        G_LDATES [ G_IBYDATEINDEX] = (uint) ( DECREMENTYEAR( __context__ , (uint)( G_LDATES[ G_IBYDATEINDEX ] ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYDATEMONTHUP_OnPush_46 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3104;
        SETBYDATEOUTPUTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANGEPERIODICTYPE_OnPush_47 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort PTYPE = 0;
        
        short PERIOD = 0;
        
        
        __context__.SourceCodeLine = 3116;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 3118;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                {
                __context__.SourceCodeLine = 3119;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 3121;
            MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
            __context__.SourceCodeLine = 3123;
            PERIODIC_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  PTYPE ,   ref  PERIOD ) ; 
            __context__.SourceCodeLine = 3125;
            PTYPE = (ushort) ( (PTYPE + 1) ) ; 
            __context__.SourceCodeLine = 3126;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PTYPE > 3 ))  ) ) 
                {
                __context__.SourceCodeLine = 3126;
                PTYPE = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 3127;
            G_EDITEVENT . SCHEDULEINFO  .UpdateValue ( Functions.ItoA (  (int) ( PTYPE ) ) + "," + Functions.ItoA (  (int) ( PERIOD ) )  ) ; 
            __context__.SourceCodeLine = 3129;
            SETTYPESPECIFICOUTPUTS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INCREASEPERIOD_OnPush_48 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort PTYPE = 0;
        
        short PERIOD = 0;
        
        
        __context__.SourceCodeLine = 3138;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 3140;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                {
                __context__.SourceCodeLine = 3141;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 3143;
            MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
            __context__.SourceCodeLine = 3145;
            PERIODIC_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  PTYPE ,   ref  PERIOD ) ; 
            __context__.SourceCodeLine = 3147;
            PERIOD = (short) ( (PERIOD + 1) ) ; 
            __context__.SourceCodeLine = 3148;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PERIOD > 200 ))  ) ) 
                {
                __context__.SourceCodeLine = 3148;
                PERIOD = (short) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 3149;
            G_EDITEVENT . SCHEDULEINFO  .UpdateValue ( Functions.ItoA (  (int) ( PTYPE ) ) + "," + Functions.ItoA (  (int) ( PERIOD ) )  ) ; 
            __context__.SourceCodeLine = 3151;
            SETTYPESPECIFICOUTPUTS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DECREASEPERIOD_OnPush_49 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort PTYPE = 0;
        
        short PERIOD = 0;
        
        
        __context__.SourceCodeLine = 3160;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 3162;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                {
                __context__.SourceCodeLine = 3163;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 3165;
            MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
            __context__.SourceCodeLine = 3167;
            PERIODIC_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  PTYPE ,   ref  PERIOD ) ; 
            __context__.SourceCodeLine = 3169;
            PERIOD = (short) ( (PERIOD - 1) ) ; 
            __context__.SourceCodeLine = 3170;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PERIOD < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 3170;
                PERIOD = (short) ( 200 ) ; 
                }
            
            __context__.SourceCodeLine = 3171;
            G_EDITEVENT . SCHEDULEINFO  .UpdateValue ( Functions.ItoA (  (int) ( PTYPE ) ) + "," + Functions.ItoA (  (int) ( PERIOD ) )  ) ; 
            __context__.SourceCodeLine = 3173;
            SETTYPESPECIFICOUTPUTS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void WEEKLY_CHANGEDAYSMONTHS (  SplusExecutionContext __context__, ushort IBIT ) 
    { 
    ushort IVALIDDAYS = 0;
    ushort IVALIDMONTHS = 0;
    
    
    __context__.SourceCodeLine = 3185;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (EVENTTYPE( __context__ , (ushort)( G_EDITEVENT.EVENTTYPE ) ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EDITEVENT.READONLY == 0) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 3187;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3189;
        WEEKLY_EXTRACTINFO (  __context__ , G_EDITEVENT.SCHEDULEINFO,   ref  IVALIDDAYS ,   ref  IVALIDMONTHS ) ; 
        __context__.SourceCodeLine = 3191;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBIT <= 7 ))  ) ) 
            { 
            __context__.SourceCodeLine = 3193;
            IVALIDDAYS = (ushort) ( TOGGLEBIT( __context__ , (ushort)( IVALIDDAYS ) , (ushort)( (IBIT - 1) ) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 3197;
            IVALIDMONTHS = (ushort) ( TOGGLEBIT( __context__ , (ushort)( IVALIDMONTHS ) , (ushort)( (IBIT - 8) ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 3199;
        G_EDITEVENT . SCHEDULEINFO  .UpdateValue ( GETBITFIELDSTRINGFROMINTEGER (  __context__ , (ushort)( IVALIDDAYS ), (ushort)( 7 )) + "," + GETBITFIELDSTRINGFROMINTEGER (  __context__ , (ushort)( IVALIDMONTHS ), (ushort)( 12 ))  ) ; 
        __context__.SourceCodeLine = 3201;
        SETTYPESPECIFICOUTPUTS (  __context__  ) ; 
        } 
    
    
    }
    
object SUNDAY_ONOFF_OnPush_50 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3207;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3208;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3210;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3212;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MONDAY_ONOFF_OnPush_51 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3217;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3218;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3220;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3222;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TUESDAY_ONOFF_OnPush_52 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3227;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3228;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3230;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3232;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 3 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEDNESDAY_ONOFF_OnPush_53 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3237;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3238;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3240;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3242;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object THURSDAY_ONOFF_OnPush_54 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3247;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3248;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3250;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3252;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 5 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FRIDAY_ONOFF_OnPush_55 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3257;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3258;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3260;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3262;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 6 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SATURDAY_ONOFF_OnPush_56 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3267;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3268;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3270;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3272;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 7 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object JAN_ONOFF_OnPush_57 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3277;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3278;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3280;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3282;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 8 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FEB_ONOFF_OnPush_58 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3287;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3288;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3290;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3292;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 9 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MAR_ONOFF_OnPush_59 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3297;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3298;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3300;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3302;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 10 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object APR_ONOFF_OnPush_60 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3307;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3308;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3310;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3312;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 11 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MAY_ONOFF_OnPush_61 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3317;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3318;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3320;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3322;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 12 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object JUN_ONOFF_OnPush_62 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3327;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3328;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3330;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3332;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 13 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object JUL_ONOFF_OnPush_63 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3337;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3338;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3340;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3342;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 14 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUG_ONOFF_OnPush_64 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3347;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3348;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3350;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3352;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 15 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SEP_ONOFF_OnPush_65 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3357;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3358;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3360;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3362;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 16 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OCT_ONOFF_OnPush_66 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3367;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3368;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3370;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3372;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 17 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NOV_ONOFF_OnPush_67 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3377;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3378;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3380;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3382;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 18 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEC_ONOFF_OnPush_68 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3387;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 3388;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 3390;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 3392;
        WEEKLY_CHANGEDAYSMONTHS (  __context__ , (ushort)( 19 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FIREEVENT_OnPush_69 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMP;
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        CrestronString MSG;
        MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 3401;
        TEMP  .UpdateValue ( Functions.Lower ( CMDEVENTNAME )  ) ; 
        __context__.SourceCodeLine = 3403;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 3405;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 3407;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMP == Functions.Lower( G_EVENTS[ I ].NAME )))  ) ) 
                    { 
                    __context__.SourceCodeLine = 3409;
                    Functions.Pulse ( 50, EVENT_DUE [ I] ) ; 
                    __context__.SourceCodeLine = 3410;
                    FIRED_EVENT_NAME__DOLLAR__  .UpdateValue ( G_EVENTS [ I] . NAME  ) ; 
                    __context__.SourceCodeLine = 3411;
                    MakeString ( MSG , "Fired '{0}' at {1} on {2}\r\n", G_EVENTS [ I] . NAME , Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
                    __context__.SourceCodeLine = 3413;
                    SCHEDULER_LOG  .UpdateValue ( MSG  ) ; 
                    __context__.SourceCodeLine = 3415;
                    Print( "{0}", MSG ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 3403;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LIST_EVENTS_OnPush_70 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IABSTIME = 0;
        
        CrestronString TEMP;
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        ushort I = 0;
        ushort BASE = 0;
        
        CrestronString ABSTIME__DOLLAR__;
        ABSTIME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
        
        uint CURRENTJDAY = 0;
        
        
        __context__.SourceCodeLine = 3429;
        CURRENTJDAY = (uint) ( GETJDAY( __context__ , (uint)( CREATEDATEL( __context__ , (ushort)( Functions.GetMonthNum() ) , (ushort)( Functions.GetDateNum() ) , (ushort)( Functions.GetYearNum() ) ) ) ) ) ; 
        __context__.SourceCodeLine = 3431;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 3433;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 3435;
                IABSTIME = (ushort) ( GETNORMALIZEDEVENTTIME( __context__ , (ushort)( I ) ) ) ; 
                __context__.SourceCodeLine = 3437;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IABSTIME < 720 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 3438;
                    BASE = (ushort) ( 0 ) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 3441;
                    BASE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 3442;
                    IABSTIME = (ushort) ( (IABSTIME - 720) ) ; 
                    } 
                
                __context__.SourceCodeLine = 3444;
                ABSTIME__DOLLAR__  .UpdateValue ( GETTIMESTRING (  __context__ , (short)( IABSTIME ), (ushort)( BASE ))  ) ; 
                __context__.SourceCodeLine = 3445;
                Print( "'{0}' executes at {1}", G_EVENTS [ I] . NAME , ABSTIME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 3447;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EVENTS[ I ].TIMEBASE > 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 3449;
                    ABSTIME__DOLLAR__  .UpdateValue ( GETTIMESTRING (  __context__ , (short)( G_EVENTS[ I ]._TIME ), (ushort)( G_EVENTS[ I ].TIMEBASE ))  ) ; 
                    __context__.SourceCodeLine = 3450;
                    Print( " ({0})", ABSTIME__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 3453;
                if ( Functions.TestForTrue  ( ( EVENTOCCURSONDAY( __context__ , (ushort)( I ) , (uint)( CURRENTJDAY ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 3454;
                    Print( ". This Event occurs today.\r\n") ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 3456;
                    Print( ". This Event does not occur today.\r\n") ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 3431;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NEWPROGLOADED_OnPush_71 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 3485;
        _SplusNVRAM.LASTCHECKED  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort ICURRENTTIME = 0;
    ushort ILASTCHECKEDTIME = 0;
    
    ushort ICURRENTDAYOFWEEK = 0;
    ushort ICURRENTMONTH = 0;
    
    ushort I = 0;
    
    short IERRCODE = 0;
    
    CrestronString MSG;
    MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    uint CURRENTJDAY = 0;
    
    FILE_INFO FIDATAFILE;
    FIDATAFILE  = new FILE_INFO();
    FIDATAFILE .PopulateDefaults();
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 3500;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 3502;
        G_IDAYSINMONTH [ 1] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3503;
        G_IDAYSINMONTH [ 2] = (ushort) ( 28 ) ; 
        __context__.SourceCodeLine = 3504;
        G_IDAYSINMONTH [ 3] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3505;
        G_IDAYSINMONTH [ 4] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 3506;
        G_IDAYSINMONTH [ 5] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3507;
        G_IDAYSINMONTH [ 6] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 3508;
        G_IDAYSINMONTH [ 7] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3509;
        G_IDAYSINMONTH [ 8] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3510;
        G_IDAYSINMONTH [ 9] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 3511;
        G_IDAYSINMONTH [ 10] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3512;
        G_IDAYSINMONTH [ 11] = (ushort) ( 30 ) ; 
        __context__.SourceCodeLine = 3513;
        G_IDAYSINMONTH [ 12] = (ushort) ( 31 ) ; 
        __context__.SourceCodeLine = 3516;
        G_IMONTHMASK [ 1] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 3517;
        G_IMONTHMASK [ 2] = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 3518;
        G_IMONTHMASK [ 3] = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 3519;
        G_IMONTHMASK [ 4] = (ushort) ( 8 ) ; 
        __context__.SourceCodeLine = 3520;
        G_IMONTHMASK [ 5] = (ushort) ( 16 ) ; 
        __context__.SourceCodeLine = 3521;
        G_IMONTHMASK [ 6] = (ushort) ( 32 ) ; 
        __context__.SourceCodeLine = 3522;
        G_IMONTHMASK [ 7] = (ushort) ( 64 ) ; 
        __context__.SourceCodeLine = 3523;
        G_IMONTHMASK [ 8] = (ushort) ( 128 ) ; 
        __context__.SourceCodeLine = 3524;
        G_IMONTHMASK [ 9] = (ushort) ( 256 ) ; 
        __context__.SourceCodeLine = 3525;
        G_IMONTHMASK [ 10] = (ushort) ( 512 ) ; 
        __context__.SourceCodeLine = 3526;
        G_IMONTHMASK [ 11] = (ushort) ( 1024 ) ; 
        __context__.SourceCodeLine = 3527;
        G_IMONTHMASK [ 12] = (ushort) ( 2048 ) ; 
        __context__.SourceCodeLine = 3529;
        G_IDAYOFWEEKMASK [ 0] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 3530;
        G_IDAYOFWEEKMASK [ 1] = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 3531;
        G_IDAYOFWEEKMASK [ 2] = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 3532;
        G_IDAYOFWEEKMASK [ 3] = (ushort) ( 8 ) ; 
        __context__.SourceCodeLine = 3533;
        G_IDAYOFWEEKMASK [ 4] = (ushort) ( 16 ) ; 
        __context__.SourceCodeLine = 3534;
        G_IDAYOFWEEKMASK [ 5] = (ushort) ( 32 ) ; 
        __context__.SourceCodeLine = 3535;
        G_IDAYOFWEEKMASK [ 6] = (ushort) ( 64 ) ; 
        __context__.SourceCodeLine = 3548;
        G_IMAXUSEDEVENT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 3550;
        TOTAL_USED_EVENTS  .Value = (ushort) ( G_IMAXUSEDEVENT ) ; 
        __context__.SourceCodeLine = 3552;
        G_FIDATAFILE .  iTime = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 3553;
        G_FIDATAFILE .  iDate = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 3555;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 3557;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 3559;
            while ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 3563;
                if ( Functions.TestForTrue  ( ( AUTOLOAD  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 3566;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 3568;
                        IERRCODE = (short) ( FindFirst( FILENAME__DOLLAR__ , ref FIDATAFILE ) ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 3572;
                        Print( "StartFileOperations() failed.\r\n") ; 
                        } 
                    
                    __context__.SourceCodeLine = 3574;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 3576;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREFILEDATEANDTIME( __context__ , FIDATAFILE , G_FIDATAFILE ) != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 3577;
                        LOADEVENTS (  __context__  ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 3580;
                ICURRENTTIME = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
                __context__.SourceCodeLine = 3582;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILASTCHECKEDTIME != ICURRENTTIME))  ) ) 
                    { 
                    __context__.SourceCodeLine = 3585;
                    MakeString ( _SplusNVRAM.LASTCHECKED , "{0:d4}{1:d2}{2:d2}{3:d4}", (short)ICURRENTTIME, (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum()) ; 
                    __context__.SourceCodeLine = 3587;
                    
                    __context__.SourceCodeLine = 3591;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 3594;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( G_EVENTS[ I ].SUSPENDED ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 3596;
                            
                            __context__.SourceCodeLine = 3599;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GETNORMALIZEDEVENTTIME( __context__ , (ushort)( I ) ) == ICURRENTTIME))  ) ) 
                                { 
                                __context__.SourceCodeLine = 3601;
                                CURRENTJDAY = (uint) ( GETJDAY( __context__ , (uint)( CREATEDATEL( __context__ , (ushort)( Functions.GetMonthNum() ) , (ushort)( Functions.GetDateNum() ) , (ushort)( Functions.GetYearNum() ) ) ) ) ) ; 
                                __context__.SourceCodeLine = 3603;
                                if ( Functions.TestForTrue  ( ( EVENTOCCURSONDAY( __context__ , (ushort)( I ) , (uint)( CURRENTJDAY ) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 3605;
                                    Functions.Pulse ( 50, EVENT_DUE [ I] ) ; 
                                    __context__.SourceCodeLine = 3606;
                                    FIRED_EVENT_NAME__DOLLAR__  .UpdateValue ( G_EVENTS [ I] . NAME  ) ; 
                                    __context__.SourceCodeLine = 3609;
                                    MakeString ( MSG , "Fired '{0}' at {1} on {2}\r\n", G_EVENTS [ I] . NAME , Functions.Time ( ) , Functions.Date (  (int) ( 1 ) ) ) ; 
                                    __context__.SourceCodeLine = 3610;
                                    SCHEDULER_LOG  .UpdateValue ( MSG  ) ; 
                                    } 
                                
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 3591;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 3618;
                ILASTCHECKEDTIME = (ushort) ( ICURRENTTIME ) ; 
                __context__.SourceCodeLine = 3621;
                Functions.Delay (  (int) ( 1000 ) ) ; 
                __context__.SourceCodeLine = 3559;
                } 
            
            __context__.SourceCodeLine = 3555;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_IMONTHMASK  = new ushort[ 13 ];
    G_IDAYOFWEEKMASK  = new ushort[ 7 ];
    G_IDAYSINMONTH  = new ushort[ 13 ];
    G_LDATES  = new uint[ 101 ];
    G_FILENAME_EVENT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    G_FILENAME_EDIT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    _SplusNVRAM.LASTCHECKED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    G_EDITEVENT  = new EVENTINFO( this, true );
    G_EDITEVENT .PopulateCustomAttributeList( false );
    G_FIDATAFILE  = new FILE_INFO();
    G_FIDATAFILE .PopulateDefaults();
    G_EVENTS  = new EVENTINFO[ 251 ];
    for( uint i = 0; i < 251; i++ )
    {
        G_EVENTS [i] = new EVENTINFO( this, true );
        G_EVENTS [i].PopulateCustomAttributeList( false );
        
    }
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    SAVE_EDIT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( SAVE_EDIT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE_EDIT_EVENT__DigitalInput__, SAVE_EDIT_EVENT );
    
    REVERT_EDIT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( REVERT_EDIT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( REVERT_EDIT_EVENT__DigitalInput__, REVERT_EDIT_EVENT );
    
    AUTOLOAD = new Crestron.Logos.SplusObjects.DigitalInput( AUTOLOAD__DigitalInput__, this );
    m_DigitalInputList.Add( AUTOLOAD__DigitalInput__, AUTOLOAD );
    
    LOAD = new Crestron.Logos.SplusObjects.DigitalInput( LOAD__DigitalInput__, this );
    m_DigitalInputList.Add( LOAD__DigitalInput__, LOAD );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    EDIT_FIRST_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_FIRST_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_FIRST_EVENT__DigitalInput__, EDIT_FIRST_EVENT );
    
    EDIT_NEXT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_NEXT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_NEXT_EVENT__DigitalInput__, EDIT_NEXT_EVENT );
    
    EDIT_PREV_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_PREV_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_PREV_EVENT__DigitalInput__, EDIT_PREV_EVENT );
    
    EDIT_LAST_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_LAST_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_LAST_EVENT__DigitalInput__, EDIT_LAST_EVENT );
    
    HOUR_UP = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_UP__DigitalInput__, HOUR_UP );
    
    HOUR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_DOWN__DigitalInput__, HOUR_DOWN );
    
    MINUTE_UP = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_UP__DigitalInput__, MINUTE_UP );
    
    MINUTE_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_DOWN__DigitalInput__, MINUTE_DOWN );
    
    AM = new Crestron.Logos.SplusObjects.DigitalInput( AM__DigitalInput__, this );
    m_DigitalInputList.Add( AM__DigitalInput__, AM );
    
    PM = new Crestron.Logos.SplusObjects.DigitalInput( PM__DigitalInput__, this );
    m_DigitalInputList.Add( PM__DigitalInput__, PM );
    
    SUNRISE = new Crestron.Logos.SplusObjects.DigitalInput( SUNRISE__DigitalInput__, this );
    m_DigitalInputList.Add( SUNRISE__DigitalInput__, SUNRISE );
    
    SUNSET = new Crestron.Logos.SplusObjects.DigitalInput( SUNSET__DigitalInput__, this );
    m_DigitalInputList.Add( SUNSET__DigitalInput__, SUNSET );
    
    START_MONTH_UP = new Crestron.Logos.SplusObjects.DigitalInput( START_MONTH_UP__DigitalInput__, this );
    m_DigitalInputList.Add( START_MONTH_UP__DigitalInput__, START_MONTH_UP );
    
    START_DAY_UP = new Crestron.Logos.SplusObjects.DigitalInput( START_DAY_UP__DigitalInput__, this );
    m_DigitalInputList.Add( START_DAY_UP__DigitalInput__, START_DAY_UP );
    
    START_YEAR_UP = new Crestron.Logos.SplusObjects.DigitalInput( START_YEAR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( START_YEAR_UP__DigitalInput__, START_YEAR_UP );
    
    START_MONTH_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( START_MONTH_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( START_MONTH_DOWN__DigitalInput__, START_MONTH_DOWN );
    
    START_DAY_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( START_DAY_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( START_DAY_DOWN__DigitalInput__, START_DAY_DOWN );
    
    START_YEAR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( START_YEAR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( START_YEAR_DOWN__DigitalInput__, START_YEAR_DOWN );
    
    STOP_MONTH_UP = new Crestron.Logos.SplusObjects.DigitalInput( STOP_MONTH_UP__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_MONTH_UP__DigitalInput__, STOP_MONTH_UP );
    
    STOP_DAY_UP = new Crestron.Logos.SplusObjects.DigitalInput( STOP_DAY_UP__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_DAY_UP__DigitalInput__, STOP_DAY_UP );
    
    STOP_YEAR_UP = new Crestron.Logos.SplusObjects.DigitalInput( STOP_YEAR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_YEAR_UP__DigitalInput__, STOP_YEAR_UP );
    
    STOP_MONTH_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( STOP_MONTH_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_MONTH_DOWN__DigitalInput__, STOP_MONTH_DOWN );
    
    STOP_DAY_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( STOP_DAY_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_DAY_DOWN__DigitalInput__, STOP_DAY_DOWN );
    
    STOP_YEAR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( STOP_YEAR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( STOP_YEAR_DOWN__DigitalInput__, STOP_YEAR_DOWN );
    
    ANNUAL_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( ANNUAL_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ANNUAL_ONOFF__DigitalInput__, ANNUAL_ONOFF );
    
    SUSPEND = new Crestron.Logos.SplusObjects.DigitalInput( SUSPEND__DigitalInput__, this );
    m_DigitalInputList.Add( SUSPEND__DigitalInput__, SUSPEND );
    
    RESUME = new Crestron.Logos.SplusObjects.DigitalInput( RESUME__DigitalInput__, this );
    m_DigitalInputList.Add( RESUME__DigitalInput__, RESUME );
    
    EXECUTEMISSEDEVENTS = new Crestron.Logos.SplusObjects.DigitalInput( EXECUTEMISSEDEVENTS__DigitalInput__, this );
    m_DigitalInputList.Add( EXECUTEMISSEDEVENTS__DigitalInput__, EXECUTEMISSEDEVENTS );
    
    SUNDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( SUNDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( SUNDAY_ONOFF__DigitalInput__, SUNDAY_ONOFF );
    
    MONDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( MONDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( MONDAY_ONOFF__DigitalInput__, MONDAY_ONOFF );
    
    TUESDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( TUESDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( TUESDAY_ONOFF__DigitalInput__, TUESDAY_ONOFF );
    
    WEDNESDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( WEDNESDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( WEDNESDAY_ONOFF__DigitalInput__, WEDNESDAY_ONOFF );
    
    THURSDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( THURSDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( THURSDAY_ONOFF__DigitalInput__, THURSDAY_ONOFF );
    
    FRIDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( FRIDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( FRIDAY_ONOFF__DigitalInput__, FRIDAY_ONOFF );
    
    SATURDAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( SATURDAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( SATURDAY_ONOFF__DigitalInput__, SATURDAY_ONOFF );
    
    JAN_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( JAN_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( JAN_ONOFF__DigitalInput__, JAN_ONOFF );
    
    FEB_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( FEB_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( FEB_ONOFF__DigitalInput__, FEB_ONOFF );
    
    MAR_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( MAR_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( MAR_ONOFF__DigitalInput__, MAR_ONOFF );
    
    APR_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( APR_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( APR_ONOFF__DigitalInput__, APR_ONOFF );
    
    MAY_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( MAY_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( MAY_ONOFF__DigitalInput__, MAY_ONOFF );
    
    JUN_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( JUN_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( JUN_ONOFF__DigitalInput__, JUN_ONOFF );
    
    JUL_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( JUL_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( JUL_ONOFF__DigitalInput__, JUL_ONOFF );
    
    AUG_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( AUG_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( AUG_ONOFF__DigitalInput__, AUG_ONOFF );
    
    SEP_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( SEP_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( SEP_ONOFF__DigitalInput__, SEP_ONOFF );
    
    OCT_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( OCT_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( OCT_ONOFF__DigitalInput__, OCT_ONOFF );
    
    NOV_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( NOV_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( NOV_ONOFF__DigitalInput__, NOV_ONOFF );
    
    DEC_ONOFF = new Crestron.Logos.SplusObjects.DigitalInput( DEC_ONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( DEC_ONOFF__DigitalInput__, DEC_ONOFF );
    
    CHANGEPERIODICTYPE = new Crestron.Logos.SplusObjects.DigitalInput( CHANGEPERIODICTYPE__DigitalInput__, this );
    m_DigitalInputList.Add( CHANGEPERIODICTYPE__DigitalInput__, CHANGEPERIODICTYPE );
    
    INCREASEPERIOD = new Crestron.Logos.SplusObjects.DigitalInput( INCREASEPERIOD__DigitalInput__, this );
    m_DigitalInputList.Add( INCREASEPERIOD__DigitalInput__, INCREASEPERIOD );
    
    DECREASEPERIOD = new Crestron.Logos.SplusObjects.DigitalInput( DECREASEPERIOD__DigitalInput__, this );
    m_DigitalInputList.Add( DECREASEPERIOD__DigitalInput__, DECREASEPERIOD );
    
    ADDDATE = new Crestron.Logos.SplusObjects.DigitalInput( ADDDATE__DigitalInput__, this );
    m_DigitalInputList.Add( ADDDATE__DigitalInput__, ADDDATE );
    
    BYDATEMONTHUP = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEMONTHUP__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEMONTHUP__DigitalInput__, BYDATEMONTHUP );
    
    BYDATEMONTHDOWN = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEMONTHDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEMONTHDOWN__DigitalInput__, BYDATEMONTHDOWN );
    
    BYDATEDAYUP = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEDAYUP__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEDAYUP__DigitalInput__, BYDATEDAYUP );
    
    BYDATEDAYDOWN = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEDAYDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEDAYDOWN__DigitalInput__, BYDATEDAYDOWN );
    
    BYDATEYEARUP = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEYEARUP__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEYEARUP__DigitalInput__, BYDATEYEARUP );
    
    BYDATEYEARDOWN = new Crestron.Logos.SplusObjects.DigitalInput( BYDATEYEARDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( BYDATEYEARDOWN__DigitalInput__, BYDATEYEARDOWN );
    
    FIRSTDATE = new Crestron.Logos.SplusObjects.DigitalInput( FIRSTDATE__DigitalInput__, this );
    m_DigitalInputList.Add( FIRSTDATE__DigitalInput__, FIRSTDATE );
    
    NEXTDATE = new Crestron.Logos.SplusObjects.DigitalInput( NEXTDATE__DigitalInput__, this );
    m_DigitalInputList.Add( NEXTDATE__DigitalInput__, NEXTDATE );
    
    PREVDATE = new Crestron.Logos.SplusObjects.DigitalInput( PREVDATE__DigitalInput__, this );
    m_DigitalInputList.Add( PREVDATE__DigitalInput__, PREVDATE );
    
    LASTDATE = new Crestron.Logos.SplusObjects.DigitalInput( LASTDATE__DigitalInput__, this );
    m_DigitalInputList.Add( LASTDATE__DigitalInput__, LASTDATE );
    
    DELETEDATE = new Crestron.Logos.SplusObjects.DigitalInput( DELETEDATE__DigitalInput__, this );
    m_DigitalInputList.Add( DELETEDATE__DigitalInput__, DELETEDATE );
    
    FIREEVENT = new Crestron.Logos.SplusObjects.DigitalInput( FIREEVENT__DigitalInput__, this );
    m_DigitalInputList.Add( FIREEVENT__DigitalInput__, FIREEVENT );
    
    LIST_EVENTS = new Crestron.Logos.SplusObjects.DigitalInput( LIST_EVENTS__DigitalInput__, this );
    m_DigitalInputList.Add( LIST_EVENTS__DigitalInput__, LIST_EVENTS );
    
    NEWPROGLOADED = new Crestron.Logos.SplusObjects.DigitalInput( NEWPROGLOADED__DigitalInput__, this );
    m_DigitalInputList.Add( NEWPROGLOADED__DigitalInput__, NEWPROGLOADED );
    
    READ_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( READ_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( READ_ERROR__DigitalOutput__, READ_ERROR );
    
    WRITE_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( WRITE_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( WRITE_ERROR__DigitalOutput__, WRITE_ERROR );
    
    EDIT_EVENT_SUSPENDED = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_EVENT_SUSPENDED__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_EVENT_SUSPENDED__DigitalOutput__, EDIT_EVENT_SUSPENDED );
    
    EDIT_EVENT_READONLY = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_EVENT_READONLY__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_EVENT_READONLY__DigitalOutput__, EDIT_EVENT_READONLY );
    
    EDIT_EVENT_ANNUAL = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_EVENT_ANNUAL__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_EVENT_ANNUAL__DigitalOutput__, EDIT_EVENT_ANNUAL );
    
    SUNDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SUNDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SUNDAY_ONOFF_FB__DigitalOutput__, SUNDAY_ONOFF_FB );
    
    MONDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( MONDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( MONDAY_ONOFF_FB__DigitalOutput__, MONDAY_ONOFF_FB );
    
    TUESDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( TUESDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( TUESDAY_ONOFF_FB__DigitalOutput__, TUESDAY_ONOFF_FB );
    
    WEDNESDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( WEDNESDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( WEDNESDAY_ONOFF_FB__DigitalOutput__, WEDNESDAY_ONOFF_FB );
    
    THURSDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( THURSDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( THURSDAY_ONOFF_FB__DigitalOutput__, THURSDAY_ONOFF_FB );
    
    FRIDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FRIDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FRIDAY_ONOFF_FB__DigitalOutput__, FRIDAY_ONOFF_FB );
    
    SATURDAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SATURDAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SATURDAY_ONOFF_FB__DigitalOutput__, SATURDAY_ONOFF_FB );
    
    JAN_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( JAN_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( JAN_ONOFF_FB__DigitalOutput__, JAN_ONOFF_FB );
    
    FEB_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( FEB_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( FEB_ONOFF_FB__DigitalOutput__, FEB_ONOFF_FB );
    
    MAR_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( MAR_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( MAR_ONOFF_FB__DigitalOutput__, MAR_ONOFF_FB );
    
    APR_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( APR_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( APR_ONOFF_FB__DigitalOutput__, APR_ONOFF_FB );
    
    MAY_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( MAY_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( MAY_ONOFF_FB__DigitalOutput__, MAY_ONOFF_FB );
    
    JUN_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( JUN_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( JUN_ONOFF_FB__DigitalOutput__, JUN_ONOFF_FB );
    
    JUL_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( JUL_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( JUL_ONOFF_FB__DigitalOutput__, JUL_ONOFF_FB );
    
    AUG_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( AUG_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( AUG_ONOFF_FB__DigitalOutput__, AUG_ONOFF_FB );
    
    SEP_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SEP_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SEP_ONOFF_FB__DigitalOutput__, SEP_ONOFF_FB );
    
    OCT_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( OCT_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCT_ONOFF_FB__DigitalOutput__, OCT_ONOFF_FB );
    
    NOV_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( NOV_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( NOV_ONOFF_FB__DigitalOutput__, NOV_ONOFF_FB );
    
    DEC_ONOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DEC_ONOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DEC_ONOFF_FB__DigitalOutput__, DEC_ONOFF_FB );
    
    EVENT_DUE = new InOutArray<DigitalOutput>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        EVENT_DUE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( EVENT_DUE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( EVENT_DUE__DigitalOutput__ + i, EVENT_DUE[i+1] );
    }
    
    EDIT_EVENT = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_EVENT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_EVENT__AnalogSerialInput__, EDIT_EVENT );
    
    MORNING_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( MORNING_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MORNING_HOUR__AnalogSerialInput__, MORNING_HOUR );
    
    MORNING_MIN = new Crestron.Logos.SplusObjects.AnalogInput( MORNING_MIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MORNING_MIN__AnalogSerialInput__, MORNING_MIN );
    
    NIGHT_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( NIGHT_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NIGHT_HOUR__AnalogSerialInput__, NIGHT_HOUR );
    
    NIGHT_MIN = new Crestron.Logos.SplusObjects.AnalogInput( NIGHT_MIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NIGHT_MIN__AnalogSerialInput__, NIGHT_MIN );
    
    EDIT_EVENT_NUMBER = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_NUMBER__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_NUMBER__AnalogSerialOutput__, EDIT_EVENT_NUMBER );
    
    EDIT_EVENT_TIMEBASE = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_TIMEBASE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_TIMEBASE__AnalogSerialOutput__, EDIT_EVENT_TIMEBASE );
    
    EDIT_EVENT_TYPE = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_TYPE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_TYPE__AnalogSerialOutput__, EDIT_EVENT_TYPE );
    
    TOTAL_USED_EVENTS = new Crestron.Logos.SplusObjects.AnalogOutput( TOTAL_USED_EVENTS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TOTAL_USED_EVENTS__AnalogSerialOutput__, TOTAL_USED_EVENTS );
    
    CMDEVENTNAME = new Crestron.Logos.SplusObjects.StringInput( CMDEVENTNAME__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( CMDEVENTNAME__AnalogSerialInput__, CMDEVENTNAME );
    
    FILENAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FILENAME__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( FILENAME__DOLLAR____AnalogSerialInput__, FILENAME__DOLLAR__ );
    
    EVENT_BYDATE_INFO = new Crestron.Logos.SplusObjects.StringOutput( EVENT_BYDATE_INFO__AnalogSerialOutput__, this );
    m_StringOutputList.Add( EVENT_BYDATE_INFO__AnalogSerialOutput__, EVENT_BYDATE_INFO );
    
    AADSSCROLLARROW__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( AADSSCROLLARROW__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( AADSSCROLLARROW__DOLLAR____AnalogSerialOutput__, AADSSCROLLARROW__DOLLAR__ );
    
    SCHEDULER_LOG = new Crestron.Logos.SplusObjects.StringOutput( SCHEDULER_LOG__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SCHEDULER_LOG__AnalogSerialOutput__, SCHEDULER_LOG );
    
    EDIT_EVENT_START__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_START__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_START__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_START__DOLLAR__ );
    
    EDIT_EVENT_STOP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_STOP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_STOP__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_STOP__DOLLAR__ );
    
    EDIT_EVENT_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_NAME__DOLLAR__ );
    
    EDIT_EVENT_TIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_TIME__DOLLAR__ );
    
    FIRED_EVENT_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( FIRED_EVENT_NAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( FIRED_EVENT_NAME__DOLLAR____AnalogSerialOutput__, FIRED_EVENT_NAME__DOLLAR__ );
    
    PERIODIC_EVENTINFO__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PERIODIC_EVENTINFO__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( PERIODIC_EVENTINFO__DOLLAR____AnalogSerialOutput__, PERIODIC_EVENTINFO__DOLLAR__ );
    
    BYDATE_EVENTINFO__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( BYDATE_EVENTINFO__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( BYDATE_EVENTINFO__DOLLAR____AnalogSerialOutput__, BYDATE_EVENTINFO__DOLLAR__ );
    
    SAVEWAIT_Callback = new WaitFunction( SAVEWAIT_CallbackFn );
    
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_0, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_DOWN_OnPush_1, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_UP_OnPush_2, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_DOWN_OnPush_3, false ) );
    AM.OnDigitalPush.Add( new InputChangeHandlerWrapper( AM_OnPush_4, false ) );
    PM.OnDigitalPush.Add( new InputChangeHandlerWrapper( PM_OnPush_5, false ) );
    SUNRISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUNRISE_OnPush_6, false ) );
    SUNSET.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUNSET_OnPush_7, false ) );
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    AM.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    PM.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    SUNRISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    SUNSET.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    EDIT_EVENT.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_EVENT_OnChange_9, false ) );
    REVERT_EDIT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_EVENT_OnChange_9, false ) );
    EDIT_FIRST_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_FIRST_EVENT_OnPush_10, false ) );
    EDIT_LAST_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_LAST_EVENT_OnPush_11, false ) );
    EDIT_NEXT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_NEXT_EVENT_OnPush_12, false ) );
    EDIT_PREV_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_PREV_EVENT_OnPush_13, false ) );
    SAVE_EDIT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_EDIT_EVENT_OnPush_14, false ) );
    SUSPEND.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUSPEND_OnPush_15, false ) );
    RESUME.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESUME_OnPush_16, false ) );
    STOP_DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_17, false ) );
    STOP_DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_DOWN_OnPush_18, false ) );
    STOP_MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_MONTH_UP_OnPush_19, false ) );
    STOP_MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_MONTH_DOWN_OnPush_20, false ) );
    STOP_YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_YEAR_UP_OnPush_21, false ) );
    STOP_YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_YEAR_DOWN_OnPush_22, false ) );
    STOP_DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    STOP_MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    STOP_YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    STOP_DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    STOP_MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    STOP_YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_DAY_UP_OnPush_23, false ) );
    START_DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_24, false ) );
    START_DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_DOWN_OnPush_25, false ) );
    START_MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_MONTH_UP_OnPush_26, false ) );
    START_MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_MONTH_DOWN_OnPush_27, false ) );
    START_YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_YEAR_UP_OnPush_28, false ) );
    START_YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_YEAR_DOWN_OnPush_29, false ) );
    START_DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    START_MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    START_YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    START_DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    START_MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    START_YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_DAY_UP_OnPush_30, false ) );
    ANNUAL_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ANNUAL_ONOFF_OnPush_31, false ) );
    LOAD.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOAD_OnPush_32, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_33, false ) );
    ADDDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ADDDATE_OnPush_34, false ) );
    DELETEDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DELETEDATE_OnPush_35, false ) );
    FIRSTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( FIRSTDATE_OnPush_36, false ) );
    NEXTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( NEXTDATE_OnPush_37, false ) );
    PREVDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( PREVDATE_OnPush_38, false ) );
    LASTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( LASTDATE_OnPush_39, false ) );
    BYDATEMONTHUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_40, false ) );
    BYDATEMONTHDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHDOWN_OnPush_41, false ) );
    BYDATEDAYUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEDAYUP_OnPush_42, false ) );
    BYDATEDAYDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEDAYDOWN_OnPush_43, false ) );
    BYDATEYEARUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEYEARUP_OnPush_44, false ) );
    BYDATEYEARDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEYEARDOWN_OnPush_45, false ) );
    BYDATEMONTHUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    BYDATEMONTHDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    BYDATEDAYUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    BYDATEDAYDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    BYDATEYEARUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    BYDATEYEARDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    NEXTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    ADDDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    DELETEDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    PREVDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    FIRSTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    LASTDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYDATEMONTHUP_OnPush_46, false ) );
    CHANGEPERIODICTYPE.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANGEPERIODICTYPE_OnPush_47, false ) );
    INCREASEPERIOD.OnDigitalPush.Add( new InputChangeHandlerWrapper( INCREASEPERIOD_OnPush_48, false ) );
    DECREASEPERIOD.OnDigitalPush.Add( new InputChangeHandlerWrapper( DECREASEPERIOD_OnPush_49, false ) );
    SUNDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUNDAY_ONOFF_OnPush_50, false ) );
    MONDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( MONDAY_ONOFF_OnPush_51, false ) );
    TUESDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( TUESDAY_ONOFF_OnPush_52, false ) );
    WEDNESDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( WEDNESDAY_ONOFF_OnPush_53, false ) );
    THURSDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( THURSDAY_ONOFF_OnPush_54, false ) );
    FRIDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( FRIDAY_ONOFF_OnPush_55, false ) );
    SATURDAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( SATURDAY_ONOFF_OnPush_56, false ) );
    JAN_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( JAN_ONOFF_OnPush_57, false ) );
    FEB_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( FEB_ONOFF_OnPush_58, false ) );
    MAR_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( MAR_ONOFF_OnPush_59, false ) );
    APR_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( APR_ONOFF_OnPush_60, false ) );
    MAY_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( MAY_ONOFF_OnPush_61, false ) );
    JUN_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( JUN_ONOFF_OnPush_62, false ) );
    JUL_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( JUL_ONOFF_OnPush_63, false ) );
    AUG_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUG_ONOFF_OnPush_64, false ) );
    SEP_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEP_ONOFF_OnPush_65, false ) );
    OCT_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( OCT_ONOFF_OnPush_66, false ) );
    NOV_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( NOV_ONOFF_OnPush_67, false ) );
    DEC_ONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEC_ONOFF_OnPush_68, false ) );
    FIREEVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( FIREEVENT_OnPush_69, false ) );
    LIST_EVENTS.OnDigitalPush.Add( new InputChangeHandlerWrapper( LIST_EVENTS_OnPush_70, false ) );
    NEWPROGLOADED.OnDigitalPush.Add( new InputChangeHandlerWrapper( NEWPROGLOADED_OnPush_71, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_EVENTSKED3_V1_2_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction SAVEWAIT_Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint SAVE_EDIT_EVENT__DigitalInput__ = 1;
const uint REVERT_EDIT_EVENT__DigitalInput__ = 2;
const uint AUTOLOAD__DigitalInput__ = 3;
const uint LOAD__DigitalInput__ = 4;
const uint SAVE__DigitalInput__ = 5;
const uint EDIT_FIRST_EVENT__DigitalInput__ = 6;
const uint EDIT_NEXT_EVENT__DigitalInput__ = 7;
const uint EDIT_PREV_EVENT__DigitalInput__ = 8;
const uint EDIT_LAST_EVENT__DigitalInput__ = 9;
const uint HOUR_UP__DigitalInput__ = 10;
const uint HOUR_DOWN__DigitalInput__ = 11;
const uint MINUTE_UP__DigitalInput__ = 12;
const uint MINUTE_DOWN__DigitalInput__ = 13;
const uint AM__DigitalInput__ = 14;
const uint PM__DigitalInput__ = 15;
const uint SUNRISE__DigitalInput__ = 16;
const uint SUNSET__DigitalInput__ = 17;
const uint START_MONTH_UP__DigitalInput__ = 18;
const uint START_DAY_UP__DigitalInput__ = 19;
const uint START_YEAR_UP__DigitalInput__ = 20;
const uint START_MONTH_DOWN__DigitalInput__ = 21;
const uint START_DAY_DOWN__DigitalInput__ = 22;
const uint START_YEAR_DOWN__DigitalInput__ = 23;
const uint STOP_MONTH_UP__DigitalInput__ = 24;
const uint STOP_DAY_UP__DigitalInput__ = 25;
const uint STOP_YEAR_UP__DigitalInput__ = 26;
const uint STOP_MONTH_DOWN__DigitalInput__ = 27;
const uint STOP_DAY_DOWN__DigitalInput__ = 28;
const uint STOP_YEAR_DOWN__DigitalInput__ = 29;
const uint ANNUAL_ONOFF__DigitalInput__ = 30;
const uint SUSPEND__DigitalInput__ = 31;
const uint RESUME__DigitalInput__ = 32;
const uint EXECUTEMISSEDEVENTS__DigitalInput__ = 33;
const uint SUNDAY_ONOFF__DigitalInput__ = 34;
const uint MONDAY_ONOFF__DigitalInput__ = 35;
const uint TUESDAY_ONOFF__DigitalInput__ = 36;
const uint WEDNESDAY_ONOFF__DigitalInput__ = 37;
const uint THURSDAY_ONOFF__DigitalInput__ = 38;
const uint FRIDAY_ONOFF__DigitalInput__ = 39;
const uint SATURDAY_ONOFF__DigitalInput__ = 40;
const uint JAN_ONOFF__DigitalInput__ = 41;
const uint FEB_ONOFF__DigitalInput__ = 42;
const uint MAR_ONOFF__DigitalInput__ = 43;
const uint APR_ONOFF__DigitalInput__ = 44;
const uint MAY_ONOFF__DigitalInput__ = 45;
const uint JUN_ONOFF__DigitalInput__ = 46;
const uint JUL_ONOFF__DigitalInput__ = 47;
const uint AUG_ONOFF__DigitalInput__ = 48;
const uint SEP_ONOFF__DigitalInput__ = 49;
const uint OCT_ONOFF__DigitalInput__ = 50;
const uint NOV_ONOFF__DigitalInput__ = 51;
const uint DEC_ONOFF__DigitalInput__ = 52;
const uint CHANGEPERIODICTYPE__DigitalInput__ = 53;
const uint INCREASEPERIOD__DigitalInput__ = 54;
const uint DECREASEPERIOD__DigitalInput__ = 55;
const uint ADDDATE__DigitalInput__ = 56;
const uint BYDATEMONTHUP__DigitalInput__ = 57;
const uint BYDATEMONTHDOWN__DigitalInput__ = 58;
const uint BYDATEDAYUP__DigitalInput__ = 59;
const uint BYDATEDAYDOWN__DigitalInput__ = 60;
const uint BYDATEYEARUP__DigitalInput__ = 61;
const uint BYDATEYEARDOWN__DigitalInput__ = 62;
const uint FIRSTDATE__DigitalInput__ = 63;
const uint NEXTDATE__DigitalInput__ = 64;
const uint PREVDATE__DigitalInput__ = 65;
const uint LASTDATE__DigitalInput__ = 66;
const uint DELETEDATE__DigitalInput__ = 67;
const uint FIREEVENT__DigitalInput__ = 68;
const uint LIST_EVENTS__DigitalInput__ = 69;
const uint CMDEVENTNAME__AnalogSerialInput__ = 0;
const uint EDIT_EVENT__AnalogSerialInput__ = 1;
const uint MORNING_HOUR__AnalogSerialInput__ = 2;
const uint MORNING_MIN__AnalogSerialInput__ = 3;
const uint NIGHT_HOUR__AnalogSerialInput__ = 4;
const uint NIGHT_MIN__AnalogSerialInput__ = 5;
const uint FILENAME__DOLLAR____AnalogSerialInput__ = 6;
const uint NEWPROGLOADED__DigitalInput__ = 70;
const uint READ_ERROR__DigitalOutput__ = 0;
const uint WRITE_ERROR__DigitalOutput__ = 1;
const uint EDIT_EVENT_SUSPENDED__DigitalOutput__ = 2;
const uint EDIT_EVENT_READONLY__DigitalOutput__ = 3;
const uint EDIT_EVENT_ANNUAL__DigitalOutput__ = 4;
const uint SUNDAY_ONOFF_FB__DigitalOutput__ = 5;
const uint MONDAY_ONOFF_FB__DigitalOutput__ = 6;
const uint TUESDAY_ONOFF_FB__DigitalOutput__ = 7;
const uint WEDNESDAY_ONOFF_FB__DigitalOutput__ = 8;
const uint THURSDAY_ONOFF_FB__DigitalOutput__ = 9;
const uint FRIDAY_ONOFF_FB__DigitalOutput__ = 10;
const uint SATURDAY_ONOFF_FB__DigitalOutput__ = 11;
const uint JAN_ONOFF_FB__DigitalOutput__ = 12;
const uint FEB_ONOFF_FB__DigitalOutput__ = 13;
const uint MAR_ONOFF_FB__DigitalOutput__ = 14;
const uint APR_ONOFF_FB__DigitalOutput__ = 15;
const uint MAY_ONOFF_FB__DigitalOutput__ = 16;
const uint JUN_ONOFF_FB__DigitalOutput__ = 17;
const uint JUL_ONOFF_FB__DigitalOutput__ = 18;
const uint AUG_ONOFF_FB__DigitalOutput__ = 19;
const uint SEP_ONOFF_FB__DigitalOutput__ = 20;
const uint OCT_ONOFF_FB__DigitalOutput__ = 21;
const uint NOV_ONOFF_FB__DigitalOutput__ = 22;
const uint DEC_ONOFF_FB__DigitalOutput__ = 23;
const uint EVENT_BYDATE_INFO__AnalogSerialOutput__ = 0;
const uint AADSSCROLLARROW__DOLLAR____AnalogSerialOutput__ = 1;
const uint SCHEDULER_LOG__AnalogSerialOutput__ = 2;
const uint EVENT_DUE__DigitalOutput__ = 24;
const uint EDIT_EVENT_NUMBER__AnalogSerialOutput__ = 3;
const uint EDIT_EVENT_TIMEBASE__AnalogSerialOutput__ = 4;
const uint EDIT_EVENT_TYPE__AnalogSerialOutput__ = 5;
const uint TOTAL_USED_EVENTS__AnalogSerialOutput__ = 6;
const uint EDIT_EVENT_START__DOLLAR____AnalogSerialOutput__ = 7;
const uint EDIT_EVENT_STOP__DOLLAR____AnalogSerialOutput__ = 8;
const uint EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__ = 9;
const uint EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__ = 10;
const uint FIRED_EVENT_NAME__DOLLAR____AnalogSerialOutput__ = 11;
const uint PERIODIC_EVENTINFO__DOLLAR____AnalogSerialOutput__ = 12;
const uint BYDATE_EVENTINFO__DOLLAR____AnalogSerialOutput__ = 13;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public CrestronString LASTCHECKED;
            
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
public class EVENTINFO : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  NAME;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  TIMEBASE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public short  _TIME = 0;
    
    [SplusStructAttribute(3, false, false)]
    public uint  _DATE = 0;
    
    [SplusStructAttribute(4, false, false)]
    public uint  _STARTDATE = 0;
    
    [SplusStructAttribute(5, false, false)]
    public uint  _STOPDATE = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  FREE = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  SUSPENDED = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  EVENTTYPE = 0;
    
    [SplusStructAttribute(9, false, false)]
    public CrestronString  SCHEDULEINFO;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  HIDDENSTATE = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  READONLY = 0;
    
    [SplusStructAttribute(12, false, false)]
    public CrestronString  LASTMODIFIED;
    
    [SplusStructAttribute(13, false, false)]
    public CrestronString  USERDATA;
    
    
    public EVENTINFO( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        NAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, Owner );
        SCHEDULEINFO  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, Owner );
        LASTMODIFIED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, Owner );
        USERDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}

}
