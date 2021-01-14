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

namespace UserModule_INTEGRA_DTR_60_6_IP_V1_0_PROCESSOR
{
    public class UserModuleClass_INTEGRA_DTR_60_6_IP_V1_0_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_DONE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TUNER_KEY;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_IN;
        Crestron.Logos.SplusObjects.AnalogInput SELECTED_TUNER;
        Crestron.Logos.SplusObjects.BufferInput TUNER_COMMAND__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput VOLUME_COMMAND__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput TUNER_FREQUENCY_IN;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_FB;
        Crestron.Logos.SplusObjects.StringOutput TUNER_FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE__DOLLAR__;
        ushort IVOLCHANGING = 0;
        ushort IVOLCOUNTER = 0;
        short IVOL = 0;
        CrestronString SFREQ;
        CrestronString STUNER;
        CrestronString SVOLUME;
        CrestronString SFREQIN;
        CrestronString STEMP;
        object TUNER_KEY_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort ITEMP = 0;
                
                
                __context__.SourceCodeLine = 67;
                ITEMP = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != 100))  ) ) 
                    { 
                    __context__.SourceCodeLine = 70;
                    switch ((int)SELECTED_TUNER  .UshortValue)
                    
                        { 
                        case 1 : 
                        
                            { 
                            __context__.SourceCodeLine = 74;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP >= 10 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 76;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 10))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 78;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) < 5 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 80;
                                        MakeString ( SFREQ , "{0}0", SFREQ ) ; 
                                        __context__.SourceCodeLine = 81;
                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} kHz", SFREQ ) ; 
                                        __context__.SourceCodeLine = 82;
                                        ITEMP = (ushort) ( 100 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 86;
                                        ITEMP = (ushort) ( 100 ) ; 
                                        } 
                                    
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 89;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 11))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 91;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 93;
                                            SFREQ  .UpdateValue ( Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) )  ) ; 
                                            __context__.SourceCodeLine = 94;
                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} kHz", SFREQ ) ; 
                                            __context__.SourceCodeLine = 95;
                                            ITEMP = (ushort) ( 100 ) ; 
                                            } 
                                        
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 98;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 12))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 100;
                                            SFREQ  .UpdateValue ( ""  ) ; 
                                            __context__.SourceCodeLine = 101;
                                            TUNER_FREQUENCY__DOLLAR__  .UpdateValue ( SFREQIN  ) ; 
                                            __context__.SourceCodeLine = 102;
                                            ITEMP = (ushort) ( 100 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 104;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 13))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 106;
                                                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) < 5 ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 108;
                                                    SFREQ  .UpdateValue ( "0" + SFREQ  ) ; 
                                                    __context__.SourceCodeLine = 106;
                                                    } 
                                                
                                                __context__.SourceCodeLine = 110;
                                                MakeString ( STEMP , "{0}{1}\r", STUNER , SFREQ ) ; 
                                                __context__.SourceCodeLine = 111;
                                                MakeString ( TO_DEVICE__DOLLAR__ , "{0}{1}{2}{3}", "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000" , Functions.Chr (  (int) ( Functions.Length( STEMP ) ) ) , "\u0001\u0000\u0000\u0000" , STEMP ) ; 
                                                __context__.SourceCodeLine = 112;
                                                SFREQ  .UpdateValue ( ""  ) ; 
                                                __context__.SourceCodeLine = 113;
                                                ITEMP = (ushort) ( 100 ) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 118;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) < 5 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 120;
                                    MakeString ( SFREQ , "{0}{1:d}", SFREQ , (short)ITEMP) ; 
                                    __context__.SourceCodeLine = 121;
                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} kHz", SFREQ ) ; 
                                    __context__.SourceCodeLine = 122;
                                    ITEMP = (ushort) ( 100 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 126;
                                    ITEMP = (ushort) ( 100 ) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 129;
                            break ; 
                            } 
                        
                        goto case 2 ;
                        case 2 : 
                        
                            { 
                            __context__.SourceCodeLine = 133;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP >= 10 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 135;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 10))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 137;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) < 5 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 139;
                                        MakeString ( SFREQ , "{0}0", SFREQ ) ; 
                                        __context__.SourceCodeLine = 140;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 5))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 142;
                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 144;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 4))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 146;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 148;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                                    } 
                                                
                                                else 
                                                    { 
                                                    __context__.SourceCodeLine = 152;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                    } 
                                                
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 155;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 3))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 157;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 159;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                        } 
                                                    
                                                    else 
                                                        { 
                                                        __context__.SourceCodeLine = 163;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                        } 
                                                    
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 166;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 2))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 168;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                        } 
                                                    
                                                    else 
                                                        { 
                                                        __context__.SourceCodeLine = 172;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                        } 
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        __context__.SourceCodeLine = 174;
                                        ITEMP = (ushort) ( 100 ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 178;
                                        ITEMP = (ushort) ( 100 ) ; 
                                        } 
                                    
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 181;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 11))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 183;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 185;
                                            SFREQ  .UpdateValue ( Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) )  ) ; 
                                            __context__.SourceCodeLine = 186;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 5))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 188;
                                                MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 190;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 4))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 192;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 194;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                                        } 
                                                    
                                                    else 
                                                        { 
                                                        __context__.SourceCodeLine = 198;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                        } 
                                                    
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 201;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 3))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 203;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 205;
                                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 209;
                                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                            } 
                                                        
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 212;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 2))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 214;
                                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 218;
                                                            MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                            } 
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            __context__.SourceCodeLine = 220;
                                            ITEMP = (ushort) ( 100 ) ; 
                                            } 
                                        
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 223;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 12))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 225;
                                            SFREQ  .UpdateValue ( ""  ) ; 
                                            __context__.SourceCodeLine = 226;
                                            TUNER_FREQUENCY__DOLLAR__  .UpdateValue ( SFREQIN  ) ; 
                                            __context__.SourceCodeLine = 227;
                                            ITEMP = (ushort) ( 100 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 229;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP == 13))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 231;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 3))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 233;
                                                    SFREQ  .UpdateValue ( "0" + SFREQ + "0"  ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 235;
                                                    if ( Functions.TestForTrue  ( ( (Functions.BoolToInt (Functions.Length( SFREQ ) == 4) & Functions.BoolToInt (Byte( SFREQ , (int)( 4 ) ) != 48)))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 237;
                                                        SFREQ  .UpdateValue ( SFREQ + "0"  ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 239;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 4))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 241;
                                                            SFREQ  .UpdateValue ( "0" + SFREQ  ) ; 
                                                            } 
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                __context__.SourceCodeLine = 243;
                                                MakeString ( STEMP , "{0}{1}\r", STUNER , SFREQ ) ; 
                                                __context__.SourceCodeLine = 244;
                                                MakeString ( TO_DEVICE__DOLLAR__ , "{0}{1}{2}{3}", "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000" , Functions.Chr (  (int) ( Functions.Length( STEMP ) ) ) , "\u0001\u0000\u0000\u0000" , STEMP ) ; 
                                                __context__.SourceCodeLine = 246;
                                                SFREQ  .UpdateValue ( ""  ) ; 
                                                __context__.SourceCodeLine = 247;
                                                ITEMP = (ushort) ( 100 ) ; 
                                                } 
                                            
                                            else 
                                                { 
                                                __context__.SourceCodeLine = 251;
                                                ITEMP = (ushort) ( 100 ) ; 
                                                } 
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 256;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SFREQ ) < 5 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 258;
                                    MakeString ( SFREQ , "{0}{1:d}", SFREQ , (short)ITEMP) ; 
                                    __context__.SourceCodeLine = 259;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 5))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 261;
                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 263;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 4))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 265;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 267;
                                                MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 2) ) ) , Functions.Right ( SFREQ ,  (int) ( 2 ) ) ) ; 
                                                } 
                                            
                                            else 
                                                { 
                                                __context__.SourceCodeLine = 271;
                                                MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                } 
                                            
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 274;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 3))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 276;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 56) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( SFREQ , (int)( 1 ) ) == 57) )) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 278;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( SFREQ ,  (int) ( (Functions.Length( SFREQ ) - 1) ) ) , Functions.Right ( SFREQ ,  (int) ( 1 ) ) ) ; 
                                                    } 
                                                
                                                else 
                                                    { 
                                                    __context__.SourceCodeLine = 282;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                    } 
                                                
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 285;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 2))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 287;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                    } 
                                                
                                                else 
                                                    { 
                                                    __context__.SourceCodeLine = 291;
                                                    MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} MHz", SFREQ ) ; 
                                                    } 
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 293;
                                    ITEMP = (ushort) ( 100 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 297;
                                    ITEMP = (ushort) ( 100 ) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 300;
                            break ; 
                            } 
                        
                        goto default;
                        default : 
                        
                            { 
                            __context__.SourceCodeLine = 304;
                            ITEMP = (ushort) ( 100 ) ; 
                            __context__.SourceCodeLine = 305;
                            break ; 
                            } 
                        break;
                        
                        } 
                        
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object VOLUME_UP_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 313;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOL < 100 ))  ) ) 
                { 
                __context__.SourceCodeLine = 315;
                IVOLCHANGING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 316;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOLCOUNTER >= 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 318;
                    IVOL = (short) ( (IVOL + 2) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 322;
                    IVOLCOUNTER = (ushort) ( (IVOLCOUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 323;
                    IVOL = (short) ( (IVOL + 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 326;
                
                __context__.SourceCodeLine = 332;
                __context__.SourceCodeLine = 333;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOL > 100 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 335;
                    IVOL = (short) ( 100 ) ; 
                    } 
                
                
                __context__.SourceCodeLine = 338;
                VOLUME_FB  .Value = (ushort) ( IVOL ) ; 
                __context__.SourceCodeLine = 339;
                MakeString ( STEMP , "{0}{1:X2}\r", SVOLUME , IVOL) ; 
                __context__.SourceCodeLine = 340;
                MakeString ( TO_DEVICE__DOLLAR__ , "{0}{1}{2}{3}", "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000" , Functions.Chr (  (int) ( Functions.Length( STEMP ) ) ) , "\u0001\u0000\u0000\u0000" , STEMP ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object VOLUME_DOWN_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 347;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 349;
            IVOLCHANGING = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 350;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOLCOUNTER >= 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 352;
                IVOL = (short) ( (IVOL - 2) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 356;
                IVOLCOUNTER = (ushort) ( (IVOLCOUNTER + 1) ) ; 
                __context__.SourceCodeLine = 357;
                IVOL = (short) ( (IVOL - 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 359;
            
            __context__.SourceCodeLine = 365;
            __context__.SourceCodeLine = 366;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVOL < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 368;
                IVOL = (short) ( 0 ) ; 
                } 
            
            
            __context__.SourceCodeLine = 371;
            VOLUME_FB  .Value = (ushort) ( IVOL ) ; 
            __context__.SourceCodeLine = 372;
            MakeString ( STEMP , "{0}{1:X2}\r", SVOLUME , IVOL) ; 
            __context__.SourceCodeLine = 373;
            MakeString ( TO_DEVICE__DOLLAR__ , "{0}{1}{2}{3}", "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000" , Functions.Chr (  (int) ( Functions.Length( STEMP ) ) ) , "\u0001\u0000\u0000\u0000" , STEMP ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_DONE_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 380;
        IVOLCHANGING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 381;
        IVOLCOUNTER = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_IN_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 386;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_IN  .UshortValue <= 100 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_IN  .UshortValue >= 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (IVOLCHANGING == 0) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (VOLUME_IN  .UshortValue != IVOL) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 388;
            IVOL = (short) ( VOLUME_IN  .ShortValue ) ; 
            __context__.SourceCodeLine = 389;
            VOLUME_FB  .Value = (ushort) ( IVOL ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TUNER_COMMAND__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 395;
        STUNER  .UpdateValue ( TUNER_COMMAND__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_COMMAND__DOLLAR___OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 400;
        SVOLUME  .UpdateValue ( VOLUME_COMMAND__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TUNER_FREQUENCY_IN_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 405;
        SFREQIN  .UpdateValue ( TUNER_FREQUENCY_IN  ) ; 
        __context__.SourceCodeLine = 406;
        Functions.ClearBuffer ( TUNER_FREQUENCY_IN ) ; 
        __context__.SourceCodeLine = 407;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SFREQ ) == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 409;
            TUNER_FREQUENCY__DOLLAR__  .UpdateValue ( SFREQIN  ) ; 
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
        
        __context__.SourceCodeLine = 419;
        IVOLCHANGING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 420;
        IVOLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 421;
        IVOL = (short) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SFREQ  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    STUNER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    SVOLUME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    SFREQIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_UP__DigitalInput__, VOLUME_UP );
    
    VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_DOWN__DigitalInput__, VOLUME_DOWN );
    
    VOLUME_DONE = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_DONE__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_DONE__DigitalInput__, VOLUME_DONE );
    
    TUNER_KEY = new InOutArray<DigitalInput>( 13, this );
    for( uint i = 0; i < 13; i++ )
    {
        TUNER_KEY[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TUNER_KEY__DigitalInput__ + i, TUNER_KEY__DigitalInput__, this );
        m_DigitalInputList.Add( TUNER_KEY__DigitalInput__ + i, TUNER_KEY[i+1] );
    }
    
    VOLUME_IN = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_IN__AnalogSerialInput__, VOLUME_IN );
    
    SELECTED_TUNER = new Crestron.Logos.SplusObjects.AnalogInput( SELECTED_TUNER__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTED_TUNER__AnalogSerialInput__, SELECTED_TUNER );
    
    VOLUME_FB = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_FB__AnalogSerialOutput__, VOLUME_FB );
    
    TUNER_FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__, TUNER_FREQUENCY__DOLLAR__ );
    
    TO_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__DOLLAR____AnalogSerialOutput__, TO_DEVICE__DOLLAR__ );
    
    TUNER_COMMAND__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( TUNER_COMMAND__DOLLAR____AnalogSerialInput__, 6, this );
    m_StringInputList.Add( TUNER_COMMAND__DOLLAR____AnalogSerialInput__, TUNER_COMMAND__DOLLAR__ );
    
    VOLUME_COMMAND__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( VOLUME_COMMAND__DOLLAR____AnalogSerialInput__, 6, this );
    m_StringInputList.Add( VOLUME_COMMAND__DOLLAR____AnalogSerialInput__, VOLUME_COMMAND__DOLLAR__ );
    
    TUNER_FREQUENCY_IN = new Crestron.Logos.SplusObjects.BufferInput( TUNER_FREQUENCY_IN__AnalogSerialInput__, 10, this );
    m_StringInputList.Add( TUNER_FREQUENCY_IN__AnalogSerialInput__, TUNER_FREQUENCY_IN );
    
    
    for( uint i = 0; i < 13; i++ )
        TUNER_KEY[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TUNER_KEY_OnPush_0, false ) );
        
    VOLUME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_UP_OnPush_1, false ) );
    VOLUME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_DOWN_OnPush_2, false ) );
    VOLUME_DONE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( VOLUME_DONE_OnRelease_3, false ) );
    VOLUME_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_IN_OnChange_4, false ) );
    TUNER_COMMAND__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TUNER_COMMAND__DOLLAR___OnChange_5, false ) );
    VOLUME_COMMAND__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( VOLUME_COMMAND__DOLLAR___OnChange_6, false ) );
    TUNER_FREQUENCY_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( TUNER_FREQUENCY_IN_OnChange_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_INTEGRA_DTR_60_6_IP_V1_0_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint VOLUME_UP__DigitalInput__ = 0;
const uint VOLUME_DOWN__DigitalInput__ = 1;
const uint VOLUME_DONE__DigitalInput__ = 2;
const uint TUNER_KEY__DigitalInput__ = 3;
const uint VOLUME_IN__AnalogSerialInput__ = 0;
const uint SELECTED_TUNER__AnalogSerialInput__ = 1;
const uint TUNER_COMMAND__DOLLAR____AnalogSerialInput__ = 2;
const uint VOLUME_COMMAND__DOLLAR____AnalogSerialInput__ = 3;
const uint TUNER_FREQUENCY_IN__AnalogSerialInput__ = 4;
const uint VOLUME_FB__AnalogSerialOutput__ = 0;
const uint TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__ = 1;
const uint TO_DEVICE__DOLLAR____AnalogSerialOutput__ = 2;

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
