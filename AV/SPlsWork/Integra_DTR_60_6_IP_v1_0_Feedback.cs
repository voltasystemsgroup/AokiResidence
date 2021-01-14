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

namespace UserModule_INTEGRA_DTR_60_6_IP_V1_0_FEEDBACK
{
    public class UserModuleClass_INTEGRA_DTR_60_6_IP_V1_0_FEEDBACK : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput NET_FF_REW_PUSHED;
        Crestron.Logos.SplusObjects.DigitalInput SEND_KEYBOARD;
        Crestron.Logos.SplusObjects.DigitalInput PROCESS_FROM_DEVICE;
        Crestron.Logos.SplusObjects.AnalogInput TUNER_BAND_IN;
        Crestron.Logos.SplusObjects.AnalogInput DELIMITER_TYPE;
        Crestron.Logos.SplusObjects.StringInput KEYBOARD_INPUT_TEXT;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BUTTON_1_HIGHLIGHTED;
        Crestron.Logos.SplusObjects.DigitalOutput BUTTON_2_HIGHLIGHTED;
        Crestron.Logos.SplusObjects.AnalogOutput SLEEP_TIME;
        Crestron.Logos.SplusObjects.AnalogOutput MAIN_VOLUME_IN;
        Crestron.Logos.SplusObjects.AnalogOutput ZONE_2_VOLUME_IN;
        Crestron.Logos.SplusObjects.AnalogOutput ZONE_3_VOLUME_IN;
        Crestron.Logos.SplusObjects.AnalogOutput ZONE_4_VOLUME_IN;
        Crestron.Logos.SplusObjects.StringOutput TUNER_FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TUNER_ZONE_FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TUNER_ZONE_3_FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TUNER_ZONE_4_FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_ARTIST__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_ALBUM__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_TITLE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_TIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_PLAY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_REPEAT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_SHUFFLE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput NAT_TRACK__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput POPUP_TYPE_VALUE;
        Crestron.Logos.SplusObjects.StringOutput TOP_TITLE_TEXT;
        Crestron.Logos.SplusObjects.StringOutput POPUP_TITLE_TEXT;
        Crestron.Logos.SplusObjects.StringOutput POPUP_MESSAGE_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_1_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_1_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_2_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_2_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_3_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_3_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_4_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_4_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_5_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_5_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_TITLE_6_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ITEM_PARAMETER_6_TEXT;
        Crestron.Logos.SplusObjects.StringOutput BUTTON_1_TEXT;
        Crestron.Logos.SplusObjects.StringOutput BUTTON_2_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> NET_CURSOR_POSITION_LINE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> NET_LINE_TEXT;
        ushort ITEMP = 0;
        ushort ISLEEP = 0;
        ushort IFLAG1 = 0;
        ushort A = 0;
        ushort IVOL = 0;
        ushort IVOL2 = 0;
        ushort IVOL3 = 0;
        ushort ITEMP1 = 0;
        ushort IVOL4 = 0;
        ushort ICURSORPOSITION = 0;
        ushort ITEMP2 = 0;
        ushort ITEMP3 = 0;
        ushort INETDELAY = 0;
        ushort IWAITING = 0;
        ushort IMARKER1 = 0;
        ushort IMARKER2 = 0;
        ushort IMARKER3 = 0;
        ushort IMARKER4 = 0;
        ushort IMARKER5 = 0;
        ushort IMARKER6 = 0;
        ushort IMARKER7 = 0;
        ushort IMARKER8 = 0;
        ushort IMARKER9 = 0;
        ushort IMARKER10 = 0;
        ushort IMARKER11 = 0;
        ushort IMARKER12 = 0;
        ushort IMARKER13 = 0;
        ushort IMARKER14 = 0;
        ushort IMARKER15 = 0;
        ushort ICURSOR = 0;
        ushort ICURSORPOINTER = 0;
        ushort ISEMAPHORE = 0;
        CrestronString STEMP;
        CrestronString STEMP1;
        CrestronString STUNER;
        CrestronString STUNERZONE;
        CrestronString STUNER3;
        CrestronString STUNER4;
        CrestronString [] SLINETEXT;
        CrestronString SNATARTIST;
        CrestronString SNATALBUM;
        CrestronString SNATTITLE;
        CrestronString SNATTIME;
        CrestronString SNATPLAY;
        CrestronString SNATREPEAT;
        CrestronString SNATSHUFFLE;
        CrestronString SNATTRACK;
        CrestronString STEMPCMD;
        CrestronString SDISPLAYTYPE;
        CrestronString STEMP2;
        CrestronString SDELIMITER;
        object SEND_KEYBOARD_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 105;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( KEYBOARD_INPUT_TEXT ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (IWAITING == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 107;
                    MakeString ( STEMPCMD , "{0}{1}\r", "!1NKY" , Functions.Left ( KEYBOARD_INPUT_TEXT ,  (int) ( 128 ) ) ) ; 
                    __context__.SourceCodeLine = 108;
                    MakeString ( TO_DEVICE__DOLLAR__ , "{0}{1}{2}{3}", "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000" , Functions.Chr (  (int) ( Functions.Length( STEMPCMD ) ) ) , "\u0001\u0000\u0000\u0000" , STEMPCMD ) ; 
                    __context__.SourceCodeLine = 109;
                    IWAITING = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object NET_FF_REW_PUSHED_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 115;
            CreateWait ( "WNETDELAY" , 500 , WNETDELAY_Callback ) ;
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public void WNETDELAY_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 117;
            INETDELAY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 118;
            NAT_PLAY__DOLLAR__  .UpdateValue ( SNATPLAY  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object NET_FF_REW_PUSHED_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 124;
        CancelWait ( "WNETDELAY" ) ; 
        __context__.SourceCodeLine = 125;
        INETDELAY = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 130;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISEMAPHORE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 132;
            ISEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 134;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 136;
                STEMP  .UpdateValue ( Functions.Gather ( "\u001A\u000D\u000A" , FROM_DEVICE__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 137;
                STEMP  .UpdateValue ( Functions.Right ( STEMP ,  (int) ( (Functions.Length( STEMP ) - Functions.Length( "ISCP\u0000\u0000\u0000\u0010\u0000\u0000\u0000\u0000\u0001\u0000\u0000\u0000" )) ) )  ) ; 
                __context__.SourceCodeLine = 138;
                STEMP  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                __context__.SourceCodeLine = 139;
                if ( Functions.TestForTrue  ( ( Functions.Length( STEMP ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 141;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NJA" , STEMP ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 143;
                        STEMP1  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 144;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 146;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1SLP" , STEMP ) > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 148;
                            ITEMP1 = (ushort) ( Functions.Find( "!1SLP" , STEMP ) ) ; 
                            __context__.SourceCodeLine = 149;
                            STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1SLP" ) + ITEMP1) ) ,  (int) ( 2 ) )  ) ; 
                            __context__.SourceCodeLine = 150;
                            ITEMP = (ushort) ( Functions.HextoI( STEMP1 ) ) ; 
                            __context__.SourceCodeLine = 151;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != ISLEEP))  ) ) 
                                { 
                                __context__.SourceCodeLine = 153;
                                ISLEEP = (ushort) ( ITEMP ) ; 
                                __context__.SourceCodeLine = 154;
                                SLEEP_TIME  .Value = (ushort) ( ISLEEP ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 156;
                            STEMP1  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 157;
                            STEMP  .UpdateValue ( ""  ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 159;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1MVL" , STEMP ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 161;
                                ITEMP1 = (ushort) ( Functions.Find( "!1MVL" , STEMP ) ) ; 
                                __context__.SourceCodeLine = 162;
                                STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1MVL" ) + ITEMP1) ) ,  (int) ( 2 ) )  ) ; 
                                __context__.SourceCodeLine = 163;
                                ITEMP = (ushort) ( Functions.HextoI( STEMP1 ) ) ; 
                                __context__.SourceCodeLine = 164;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != IVOL))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 166;
                                    IVOL = (ushort) ( ITEMP ) ; 
                                    __context__.SourceCodeLine = 167;
                                    MAIN_VOLUME_IN  .Value = (ushort) ( IVOL ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 169;
                                STEMP1  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 170;
                                STEMP  .UpdateValue ( ""  ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 172;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1ZVL" , STEMP ) > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 174;
                                    ITEMP1 = (ushort) ( Functions.Find( "!1ZVL" , STEMP ) ) ; 
                                    __context__.SourceCodeLine = 175;
                                    STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1ZVL" ) + ITEMP1) ) ,  (int) ( 2 ) )  ) ; 
                                    __context__.SourceCodeLine = 176;
                                    ITEMP = (ushort) ( Functions.HextoI( STEMP1 ) ) ; 
                                    __context__.SourceCodeLine = 177;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != IVOL2))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 179;
                                        IVOL2 = (ushort) ( ITEMP ) ; 
                                        __context__.SourceCodeLine = 180;
                                        ZONE_2_VOLUME_IN  .Value = (ushort) ( IVOL2 ) ; 
                                        } 
                                    
                                    __context__.SourceCodeLine = 182;
                                    STEMP1  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 183;
                                    STEMP  .UpdateValue ( ""  ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 185;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1VL3" , STEMP ) > 0 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 187;
                                        ITEMP1 = (ushort) ( Functions.Find( "!1VL3" , STEMP ) ) ; 
                                        __context__.SourceCodeLine = 188;
                                        STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1VL3" ) + ITEMP1) ) ,  (int) ( 2 ) )  ) ; 
                                        __context__.SourceCodeLine = 189;
                                        ITEMP = (ushort) ( Functions.HextoI( STEMP1 ) ) ; 
                                        __context__.SourceCodeLine = 190;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != IVOL3))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 192;
                                            IVOL3 = (ushort) ( ITEMP ) ; 
                                            __context__.SourceCodeLine = 193;
                                            ZONE_3_VOLUME_IN  .Value = (ushort) ( IVOL3 ) ; 
                                            } 
                                        
                                        __context__.SourceCodeLine = 195;
                                        STEMP1  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 196;
                                        STEMP  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 198;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1VL4" , STEMP ) > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 200;
                                            ITEMP1 = (ushort) ( Functions.Find( "!1VL4" , STEMP ) ) ; 
                                            __context__.SourceCodeLine = 201;
                                            STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1VL4" ) + ITEMP1) ) ,  (int) ( 2 ) )  ) ; 
                                            __context__.SourceCodeLine = 202;
                                            ITEMP = (ushort) ( Functions.HextoI( STEMP1 ) ) ; 
                                            __context__.SourceCodeLine = 203;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEMP != IVOL4))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 205;
                                                IVOL4 = (ushort) ( ITEMP ) ; 
                                                __context__.SourceCodeLine = 206;
                                                ZONE_4_VOLUME_IN  .Value = (ushort) ( IVOL4 ) ; 
                                                } 
                                            
                                            __context__.SourceCodeLine = 208;
                                            STEMP1  .UpdateValue ( ""  ) ; 
                                            __context__.SourceCodeLine = 209;
                                            STEMP  .UpdateValue ( ""  ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 211;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1TUN" , STEMP ) > 0 ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 213;
                                                ITEMP1 = (ushort) ( Functions.Find( "!1TUN" , STEMP ) ) ; 
                                                __context__.SourceCodeLine = 214;
                                                STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1TUN" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1TUN" )) - ITEMP1) ) )  ) ; 
                                                __context__.SourceCodeLine = 215;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STUNER != STEMP1))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 217;
                                                    MakeString ( STUNER , "{0:d}", (short)Functions.Atoi( STEMP1 )) ; 
                                                    __context__.SourceCodeLine = 218;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TUNER_BAND_IN  .UshortValue == 1))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 220;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( STUNER ,  (int) ( (Functions.Length( STUNER ) - 2) ) ) , Functions.Right ( STUNER ,  (int) ( 2 ) ) ) ; 
                                                        } 
                                                    
                                                    else 
                                                        { 
                                                        __context__.SourceCodeLine = 224;
                                                        MakeString ( TUNER_FREQUENCY__DOLLAR__ , "{0} kHz", STUNER ) ; 
                                                        } 
                                                    
                                                    } 
                                                
                                                __context__.SourceCodeLine = 227;
                                                STEMP1  .UpdateValue ( ""  ) ; 
                                                __context__.SourceCodeLine = 228;
                                                STEMP  .UpdateValue ( ""  ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 230;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1TUZ" , STEMP ) > 0 ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 232;
                                                    ITEMP1 = (ushort) ( Functions.Find( "!1TUZ" , STEMP ) ) ; 
                                                    __context__.SourceCodeLine = 233;
                                                    STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1TUZ" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1TUZ" )) - ITEMP1) ) )  ) ; 
                                                    __context__.SourceCodeLine = 234;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STUNERZONE != STEMP1))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 236;
                                                        MakeString ( STUNERZONE , "{0:d}", (short)Functions.Atoi( STEMP1 )) ; 
                                                        __context__.SourceCodeLine = 237;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TUNER_BAND_IN  .UshortValue == 1))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 239;
                                                            MakeString ( TUNER_ZONE_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( STUNERZONE ,  (int) ( (Functions.Length( STUNERZONE ) - 2) ) ) , Functions.Right ( STUNERZONE ,  (int) ( 2 ) ) ) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 243;
                                                            MakeString ( TUNER_ZONE_FREQUENCY__DOLLAR__ , "{0} kHz", STUNERZONE ) ; 
                                                            } 
                                                        
                                                        } 
                                                    
                                                    __context__.SourceCodeLine = 246;
                                                    STEMP1  .UpdateValue ( ""  ) ; 
                                                    __context__.SourceCodeLine = 247;
                                                    STEMP  .UpdateValue ( ""  ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 249;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1TU3" , STEMP ) > 0 ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 251;
                                                        ITEMP1 = (ushort) ( Functions.Find( "!1TU3" , STEMP ) ) ; 
                                                        __context__.SourceCodeLine = 252;
                                                        STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1TU3" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1TU3" )) - ITEMP1) ) )  ) ; 
                                                        __context__.SourceCodeLine = 253;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STUNER3 != STEMP1))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 255;
                                                            MakeString ( STUNER3 , "{0:d}", (short)Functions.Atoi( STEMP1 )) ; 
                                                            __context__.SourceCodeLine = 256;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TUNER_BAND_IN  .UshortValue == 1))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 258;
                                                                MakeString ( TUNER_ZONE_3_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( STUNER3 ,  (int) ( (Functions.Length( STUNER3 ) - 2) ) ) , Functions.Right ( STUNER3 ,  (int) ( 2 ) ) ) ; 
                                                                } 
                                                            
                                                            else 
                                                                { 
                                                                __context__.SourceCodeLine = 262;
                                                                MakeString ( TUNER_ZONE_3_FREQUENCY__DOLLAR__ , "{0} kHz", STUNER3 ) ; 
                                                                } 
                                                            
                                                            } 
                                                        
                                                        __context__.SourceCodeLine = 265;
                                                        STEMP1  .UpdateValue ( ""  ) ; 
                                                        __context__.SourceCodeLine = 266;
                                                        STEMP  .UpdateValue ( ""  ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 268;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1TU4" , STEMP ) > 0 ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 270;
                                                            ITEMP1 = (ushort) ( Functions.Find( "!1TU4" , STEMP ) ) ; 
                                                            __context__.SourceCodeLine = 271;
                                                            STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1TU4" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1TU4" )) - ITEMP1) ) )  ) ; 
                                                            __context__.SourceCodeLine = 272;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STUNER4 != STEMP1))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 274;
                                                                MakeString ( STUNER4 , "{0:d}", (short)Functions.Atoi( STEMP1 )) ; 
                                                                __context__.SourceCodeLine = 275;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TUNER_BAND_IN  .UshortValue == 1))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 277;
                                                                    MakeString ( TUNER_ZONE_4_FREQUENCY__DOLLAR__ , "{0}.{1} MHz", Functions.Left ( STUNER4 ,  (int) ( (Functions.Length( STUNER4 ) - 2) ) ) , Functions.Right ( STUNER4 ,  (int) ( 2 ) ) ) ; 
                                                                    } 
                                                                
                                                                else 
                                                                    { 
                                                                    __context__.SourceCodeLine = 281;
                                                                    MakeString ( TUNER_ZONE_4_FREQUENCY__DOLLAR__ , "{0} kHz", STUNER4 ) ; 
                                                                    } 
                                                                
                                                                } 
                                                            
                                                            __context__.SourceCodeLine = 284;
                                                            STEMP1  .UpdateValue ( ""  ) ; 
                                                            __context__.SourceCodeLine = 285;
                                                            STEMP  .UpdateValue ( ""  ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 287;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NLSA" , STEMP ) > 0 ))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 289;
                                                                ITEMP1 = (ushort) ( Functions.Find( "!1NLSA" , STEMP ) ) ; 
                                                                __context__.SourceCodeLine = 290;
                                                                ITEMP2 = (ushort) ( (Functions.Atoi( Functions.Mid( STEMP , (int)( (ITEMP1 + 2) ) , (int)( 8 ) ) ) + 1) ) ; 
                                                                __context__.SourceCodeLine = 291;
                                                                ITEMP3 = (ushort) ( Functions.Find( "\u001A" , STEMP ) ) ; 
                                                                __context__.SourceCodeLine = 292;
                                                                STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 9 ) ,  (int) ( (ITEMP3 - 9) ) )  ) ; 
                                                                __context__.SourceCodeLine = 293;
                                                                IMARKER1 = (ushort) ( 0 ) ; 
                                                                __context__.SourceCodeLine = 294;
                                                                IMARKER1 = (ushort) ( Functions.Find( "\u0000" , STEMP1 ) ) ; 
                                                                __context__.SourceCodeLine = 295;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMARKER1 > 0 ))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 297;
                                                                    STEMP1  .UpdateValue ( Functions.Left ( STEMP1 ,  (int) ( (IMARKER1 - 1) ) )  ) ; 
                                                                    __context__.SourceCodeLine = 298;
                                                                    IMARKER1 = (ushort) ( 0 ) ; 
                                                                    } 
                                                                
                                                                __context__.SourceCodeLine = 300;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SLINETEXT[ ITEMP2 ] != STEMP1))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 302;
                                                                    SLINETEXT [ ITEMP2 ]  .UpdateValue ( STEMP1  ) ; 
                                                                    __context__.SourceCodeLine = 303;
                                                                    NET_LINE_TEXT [ ITEMP2]  .UpdateValue ( SLINETEXT [ ITEMP2 ]  ) ; 
                                                                    } 
                                                                
                                                                } 
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 306;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NLSU" , STEMP ) > 0 ))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 308;
                                                                    ITEMP1 = (ushort) ( Functions.Find( "!1NLSU" , STEMP ) ) ; 
                                                                    __context__.SourceCodeLine = 309;
                                                                    ITEMP2 = (ushort) ( (Functions.Atoi( Functions.Mid( STEMP , (int)( (ITEMP1 + 2) ) , (int)( 5 ) ) ) + 1) ) ; 
                                                                    __context__.SourceCodeLine = 310;
                                                                    ITEMP3 = (ushort) ( Functions.Find( "\u001A" , STEMP ) ) ; 
                                                                    __context__.SourceCodeLine = 311;
                                                                    STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 9 ) ,  (int) ( (ITEMP3 - 9) ) )  ) ; 
                                                                    __context__.SourceCodeLine = 312;
                                                                    IMARKER1 = (ushort) ( 0 ) ; 
                                                                    __context__.SourceCodeLine = 313;
                                                                    IMARKER1 = (ushort) ( Functions.Find( "\u0000" , STEMP1 ) ) ; 
                                                                    __context__.SourceCodeLine = 314;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IMARKER1 > 0 ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 316;
                                                                        STEMP1  .UpdateValue ( Functions.Left ( STEMP1 ,  (int) ( (IMARKER1 - 1) ) )  ) ; 
                                                                        __context__.SourceCodeLine = 317;
                                                                        IMARKER1 = (ushort) ( 0 ) ; 
                                                                        } 
                                                                    
                                                                    __context__.SourceCodeLine = 319;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SLINETEXT[ ITEMP2 ] != STEMP1))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 321;
                                                                        SLINETEXT [ ITEMP2 ]  .UpdateValue ( STEMP1  ) ; 
                                                                        __context__.SourceCodeLine = 322;
                                                                        NET_LINE_TEXT [ ITEMP2]  .UpdateValue ( SLINETEXT [ ITEMP2 ]  ) ; 
                                                                        } 
                                                                    
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 325;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NLSC" , STEMP ) > 0 ))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 327;
                                                                        ITEMP1 = (ushort) ( Functions.Find( "!1NLSC" , STEMP ) ) ; 
                                                                        __context__.SourceCodeLine = 328;
                                                                        ITEMP2 = (ushort) ( (Functions.Atoi( Functions.Mid( STEMP , (int)( (ITEMP1 + 2) ) , (int)( 8 ) ) ) + 1) ) ; 
                                                                        __context__.SourceCodeLine = 329;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STEMP , (int)( 7 ) , (int)( 1 ) ) == "-"))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 331;
                                                                            ITEMP2 = (ushort) ( 0 ) ; 
                                                                            } 
                                                                        
                                                                        __context__.SourceCodeLine = 333;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICURSORPOSITION != ITEMP2))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 335;
                                                                            ICURSORPOSITION = (ushort) ( ITEMP2 ) ; 
                                                                            __context__.SourceCodeLine = 336;
                                                                            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                                                            ushort __FN_FOREND_VAL__1 = (ushort)10; 
                                                                            int __FN_FORSTEP_VAL__1 = (int)1; 
                                                                            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 338;
                                                                                NET_CURSOR_POSITION_LINE [ A]  .Value = (ushort) ( 0 ) ; 
                                                                                __context__.SourceCodeLine = 336;
                                                                                } 
                                                                            
                                                                            __context__.SourceCodeLine = 340;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ICURSORPOSITION > 0 ))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 342;
                                                                                NET_CURSOR_POSITION_LINE [ ICURSORPOSITION]  .Value = (ushort) ( 1 ) ; 
                                                                                } 
                                                                            
                                                                            } 
                                                                        
                                                                        __context__.SourceCodeLine = 345;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "P" , Functions.Mid( STEMP , (int)( 8 ) , (int)( 1 ) ) ) > 0 ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 347;
                                                                            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                                                            ushort __FN_FOREND_VAL__2 = (ushort)10; 
                                                                            int __FN_FORSTEP_VAL__2 = (int)1; 
                                                                            for ( A  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (A  >= __FN_FORSTART_VAL__2) && (A  <= __FN_FOREND_VAL__2) ) : ( (A  <= __FN_FORSTART_VAL__2) && (A  >= __FN_FOREND_VAL__2) ) ; A  += (ushort)__FN_FORSTEP_VAL__2) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 349;
                                                                                SLINETEXT [ A ]  .UpdateValue ( ""  ) ; 
                                                                                __context__.SourceCodeLine = 350;
                                                                                NET_LINE_TEXT [ A]  .UpdateValue ( SLINETEXT [ A ]  ) ; 
                                                                                __context__.SourceCodeLine = 347;
                                                                                } 
                                                                            
                                                                            } 
                                                                        
                                                                        } 
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 354;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NAT" , STEMP ) > 0 ))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 356;
                                                                            ITEMP1 = (ushort) ( Functions.Find( "!1NAT" , STEMP ) ) ; 
                                                                            __context__.SourceCodeLine = 357;
                                                                            STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1NAT" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1NAT" )) - ITEMP1) ) )  ) ; 
                                                                            __context__.SourceCodeLine = 358;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATARTIST != STEMP1))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 360;
                                                                                SNATARTIST  .UpdateValue ( STEMP1  ) ; 
                                                                                __context__.SourceCodeLine = 361;
                                                                                NAT_ARTIST__DOLLAR__  .UpdateValue ( SNATARTIST  ) ; 
                                                                                } 
                                                                            
                                                                            __context__.SourceCodeLine = 363;
                                                                            STEMP1  .UpdateValue ( ""  ) ; 
                                                                            __context__.SourceCodeLine = 364;
                                                                            STEMP  .UpdateValue ( ""  ) ; 
                                                                            } 
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 366;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NAL" , STEMP ) > 0 ))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 368;
                                                                                ITEMP1 = (ushort) ( Functions.Find( "!1NAL" , STEMP ) ) ; 
                                                                                __context__.SourceCodeLine = 369;
                                                                                STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1NAL" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1NAL" )) - ITEMP1) ) )  ) ; 
                                                                                __context__.SourceCodeLine = 370;
                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATALBUM != STEMP1))  ) ) 
                                                                                    { 
                                                                                    __context__.SourceCodeLine = 372;
                                                                                    SNATALBUM  .UpdateValue ( STEMP1  ) ; 
                                                                                    __context__.SourceCodeLine = 373;
                                                                                    NAT_ALBUM__DOLLAR__  .UpdateValue ( SNATALBUM  ) ; 
                                                                                    } 
                                                                                
                                                                                __context__.SourceCodeLine = 375;
                                                                                STEMP1  .UpdateValue ( ""  ) ; 
                                                                                __context__.SourceCodeLine = 376;
                                                                                STEMP  .UpdateValue ( ""  ) ; 
                                                                                } 
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 378;
                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NTI" , STEMP ) > 0 ))  ) ) 
                                                                                    { 
                                                                                    __context__.SourceCodeLine = 380;
                                                                                    ITEMP1 = (ushort) ( Functions.Find( "!1NTI" , STEMP ) ) ; 
                                                                                    __context__.SourceCodeLine = 381;
                                                                                    STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1NTI" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1NTI" )) - ITEMP1) ) )  ) ; 
                                                                                    __context__.SourceCodeLine = 382;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATTITLE != STEMP1))  ) ) 
                                                                                        { 
                                                                                        __context__.SourceCodeLine = 384;
                                                                                        SNATTITLE  .UpdateValue ( STEMP1  ) ; 
                                                                                        __context__.SourceCodeLine = 385;
                                                                                        NAT_TITLE__DOLLAR__  .UpdateValue ( SNATTITLE  ) ; 
                                                                                        } 
                                                                                    
                                                                                    __context__.SourceCodeLine = 387;
                                                                                    STEMP1  .UpdateValue ( ""  ) ; 
                                                                                    __context__.SourceCodeLine = 388;
                                                                                    STEMP  .UpdateValue ( ""  ) ; 
                                                                                    } 
                                                                                
                                                                                else 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 390;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NTM" , STEMP ) > 0 ))  ) ) 
                                                                                        { 
                                                                                        __context__.SourceCodeLine = 392;
                                                                                        ITEMP1 = (ushort) ( Functions.Find( "!1NTM" , STEMP ) ) ; 
                                                                                        __context__.SourceCodeLine = 393;
                                                                                        STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1NTM" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1NTM" )) - ITEMP1) ) )  ) ; 
                                                                                        __context__.SourceCodeLine = 394;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATTIME != STEMP1))  ) ) 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 396;
                                                                                            SNATTIME  .UpdateValue ( STEMP1  ) ; 
                                                                                            __context__.SourceCodeLine = 397;
                                                                                            NAT_TIME__DOLLAR__  .UpdateValue ( SNATTIME  ) ; 
                                                                                            } 
                                                                                        
                                                                                        __context__.SourceCodeLine = 399;
                                                                                        STEMP1  .UpdateValue ( ""  ) ; 
                                                                                        __context__.SourceCodeLine = 400;
                                                                                        STEMP  .UpdateValue ( ""  ) ; 
                                                                                        } 
                                                                                    
                                                                                    else 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 402;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NTR" , STEMP ) > 0 ))  ) ) 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 404;
                                                                                            ITEMP1 = (ushort) ( Functions.Find( "!1NTR" , STEMP ) ) ; 
                                                                                            __context__.SourceCodeLine = 405;
                                                                                            STEMP1  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (Functions.Length( "!1NTR" ) + ITEMP1) ) ,  (int) ( ((Functions.Length( STEMP ) - Functions.Length( "!1NTR" )) - ITEMP1) ) )  ) ; 
                                                                                            __context__.SourceCodeLine = 406;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATTRACK != STEMP1))  ) ) 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 408;
                                                                                                SNATTRACK  .UpdateValue ( STEMP1  ) ; 
                                                                                                __context__.SourceCodeLine = 409;
                                                                                                NAT_TRACK__DOLLAR__  .UpdateValue ( SNATTRACK  ) ; 
                                                                                                } 
                                                                                            
                                                                                            __context__.SourceCodeLine = 411;
                                                                                            STEMP1  .UpdateValue ( ""  ) ; 
                                                                                            __context__.SourceCodeLine = 412;
                                                                                            STEMP  .UpdateValue ( ""  ) ; 
                                                                                            } 
                                                                                        
                                                                                        else 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 414;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NST" , STEMP ) > 0 ))  ) ) 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 416;
                                                                                                ITEMP1 = (ushort) ( Functions.Find( "!1NAT" , STEMP ) ) ; 
                                                                                                __context__.SourceCodeLine = 417;
                                                                                                STEMP1  .UpdateValue ( Functions.Chr (  (int) ( Byte( STEMP , (int)( 6 ) ) ) )  ) ; 
                                                                                                __context__.SourceCodeLine = 418;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATPLAY != STEMP1))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 420;
                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STEMP1 == "P") ) && Functions.TestForTrue ( Functions.BoolToInt (INETDELAY != 1) )) ))  ) ) 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 422;
                                                                                                        SNATPLAY  .UpdateValue ( STEMP1  ) ; 
                                                                                                        __context__.SourceCodeLine = 423;
                                                                                                        NAT_PLAY__DOLLAR__  .UpdateValue ( SNATPLAY  ) ; 
                                                                                                        } 
                                                                                                    
                                                                                                    else 
                                                                                                        {
                                                                                                        __context__.SourceCodeLine = 425;
                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STEMP1 == "P") ) && Functions.TestForTrue ( Functions.BoolToInt (INETDELAY == 1) )) ))  ) ) 
                                                                                                            { 
                                                                                                            __context__.SourceCodeLine = 427;
                                                                                                            SNATPLAY  .UpdateValue ( STEMP1  ) ; 
                                                                                                            } 
                                                                                                        
                                                                                                        else 
                                                                                                            { 
                                                                                                            __context__.SourceCodeLine = 431;
                                                                                                            SNATPLAY  .UpdateValue ( STEMP1  ) ; 
                                                                                                            __context__.SourceCodeLine = 432;
                                                                                                            NAT_PLAY__DOLLAR__  .UpdateValue ( SNATPLAY  ) ; 
                                                                                                            } 
                                                                                                        
                                                                                                        }
                                                                                                    
                                                                                                    } 
                                                                                                
                                                                                                __context__.SourceCodeLine = 435;
                                                                                                STEMP1  .UpdateValue ( Functions.Chr (  (int) ( Byte( STEMP , (int)( 7 ) ) ) )  ) ; 
                                                                                                __context__.SourceCodeLine = 436;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATREPEAT != STEMP1))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 438;
                                                                                                    SNATREPEAT  .UpdateValue ( STEMP1  ) ; 
                                                                                                    __context__.SourceCodeLine = 439;
                                                                                                    NAT_REPEAT__DOLLAR__  .UpdateValue ( SNATREPEAT  ) ; 
                                                                                                    } 
                                                                                                
                                                                                                __context__.SourceCodeLine = 441;
                                                                                                STEMP1  .UpdateValue ( Functions.Chr (  (int) ( Byte( STEMP , (int)( 8 ) ) ) )  ) ; 
                                                                                                __context__.SourceCodeLine = 442;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNATSHUFFLE != STEMP1))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 444;
                                                                                                    SNATSHUFFLE  .UpdateValue ( STEMP1  ) ; 
                                                                                                    __context__.SourceCodeLine = 445;
                                                                                                    NAT_SHUFFLE__DOLLAR__  .UpdateValue ( SNATSHUFFLE  ) ; 
                                                                                                    } 
                                                                                                
                                                                                                __context__.SourceCodeLine = 447;
                                                                                                STEMP1  .UpdateValue ( ""  ) ; 
                                                                                                __context__.SourceCodeLine = 448;
                                                                                                STEMP  .UpdateValue ( ""  ) ; 
                                                                                                } 
                                                                                            
                                                                                            else 
                                                                                                {
                                                                                                __context__.SourceCodeLine = 450;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NKY" , STEMP ) > 0 ))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 452;
                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "00" , STEMP ) > 0 ))  ) ) 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 454;
                                                                                                        IWAITING = (ushort) ( 0 ) ; 
                                                                                                        } 
                                                                                                    
                                                                                                    else 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 458;
                                                                                                        IWAITING = (ushort) ( 1 ) ; 
                                                                                                        } 
                                                                                                    
                                                                                                    } 
                                                                                                
                                                                                                else 
                                                                                                    {
                                                                                                    __context__.SourceCodeLine = 461;
                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!1NPU" , STEMP ) > 0 ))  ) ) 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 463;
                                                                                                        SDISPLAYTYPE  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 6 ) ,  (int) ( 1 ) )  ) ; 
                                                                                                        __context__.SourceCodeLine = 464;
                                                                                                        POPUP_TYPE_VALUE  .UpdateValue ( SDISPLAYTYPE  ) ; 
                                                                                                        __context__.SourceCodeLine = 465;
                                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDISPLAYTYPE == "T"))  ) ) 
                                                                                                            { 
                                                                                                            __context__.SourceCodeLine = 467;
                                                                                                            IMARKER1 = (ushort) ( Functions.Find( "\u0000" , STEMP ) ) ; 
                                                                                                            __context__.SourceCodeLine = 468;
                                                                                                            IMARKER2 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER1 + 1) ) ) ; 
                                                                                                            __context__.SourceCodeLine = 469;
                                                                                                            IMARKER3 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER2 + 1) ) ) ; 
                                                                                                            __context__.SourceCodeLine = 470;
                                                                                                            IMARKER4 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER3 + 1) ) ) ; 
                                                                                                            __context__.SourceCodeLine = 471;
                                                                                                            IMARKER5 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER4 + 1) ) ) ; 
                                                                                                            __context__.SourceCodeLine = 472;
                                                                                                            TOP_TITLE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 7 ) ,  (int) ( (IMARKER1 - 7) ) )  ) ; 
                                                                                                            __context__.SourceCodeLine = 473;
                                                                                                            POPUP_TITLE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER2 - (IMARKER1 + 1)) ) )  ) ; 
                                                                                                            __context__.SourceCodeLine = 474;
                                                                                                            POPUP_MESSAGE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER2 + 1) ) ,  (int) ( (IMARKER3 - (IMARKER2 + 1)) ) )  ) ; 
                                                                                                            __context__.SourceCodeLine = 475;
                                                                                                            ICURSORPOINTER = (ushort) ( (IMARKER3 + 1) ) ; 
                                                                                                            __context__.SourceCodeLine = 476;
                                                                                                            ICURSOR = (ushort) ( Functions.Atoi( Functions.Mid( STEMP , (int)( (IMARKER3 + 1) ) , (int)( 1 ) ) ) ) ; 
                                                                                                            __context__.SourceCodeLine = 477;
                                                                                                            
                                                                                                                {
                                                                                                                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ICURSOR);
                                                                                                                
                                                                                                                    { 
                                                                                                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                                                                                                                        { 
                                                                                                                        __context__.SourceCodeLine = 481;
                                                                                                                        BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                        __context__.SourceCodeLine = 482;
                                                                                                                        BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                        } 
                                                                                                                    
                                                                                                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                                                                                                        { 
                                                                                                                        __context__.SourceCodeLine = 486;
                                                                                                                        BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                        __context__.SourceCodeLine = 487;
                                                                                                                        BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                        } 
                                                                                                                    
                                                                                                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                                                                                                        { 
                                                                                                                        __context__.SourceCodeLine = 491;
                                                                                                                        BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                        __context__.SourceCodeLine = 492;
                                                                                                                        BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                        } 
                                                                                                                    
                                                                                                                    } 
                                                                                                                    
                                                                                                                }
                                                                                                                
                                                                                                            
                                                                                                            __context__.SourceCodeLine = 495;
                                                                                                            BUTTON_1_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER3 + 2) ) ,  (int) ( (IMARKER4 - (IMARKER3 + 2)) ) )  ) ; 
                                                                                                            __context__.SourceCodeLine = 496;
                                                                                                            BUTTON_2_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER4 + 1) ) ,  (int) ( (IMARKER5 - (IMARKER4 + 1)) ) )  ) ; 
                                                                                                            } 
                                                                                                        
                                                                                                        else 
                                                                                                            {
                                                                                                            __context__.SourceCodeLine = 498;
                                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDISPLAYTYPE == "B"))  ) ) 
                                                                                                                { 
                                                                                                                __context__.SourceCodeLine = 500;
                                                                                                                IMARKER1 = (ushort) ( Functions.Find( "\u0000" , STEMP ) ) ; 
                                                                                                                __context__.SourceCodeLine = 501;
                                                                                                                IMARKER2 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER1 + 1) ) ) ; 
                                                                                                                __context__.SourceCodeLine = 502;
                                                                                                                IMARKER3 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER2 + 1) ) ) ; 
                                                                                                                __context__.SourceCodeLine = 503;
                                                                                                                IMARKER4 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER3 + 1) ) ) ; 
                                                                                                                __context__.SourceCodeLine = 504;
                                                                                                                IMARKER5 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER4 + 1) ) ) ; 
                                                                                                                __context__.SourceCodeLine = 505;
                                                                                                                TOP_TITLE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 7 ) ,  (int) ( (IMARKER1 - 7) ) )  ) ; 
                                                                                                                __context__.SourceCodeLine = 506;
                                                                                                                POPUP_TITLE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER2 - (IMARKER1 + 1)) ) )  ) ; 
                                                                                                                __context__.SourceCodeLine = 507;
                                                                                                                POPUP_MESSAGE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER2 + 1) ) ,  (int) ( (IMARKER3 - (IMARKER2 + 1)) ) )  ) ; 
                                                                                                                __context__.SourceCodeLine = 508;
                                                                                                                ICURSORPOINTER = (ushort) ( (IMARKER3 + 1) ) ; 
                                                                                                                __context__.SourceCodeLine = 509;
                                                                                                                ICURSOR = (ushort) ( Functions.Atoi( Functions.Mid( STEMP , (int)( (IMARKER3 + 1) ) , (int)( 1 ) ) ) ) ; 
                                                                                                                __context__.SourceCodeLine = 510;
                                                                                                                
                                                                                                                    {
                                                                                                                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)ICURSOR);
                                                                                                                    
                                                                                                                        { 
                                                                                                                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                                                                                                                            { 
                                                                                                                            __context__.SourceCodeLine = 514;
                                                                                                                            BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                            __context__.SourceCodeLine = 515;
                                                                                                                            BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                            } 
                                                                                                                        
                                                                                                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                                                                                                                            { 
                                                                                                                            __context__.SourceCodeLine = 519;
                                                                                                                            BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                            __context__.SourceCodeLine = 520;
                                                                                                                            BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                            } 
                                                                                                                        
                                                                                                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                                                                                                                            { 
                                                                                                                            __context__.SourceCodeLine = 524;
                                                                                                                            BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                            __context__.SourceCodeLine = 525;
                                                                                                                            BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                            } 
                                                                                                                        
                                                                                                                        } 
                                                                                                                        
                                                                                                                    }
                                                                                                                    
                                                                                                                
                                                                                                                __context__.SourceCodeLine = 528;
                                                                                                                BUTTON_1_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER3 + 2) ) ,  (int) ( (IMARKER4 - (IMARKER3 + 2)) ) )  ) ; 
                                                                                                                __context__.SourceCodeLine = 529;
                                                                                                                BUTTON_2_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER4 + 1) ) ,  (int) ( (IMARKER5 - (IMARKER4 + 1)) ) )  ) ; 
                                                                                                                } 
                                                                                                            
                                                                                                            else 
                                                                                                                {
                                                                                                                __context__.SourceCodeLine = 531;
                                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDISPLAYTYPE == "L"))  ) ) 
                                                                                                                    { 
                                                                                                                    __context__.SourceCodeLine = 535;
                                                                                                                    IMARKER1 = (ushort) ( Functions.Find( "\u0000" , STEMP ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 536;
                                                                                                                    IMARKER2 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER1 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 537;
                                                                                                                    IMARKER3 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER2 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 538;
                                                                                                                    IMARKER4 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER3 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 539;
                                                                                                                    IMARKER5 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER4 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 540;
                                                                                                                    IMARKER6 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER5 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 541;
                                                                                                                    IMARKER7 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER6 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 542;
                                                                                                                    IMARKER8 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER7 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 543;
                                                                                                                    IMARKER9 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER8 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 544;
                                                                                                                    IMARKER10 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER9 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 545;
                                                                                                                    IMARKER11 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER10 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 546;
                                                                                                                    IMARKER12 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER11 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 547;
                                                                                                                    IMARKER13 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER12 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 548;
                                                                                                                    IMARKER14 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER13 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 549;
                                                                                                                    IMARKER15 = (ushort) ( Functions.Find( "\u0000" , STEMP , (IMARKER14 + 1) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 550;
                                                                                                                    TOP_TITLE_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( 7 ) ,  (int) ( (IMARKER1 - 7) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 551;
                                                                                                                    ITEM_TITLE_1_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER2 - (IMARKER1 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 552;
                                                                                                                    ITEM_PARAMETER_1_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER2 + 1) ) ,  (int) ( (IMARKER3 - (IMARKER2 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 553;
                                                                                                                    ITEM_TITLE_2_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER3 + 1) ) ,  (int) ( (IMARKER4 - (IMARKER3 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 554;
                                                                                                                    ITEM_PARAMETER_2_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER4 + 1) ) ,  (int) ( (IMARKER5 - (IMARKER4 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 555;
                                                                                                                    ITEM_TITLE_3_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER6 - (IMARKER5 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 556;
                                                                                                                    ITEM_PARAMETER_3_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER7 - (IMARKER6 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 557;
                                                                                                                    ITEM_TITLE_4_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER8 - (IMARKER7 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 558;
                                                                                                                    ITEM_PARAMETER_4_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER9 - (IMARKER8 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 559;
                                                                                                                    ITEM_TITLE_5_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER10 - (IMARKER9 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 560;
                                                                                                                    ITEM_PARAMETER_5_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER11 - (IMARKER10 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 561;
                                                                                                                    ITEM_TITLE_6_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER12 - (IMARKER11 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 562;
                                                                                                                    ITEM_PARAMETER_6_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER1 + 1) ) ,  (int) ( (IMARKER13 - (IMARKER12 + 1)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 563;
                                                                                                                    ICURSORPOINTER = (ushort) ( (IMARKER13 + 1) ) ; 
                                                                                                                    __context__.SourceCodeLine = 564;
                                                                                                                    ICURSOR = (ushort) ( Functions.Atoi( Functions.Mid( STEMP , (int)( (IMARKER13 + 1) ) , (int)( 1 ) ) ) ) ; 
                                                                                                                    __context__.SourceCodeLine = 565;
                                                                                                                    
                                                                                                                        {
                                                                                                                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)ICURSOR);
                                                                                                                        
                                                                                                                            { 
                                                                                                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 0) ) ) ) 
                                                                                                                                { 
                                                                                                                                __context__.SourceCodeLine = 569;
                                                                                                                                BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                                __context__.SourceCodeLine = 570;
                                                                                                                                BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                                } 
                                                                                                                            
                                                                                                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                                                                                                                { 
                                                                                                                                __context__.SourceCodeLine = 574;
                                                                                                                                BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                                __context__.SourceCodeLine = 575;
                                                                                                                                BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                                } 
                                                                                                                            
                                                                                                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                                                                                                                { 
                                                                                                                                __context__.SourceCodeLine = 579;
                                                                                                                                BUTTON_1_HIGHLIGHTED  .Value = (ushort) ( 0 ) ; 
                                                                                                                                __context__.SourceCodeLine = 580;
                                                                                                                                BUTTON_2_HIGHLIGHTED  .Value = (ushort) ( 1 ) ; 
                                                                                                                                } 
                                                                                                                            
                                                                                                                            } 
                                                                                                                            
                                                                                                                        }
                                                                                                                        
                                                                                                                    
                                                                                                                    __context__.SourceCodeLine = 583;
                                                                                                                    BUTTON_1_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER13 + 2) ) ,  (int) ( (IMARKER14 - (IMARKER13 + 2)) ) )  ) ; 
                                                                                                                    __context__.SourceCodeLine = 584;
                                                                                                                    BUTTON_2_TEXT  .UpdateValue ( Functions.Mid ( STEMP ,  (int) ( (IMARKER14 + 1) ) ,  (int) ( (IMARKER15 - (IMARKER14 + 1)) ) )  ) ; 
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
                    
                    } 
                
                __context__.SourceCodeLine = 134;
                } 
            
            __context__.SourceCodeLine = 589;
            ISEMAPHORE = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DELIMITER_TYPE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 595;
        switch ((int)DELIMITER_TYPE  .UshortValue)
        
            { 
            case 1 : 
            
                { 
                __context__.SourceCodeLine = 597;
                SDELIMITER  .UpdateValue ( "\u001A"  ) ; 
                __context__.SourceCodeLine = 597;
                break ; 
                } 
            
            goto case 2 ;
            case 2 : 
            
                { 
                __context__.SourceCodeLine = 598;
                SDELIMITER  .UpdateValue ( "\u001A\u000D"  ) ; 
                __context__.SourceCodeLine = 598;
                break ; 
                } 
            
            goto case 3 ;
            case 3 : 
            
                { 
                __context__.SourceCodeLine = 599;
                SDELIMITER  .UpdateValue ( "\u001A\u000D\u000A"  ) ; 
                __context__.SourceCodeLine = 599;
                break ; 
                } 
            
            break;
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
        
        __context__.SourceCodeLine = 609;
        IFLAG1 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 610;
        STEMP  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 611;
        STEMP1  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 612;
        ITEMP = (ushort) ( 100 ) ; 
        __context__.SourceCodeLine = 613;
        INETDELAY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 614;
        ISEMAPHORE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10000, this );
    STEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STUNER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
    STUNERZONE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
    STUNER3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
    STUNER4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
    SNATARTIST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    SNATALBUM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    SNATTITLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    SNATTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    SNATPLAY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SNATREPEAT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SNATSHUFFLE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SNATTRACK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    STEMPCMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    SDISPLAYTYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    STEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    SDELIMITER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    SLINETEXT  = new CrestronString[ 11 ];
    for( uint i = 0; i < 11; i++ )
        SLINETEXT [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 70, this );
    
    NET_FF_REW_PUSHED = new Crestron.Logos.SplusObjects.DigitalInput( NET_FF_REW_PUSHED__DigitalInput__, this );
    m_DigitalInputList.Add( NET_FF_REW_PUSHED__DigitalInput__, NET_FF_REW_PUSHED );
    
    SEND_KEYBOARD = new Crestron.Logos.SplusObjects.DigitalInput( SEND_KEYBOARD__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_KEYBOARD__DigitalInput__, SEND_KEYBOARD );
    
    PROCESS_FROM_DEVICE = new Crestron.Logos.SplusObjects.DigitalInput( PROCESS_FROM_DEVICE__DigitalInput__, this );
    m_DigitalInputList.Add( PROCESS_FROM_DEVICE__DigitalInput__, PROCESS_FROM_DEVICE );
    
    BUTTON_1_HIGHLIGHTED = new Crestron.Logos.SplusObjects.DigitalOutput( BUTTON_1_HIGHLIGHTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUTTON_1_HIGHLIGHTED__DigitalOutput__, BUTTON_1_HIGHLIGHTED );
    
    BUTTON_2_HIGHLIGHTED = new Crestron.Logos.SplusObjects.DigitalOutput( BUTTON_2_HIGHLIGHTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUTTON_2_HIGHLIGHTED__DigitalOutput__, BUTTON_2_HIGHLIGHTED );
    
    NET_CURSOR_POSITION_LINE = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        NET_CURSOR_POSITION_LINE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( NET_CURSOR_POSITION_LINE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( NET_CURSOR_POSITION_LINE__DigitalOutput__ + i, NET_CURSOR_POSITION_LINE[i+1] );
    }
    
    TUNER_BAND_IN = new Crestron.Logos.SplusObjects.AnalogInput( TUNER_BAND_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TUNER_BAND_IN__AnalogSerialInput__, TUNER_BAND_IN );
    
    DELIMITER_TYPE = new Crestron.Logos.SplusObjects.AnalogInput( DELIMITER_TYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DELIMITER_TYPE__AnalogSerialInput__, DELIMITER_TYPE );
    
    SLEEP_TIME = new Crestron.Logos.SplusObjects.AnalogOutput( SLEEP_TIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SLEEP_TIME__AnalogSerialOutput__, SLEEP_TIME );
    
    MAIN_VOLUME_IN = new Crestron.Logos.SplusObjects.AnalogOutput( MAIN_VOLUME_IN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MAIN_VOLUME_IN__AnalogSerialOutput__, MAIN_VOLUME_IN );
    
    ZONE_2_VOLUME_IN = new Crestron.Logos.SplusObjects.AnalogOutput( ZONE_2_VOLUME_IN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONE_2_VOLUME_IN__AnalogSerialOutput__, ZONE_2_VOLUME_IN );
    
    ZONE_3_VOLUME_IN = new Crestron.Logos.SplusObjects.AnalogOutput( ZONE_3_VOLUME_IN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONE_3_VOLUME_IN__AnalogSerialOutput__, ZONE_3_VOLUME_IN );
    
    ZONE_4_VOLUME_IN = new Crestron.Logos.SplusObjects.AnalogOutput( ZONE_4_VOLUME_IN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONE_4_VOLUME_IN__AnalogSerialOutput__, ZONE_4_VOLUME_IN );
    
    KEYBOARD_INPUT_TEXT = new Crestron.Logos.SplusObjects.StringInput( KEYBOARD_INPUT_TEXT__AnalogSerialInput__, 128, this );
    m_StringInputList.Add( KEYBOARD_INPUT_TEXT__AnalogSerialInput__, KEYBOARD_INPUT_TEXT );
    
    TUNER_FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__, TUNER_FREQUENCY__DOLLAR__ );
    
    TUNER_ZONE_FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUNER_ZONE_FREQUENCY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_ZONE_FREQUENCY__DOLLAR____AnalogSerialOutput__, TUNER_ZONE_FREQUENCY__DOLLAR__ );
    
    TUNER_ZONE_3_FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUNER_ZONE_3_FREQUENCY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_ZONE_3_FREQUENCY__DOLLAR____AnalogSerialOutput__, TUNER_ZONE_3_FREQUENCY__DOLLAR__ );
    
    TUNER_ZONE_4_FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUNER_ZONE_4_FREQUENCY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_ZONE_4_FREQUENCY__DOLLAR____AnalogSerialOutput__, TUNER_ZONE_4_FREQUENCY__DOLLAR__ );
    
    NAT_ARTIST__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_ARTIST__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_ARTIST__DOLLAR____AnalogSerialOutput__, NAT_ARTIST__DOLLAR__ );
    
    NAT_ALBUM__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_ALBUM__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_ALBUM__DOLLAR____AnalogSerialOutput__, NAT_ALBUM__DOLLAR__ );
    
    NAT_TITLE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_TITLE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_TITLE__DOLLAR____AnalogSerialOutput__, NAT_TITLE__DOLLAR__ );
    
    NAT_TIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_TIME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_TIME__DOLLAR____AnalogSerialOutput__, NAT_TIME__DOLLAR__ );
    
    NAT_PLAY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_PLAY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_PLAY__DOLLAR____AnalogSerialOutput__, NAT_PLAY__DOLLAR__ );
    
    NAT_REPEAT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_REPEAT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_REPEAT__DOLLAR____AnalogSerialOutput__, NAT_REPEAT__DOLLAR__ );
    
    NAT_SHUFFLE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_SHUFFLE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_SHUFFLE__DOLLAR____AnalogSerialOutput__, NAT_SHUFFLE__DOLLAR__ );
    
    NAT_TRACK__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAT_TRACK__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAT_TRACK__DOLLAR____AnalogSerialOutput__, NAT_TRACK__DOLLAR__ );
    
    POPUP_TYPE_VALUE = new Crestron.Logos.SplusObjects.StringOutput( POPUP_TYPE_VALUE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( POPUP_TYPE_VALUE__AnalogSerialOutput__, POPUP_TYPE_VALUE );
    
    TOP_TITLE_TEXT = new Crestron.Logos.SplusObjects.StringOutput( TOP_TITLE_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TOP_TITLE_TEXT__AnalogSerialOutput__, TOP_TITLE_TEXT );
    
    POPUP_TITLE_TEXT = new Crestron.Logos.SplusObjects.StringOutput( POPUP_TITLE_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( POPUP_TITLE_TEXT__AnalogSerialOutput__, POPUP_TITLE_TEXT );
    
    POPUP_MESSAGE_TEXT = new Crestron.Logos.SplusObjects.StringOutput( POPUP_MESSAGE_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( POPUP_MESSAGE_TEXT__AnalogSerialOutput__, POPUP_MESSAGE_TEXT );
    
    ITEM_TITLE_1_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_1_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_1_TEXT__AnalogSerialOutput__, ITEM_TITLE_1_TEXT );
    
    ITEM_PARAMETER_1_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_1_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_1_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_1_TEXT );
    
    ITEM_TITLE_2_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_2_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_2_TEXT__AnalogSerialOutput__, ITEM_TITLE_2_TEXT );
    
    ITEM_PARAMETER_2_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_2_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_2_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_2_TEXT );
    
    ITEM_TITLE_3_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_3_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_3_TEXT__AnalogSerialOutput__, ITEM_TITLE_3_TEXT );
    
    ITEM_PARAMETER_3_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_3_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_3_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_3_TEXT );
    
    ITEM_TITLE_4_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_4_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_4_TEXT__AnalogSerialOutput__, ITEM_TITLE_4_TEXT );
    
    ITEM_PARAMETER_4_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_4_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_4_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_4_TEXT );
    
    ITEM_TITLE_5_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_5_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_5_TEXT__AnalogSerialOutput__, ITEM_TITLE_5_TEXT );
    
    ITEM_PARAMETER_5_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_5_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_5_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_5_TEXT );
    
    ITEM_TITLE_6_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_TITLE_6_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_TITLE_6_TEXT__AnalogSerialOutput__, ITEM_TITLE_6_TEXT );
    
    ITEM_PARAMETER_6_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ITEM_PARAMETER_6_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ITEM_PARAMETER_6_TEXT__AnalogSerialOutput__, ITEM_PARAMETER_6_TEXT );
    
    BUTTON_1_TEXT = new Crestron.Logos.SplusObjects.StringOutput( BUTTON_1_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( BUTTON_1_TEXT__AnalogSerialOutput__, BUTTON_1_TEXT );
    
    BUTTON_2_TEXT = new Crestron.Logos.SplusObjects.StringOutput( BUTTON_2_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( BUTTON_2_TEXT__AnalogSerialOutput__, BUTTON_2_TEXT );
    
    TO_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__DOLLAR____AnalogSerialOutput__, TO_DEVICE__DOLLAR__ );
    
    NET_LINE_TEXT = new InOutArray<StringOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        NET_LINE_TEXT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( NET_LINE_TEXT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( NET_LINE_TEXT__AnalogSerialOutput__ + i, NET_LINE_TEXT[i+1] );
    }
    
    FROM_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__DOLLAR____AnalogSerialInput__, 65000, this );
    m_StringInputList.Add( FROM_DEVICE__DOLLAR____AnalogSerialInput__, FROM_DEVICE__DOLLAR__ );
    
    WNETDELAY_Callback = new WaitFunction( WNETDELAY_CallbackFn );
    
    SEND_KEYBOARD.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_KEYBOARD_OnPush_0, false ) );
    NET_FF_REW_PUSHED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( NET_FF_REW_PUSHED_OnRelease_1, false ) );
    NET_FF_REW_PUSHED.OnDigitalPush.Add( new InputChangeHandlerWrapper( NET_FF_REW_PUSHED_OnPush_2, false ) );
    FROM_DEVICE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE__DOLLAR___OnChange_3, false ) );
    DELIMITER_TYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( DELIMITER_TYPE_OnChange_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_INTEGRA_DTR_60_6_IP_V1_0_FEEDBACK ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WNETDELAY_Callback;


const uint NET_FF_REW_PUSHED__DigitalInput__ = 0;
const uint SEND_KEYBOARD__DigitalInput__ = 1;
const uint PROCESS_FROM_DEVICE__DigitalInput__ = 2;
const uint TUNER_BAND_IN__AnalogSerialInput__ = 0;
const uint DELIMITER_TYPE__AnalogSerialInput__ = 1;
const uint KEYBOARD_INPUT_TEXT__AnalogSerialInput__ = 2;
const uint FROM_DEVICE__DOLLAR____AnalogSerialInput__ = 3;
const uint BUTTON_1_HIGHLIGHTED__DigitalOutput__ = 0;
const uint BUTTON_2_HIGHLIGHTED__DigitalOutput__ = 1;
const uint SLEEP_TIME__AnalogSerialOutput__ = 0;
const uint MAIN_VOLUME_IN__AnalogSerialOutput__ = 1;
const uint ZONE_2_VOLUME_IN__AnalogSerialOutput__ = 2;
const uint ZONE_3_VOLUME_IN__AnalogSerialOutput__ = 3;
const uint ZONE_4_VOLUME_IN__AnalogSerialOutput__ = 4;
const uint TUNER_FREQUENCY__DOLLAR____AnalogSerialOutput__ = 5;
const uint TUNER_ZONE_FREQUENCY__DOLLAR____AnalogSerialOutput__ = 6;
const uint TUNER_ZONE_3_FREQUENCY__DOLLAR____AnalogSerialOutput__ = 7;
const uint TUNER_ZONE_4_FREQUENCY__DOLLAR____AnalogSerialOutput__ = 8;
const uint NAT_ARTIST__DOLLAR____AnalogSerialOutput__ = 9;
const uint NAT_ALBUM__DOLLAR____AnalogSerialOutput__ = 10;
const uint NAT_TITLE__DOLLAR____AnalogSerialOutput__ = 11;
const uint NAT_TIME__DOLLAR____AnalogSerialOutput__ = 12;
const uint NAT_PLAY__DOLLAR____AnalogSerialOutput__ = 13;
const uint NAT_REPEAT__DOLLAR____AnalogSerialOutput__ = 14;
const uint NAT_SHUFFLE__DOLLAR____AnalogSerialOutput__ = 15;
const uint NAT_TRACK__DOLLAR____AnalogSerialOutput__ = 16;
const uint POPUP_TYPE_VALUE__AnalogSerialOutput__ = 17;
const uint TOP_TITLE_TEXT__AnalogSerialOutput__ = 18;
const uint POPUP_TITLE_TEXT__AnalogSerialOutput__ = 19;
const uint POPUP_MESSAGE_TEXT__AnalogSerialOutput__ = 20;
const uint ITEM_TITLE_1_TEXT__AnalogSerialOutput__ = 21;
const uint ITEM_PARAMETER_1_TEXT__AnalogSerialOutput__ = 22;
const uint ITEM_TITLE_2_TEXT__AnalogSerialOutput__ = 23;
const uint ITEM_PARAMETER_2_TEXT__AnalogSerialOutput__ = 24;
const uint ITEM_TITLE_3_TEXT__AnalogSerialOutput__ = 25;
const uint ITEM_PARAMETER_3_TEXT__AnalogSerialOutput__ = 26;
const uint ITEM_TITLE_4_TEXT__AnalogSerialOutput__ = 27;
const uint ITEM_PARAMETER_4_TEXT__AnalogSerialOutput__ = 28;
const uint ITEM_TITLE_5_TEXT__AnalogSerialOutput__ = 29;
const uint ITEM_PARAMETER_5_TEXT__AnalogSerialOutput__ = 30;
const uint ITEM_TITLE_6_TEXT__AnalogSerialOutput__ = 31;
const uint ITEM_PARAMETER_6_TEXT__AnalogSerialOutput__ = 32;
const uint BUTTON_1_TEXT__AnalogSerialOutput__ = 33;
const uint BUTTON_2_TEXT__AnalogSerialOutput__ = 34;
const uint TO_DEVICE__DOLLAR____AnalogSerialOutput__ = 35;
const uint NET_CURSOR_POSITION_LINE__DigitalOutput__ = 2;
const uint NET_LINE_TEXT__AnalogSerialOutput__ = 36;

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
