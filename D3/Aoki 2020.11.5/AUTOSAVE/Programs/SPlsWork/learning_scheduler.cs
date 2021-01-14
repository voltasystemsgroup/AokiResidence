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

namespace CrestronModule_LEARNING_SCHEDULER
{
    public class CrestronModuleClass_LEARNING_SCHEDULER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITONETIME;
        Crestron.Logos.SplusObjects.DigitalInput STARTRECORDING;
        Crestron.Logos.SplusObjects.DigitalInput STARTPLAYBACK;
        Crestron.Logos.SplusObjects.DigitalInput STOP;
        Crestron.Logos.SplusObjects.DigitalInput RECORD2WKPERIOD;
        Crestron.Logos.SplusObjects.DigitalInput DONTCOPYDATAFROMSAVEDFILE;
        Crestron.Logos.SplusObjects.DigitalInput VARYPLAYBACK;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SWITCHEDLEVELS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PLAYBACKSWITCHEDLEVELS;
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput RECORDINGINTERVALINMINUTES;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DIMLEVELS;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENT_MODE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> PLAYBACKDIMLEVELS;
        UShortParameter SCALEBACKFACTOR;
        ushort G_IFILEOPERATIONS = 0;
        ushort G_BINITIALIZING = 0;
        
        private int LMIN (  SplusExecutionContext __context__, int A , int B ) 
            { 
            
            __context__.SourceCodeLine = 252;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( A < B ))  ) ) 
                {
                __context__.SourceCodeLine = 253;
                return (int)( A) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 255;
                return (int)( B) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private short SRANDOM (  SplusExecutionContext __context__, short ILOWERBOUND , short IUPPERBOUND ) 
            { 
            ushort IRANDOM = 0;
            
            ushort _ILOWERBOUND = 0;
            ushort _IUPPERBOUND = 0;
            
            ushort IOFFSET = 0;
            
            
            __context__.SourceCodeLine = 359;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ILOWERBOUND > IUPPERBOUND ))  ) ) 
                {
                __context__.SourceCodeLine = 360;
                return (short)( ILOWERBOUND) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 361;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILOWERBOUND == IUPPERBOUND))  ) ) 
                    {
                    __context__.SourceCodeLine = 362;
                    return (short)( ILOWERBOUND) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 364;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ILOWERBOUND < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 365;
                IOFFSET = (ushort) ( Functions.Abs( ILOWERBOUND ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 367;
                IOFFSET = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 369;
            _ILOWERBOUND = (ushort) ( (ILOWERBOUND + IOFFSET) ) ; 
            __context__.SourceCodeLine = 370;
            _IUPPERBOUND = (ushort) ( (IUPPERBOUND + IOFFSET) ) ; 
            __context__.SourceCodeLine = 372;
            IRANDOM = (ushort) ( Functions.Random( (ushort)( _ILOWERBOUND ) , (ushort)( _IUPPERBOUND ) ) ) ; 
            __context__.SourceCodeLine = 374;
            return (short)( (IRANDOM - IOFFSET)) ; 
            
            }
            
        private ushort GETTIMEINMINUTES (  SplusExecutionContext __context__, ushort IHOUR , ushort IMINUTE ) 
            { 
            
            __context__.SourceCodeLine = 387;
            return (ushort)( ((IHOUR * 60) + IMINUTE)) ; 
            
            }
            
        private CrestronString GETTIMESTRING (  SplusExecutionContext __context__, ushort ITIMEINMINUTES ) 
            { 
            ushort IHOUR = 0;
            ushort IMINUTE = 0;
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            
            __context__.SourceCodeLine = 402;
            IHOUR = (ushort) ( (ITIMEINMINUTES / 60) ) ; 
            __context__.SourceCodeLine = 403;
            IMINUTE = (ushort) ( Mod( ITIMEINMINUTES , 60 ) ) ; 
            __context__.SourceCodeLine = 405;
            MakeString ( STIME , "{0:d2}:{1:d2}", (short)IHOUR, (short)IMINUTE) ; 
            __context__.SourceCodeLine = 407;
            return ( STIME ) ; 
            
            }
            
        private ushort GETRANDOMLIGHTLEVEL (  SplusExecutionContext __context__, ushort ICURRENTLEVEL , ushort ILOWERBOUND , ushort IUPPERBOUND , ushort ITIME ) 
            { 
            ushort IRAND = 0;
            
            ushort IACTIVITYLEVEL = 0;
            ushort IAVERAGELIGHTLEVEL = 0;
            
            
            __context__.SourceCodeLine = 434;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITIME < 360 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( ITIME > 1380 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 436;
                IACTIVITYLEVEL = (ushort) ( 5 ) ; 
                __context__.SourceCodeLine = 437;
                IAVERAGELIGHTLEVEL = (ushort) ( 10 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 439;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( ITIME > 540 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( ITIME < 960 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 441;
                    IACTIVITYLEVEL = (ushort) ( 15 ) ; 
                    __context__.SourceCodeLine = 442;
                    IAVERAGELIGHTLEVEL = (ushort) ( 30 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 446;
                    IACTIVITYLEVEL = (ushort) ( 30 ) ; 
                    __context__.SourceCodeLine = 447;
                    IAVERAGELIGHTLEVEL = (ushort) ( 50 ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 450;
            IRAND = (ushort) ( Functions.Random( (ushort)( 0 ) , (ushort)( 100 ) ) ) ; 
            __context__.SourceCodeLine = 452;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRAND < IACTIVITYLEVEL ))  ) ) 
                { 
                __context__.SourceCodeLine = 455;
                IRAND = (ushort) ( Functions.MulDiv( (ushort)( IRAND ) , (ushort)( 100 ) , (ushort)( IACTIVITYLEVEL ) ) ) ; 
                __context__.SourceCodeLine = 458;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRAND > IAVERAGELIGHTLEVEL ))  ) ) 
                    {
                    __context__.SourceCodeLine = 459;
                    return (ushort)( 0) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 461;
                    return (ushort)( Functions.Random( (ushort)( ILOWERBOUND ) , (ushort)( IUPPERBOUND ) )) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 464;
                return (ushort)( ICURRENTLEVEL) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void GETRANDOMLIGHTLEVELS (  SplusExecutionContext __context__, ushort ITIME ) 
            { 
            ushort IARRAYSIZE = 0;
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 482;
            IARRAYSIZE = (ushort) ( Functions.Min( Functions.GetNumArrayCols( _SplusNVRAM.G_LDIMLEVELSTOPLAYBACK ) , _SplusNVRAM.G_INUMBEROFDIMCKTS ) ) ; 
            __context__.SourceCodeLine = 484;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)IARRAYSIZE; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 486;
                
                __context__.SourceCodeLine = 489;
                _SplusNVRAM.G_LDIMLEVELSTOPLAYBACK [ I] = (int) ( GETRANDOMLIGHTLEVEL( __context__ , (ushort)( _SplusNVRAM.G_LDIMLEVELSTOPLAYBACK[ I ] ) , (ushort)( 16384 ) , (ushort)( 62258 ) , (ushort)( ITIME ) ) ) ; 
                __context__.SourceCodeLine = 490;
                
                __context__.SourceCodeLine = 484;
                } 
            
            __context__.SourceCodeLine = 495;
            IARRAYSIZE = (ushort) ( Functions.Min( Functions.GetNumArrayCols( _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK ) , _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) ; 
            __context__.SourceCodeLine = 497;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)IARRAYSIZE; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 499;
                
                __context__.SourceCodeLine = 506;
                _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK [ I] = (int) ( GETRANDOMLIGHTLEVEL( __context__ , (ushort)( _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK[ I ] ) , (ushort)( 1 ) , (ushort)( 1 ) , (ushort)( ITIME ) ) ) ; 
                __context__.SourceCodeLine = 507;
                
                __context__.SourceCodeLine = 497;
                } 
            
            
            }
            
        private short SETRECORDINTERVAL (  SplusExecutionContext __context__, ushort IINTERVAL ) 
            { 
            
            __context__.SourceCodeLine = 524;
            
            __context__.SourceCodeLine = 527;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IINTERVAL >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IINTERVAL <= 60 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 529;
                _SplusNVRAM.G_ISAVEDRECORDINGINTERVALINMINUTES = (ushort) ( IINTERVAL ) ; 
                __context__.SourceCodeLine = 530;
                return (short)( 0) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 534;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.G_ISAVEDRECORDINGINTERVALINMINUTES >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.G_ISAVEDRECORDINGINTERVALINMINUTES <= 60 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 535;
                    return (short)( _SplusNVRAM.G_ISAVEDRECORDINGINTERVALINMINUTES) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 537;
                    return (short)( 15) ; 
                    }
                
                __context__.SourceCodeLine = 539;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort GETRECORDINTERVAL (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 552;
            return (ushort)( _SplusNVRAM.G_ISAVEDRECORDINGINTERVALINMINUTES) ; 
            
            }
            
        private void SAVEVALUESTOFILE (  SplusExecutionContext __context__, CrestronString SFILENAME , ushort ITIMESTAMPINMINUTES ) 
            { 
            ushort I = 0;
            ushort VALUE = 0;
            
            short NCHARS = 0;
            short NHANDLE = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString SCIRCUITDATA;
            CrestronString SLEVEL;
            SCIRCUITDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            SLEVEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            CrestronString TEMPINT;
            TEMPINT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            
            __context__.SourceCodeLine = 576;
            
            __context__.SourceCodeLine = 580;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 582;
            NHANDLE = (short) ( FileOpen( SFILENAME ,(ushort) (((1 | 8) | 256) | 16384) ) ) ; 
            __context__.SourceCodeLine = 583;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NHANDLE < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 584;
                GenerateUserError ( "Vacation Scheduler, SaveValuesToFile: Cannot open file {0} for write. Error code = {1:d}\r\n", SFILENAME , (short)NHANDLE) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 590;
                STIME  .UpdateValue ( GETTIMESTRING (  __context__ , (ushort)( ITIMESTAMPINMINUTES ))  ) ; 
                __context__.SourceCodeLine = 592;
                NCHARS = (short) ( FileWrite( (short)( NHANDLE ) , STIME , (ushort)( 5 ) ) ) ; 
                __context__.SourceCodeLine = 593;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < 5 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 594;
                    GenerateUserError ( "Vacation Scheduler, SaveValuesToFile: Could not save time to file {0}. Error code = {1:d}\r\n", SFILENAME , (short)NCHARS) ; 
                    }
                
                __context__.SourceCodeLine = 598;
                
                __context__.SourceCodeLine = 601;
                __context__.SourceCodeLine = 604;
                TEMPINT  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.G_INUMBEROFDIMCKTS ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.G_INUMBEROFDIMCKTS ) ) )  ) ; 
                __context__.SourceCodeLine = 605;
                NCHARS = (short) ( FileWrite( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                
                __context__.SourceCodeLine = 608;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 610;
                    GenerateUserError ( "Could not save number of dim ckts at time: {0}. nChars={1:d}\r\n", STIME , (short)NCHARS) ; 
                    __context__.SourceCodeLine = 611;
                    FileClose (  (short) ( NHANDLE ) ) ; 
                    __context__.SourceCodeLine = 612;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 613;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 616;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)_SplusNVRAM.G_INUMBEROFDIMCKTS; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 618;
                    SLEVEL  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) DIMLEVELS[ I ] .UshortValue ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) DIMLEVELS[ I ] .UshortValue ) ) )  ) ; 
                    __context__.SourceCodeLine = 619;
                    SetString ( SLEVEL , (int)((I * 2) - 1), SCIRCUITDATA ) ; 
                    __context__.SourceCodeLine = 616;
                    } 
                
                __context__.SourceCodeLine = 623;
                
                __context__.SourceCodeLine = 626;
                NCHARS = (short) ( FileWrite( (short)( NHANDLE ) , SCIRCUITDATA , (ushort)( (_SplusNVRAM.G_INUMBEROFDIMCKTS * 2) ) ) ) ; 
                __context__.SourceCodeLine = 627;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < (_SplusNVRAM.G_INUMBEROFDIMCKTS * 2) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 629;
                    GenerateUserError ( "Could not save dim levels at time: {0}. nChars={1:d}\r\n", STIME , (short)NCHARS) ; 
                    __context__.SourceCodeLine = 630;
                    FileClose (  (short) ( NHANDLE ) ) ; 
                    __context__.SourceCodeLine = 631;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 632;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 636;
                
                __context__.SourceCodeLine = 639;
                __context__.SourceCodeLine = 642;
                TEMPINT  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) )  ) ; 
                __context__.SourceCodeLine = 643;
                NCHARS = (short) ( FileWrite( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                
                __context__.SourceCodeLine = 646;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 648;
                    GenerateUserError ( "Could not save number of switched ckts at time: {0}. nChars={1:d}\r\n", STIME , (short)NCHARS) ; 
                    __context__.SourceCodeLine = 649;
                    FileClose (  (short) ( NHANDLE ) ) ; 
                    __context__.SourceCodeLine = 650;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 651;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 654;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)_SplusNVRAM.G_INUMBEROFSWITCHEDCKTS; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 656;
                    SLEVEL  .UpdateValue ( Functions.Chr (  (int) ( SWITCHEDLEVELS[ I ] .Value ) )  ) ; 
                    __context__.SourceCodeLine = 657;
                    SetString ( SLEVEL , (int)I, SCIRCUITDATA ) ; 
                    __context__.SourceCodeLine = 654;
                    } 
                
                __context__.SourceCodeLine = 659;
                
                __context__.SourceCodeLine = 662;
                NCHARS = (short) ( FileWrite( (short)( NHANDLE ) , SCIRCUITDATA , (ushort)( _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) ) ; 
                __context__.SourceCodeLine = 663;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 665;
                    GenerateUserError ( "Could not save non-dim levels at time: {0}. nChars={1:d}\r\n", STIME , (short)NCHARS) ; 
                    __context__.SourceCodeLine = 666;
                    FileClose (  (short) ( NHANDLE ) ) ; 
                    __context__.SourceCodeLine = 667;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 668;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 671;
                FileClose (  (short) ( NHANDLE ) ) ; 
                } 
            
            __context__.SourceCodeLine = 674;
            EndFileOperations ( ) ; 
            
            }
            
        private ushort GETNEXTPLAYBACKTIME (  SplusExecutionContext __context__, CrestronString SFILENAME , ref uint LFILEPOSITION , ushort IMINIMUMTIME , ref ushort INEXTTIMETOPLAYBACK ) 
            { 
            ushort I = 0;
            ushort RETURNVALUE = 0;
            
            short NHANDLE = 0;
            short NCHARS = 0;
            
            int IERR = 0;
            
            ushort IVALUE = 0;
            
            uint LSEEK = 0;
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            short INEXTTIMEINFILE = 0;
            
            CrestronString TEMPINT;
            TEMPINT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            
            __context__.SourceCodeLine = 706;
            INEXTTIMEINFILE = (short) ( -1 ) ; 
            __context__.SourceCodeLine = 707;
            RETURNVALUE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 709;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 712;
            NHANDLE = (short) ( FileOpen( SFILENAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 713;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 715;
                GenerateUserError ( "Cannot open file {0}.\r\n", SFILENAME ) ; 
                __context__.SourceCodeLine = 716;
                RETURNVALUE = (ushort) ( 0 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 720;
                do 
                    { 
                    __context__.SourceCodeLine = 723;
                    NCHARS = (short) ( FileRead( (short)( NHANDLE ) , STIME , (ushort)( 5 ) ) ) ; 
                    __context__.SourceCodeLine = 724;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 726;
                        RETURNVALUE = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 727;
                        break ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 731;
                        INEXTTIMEINFILE = (short) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.Atoi( Functions.Left( STIME , (int)( 2 ) ) ) ) , (ushort)( Functions.Atoi( Functions.Mid( STIME , (int)( 4 ) , (int)( 2 ) ) ) ) ) ) ; 
                        __context__.SourceCodeLine = 732;
                        
                        __context__.SourceCodeLine = 735;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTTIMEINFILE > IMINIMUMTIME ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 737;
                            
                            __context__.SourceCodeLine = 740;
                            LFILEPOSITION = (uint) ( FileSeek( (short)( NHANDLE ) , (uint)( _SplusNVRAM.G_LZEROLONG ) , (ushort)( 1 ) ) ) ; 
                            __context__.SourceCodeLine = 741;
                            RETURNVALUE = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 742;
                            break ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 747;
                            INEXTTIMEINFILE = (short) ( -1 ) ; 
                            __context__.SourceCodeLine = 750;
                            __context__.SourceCodeLine = 753;
                            IERR = (int) ( FileRead( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                            __context__.SourceCodeLine = 754;
                            IVALUE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                            
                            __context__.SourceCodeLine = 756;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERR < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 758;
                                RETURNVALUE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 759;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 761;
                            LSEEK = (uint) ( (IVALUE * 2) ) ; 
                            __context__.SourceCodeLine = 762;
                            IERR = (int) ( FileSeek( (short)( NHANDLE ) , (uint)( LSEEK ) , (ushort)( 1 ) ) ) ; 
                            __context__.SourceCodeLine = 763;
                            
                            __context__.SourceCodeLine = 766;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERR < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 768;
                                RETURNVALUE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 769;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 773;
                            __context__.SourceCodeLine = 776;
                            IERR = (int) ( FileRead( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                            __context__.SourceCodeLine = 777;
                            IVALUE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                            
                            __context__.SourceCodeLine = 779;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERR < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 781;
                                RETURNVALUE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 782;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 784;
                            LSEEK = (uint) ( IVALUE ) ; 
                            __context__.SourceCodeLine = 785;
                            IERR = (int) ( FileSeek( (short)( NHANDLE ) , (uint)( LSEEK ) , (ushort)( 1 ) ) ) ; 
                            __context__.SourceCodeLine = 786;
                            
                            __context__.SourceCodeLine = 789;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERR < 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 791;
                                RETURNVALUE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 792;
                                break ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    } 
                while (false == ( Functions.TestForTrue  ( FileEOF( (short)( NHANDLE ) )) )); 
                } 
            
            __context__.SourceCodeLine = 799;
            FileClose (  (short) ( NHANDLE ) ) ; 
            __context__.SourceCodeLine = 801;
            
            __context__.SourceCodeLine = 805;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 807;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RETURNVALUE == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 810;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (INEXTTIMEINFILE - IMINIMUMTIME) > GETRECORDINTERVAL( __context__ ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 811;
                    RETURNVALUE = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 813;
                    INEXTTIMETOPLAYBACK = (ushort) ( INEXTTIMEINFILE ) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 816;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RETURNVALUE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 818;
                INEXTTIMETOPLAYBACK = (ushort) ( (IMINIMUMTIME + GETRECORDINTERVAL( __context__ )) ) ; 
                } 
            
            __context__.SourceCodeLine = 822;
            if ( Functions.TestForTrue  ( ( VARYPLAYBACK  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 825;
                do 
                    { 
                    __context__.SourceCodeLine = 827;
                    INEXTTIMETOPLAYBACK = (ushort) ( (INEXTTIMETOPLAYBACK + SRANDOM( __context__ , (short)( (Functions.ToSignedInteger( -( GETRECORDINTERVAL( __context__ ) ) ) + 1) ) , (short)( (GETRECORDINTERVAL( __context__ ) - 1) ) )) ) ; 
                    } 
                while (false == ( Functions.TestForTrue  ( Functions.BoolToInt ( INEXTTIMETOPLAYBACK > IMINIMUMTIME )) )); 
                __context__.SourceCodeLine = 832;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (INEXTTIMEINFILE != -1) ) && Functions.TestForTrue ( Functions.BoolToInt ( INEXTTIMETOPLAYBACK > INEXTTIMEINFILE ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 834;
                    INEXTTIMETOPLAYBACK = (ushort) ( INEXTTIMEINFILE ) ; 
                    __context__.SourceCodeLine = 835;
                    RETURNVALUE = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 839;
            
            __context__.SourceCodeLine = 847;
            return (ushort)( RETURNVALUE) ; 
            
            }
            
        private ushort READVALUESFROMFILE (  SplusExecutionContext __context__, CrestronString SFILENAME , uint LFILEPOSITION ) 
            { 
            ushort I = 0;
            ushort J = 0;
            
            int NVALUE = 0;
            
            short NHANDLE = 0;
            short NCHARS = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            ushort INUMCKTSINFILE = 0;
            ushort INUMCKTSTOREAD = 0;
            
            CrestronString SCIRCUITDATA;
            SCIRCUITDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            CrestronString TEMPINT;
            TEMPINT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            
            __context__.SourceCodeLine = 869;
            
            __context__.SourceCodeLine = 873;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 875;
            NHANDLE = (short) ( FileOpen( SFILENAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 876;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 878;
                GenerateUserError ( "Cannot open file {0}.\r\n", SFILENAME ) ; 
                __context__.SourceCodeLine = 879;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 880;
                return (ushort)( 0) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 884;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileSeek( (short)( NHANDLE ) , (uint)( LFILEPOSITION ) , (ushort)( 0 ) ) < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 886;
                    GenerateUserError ( "Error seeking in file.\r\n") ; 
                    __context__.SourceCodeLine = 887;
                    FileClose (  (short) ( NHANDLE ) ) ; 
                    __context__.SourceCodeLine = 888;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 889;
                    return (ushort)( 0) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 898;
                    __context__.SourceCodeLine = 901;
                    NCHARS = (short) ( FileRead( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 902;
                    INUMCKTSINFILE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                    
                    __context__.SourceCodeLine = 905;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 907;
                        GenerateUserError ( "ReadValuesFromFile: Could not read number of dim ckts. Filename = {0}, FilePos = {1:d}\r\n", SFILENAME , (int)LFILEPOSITION) ; 
                        __context__.SourceCodeLine = 908;
                        FileClose (  (short) ( NHANDLE ) ) ; 
                        __context__.SourceCodeLine = 909;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 910;
                        return (ushort)( 0) ; 
                        } 
                    
                    __context__.SourceCodeLine = 913;
                    INUMCKTSTOREAD = (ushort) ( Functions.Min( INUMCKTSINFILE , _SplusNVRAM.G_INUMBEROFDIMCKTS ) ) ; 
                    __context__.SourceCodeLine = 916;
                    NCHARS = (short) ( FileRead( (short)( NHANDLE ) , SCIRCUITDATA , (ushort)( (INUMCKTSTOREAD * 2) ) ) ) ; 
                    __context__.SourceCodeLine = 917;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 919;
                        GenerateUserError ( "ReadValuesFromFile: Could not read dim levels. Filename = {0}, FilePos = {1:d}\r\n", SFILENAME , (int)LFILEPOSITION) ; 
                        __context__.SourceCodeLine = 920;
                        FileClose (  (short) ( NHANDLE ) ) ; 
                        __context__.SourceCodeLine = 921;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 922;
                        return (ushort)( 0) ; 
                        } 
                    
                    __context__.SourceCodeLine = 925;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)INUMCKTSTOREAD; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 927;
                        NVALUE = (int) ( ((Byte( SCIRCUITDATA , (int)( ((I * 2) - 1) ) ) * 256) + Byte( SCIRCUITDATA , (int)( (I * 2) ) )) ) ; 
                        __context__.SourceCodeLine = 928;
                        _SplusNVRAM.G_LDIMLEVELSTOPLAYBACK [ I] = (int) ( NVALUE ) ; 
                        __context__.SourceCodeLine = 925;
                        } 
                    
                    __context__.SourceCodeLine = 936;
                    __context__.SourceCodeLine = 939;
                    NCHARS = (short) ( FileRead( (short)( NHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 940;
                    INUMCKTSINFILE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                    
                    __context__.SourceCodeLine = 943;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 945;
                        GenerateUserError ( "ReadValuesFromFile: Could not read number of switched ckts. Filename = {0}, FilePos = {1:d}\r\n", SFILENAME , (int)LFILEPOSITION) ; 
                        __context__.SourceCodeLine = 946;
                        FileClose (  (short) ( NHANDLE ) ) ; 
                        __context__.SourceCodeLine = 947;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 948;
                        return (ushort)( 0) ; 
                        } 
                    
                    __context__.SourceCodeLine = 951;
                    INUMCKTSTOREAD = (ushort) ( Functions.Min( INUMCKTSINFILE , _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) ; 
                    __context__.SourceCodeLine = 954;
                    NCHARS = (short) ( FileRead( (short)( NHANDLE ) , SCIRCUITDATA , (ushort)( INUMCKTSINFILE ) ) ) ; 
                    __context__.SourceCodeLine = 955;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 957;
                        GenerateUserError ( "ReadValuesFromFile: Could not read switched levels. Filename = {0}, FilePos = {1:d}\r\n", SFILENAME , (int)LFILEPOSITION) ; 
                        __context__.SourceCodeLine = 958;
                        FileClose (  (short) ( NHANDLE ) ) ; 
                        __context__.SourceCodeLine = 959;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 960;
                        return (ushort)( 0) ; 
                        } 
                    
                    __context__.SourceCodeLine = 963;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)NCHARS; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 965;
                        NVALUE = (int) ( Byte( SCIRCUITDATA , (int)( I ) ) ) ; 
                        __context__.SourceCodeLine = 966;
                        _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK [ I] = (int) ( NVALUE ) ; 
                        __context__.SourceCodeLine = 963;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 969;
                FileClose (  (short) ( NHANDLE ) ) ; 
                } 
            
            __context__.SourceCodeLine = 973;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 975;
            return (ushort)( 1) ; 
            
            }
            
        private void COPYSAVEDLIGHTVALUESTOOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 991;
            
            __context__.SourceCodeLine = 995;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)_SplusNVRAM.G_INUMBEROFDIMCKTS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 997;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.G_LDIMLEVELSTOPLAYBACK[ I ] != -1))  ) ) 
                    {
                    __context__.SourceCodeLine = 998;
                    PLAYBACKDIMLEVELS [ I]  .Value = (ushort) ( ((_SplusNVRAM.G_LDIMLEVELSTOPLAYBACK[ I ] * SCALEBACKFACTOR  .Value) / 65535) ) ; 
                    }
                
                __context__.SourceCodeLine = 995;
                } 
            
            __context__.SourceCodeLine = 1001;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)_SplusNVRAM.G_INUMBEROFSWITCHEDCKTS; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 1003;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK[ I ] != -1))  ) ) 
                    {
                    __context__.SourceCodeLine = 1004;
                    PLAYBACKSWITCHEDLEVELS [ I]  .Value = (ushort) ( _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK[ I ] ) ; 
                    }
                
                __context__.SourceCodeLine = 1001;
                } 
            
            
            }
            
        private ushort FILEEXISTS (  SplusExecutionContext __context__, CrestronString SFILENAME ) 
            { 
            short NHANDLE = 0;
            
            ushort BRETURNVALUE = 0;
            
            
            __context__.SourceCodeLine = 1020;
            BRETURNVALUE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1022;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1024;
            NHANDLE = (short) ( FileOpen( SFILENAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1025;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1026;
                FileClose (  (short) ( NHANDLE ) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1028;
                BRETURNVALUE = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 1030;
            
            __context__.SourceCodeLine = 1034;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1036;
            return (ushort)( BRETURNVALUE) ; 
            
            }
            
        private void FILECOPY (  SplusExecutionContext __context__, CrestronString SRCFILE , CrestronString DESTFILE ) 
            { 
            CrestronString SBUFFER;
            SBUFFER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4096, this );
            
            short NSRCHANDLE = 0;
            short NDESTHANDLE = 0;
            short NBYTES = 0;
            
            uint LTOTALBYTES = 0;
            
            
            __context__.SourceCodeLine = 1054;
            
            __context__.SourceCodeLine = 1058;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1060;
            NSRCHANDLE = (short) ( FileOpen( SRCFILE ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1061;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NSRCHANDLE < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1062;
                GenerateUserError ( "Cannot open file to copy {0}.\r\n", SRCFILE ) ; 
                }
            
            __context__.SourceCodeLine = 1064;
            NDESTHANDLE = (short) ( FileOpen( DESTFILE ,(ushort) (((1 | 256) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 1065;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1066;
                GenerateUserError ( "Cannot create file {0}.\r\n", DESTFILE ) ; 
                }
            
            __context__.SourceCodeLine = 1067;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( NSRCHANDLE >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( NDESTHANDLE >= 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1069;
                LTOTALBYTES = (uint) ( 0 ) ; 
                __context__.SourceCodeLine = 1070;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileEOF( (short)( NSRCHANDLE ) ) == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1072;
                    NBYTES = (short) ( FileRead( (short)( NSRCHANDLE ) , SBUFFER , (ushort)( 4096 ) ) ) ; 
                    __context__.SourceCodeLine = 1073;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileWrite( (short)( NDESTHANDLE ) , SBUFFER , (ushort)( NBYTES ) ) < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1075;
                        GenerateUserError ( "Cannot write bytes to file {0}\r\n", DESTFILE ) ; 
                        __context__.SourceCodeLine = 1076;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 1078;
                    LTOTALBYTES = (uint) ( (LTOTALBYTES + NBYTES) ) ; 
                    __context__.SourceCodeLine = 1070;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 1082;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NSRCHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1083;
                FileClose (  (short) ( NSRCHANDLE ) ) ; 
                }
            
            __context__.SourceCodeLine = 1084;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1085;
                FileClose (  (short) ( NDESTHANDLE ) ) ; 
                }
            
            __context__.SourceCodeLine = 1087;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1089;
            
            
            }
            
        private void MERGEFILES (  SplusExecutionContext __context__, CrestronString SRCFILE1 , CrestronString SRCFILE2 , ushort INTTIME , CrestronString DESTFILE ) 
            { 
            short NFILEHANDLE1 = 0;
            short NFILEHANDLE2 = 0;
            short NDESTHANDLE = 0;
            
            short NCHARS = 0;
            short NERROR = 0;
            
            ushort FOUND2NDFILEPOS = 0;
            
            int LFILEPOS1 = 0;
            int LFILEPOS2 = 0;
            int LCURFILEPOS = 0;
            
            ushort INUMCKTS = 0;
            ushort ITIMEINFILE = 0;
            
            ushort IBLOCKSIZE = 0;
            
            CrestronString SDATA;
            SDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4096, this );
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            CrestronString TEMPINT;
            TEMPINT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            
            __context__.SourceCodeLine = 1117;
            FOUND2NDFILEPOS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1120;
            
            __context__.SourceCodeLine = 1124;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1126;
            NFILEHANDLE1 = (short) ( FileOpen( SRCFILE1 ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1128;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE1 < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1130;
                LFILEPOS1 = (int) ( Functions.ToSignedLongInteger( -( 1 ) ) ) ; 
                __context__.SourceCodeLine = 1131;
                FileClose (  (short) ( NFILEHANDLE1 ) ) ; 
                __context__.SourceCodeLine = 1132;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 1133;
                return ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1137;
                while ( Functions.TestForTrue  ( ( Functions.Not( FileEOF( (short)( NFILEHANDLE1 ) ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1139;
                    NCHARS = (short) ( FileRead( (short)( NFILEHANDLE1 ) , STIME , (ushort)( 5 ) ) ) ; 
                    __context__.SourceCodeLine = 1140;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NCHARS != 5))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1143;
                        FileClose (  (short) ( NFILEHANDLE1 ) ) ; 
                        __context__.SourceCodeLine = 1144;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1145;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1148;
                    ITIMEINFILE = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.Atoi( Functions.Left( STIME , (int)( 2 ) ) ) ) , (ushort)( Functions.Atoi( Functions.Mid( STIME , (int)( 4 ) , (int)( 2 ) ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 1150;
                    
                    __context__.SourceCodeLine = 1154;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIMEINFILE > INTTIME ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1156;
                        LFILEPOS1 = (int) ( (FileSeek( (short)( NFILEHANDLE1 ) , (uint)( 0 ) , (ushort)( 1 ) ) - 5) ) ; 
                        __context__.SourceCodeLine = 1157;
                        
                        __context__.SourceCodeLine = 1160;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 1164;
                    __context__.SourceCodeLine = 1167;
                    NERROR = (short) ( FileRead( (short)( NFILEHANDLE1 ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 1168;
                    INUMCKTS = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                    
                    __context__.SourceCodeLine = 1172;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NERROR < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1174;
                        GenerateUserError ( "MergeFiles ERROR. Cannot read number of dimmed circuits.\r\n") ; 
                        __context__.SourceCodeLine = 1175;
                        FileClose (  (short) ( NFILEHANDLE1 ) ) ; 
                        __context__.SourceCodeLine = 1176;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1177;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1180;
                    FileSeek (  (short) ( NFILEHANDLE1 ) ,  (uint) ( (INUMCKTS * 2) ) ,  (ushort) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 1183;
                    __context__.SourceCodeLine = 1188;
                    NERROR = (short) ( FileRead( (short)( NFILEHANDLE1 ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 1189;
                    INUMCKTS = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                    
                    __context__.SourceCodeLine = 1194;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NERROR < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1196;
                        GenerateUserError ( "MergeFiles ERROR. Cannot read number of switched circuits.\r\n") ; 
                        __context__.SourceCodeLine = 1197;
                        FileClose (  (short) ( NFILEHANDLE1 ) ) ; 
                        __context__.SourceCodeLine = 1198;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1199;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1202;
                    LFILEPOS1 = (int) ( FileSeek( (short)( NFILEHANDLE1 ) , (uint)( INUMCKTS ) , (ushort)( 1 ) ) ) ; 
                    __context__.SourceCodeLine = 1137;
                    } 
                
                __context__.SourceCodeLine = 1204;
                
                __context__.SourceCodeLine = 1207;
                LCURFILEPOS = (int) ( FileSeek( (short)( NFILEHANDLE1 ) , (uint)( 0 ) , (ushort)( 0 ) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 1214;
            NFILEHANDLE2 = (short) ( FileOpen( SRCFILE2 ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1216;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE2 < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1217;
                LFILEPOS2 = (int) ( Functions.ToSignedLongInteger( -( 1 ) ) ) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1220;
                while ( Functions.TestForTrue  ( ( Functions.Not( FileEOF( (short)( NFILEHANDLE2 ) ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1222;
                    NCHARS = (short) ( FileRead( (short)( NFILEHANDLE2 ) , STIME , (ushort)( 5 ) ) ) ; 
                    __context__.SourceCodeLine = 1223;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NCHARS != 5))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1226;
                        FileClose (  (short) ( NFILEHANDLE2 ) ) ; 
                        __context__.SourceCodeLine = 1227;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1228;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1231;
                    ITIMEINFILE = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.Atoi( Functions.Left( STIME , (int)( 2 ) ) ) ) , (ushort)( Functions.Atoi( Functions.Mid( STIME , (int)( 4 ) , (int)( 2 ) ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 1232;
                    
                    __context__.SourceCodeLine = 1236;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIMEINFILE <= INTTIME ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1238;
                        LFILEPOS2 = (int) ( (FileSeek( (short)( NFILEHANDLE2 ) , (uint)( 0 ) , (ushort)( 1 ) ) - 5) ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1242;
                        
                        __context__.SourceCodeLine = 1246;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FOUND2NDFILEPOS == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1248;
                            FOUND2NDFILEPOS = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1249;
                            LFILEPOS2 = (int) ( (FileSeek( (short)( NFILEHANDLE2 ) , (uint)( 0 ) , (ushort)( 1 ) ) - 5) ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1251;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 1256;
                    __context__.SourceCodeLine = 1259;
                    NERROR = (short) ( FileRead( (short)( NFILEHANDLE2 ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 1260;
                    INUMCKTS = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                    
                    __context__.SourceCodeLine = 1264;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NERROR < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1266;
                        GenerateUserError ( "MergeFiles ERROR. Cannot read number of dimmed circuits.\r\n") ; 
                        __context__.SourceCodeLine = 1267;
                        FileClose (  (short) ( NFILEHANDLE2 ) ) ; 
                        __context__.SourceCodeLine = 1268;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1269;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1272;
                    FileSeek (  (short) ( NFILEHANDLE2 ) ,  (uint) ( (INUMCKTS * 2) ) ,  (ushort) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 1275;
                    __context__.SourceCodeLine = 1278;
                    NERROR = (short) ( FileRead( (short)( NFILEHANDLE2 ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 1279;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NERROR > 0 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1280;
                        INUMCKTS = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                        }
                    
                    
                    __context__.SourceCodeLine = 1283;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NERROR < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1285;
                        GenerateUserError ( "MergeFiles ERROR. Cannot read number of switched circuits.\r\n") ; 
                        __context__.SourceCodeLine = 1286;
                        FileClose (  (short) ( NFILEHANDLE2 ) ) ; 
                        __context__.SourceCodeLine = 1287;
                        EndFileOperations ( ) ; 
                        __context__.SourceCodeLine = 1288;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 1291;
                    FileSeek (  (short) ( NFILEHANDLE2 ) ,  (uint) ( (INUMCKTS * 2) ) ,  (ushort) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 1220;
                    } 
                
                __context__.SourceCodeLine = 1293;
                FileSeek (  (short) ( NFILEHANDLE2 ) ,  (uint) ( LFILEPOS2 ) ,  (ushort) ( 0 ) ) ; 
                } 
            
            __context__.SourceCodeLine = 1296;
            NDESTHANDLE = (short) ( FileOpen( DESTFILE ,(ushort) (((1 | 512) | 256) | 16384) ) ) ; 
            __context__.SourceCodeLine = 1297;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1299;
                GenerateUserError ( "MergeFiles ERROR. Unable to create destination file {0}. Error = {1:d}\r\n", DESTFILE , (short)NDESTHANDLE) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1304;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LFILEPOS1 >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1306;
                    
                    __context__.SourceCodeLine = 1311;
                    do 
                        { 
                        __context__.SourceCodeLine = 1313;
                        IBLOCKSIZE = (ushort) ( LMIN( __context__ , (int)( 4096 ) , (int)( (LFILEPOS1 - LCURFILEPOS) ) ) ) ; 
                        __context__.SourceCodeLine = 1315;
                        
                        __context__.SourceCodeLine = 1319;
                        NCHARS = (short) ( FileRead( (short)( NFILEHANDLE1 ) , SDATA , (ushort)( IBLOCKSIZE ) ) ) ; 
                        __context__.SourceCodeLine = 1320;
                        NERROR = (short) ( FileWrite( (short)( NDESTHANDLE ) , SDATA , (ushort)( NCHARS ) ) ) ; 
                        __context__.SourceCodeLine = 1321;
                        LCURFILEPOS = (int) ( FileSeek( (short)( NFILEHANDLE1 ) , (uint)( 0 ) , (ushort)( 1 ) ) ) ; 
                        __context__.SourceCodeLine = 1323;
                        
                        } 
                    while (false == ( Functions.TestForTrue  ( Functions.BoolToInt ( LCURFILEPOS >= LFILEPOS1 )) )); 
                    } 
                
                __context__.SourceCodeLine = 1330;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LFILEPOS2 >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1332;
                    
                    __context__.SourceCodeLine = 1337;
                    IBLOCKSIZE = (ushort) ( 4096 ) ; 
                    __context__.SourceCodeLine = 1338;
                    while ( Functions.TestForTrue  ( ( Functions.Not( FileEOF( (short)( NFILEHANDLE2 ) ) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1340;
                        NCHARS = (short) ( FileRead( (short)( NFILEHANDLE2 ) , SDATA , (ushort)( IBLOCKSIZE ) ) ) ; 
                        __context__.SourceCodeLine = 1341;
                        NERROR = (short) ( FileWrite( (short)( NDESTHANDLE ) , SDATA , (ushort)( NCHARS ) ) ) ; 
                        __context__.SourceCodeLine = 1343;
                        
                        __context__.SourceCodeLine = 1338;
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 1351;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE1 >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1351;
                FileClose (  (short) ( NFILEHANDLE1 ) ) ; 
                }
            
            __context__.SourceCodeLine = 1352;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE2 >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1352;
                FileClose (  (short) ( NFILEHANDLE2 ) ) ; 
                }
            
            __context__.SourceCodeLine = 1353;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1353;
                FileClose (  (short) ( NDESTHANDLE ) ) ; 
                }
            
            __context__.SourceCodeLine = 1355;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1357;
            
            
            }
            
        private void COPYPREVIOUSVALUES (  SplusExecutionContext __context__, CrestronString SRCFILE , CrestronString DESTFILE , ushort ITIME ) 
            { 
            CrestronString SBUFFER;
            SBUFFER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            short NSRCHANDLE = 0;
            short NDESTHANDLE = 0;
            short NCHARS = 0;
            short NVALUE = 0;
            
            ushort ITIMEINFILE = 0;
            ushort I = 0;
            ushort J = 0;
            
            ushort INUMCKTSINFILE = 0;
            ushort INUMCKTSTOREAD = 0;
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
            
            ushort INUMWRITES = 0;
            
            CrestronString SCKTDATA;
            SCKTDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
            
            CrestronString TEMPINT;
            TEMPINT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            CrestronString TEMPINT2;
            TEMPINT2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            
            __context__.SourceCodeLine = 1386;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( SRCFILE ) == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( DESTFILE ) == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1388;
                GenerateUserError ( "CopyValues: invalid file names, Source='{0}', Dest='{1}'\r\n", SRCFILE , DESTFILE ) ; 
                __context__.SourceCodeLine = 1389;
                return ; 
                } 
            
            __context__.SourceCodeLine = 1393;
            
            __context__.SourceCodeLine = 1398;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1403;
            NSRCHANDLE = (short) ( FileOpen( SRCFILE ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 1410;
            NDESTHANDLE = (short) ( FileOpen( DESTFILE ,(ushort) (((1 | 512) | 256) | 16384) ) ) ; 
            __context__.SourceCodeLine = 1412;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1414;
                GenerateUserError ( "CopyValues: Cannot open or create file {0}. Error Code = {1:d}\r\n", DESTFILE , (short)NDESTHANDLE) ; 
                __context__.SourceCodeLine = 1415;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NSRCHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1417;
                    FileClose (  (short) ( NSRCHANDLE ) ) ; 
                    __context__.SourceCodeLine = 1418;
                    EndFileOperations ( ) ; 
                    __context__.SourceCodeLine = 1419;
                    return ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 1423;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( NSRCHANDLE >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( NDESTHANDLE >= 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (FileEOF( (short)( NSRCHANDLE ) ) == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1426;
                INUMWRITES = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1427;
                
                __context__.SourceCodeLine = 1431;
                NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , STIME , (ushort)( 5 ) ) ) ; 
                __context__.SourceCodeLine = 1432;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1433;
                    GenerateUserError ( "CopyValues: Could not read the time from {0}.\r\n", SRCFILE ) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 1436;
                    ITIMEINFILE = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.Atoi( Functions.Left( STIME , (int)( 2 ) ) ) ) , (ushort)( Functions.Atoi( Functions.Mid( STIME , (int)( 4 ) , (int)( 2 ) ) ) ) ) ) ; 
                    __context__.SourceCodeLine = 1437;
                    while ( Functions.TestForTrue  ( ( 1)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1439;
                        
                        __context__.SourceCodeLine = 1442;
                        INUMWRITES = (ushort) ( (INUMWRITES + 1) ) ; 
                        __context__.SourceCodeLine = 1446;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIMEINFILE >= ITIME ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1448;
                            
                            __context__.SourceCodeLine = 1451;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1455;
                        NCHARS = (short) ( FileWrite( (short)( NDESTHANDLE ) , STIME , (ushort)( 5 ) ) ) ; 
                        __context__.SourceCodeLine = 1456;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1458;
                            GenerateUserError ( "CopyValues: Could not save number of ckts at time {0}.\r\n", STIME ) ; 
                            __context__.SourceCodeLine = 1459;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1469;
                        __context__.SourceCodeLine = 1472;
                        NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                        __context__.SourceCodeLine = 1473;
                        INUMCKTSINFILE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                        
                        __context__.SourceCodeLine = 1476;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1478;
                            GenerateUserError ( "CopyValues: Error reading number of dim ckts at time {0}.\r\n", STIME ) ; 
                            __context__.SourceCodeLine = 1479;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1483;
                        INUMCKTSTOREAD = (ushort) ( Functions.Min( INUMCKTSINFILE , _SplusNVRAM.G_INUMBEROFDIMCKTS ) ) ; 
                        __context__.SourceCodeLine = 1485;
                        NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , SCKTDATA , (ushort)( (INUMCKTSTOREAD * 2) ) ) ) ; 
                        __context__.SourceCodeLine = 1486;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < (INUMCKTSTOREAD * 2) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1488;
                            GenerateUserError ( "CopyValues: Error reading dimmed circuit values. Expected {0:d}, read {1:d}\r\n", (short)INUMCKTSTOREAD, (short)(NCHARS / 2)) ; 
                            __context__.SourceCodeLine = 1489;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1493;
                        __context__.SourceCodeLine = 1496;
                        TEMPINT  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) INUMCKTSTOREAD ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) INUMCKTSTOREAD ) ) )  ) ; 
                        __context__.SourceCodeLine = 1497;
                        NCHARS = (short) ( FileWrite( (short)( NDESTHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                        
                        __context__.SourceCodeLine = 1500;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1502;
                            GenerateUserError ( "CopyValues: Could not save number of dim ckts at time {0}.\r\n", STIME ) ; 
                            __context__.SourceCodeLine = 1503;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1506;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INUMCKTSTOREAD > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1509;
                            NCHARS = (short) ( FileWrite( (short)( NDESTHANDLE ) , SCKTDATA , (ushort)( (INUMCKTSTOREAD * 2) ) ) ) ; 
                            __context__.SourceCodeLine = 1510;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < (INUMCKTSTOREAD * 2) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1512;
                                GenerateUserError ( "CopyValues: Could not save dim levels at time {0}. iNumCktsInFile = {1:d}, nChars = {2:d}\r\n", STIME , (short)INUMCKTSINFILE, (short)NCHARS) ; 
                                __context__.SourceCodeLine = 1513;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 1517;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INUMCKTSINFILE > INUMCKTSTOREAD ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1518;
                                FileSeek (  (short) ( NSRCHANDLE ) ,  (uint) ( (INUMCKTSINFILE - INUMCKTSTOREAD) ) ,  (ushort) ( 1 ) ) ; 
                                }
                            
                            } 
                        
                        __context__.SourceCodeLine = 1528;
                        __context__.SourceCodeLine = 1531;
                        NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                        __context__.SourceCodeLine = 1532;
                        INUMCKTSINFILE = (ushort) ( ((Byte( TEMPINT , (int)( 1 ) ) * 256) + Byte( TEMPINT , (int)( 2 ) )) ) ; 
                        
                        __context__.SourceCodeLine = 1535;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1537;
                            GenerateUserError ( "CopyValues: Error reading number of non-dim ckts at time {0}.\r\n", STIME ) ; 
                            __context__.SourceCodeLine = 1538;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1542;
                        INUMCKTSTOREAD = (ushort) ( Functions.Min( INUMCKTSINFILE , _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS ) ) ; 
                        __context__.SourceCodeLine = 1544;
                        NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , SCKTDATA , (ushort)( INUMCKTSTOREAD ) ) ) ; 
                        __context__.SourceCodeLine = 1545;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < INUMCKTSTOREAD ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1547;
                            GenerateUserError ( "CopyValues: Error reading non-dimmed circuit values. Expected {0:d}, read {1:d}\r\n", (short)INUMCKTSTOREAD, (short)NCHARS) ; 
                            __context__.SourceCodeLine = 1548;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1552;
                        __context__.SourceCodeLine = 1555;
                        TEMPINT  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) INUMCKTSTOREAD ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) INUMCKTSTOREAD ) ) )  ) ; 
                        __context__.SourceCodeLine = 1556;
                        NCHARS = (short) ( FileWrite( (short)( NDESTHANDLE ) , TEMPINT , (ushort)( 2 ) ) ) ; 
                        
                        __context__.SourceCodeLine = 1559;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1561;
                            GenerateUserError ( "CopyValues: Could not save number of non-dim ckts at time {0}.\r\n", STIME ) ; 
                            __context__.SourceCodeLine = 1562;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1565;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INUMCKTSTOREAD > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1567;
                            NCHARS = (short) ( FileWrite( (short)( NDESTHANDLE ) , SCKTDATA , (ushort)( INUMCKTSTOREAD ) ) ) ; 
                            __context__.SourceCodeLine = 1568;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS < INUMCKTSTOREAD ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1570;
                                GenerateUserError ( "CopyValues: Could not save non-dim levels at time {0}. iNumCktsInFile = {1:d}, nChars = {2:d}\r\n", STIME , (short)INUMCKTSINFILE, (short)NCHARS) ; 
                                __context__.SourceCodeLine = 1571;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 1574;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INUMCKTSINFILE > INUMCKTSTOREAD ))  ) ) 
                                {
                                __context__.SourceCodeLine = 1575;
                                FileSeek (  (short) ( NSRCHANDLE ) ,  (uint) ( (INUMCKTSINFILE - INUMCKTSTOREAD) ) ,  (ushort) ( 1 ) ) ; 
                                }
                            
                            } 
                        
                        __context__.SourceCodeLine = 1580;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FileEOF( (short)( NSRCHANDLE ) ) == 1))  ) ) 
                            {
                            __context__.SourceCodeLine = 1581;
                            break ; 
                            }
                        
                        __context__.SourceCodeLine = 1584;
                        NCHARS = (short) ( FileRead( (short)( NSRCHANDLE ) , STIME , (ushort)( 5 ) ) ) ; 
                        __context__.SourceCodeLine = 1586;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCHARS <= 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1587;
                            break ; 
                            }
                        
                        __context__.SourceCodeLine = 1588;
                        ITIMEINFILE = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.Atoi( Functions.Left( STIME , (int)( 2 ) ) ) ) , (ushort)( Functions.Atoi( Functions.Mid( STIME , (int)( 4 ) , (int)( 2 ) ) ) ) ) ) ; 
                        __context__.SourceCodeLine = 1437;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1592;
                
                } 
            
            __context__.SourceCodeLine = 1597;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NSRCHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1598;
                FileClose (  (short) ( NSRCHANDLE ) ) ; 
                }
            
            __context__.SourceCodeLine = 1599;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 1600;
                FileClose (  (short) ( NDESTHANDLE ) ) ; 
                }
            
            __context__.SourceCodeLine = 1602;
            EndFileOperations ( ) ; 
            
            }
            
        private void INCREMENTDAYANDWEEK (  SplusExecutionContext __context__, ref ushort IDAYOFCYCLE , ref ushort IWEEKOFCYCLE , ushort IWEEKLIMIT ) 
            { 
            
            __context__.SourceCodeLine = 1618;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWEEKLIMIT != 2))  ) ) 
                {
                __context__.SourceCodeLine = 1619;
                IWEEKLIMIT = (ushort) ( 1 ) ; 
                }
            
            __context__.SourceCodeLine = 1621;
            IDAYOFCYCLE = (ushort) ( (IDAYOFCYCLE + 1) ) ; 
            __context__.SourceCodeLine = 1622;
            IWEEKOFCYCLE = (ushort) ( (((IDAYOFCYCLE - 1) / 7) + 1) ) ; 
            __context__.SourceCodeLine = 1625;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IDAYOFCYCLE > (7 * IWEEKLIMIT) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1627;
                IDAYOFCYCLE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1628;
                IWEEKOFCYCLE = (ushort) ( 1 ) ; 
                } 
            
            
            }
            
        private void MAKEFILENAME (  SplusExecutionContext __context__, ref CrestronString FILENAME , ushort DAYOFWEEK , ushort WEEKOFCYCLE ) 
            { 
            
            __context__.SourceCodeLine = 1643;
            MakeString ( FILENAME , "{0}\\learn{1:d}w{2:d}.dat", PATH__DOLLAR__ , (short)DAYOFWEEK, (short)WEEKOFCYCLE) ; 
            
            }
            
        private ushort GETRECORDINGCYCLEINWEEKS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 1648;
            if ( Functions.TestForTrue  ( ( RECORD2WKPERIOD  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 1649;
                return (ushort)( 2) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1651;
                return (ushort)( 1) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort SETMODE (  SplusExecutionContext __context__, ushort IMODE ) 
            { 
            short IFILEHANDLE = 0;
            
            CrestronString SMODEFILENAME;
            SMODEFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1666;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMODE < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( IMODE > 2 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1668;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_MODE  .Value < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( CURRENT_MODE  .Value > 2 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1669;
                    IMODE = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1671;
                    IMODE = (ushort) ( CURRENT_MODE  .Value ) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1674;
            CURRENT_MODE  .Value = (ushort) ( IMODE ) ; 
            __context__.SourceCodeLine = 1678;
            MakeString ( SMODEFILENAME , "{0}\\{1}", PATH__DOLLAR__ , "learn_mode.dat" ) ; 
            __context__.SourceCodeLine = 1680;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1682;
            IFILEHANDLE = (short) ( FileOpen( SMODEFILENAME ,(ushort) (((32768 | 256) | 1) | 512) ) ) ; 
            __context__.SourceCodeLine = 1683;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1685;
                GenerateUserError ( "ERROR: Cannot open/create mode file '{0}'\r\n", SMODEFILENAME ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1689;
                FileWrite (  (short) ( IFILEHANDLE ) , Functions.Chr (  (int) ( CURRENT_MODE  .Value ) ) ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1690;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                } 
            
            __context__.SourceCodeLine = 1693;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1695;
            return (ushort)( CURRENT_MODE  .Value) ; 
            
            }
            
        private ushort GETMODEFROMFILE (  SplusExecutionContext __context__ ) 
            { 
            ushort IMODE = 0;
            
            short IFILEHANDLE = 0;
            
            CrestronString SMODEFILENAME;
            SMODEFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            CrestronString SMODE;
            SMODE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 1713;
            MakeString ( SMODEFILENAME , "{0}\\{1}", PATH__DOLLAR__ , "learn_mode.dat" ) ; 
            __context__.SourceCodeLine = 1715;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 1717;
            IFILEHANDLE = (short) ( FileOpen( SMODEFILENAME ,(ushort) (32768 | 0) ) ) ; 
            __context__.SourceCodeLine = 1718;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1721;
                IMODE = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1725;
                FileRead (  (short) ( IFILEHANDLE ) , SMODE ,  (ushort) ( 1 ) ) ; 
                __context__.SourceCodeLine = 1726;
                FileClose (  (short) ( IFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 1727;
                IMODE = (ushort) ( Byte( SMODE , (int)( 1 ) ) ) ; 
                __context__.SourceCodeLine = 1729;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IMODE < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( IMODE > 2 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1730;
                    IMODE = (ushort) ( 1 ) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 1734;
            EndFileOperations ( ) ; 
            __context__.SourceCodeLine = 1736;
            return (ushort)( IMODE) ; 
            
            }
            
        private ushort GETPLAYBACKFILE (  SplusExecutionContext __context__, ushort IWEEKOFCYCLE ) 
            { 
            ushort IDAYTOTRY = 0;
            ushort IDAYOFWEEK = 0;
            
            ushort BFOUNDFILE = 0;
            
            
            __context__.SourceCodeLine = 1757;
            BFOUNDFILE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1760;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEEXISTS( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 1762;
                IDAYOFWEEK = (ushort) ( (Functions.GetDayOfWeekNum() + 1) ) ; 
                __context__.SourceCodeLine = 1763;
                BFOUNDFILE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1766;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IWEEKOFCYCLE == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1768;
                    MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( IDAYOFWEEK ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1769;
                    
                    __context__.SourceCodeLine = 1772;
                    if ( Functions.TestForTrue  ( ( FILEEXISTS( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1773;
                        BFOUNDFILE = (ushort) ( 1 ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1777;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BFOUNDFILE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1779;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDAYOFWEEK == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 1780;
                        IDAYTOTRY = (ushort) ( 7 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1781;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDAYOFWEEK == 7))  ) ) 
                            {
                            __context__.SourceCodeLine = 1782;
                            IDAYTOTRY = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1783;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDAYOFWEEK == 2))  ) ) 
                                {
                                __context__.SourceCodeLine = 1784;
                                IDAYTOTRY = (ushort) ( 3 ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1786;
                                IDAYTOTRY = (ushort) ( 2 ) ; 
                                }
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 1788;
                    MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( IDAYTOTRY ), (ushort)( 1 )) ; 
                    __context__.SourceCodeLine = 1789;
                    
                    __context__.SourceCodeLine = 1792;
                    if ( Functions.TestForTrue  ( ( FILEEXISTS( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1793;
                        BFOUNDFILE = (ushort) ( 1 ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 1797;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BFOUNDFILE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1799;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)7; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( IDAYTOTRY  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IDAYTOTRY  >= __FN_FORSTART_VAL__1) && (IDAYTOTRY  <= __FN_FOREND_VAL__1) ) : ( (IDAYTOTRY  <= __FN_FORSTART_VAL__1) && (IDAYTOTRY  >= __FN_FOREND_VAL__1) ) ; IDAYTOTRY  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1801;
                        MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( IDAYTOTRY ), (ushort)( 1 )) ; 
                        __context__.SourceCodeLine = 1802;
                        
                        __context__.SourceCodeLine = 1805;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FILEEXISTS( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME ) == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1807;
                            BFOUNDFILE = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 1808;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 1799;
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 1813;
            return (ushort)( BFOUNDFILE) ; 
            
            }
            
        private void CHANGEOFDAYFUNCTIONS (  SplusExecutionContext __context__ ) 
            { 
            short NDESTHANDLE = 0;
            
            ushort ITIMEINFILE = 0;
            
            ushort BFOUNDFILE = 0;
            
            ushort IWEEKOFCYCLE = 0;
            ushort IDAYTOTRY = 0;
            
            ushort ICURRENTTIME = 0;
            
            
            __context__.SourceCodeLine = 1836;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_MODE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 1838;
                
                __context__.SourceCodeLine = 1842;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 1844;
                FileDelete ( _SplusNVRAM.G_SPERMANENTFILENAME ) ; 
                __context__.SourceCodeLine = 1846;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 1849;
                FILECOPY (  __context__ , _SplusNVRAM.G_STEMPFILENAME, _SplusNVRAM.G_SPERMANENTFILENAME) ; 
                __context__.SourceCodeLine = 1851;
                INCREMENTDAYANDWEEK (  __context__ ,   ref  _SplusNVRAM.G_IDAYOFCYCLEBEINGRECORDED ,   ref  IWEEKOFCYCLE , (ushort)( GETRECORDINGCYCLEINWEEKS( __context__ ) )) ; 
                __context__.SourceCodeLine = 1852;
                MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( (Functions.GetDayOfWeekNum() + 1) ), (ushort)( IWEEKOFCYCLE )) ; 
                __context__.SourceCodeLine = 1854;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 1856;
                NDESTHANDLE = (short) ( FileOpen( _SplusNVRAM.G_STEMPFILENAME ,(ushort) (((1 | 256) | 512) | 16384) ) ) ; 
                __context__.SourceCodeLine = 1857;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDESTHANDLE < 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1858;
                    GenerateUserError ( "Cannot create file {0}.\r\n", _SplusNVRAM.G_STEMPFILENAME ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1860;
                    FileClose (  (short) ( NDESTHANDLE ) ) ; 
                    }
                
                __context__.SourceCodeLine = 1861;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 1863;
                _SplusNVRAM.G_ITIMEWHENRECORDED = (ushort) ( 0 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1866;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_MODE  .Value == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1868;
                    
                    __context__.SourceCodeLine = 1873;
                    INCREMENTDAYANDWEEK (  __context__ ,   ref  _SplusNVRAM.G_IDAYOFCYCLEBEINGPLAYEDBACK ,   ref  IWEEKOFCYCLE , (ushort)( GETRECORDINGCYCLEINWEEKS( __context__ ) )) ; 
                    __context__.SourceCodeLine = 1874;
                    MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( (Functions.GetDayOfWeekNum() + 1) ), (ushort)( IWEEKOFCYCLE )) ; 
                    __context__.SourceCodeLine = 1876;
                    BFOUNDFILE = (ushort) ( GETPLAYBACKFILE( __context__ , (ushort)( IWEEKOFCYCLE ) ) ) ; 
                    __context__.SourceCodeLine = 1877;
                    ICURRENTTIME = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.GetHourNum() ) , (ushort)( Functions.GetMinutesNum() ) ) ) ; 
                    __context__.SourceCodeLine = 1878;
                    _SplusNVRAM.G_INEXTPLAYBACKSOURCE = (ushort) ( GETNEXTPLAYBACKTIME( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME , ref _SplusNVRAM.G_LPERMANENTFILEPOSITION , (ushort)( ICURRENTTIME ) , ref _SplusNVRAM.G_ITIMETOPLAYBACK ) ) ; 
                    } 
                
                }
            
            
            }
            
        private void INITSETTINGSFIRSTTIME (  SplusExecutionContext __context__ ) 
            { 
            short NDESTHANDLE = 0;
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 1895;
            
            __context__.SourceCodeLine = 1898;
            _SplusNVRAM.G_IDAYOFCYCLEBEINGRECORDED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1899;
            _SplusNVRAM.G_IDAYOFCYCLEBEINGPLAYEDBACK = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1901;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.G_IENTERMODE == Functions.ToSignedLongInteger( -( 1 ) )))  ) ) 
                {
                __context__.SourceCodeLine = 1902;
                _SplusNVRAM.G_IENTERMODE = (short) ( 1 ) ; 
                }
            
            
            }
            
        private void _STOP (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SMERGEDFILE;
            SMERGEDFILE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 1917;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_MODE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 1919;
                MakeString ( SMERGEDFILE , "{0}\\learn_temp.dat", PATH__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1920;
                _SplusNVRAM.G_ITIMEWHENRECORDED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1924;
                
                __context__.SourceCodeLine = 1927;
                MERGEFILES (  __context__ , _SplusNVRAM.G_STEMPFILENAME, _SplusNVRAM.G_SPERMANENTFILENAME, (ushort)( GETTIMEINMINUTES( __context__ , (ushort)( Functions.GetHourNum() ) , (ushort)( Functions.GetMinutesNum() ) ) ), SMERGEDFILE) ; 
                __context__.SourceCodeLine = 1930;
                FILECOPY (  __context__ , SMERGEDFILE, _SplusNVRAM.G_SPERMANENTFILENAME) ; 
                __context__.SourceCodeLine = 1932;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 1933;
                FileDelete ( SMERGEDFILE ) ; 
                __context__.SourceCodeLine = 1934;
                FileDelete ( _SplusNVRAM.G_STEMPFILENAME ) ; 
                __context__.SourceCodeLine = 1935;
                EndFileOperations ( ) ; 
                } 
            
            __context__.SourceCodeLine = 1938;
            SETMODE (  __context__ , (ushort)( 0 )) ; 
            
            }
            
        private void _RECORD (  SplusExecutionContext __context__ ) 
            { 
            ushort ICURRENTTIME = 0;
            
            short NDESTHANDLE = 0;
            
            
            __context__.SourceCodeLine = 1954;
            _STOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1956;
            SETMODE (  __context__ , (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1957;
            _SplusNVRAM.G_IDAYOFCYCLEBEINGRECORDED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1958;
            MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( (Functions.GetDayOfWeekNum() + 1) ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1959;
            _SplusNVRAM.G_ITIMEWHENRECORDED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1963;
            
            __context__.SourceCodeLine = 1966;
            ICURRENTTIME = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.GetHourNum() ) , (ushort)( Functions.GetMinutesNum() ) ) ) ; 
            __context__.SourceCodeLine = 1967;
            COPYPREVIOUSVALUES (  __context__ , _SplusNVRAM.G_SPERMANENTFILENAME, _SplusNVRAM.G_STEMPFILENAME, (ushort)( ICURRENTTIME )) ; 
            
            }
            
        private void _PLAY (  SplusExecutionContext __context__ ) 
            { 
            ushort BFOUNDFILE = 0;
            
            ushort ICURRENTTIME = 0;
            
            
            __context__.SourceCodeLine = 1984;
            _STOP (  __context__  ) ; 
            __context__.SourceCodeLine = 1986;
            _SplusNVRAM.G_IDAYOFCYCLEBEINGPLAYEDBACK = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1987;
            MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( (Functions.GetDayOfWeekNum() + 1) ), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 1989;
            
            __context__.SourceCodeLine = 1994;
            BFOUNDFILE = (ushort) ( GETPLAYBACKFILE( __context__ , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 1995;
            ICURRENTTIME = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.GetHourNum() ) , (ushort)( Functions.GetMinutesNum() ) ) ) ; 
            __context__.SourceCodeLine = 1996;
            _SplusNVRAM.G_INEXTPLAYBACKSOURCE = (ushort) ( GETNEXTPLAYBACKTIME( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME , ref _SplusNVRAM.G_LPERMANENTFILEPOSITION , (ushort)( ICURRENTTIME ) , ref _SplusNVRAM.G_ITIMETOPLAYBACK ) ) ; 
            __context__.SourceCodeLine = 1997;
            SETMODE (  __context__ , (ushort)( 2 )) ; 
            
            }
            
        object INITONETIME_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 2005;
                INITSETTINGSFIRSTTIME (  __context__  ) ; 
                __context__.SourceCodeLine = 2007;
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object STARTRECORDING_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 2014;
            
            __context__.SourceCodeLine = 2018;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.G_SEMAPHORE)  ) ) 
                {
                __context__.SourceCodeLine = 2019;
                return  this ; 
                }
            
            __context__.SourceCodeLine = 2020;
            _SplusNVRAM.G_SEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 2021;
            _RECORD (  __context__  ) ; 
            __context__.SourceCodeLine = 2022;
            _SplusNVRAM.G_IENTERMODE = (short) ( 1 ) ; 
            __context__.SourceCodeLine = 2023;
            _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object STARTPLAYBACK_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2028;
        
        __context__.SourceCodeLine = 2031;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.G_SEMAPHORE)  ) ) 
            {
            __context__.SourceCodeLine = 2032;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2033;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2034;
        _PLAY (  __context__  ) ; 
        __context__.SourceCodeLine = 2035;
        _SplusNVRAM.G_IENTERMODE = (short) ( 2 ) ; 
        __context__.SourceCodeLine = 2036;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOP_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2041;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.G_SEMAPHORE)  ) ) 
            {
            __context__.SourceCodeLine = 2042;
            return  this ; 
            }
        
        __context__.SourceCodeLine = 2043;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2044;
        _STOP (  __context__  ) ; 
        __context__.SourceCodeLine = 2045;
        _SplusNVRAM.G_IENTERMODE = (short) ( 0 ) ; 
        __context__.SourceCodeLine = 2046;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RECORDINGINTERVALINMINUTES_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 2053;
        if ( Functions.TestForTrue  ( ( SETRECORDINTERVAL( __context__ , (ushort)( RECORDINGINTERVALINMINUTES  .UshortValue ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2054;
            GenerateUserError ( "Illegal recording interval {0:d}.\r\n", (short)RECORDINGINTERVALINMINUTES  .UshortValue) ; 
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
        FILE_INFO FI;
        FI  = new FILE_INFO();
        FI .PopulateDefaults();
        
        short IRESULT = 0;
        
        
        __context__.SourceCodeLine = 2065;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Right( PATH__DOLLAR__ , (int)( 1 ) ) == "\\"))  ) ) 
            { 
            __context__.SourceCodeLine = 2068;
            PATH__DOLLAR__  .UpdateValue ( Functions.Left ( PATH__DOLLAR__ ,  (int) ( (Functions.Length( PATH__DOLLAR__ ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 2065;
            } 
        
        __context__.SourceCodeLine = 2072;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PATH__DOLLAR__ == "\\NVRAM"))  ) ) 
            {
            __context__.SourceCodeLine = 2073;
            ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 2076;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 2078;
            IRESULT = (short) ( FindFirst( PATH__DOLLAR__ , ref FI ) ) ; 
            __context__.SourceCodeLine = 2080;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IRESULT < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 2082;
                IRESULT = (short) ( MakeDirectory( PATH__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 2083;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IRESULT != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 2084;
                    GenerateUserError ( "ERROR: Unable to create directory: {0}\r\nError={1:d}\r\n", PATH__DOLLAR__ , (short)IRESULT) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 2086;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.IsDirectory( FI ) == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2088;
                    GenerateUserError ( "ERROR: '{0}' is not a valid path name\r\n", PATH__DOLLAR__ ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 2091;
            EndFileOperations ( ) ; 
            } 
        
        __context__.SourceCodeLine = 2094;
        MakeString ( _SplusNVRAM.G_STEMPFILENAME , "{0}\\learn_0.dat", PATH__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 2095;
        MAKEFILENAME (  __context__ ,   ref  _SplusNVRAM.G_SPERMANENTFILENAME , (ushort)( (Functions.GetDayOfWeekNum() + 1) ), (ushort)( 1 )) ; 
        __context__.SourceCodeLine = 2097;
        G_BINITIALIZING = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort BDIDCHANGEOFDAY = 0;
    
    ushort ISECONDSPASTMINUTE = 0;
    ushort IWAITTIME = 0;
    ushort ICURRENTTIME = 0;
    ushort ISECONDS = 0;
    
    ushort INEXTTIMETOPLAYBACK = 0;
    
    ushort I = 0;
    
    short ITIMEGAP = 0;
    short ITIMEUNTILNEXTPLAYBACK = 0;
    short IELAPSEDTIME = 0;
    
    ushort BUSERANDOMLEVELS = 0;
    
    ushort ITIMETOPLAYBACKFROMFILE = 0;
    
    CrestronString SCURRENTDATE;
    CrestronString SLASTPROCESSEDDATE;
    SCURRENTDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    SLASTPROCESSEDDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 2117;
        G_BINITIALIZING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 2118;
        _SplusNVRAM.G_SEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2120;
        _SplusNVRAM.G_IENTERMODE = (short) ( Functions.ToSignedInteger( -( 1 ) ) ) ; 
        __context__.SourceCodeLine = 2122;
        SETRECORDINTERVAL (  __context__ , (ushort)( 15 )) ; 
        __context__.SourceCodeLine = 2125;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 500 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 2127;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( DIMLEVELS[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 2129;
                break ; 
                } 
            
            __context__.SourceCodeLine = 2125;
            } 
        
        __context__.SourceCodeLine = 2132;
        _SplusNVRAM.G_INUMBEROFDIMCKTS = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 2135;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 500 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)1; 
        int __FN_FORSTEP_VAL__2 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 2137;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( SWITCHEDLEVELS[ I ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 2139;
                break ; 
                } 
            
            __context__.SourceCodeLine = 2135;
            } 
        
        __context__.SourceCodeLine = 2142;
        _SplusNVRAM.G_INUMBEROFSWITCHEDCKTS = (ushort) ( I ) ; 
        __context__.SourceCodeLine = 2144;
        _SplusNVRAM.G_LZEROLONG = (uint) ( 0 ) ; 
        __context__.SourceCodeLine = 2145;
        BDIDCHANGEOFDAY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2146;
        _SplusNVRAM.G_ITIMEWHENRECORDED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2147;
        G_IFILEOPERATIONS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 2150;
        while ( Functions.TestForTrue  ( ( G_BINITIALIZING)  ) ) 
            { 
            __context__.SourceCodeLine = 2152;
            Functions.Delay (  (int) ( 100 ) ) ; 
            __context__.SourceCodeLine = 2150;
            } 
        
        __context__.SourceCodeLine = 2155;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 2158;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.G_IENTERMODE > Functions.ToSignedLongInteger( -( 1 ) ) ))  ) ) 
            {
            __context__.SourceCodeLine = 2159;
            CURRENT_MODE  .Value = (ushort) ( _SplusNVRAM.G_IENTERMODE ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 2161;
            CURRENT_MODE  .Value = (ushort) ( GETMODEFROMFILE( __context__ ) ) ; 
            }
        
        __context__.SourceCodeLine = 2163;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)CURRENT_MODE  .Value);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2165;
                    _RECORD (  __context__  ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2166;
                    _PLAY (  __context__  ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                    {
                    __context__.SourceCodeLine = 2167;
                    _STOP (  __context__  ) ; 
                    }
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 2170;
        ISECONDSPASTMINUTE = (ushort) ( Functions.GetSecondsNum() ) ; 
        __context__.SourceCodeLine = 2171;
        SLASTPROCESSEDDATE  .UpdateValue ( Functions.Date (  (int) ( 1 ) )  ) ; 
        __context__.SourceCodeLine = 2173;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 2176;
            IWAITTIME = (ushort) ( ((61 - ISECONDSPASTMINUTE) * 100) ) ; 
            __context__.SourceCodeLine = 2177;
            Functions.Delay (  (int) ( IWAITTIME ) ) ; 
            __context__.SourceCodeLine = 2178;
            ICURRENTTIME = (ushort) ( GETTIMEINMINUTES( __context__ , (ushort)( Functions.GetHourNum() ) , (ushort)( Functions.GetMinutesNum() ) ) ) ; 
            __context__.SourceCodeLine = 2179;
            SCURRENTDATE  .UpdateValue ( Functions.Date (  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 2185;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SCURRENTDATE != SLASTPROCESSEDDATE))  ) ) 
                { 
                __context__.SourceCodeLine = 2187;
                CHANGEOFDAYFUNCTIONS (  __context__  ) ; 
                __context__.SourceCodeLine = 2188;
                BDIDCHANGEOFDAY = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 2192;
                BDIDCHANGEOFDAY = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 2195;
            SLASTPROCESSEDDATE  .UpdateValue ( SCURRENTDATE  ) ; 
            __context__.SourceCodeLine = 2206;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_MODE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 2209;
                IELAPSEDTIME = (short) ( (ICURRENTTIME - _SplusNVRAM.G_ITIMEWHENRECORDED) ) ; 
                __context__.SourceCodeLine = 2210;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IELAPSEDTIME >= GETRECORDINTERVAL( __context__ ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2212;
                    SAVEVALUESTOFILE (  __context__ , _SplusNVRAM.G_STEMPFILENAME, (ushort)( ICURRENTTIME )) ; 
                    __context__.SourceCodeLine = 2214;
                    _SplusNVRAM.G_ITIMEWHENRECORDED = (ushort) ( ICURRENTTIME ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 2227;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENT_MODE  .Value == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 2230;
                    ITIMEUNTILNEXTPLAYBACK = (short) ( (_SplusNVRAM.G_ITIMETOPLAYBACK - ICURRENTTIME) ) ; 
                    __context__.SourceCodeLine = 2232;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIMEUNTILNEXTPLAYBACK <= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 2235;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.G_INEXTPLAYBACKSOURCE == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 2236;
                            GETRANDOMLIGHTLEVELS (  __context__ , (ushort)( ICURRENTTIME )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 2238;
                            READVALUESFROMFILE (  __context__ , _SplusNVRAM.G_SPERMANENTFILENAME, (uint)( _SplusNVRAM.G_LPERMANENTFILEPOSITION )) ; 
                            }
                        
                        __context__.SourceCodeLine = 2241;
                        COPYSAVEDLIGHTVALUESTOOUTPUTS (  __context__  ) ; 
                        __context__.SourceCodeLine = 2243;
                        _SplusNVRAM.G_INEXTPLAYBACKSOURCE = (ushort) ( GETNEXTPLAYBACKTIME( __context__ , _SplusNVRAM.G_SPERMANENTFILENAME , ref _SplusNVRAM.G_LPERMANENTFILEPOSITION , (ushort)( ICURRENTTIME ) , ref _SplusNVRAM.G_ITIMETOPLAYBACK ) ) ; 
                        } 
                    
                    } 
                
                }
            
            __context__.SourceCodeLine = 2246;
            ISECONDSPASTMINUTE = (ushort) ( Functions.GetSecondsNum() ) ; 
            __context__.SourceCodeLine = 2173;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.G_LDIMLEVELSTOPLAYBACK  = new int[ 501 ];
    _SplusNVRAM.G_LSWITCHEDLEVELSTOPLAYBACK  = new int[ 501 ];
    _SplusNVRAM.G_STEMPFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    _SplusNVRAM.G_SPERMANENTFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    
    INITONETIME = new Crestron.Logos.SplusObjects.DigitalInput( INITONETIME__DigitalInput__, this );
    m_DigitalInputList.Add( INITONETIME__DigitalInput__, INITONETIME );
    
    STARTRECORDING = new Crestron.Logos.SplusObjects.DigitalInput( STARTRECORDING__DigitalInput__, this );
    m_DigitalInputList.Add( STARTRECORDING__DigitalInput__, STARTRECORDING );
    
    STARTPLAYBACK = new Crestron.Logos.SplusObjects.DigitalInput( STARTPLAYBACK__DigitalInput__, this );
    m_DigitalInputList.Add( STARTPLAYBACK__DigitalInput__, STARTPLAYBACK );
    
    STOP = new Crestron.Logos.SplusObjects.DigitalInput( STOP__DigitalInput__, this );
    m_DigitalInputList.Add( STOP__DigitalInput__, STOP );
    
    RECORD2WKPERIOD = new Crestron.Logos.SplusObjects.DigitalInput( RECORD2WKPERIOD__DigitalInput__, this );
    m_DigitalInputList.Add( RECORD2WKPERIOD__DigitalInput__, RECORD2WKPERIOD );
    
    DONTCOPYDATAFROMSAVEDFILE = new Crestron.Logos.SplusObjects.DigitalInput( DONTCOPYDATAFROMSAVEDFILE__DigitalInput__, this );
    m_DigitalInputList.Add( DONTCOPYDATAFROMSAVEDFILE__DigitalInput__, DONTCOPYDATAFROMSAVEDFILE );
    
    VARYPLAYBACK = new Crestron.Logos.SplusObjects.DigitalInput( VARYPLAYBACK__DigitalInput__, this );
    m_DigitalInputList.Add( VARYPLAYBACK__DigitalInput__, VARYPLAYBACK );
    
    SWITCHEDLEVELS = new InOutArray<DigitalInput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        SWITCHEDLEVELS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHEDLEVELS__DigitalInput__ + i, SWITCHEDLEVELS__DigitalInput__, this );
        m_DigitalInputList.Add( SWITCHEDLEVELS__DigitalInput__ + i, SWITCHEDLEVELS[i+1] );
    }
    
    PLAYBACKSWITCHEDLEVELS = new InOutArray<DigitalOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        PLAYBACKSWITCHEDLEVELS[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PLAYBACKSWITCHEDLEVELS__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PLAYBACKSWITCHEDLEVELS__DigitalOutput__ + i, PLAYBACKSWITCHEDLEVELS[i+1] );
    }
    
    RECORDINGINTERVALINMINUTES = new Crestron.Logos.SplusObjects.AnalogInput( RECORDINGINTERVALINMINUTES__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RECORDINGINTERVALINMINUTES__AnalogSerialInput__, RECORDINGINTERVALINMINUTES );
    
    DIMLEVELS = new InOutArray<AnalogInput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        DIMLEVELS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DIMLEVELS__AnalogSerialInput__ + i, DIMLEVELS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( DIMLEVELS__AnalogSerialInput__ + i, DIMLEVELS[i+1] );
    }
    
    CURRENT_MODE = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENT_MODE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENT_MODE__AnalogSerialOutput__, CURRENT_MODE );
    
    PLAYBACKDIMLEVELS = new InOutArray<AnalogOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        PLAYBACKDIMLEVELS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( PLAYBACKDIMLEVELS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( PLAYBACKDIMLEVELS__AnalogSerialOutput__ + i, PLAYBACKDIMLEVELS[i+1] );
    }
    
    PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 128, this );
    m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
    
    SCALEBACKFACTOR = new UShortParameter( SCALEBACKFACTOR__Parameter__, this );
    m_ParameterList.Add( SCALEBACKFACTOR__Parameter__, SCALEBACKFACTOR );
    
    
    INITONETIME.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITONETIME_OnPush_0, false ) );
    STARTRECORDING.OnDigitalPush.Add( new InputChangeHandlerWrapper( STARTRECORDING_OnPush_1, false ) );
    STARTPLAYBACK.OnDigitalPush.Add( new InputChangeHandlerWrapper( STARTPLAYBACK_OnPush_2, false ) );
    STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOP_OnPush_3, false ) );
    RECORDINGINTERVALINMINUTES.OnAnalogChange.Add( new InputChangeHandlerWrapper( RECORDINGINTERVALINMINUTES_OnChange_4, false ) );
    PATH__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( PATH__DOLLAR___OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_LEARNING_SCHEDULER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITONETIME__DigitalInput__ = 0;
const uint STARTRECORDING__DigitalInput__ = 1;
const uint STARTPLAYBACK__DigitalInput__ = 2;
const uint STOP__DigitalInput__ = 3;
const uint RECORD2WKPERIOD__DigitalInput__ = 4;
const uint DONTCOPYDATAFROMSAVEDFILE__DigitalInput__ = 5;
const uint VARYPLAYBACK__DigitalInput__ = 6;
const uint SWITCHEDLEVELS__DigitalInput__ = 7;
const uint PLAYBACKSWITCHEDLEVELS__DigitalOutput__ = 0;
const uint PATH__DOLLAR____AnalogSerialInput__ = 0;
const uint RECORDINGINTERVALINMINUTES__AnalogSerialInput__ = 1;
const uint DIMLEVELS__AnalogSerialInput__ = 2;
const uint CURRENT_MODE__AnalogSerialOutput__ = 0;
const uint PLAYBACKDIMLEVELS__AnalogSerialOutput__ = 1;
const uint SCALEBACKFACTOR__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort G_IDAYOFCYCLEBEINGRECORDED = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort G_IDAYOFCYCLEBEINGPLAYEDBACK = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort G_SEMAPHORE = 0;
            [SplusStructAttribute(3, false, true)]
            public CrestronString G_STEMPFILENAME;
            [SplusStructAttribute(4, false, true)]
            public CrestronString G_SPERMANENTFILENAME;
            [SplusStructAttribute(5, false, true)]
            public uint G_LPERMANENTFILEPOSITION = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort G_ISAVEDRECORDINGINTERVALINMINUTES = 0;
            [SplusStructAttribute(7, false, true)]
            public int [] G_LDIMLEVELSTOPLAYBACK;
            [SplusStructAttribute(8, false, true)]
            public int [] G_LSWITCHEDLEVELSTOPLAYBACK;
            [SplusStructAttribute(9, false, true)]
            public ushort G_INUMBEROFDIMCKTS = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort G_INUMBEROFSWITCHEDCKTS = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort G_ITIMEWHENRECORDED = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort G_ITIMETOPLAYBACK = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort G_INEXTPLAYBACKSOURCE = 0;
            [SplusStructAttribute(14, false, true)]
            public short G_IENTERMODE = 0;
            [SplusStructAttribute(15, false, true)]
            public uint G_LZEROLONG = 0;
            
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
