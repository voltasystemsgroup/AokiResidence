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

namespace UserModule_MODBUS_TCP_READ_AND_WRITE_COILS_V1_3
{
    public class UserModuleClass_MODBUS_TCP_READ_AND_WRITE_COILS_V1_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput POLL_ALL;
        Crestron.Logos.SplusObjects.DigitalInput SEND_ALL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ON_;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> OFF_;
        Crestron.Logos.SplusObjects.BufferInput FROM_PROCESSOR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ON_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OFF_FB;
        Crestron.Logos.SplusObjects.StringOutput TO_PROCESSOR;
        UShortParameter UNIT_ID;
        UShortParameter START_ADDRESS;
        UShortParameter COUNT_COIL;
        UShortParameter SEND_REACTION;
        CrestronString START_COM;
        CrestronString END_COM;
        CrestronString TEMP;
        CrestronString TEMPSTRING;
        ushort RXOK = 0;
        ushort ARRAY_INDEX = 0;
        ushort [] COIL_ARRAY;
        ushort START_MARKER = 0;
        ushort END_MARKER = 0;
        private void PROCESSSTRING (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort HIGH_B = 0;
            ushort LOW_B = 0;
            ushort TEMP = 0;
            ushort S = 0;
            ushort W = 0;
            ushort INDEX = 0;
            ushort B_LENGTH = 0;
            
            ushort FINAL_VALUE = 0;
            
            
            __context__.SourceCodeLine = 121;
            B_LENGTH = (ushort) ( (COUNT_COIL  .Value / 8) ) ; 
            __context__.SourceCodeLine = 122;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( COUNT_COIL  .Value , 8 ) != 0))  ) ) 
                {
                __context__.SourceCodeLine = 122;
                B_LENGTH = (ushort) ( (B_LENGTH + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 123;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 125;
                S = (ushort) ( 10 ) ; 
                __context__.SourceCodeLine = 127;
                HIGH_B = (ushort) ( Byte( TEMPSTRING , (int)( S ) ) ) ; 
                __context__.SourceCodeLine = 128;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COUNT_COIL  .Value == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 128;
                    LOW_B = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 129;
                    LOW_B = (ushort) ( Byte( TEMPSTRING , (int)( (S + 1) ) ) ) ; 
                    }
                
                __context__.SourceCodeLine = 131;
                TEMP = (ushort) ( ((LOW_B & 255) << 8) ) ; 
                __context__.SourceCodeLine = 132;
                FINAL_VALUE = (ushort) ( (TEMP | HIGH_B) ) ; 
                __context__.SourceCodeLine = 133;
                W = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 135;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)COUNT_COIL  .Value; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 137;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((FINAL_VALUE & W) == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 139;
                        ON_FB [ I]  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 140;
                        OFF_FB [ I]  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 144;
                        ON_FB [ I]  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 145;
                        OFF_FB [ I]  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 148;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( I , 16 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (I != COUNT_COIL  .Value) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 150;
                        S = (ushort) ( (S + 2) ) ; 
                        __context__.SourceCodeLine = 151;
                        W = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 153;
                        HIGH_B = (ushort) ( Byte( TEMPSTRING , (int)( S ) ) ) ; 
                        __context__.SourceCodeLine = 154;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (I == ((COUNT_COIL  .Value / 16) * 16)) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( B_LENGTH , 2 ) == 1) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 156;
                            LOW_B = (ushort) ( 0 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 158;
                            LOW_B = (ushort) ( Byte( TEMPSTRING , (int)( (S + 1) ) ) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 160;
                        TEMP = (ushort) ( ((LOW_B & 255) << 8) ) ; 
                        __context__.SourceCodeLine = 161;
                        FINAL_VALUE = (ushort) ( (TEMP | HIGH_B) ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 165;
                        W = (ushort) ( (W << 1) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 135;
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 169;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 15))  ) ) 
                    { 
                    __context__.SourceCodeLine = 171;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)COUNT_COIL  .Value; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 173;
                        ON_FB [ I]  .Value = (ushort) ( COIL_ARRAY[ I ] ) ; 
                        __context__.SourceCodeLine = 174;
                        OFF_FB [ I]  .Value = (ushort) ( Functions.OnesComplement( COIL_ARRAY[ I ] ) ) ; 
                        __context__.SourceCodeLine = 171;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 177;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 5))  ) ) 
                        { 
                        __context__.SourceCodeLine = 179;
                        HIGH_B = (ushort) ( Byte( TEMPSTRING , (int)( 9 ) ) ) ; 
                        __context__.SourceCodeLine = 180;
                        LOW_B = (ushort) ( Byte( TEMPSTRING , (int)( 10 ) ) ) ; 
                        __context__.SourceCodeLine = 182;
                        TEMP = (ushort) ( ((HIGH_B & 255) << 8) ) ; 
                        __context__.SourceCodeLine = 183;
                        INDEX = (ushort) ( (TEMP | LOW_B) ) ; 
                        __context__.SourceCodeLine = 184;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INDEX >= START_ADDRESS  .Value ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX <= (START_ADDRESS  .Value + 100) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 186;
                            INDEX = (ushort) ( ((INDEX - START_ADDRESS  .Value) + 1) ) ; 
                            __context__.SourceCodeLine = 187;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 11 ) ) == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 189;
                                ON_FB [ INDEX]  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 190;
                                OFF_FB [ INDEX]  .Value = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 194;
                                ON_FB [ INDEX]  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 195;
                                OFF_FB [ INDEX]  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 199;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 129) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 133) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPSTRING , (int)( 8 ) ) == 143) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 201;
                            Trace( "Exception in module {0:d}: invalid start address or number of addresses", (short)ARRAY_INDEX) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            
            }
            
        object POLL_ALL_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort H_START = 0;
                ushort L_START = 0;
                ushort H_COUNT = 0;
                ushort L_COUNT = 0;
                
                
                __context__.SourceCodeLine = 214;
                L_START = (ushort) ( (START_ADDRESS  .Value & 255) ) ; 
                __context__.SourceCodeLine = 215;
                H_START = (ushort) ( ((START_ADDRESS  .Value & 65280) >> 8) ) ; 
                __context__.SourceCodeLine = 217;
                L_COUNT = (ushort) ( (COUNT_COIL  .Value & 255) ) ; 
                __context__.SourceCodeLine = 218;
                H_COUNT = (ushort) ( ((COUNT_COIL  .Value & 65280) >> 8) ) ; 
                __context__.SourceCodeLine = 220;
                TO_PROCESSOR  .UpdateValue ( START_COM + Functions.Chr (  (int) ( ARRAY_INDEX ) ) + "\u0000\u0000\u0000\u0000\u0000\u0006" + Functions.Chr (  (int) ( UNIT_ID  .Value ) ) + "\u0001" + Functions.Chr (  (int) ( H_START ) ) + Functions.Chr (  (int) ( L_START ) ) + Functions.Chr (  (int) ( H_COUNT ) ) + Functions.Chr (  (int) ( L_COUNT ) ) + END_COM  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SEND_ALL_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort H_START = 0;
            ushort L_START = 0;
            ushort H_COUNT = 0;
            ushort L_COUNT = 0;
            ushort W = 0;
            ushort H_VALUE = 0;
            ushort L_VALUE = 0;
            ushort I = 0;
            ushort WRITE_BYTE = 0;
            ushort TEMP1 = 0;
            
            CrestronString COMMAND_STRING;
            COMMAND_STRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
            
            
            __context__.SourceCodeLine = 229;
            WRITE_BYTE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 231;
            L_START = (ushort) ( (START_ADDRESS  .Value & 255) ) ; 
            __context__.SourceCodeLine = 232;
            H_START = (ushort) ( ((START_ADDRESS  .Value & 65280) >> 8) ) ; 
            __context__.SourceCodeLine = 234;
            L_COUNT = (ushort) ( (COUNT_COIL  .Value & 255) ) ; 
            __context__.SourceCodeLine = 235;
            H_COUNT = (ushort) ( ((COUNT_COIL  .Value & 65280) >> 8) ) ; 
            __context__.SourceCodeLine = 237;
            COMMAND_STRING  .UpdateValue ( "\u0000\u0000\u0000\u0000\u0000" + Functions.Chr (  (int) ( ((COUNT_COIL  .Value / 8) + 8) ) ) + Functions.Chr (  (int) ( UNIT_ID  .Value ) ) + "\u000F" + Functions.Chr (  (int) ( H_START ) ) + Functions.Chr (  (int) ( L_START ) ) + Functions.Chr (  (int) ( H_COUNT ) ) + Functions.Chr (  (int) ( L_COUNT ) ) + Functions.Chr (  (int) ( ((COUNT_COIL  .Value / 8) + 1) ) )  ) ; 
            __context__.SourceCodeLine = 239;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)COUNT_COIL  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 241;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ON_[ I ] .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 243;
                    COIL_ARRAY [ I] = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 244;
                    TEMP1 = (ushort) ( (ON_[ I ] .Value << (Mod( I , 8 ) - 1)) ) ; 
                    __context__.SourceCodeLine = 245;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( I , 8 ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 245;
                        TEMP1 = (ushort) ( (ON_[ I ] .Value << 7) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 246;
                    WRITE_BYTE = (ushort) ( (TEMP1 | WRITE_BYTE) ) ; 
                    } 
                
                __context__.SourceCodeLine = 249;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( I , 8 ) == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (I == COUNT_COIL  .Value) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 251;
                    WRITE_BYTE = (ushort) ( (WRITE_BYTE & 255) ) ; 
                    __context__.SourceCodeLine = 252;
                    COMMAND_STRING  .UpdateValue ( COMMAND_STRING + Functions.Chr (  (int) ( WRITE_BYTE ) )  ) ; 
                    __context__.SourceCodeLine = 253;
                    WRITE_BYTE = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 239;
                } 
            
            __context__.SourceCodeLine = 257;
            TO_PROCESSOR  .UpdateValue ( START_COM + Functions.Chr (  (int) ( ARRAY_INDEX ) ) + COMMAND_STRING + END_COM  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ON__OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort H_START1 = 0;
        ushort L_START1 = 0;
        
        CrestronString COMMAND_STRING1;
        COMMAND_STRING1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
        
        
        __context__.SourceCodeLine = 265;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEND_REACTION  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 267;
            L_START1 = (ushort) ( (((START_ADDRESS  .Value + Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )) - 1) & 255) ) ; 
            __context__.SourceCodeLine = 268;
            H_START1 = (ushort) ( ((((START_ADDRESS  .Value + Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )) - 1) & 65280) >> 8) ) ; 
            __context__.SourceCodeLine = 270;
            COMMAND_STRING1  .UpdateValue ( "\u0000\u0000\u0000\u0000\u0000\u0006" + Functions.Chr (  (int) ( UNIT_ID  .Value ) ) + "\u0005" + Functions.Chr (  (int) ( H_START1 ) ) + Functions.Chr (  (int) ( L_START1 ) ) + "\u00FF\u0000"  ) ; 
            __context__.SourceCodeLine = 272;
            TO_PROCESSOR  .UpdateValue ( START_COM + Functions.Chr (  (int) ( ARRAY_INDEX ) ) + COMMAND_STRING1 + END_COM  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OFF__OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort H_START1 = 0;
        ushort L_START1 = 0;
        
        CrestronString COMMAND_STRING1;
        COMMAND_STRING1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
        
        
        __context__.SourceCodeLine = 281;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEND_REACTION  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 283;
            L_START1 = (ushort) ( (((START_ADDRESS  .Value + Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )) - 1) & 255) ) ; 
            __context__.SourceCodeLine = 284;
            H_START1 = (ushort) ( ((((START_ADDRESS  .Value + Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )) - 1) & 65280) >> 8) ) ; 
            __context__.SourceCodeLine = 286;
            COMMAND_STRING1  .UpdateValue ( "\u0000\u0000\u0000\u0000\u0000\u0006" + Functions.Chr (  (int) ( UNIT_ID  .Value ) ) + "\u0005" + Functions.Chr (  (int) ( H_START1 ) ) + Functions.Chr (  (int) ( L_START1 ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 288;
            TO_PROCESSOR  .UpdateValue ( START_COM + Functions.Chr (  (int) ( ARRAY_INDEX ) ) + COMMAND_STRING1 + END_COM  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_PROCESSOR_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 295;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( FROM_PROCESSOR ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 297;
            START_MARKER = (ushort) ( Functions.Find( START_COM , FROM_PROCESSOR ) ) ; 
            __context__.SourceCodeLine = 299;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (START_MARKER == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 301;
                TEMP  .UpdateValue ( Functions.Remove ( (START_MARKER + 3), FROM_PROCESSOR )  ) ; 
                __context__.SourceCodeLine = 302;
                END_MARKER = (ushort) ( (Byte( FROM_PROCESSOR , (int)( 6 ) ) + 6) ) ; 
                __context__.SourceCodeLine = 304;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( FROM_PROCESSOR , (int)( (END_MARKER + 1) ) , (int)( 4 ) ) == END_COM))  ) ) 
                    { 
                    __context__.SourceCodeLine = 306;
                    TEMPSTRING  .UpdateValue ( Functions.Remove ( END_MARKER, FROM_PROCESSOR )  ) ; 
                    __context__.SourceCodeLine = 307;
                    TEMP  .UpdateValue ( Functions.Remove ( 4, FROM_PROCESSOR )  ) ; 
                    __context__.SourceCodeLine = 308;
                    PROCESSSTRING (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 310;
                    Functions.ClearBuffer ( FROM_PROCESSOR ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 312;
                if ( Functions.TestForTrue  ( ( Functions.Find( "array_index=" , FROM_PROCESSOR ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 314;
                    ARRAY_INDEX = (ushort) ( Byte( FROM_PROCESSOR , (int)( (Functions.Find( "array_index=" , FROM_PROCESSOR ) + 12) ) ) ) ; 
                    __context__.SourceCodeLine = 315;
                    Functions.ClearBuffer ( FROM_PROCESSOR ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 317;
                    Functions.ClearBuffer ( FROM_PROCESSOR ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 295;
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
        
        __context__.SourceCodeLine = 365;
        RXOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 366;
        START_COM  .UpdateValue ( "\u0000\u00FF\u0000\u00FF"  ) ; 
        __context__.SourceCodeLine = 367;
        END_COM  .UpdateValue ( "\u0000\u00FE\u0000\u00FE"  ) ; 
        __context__.SourceCodeLine = 368;
        Functions.SetArray (  ref COIL_ARRAY , (ushort)0) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    COIL_ARRAY  = new ushort[ 101 ];
    START_COM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    END_COM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
    
    POLL_ALL = new Crestron.Logos.SplusObjects.DigitalInput( POLL_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_ALL__DigitalInput__, POLL_ALL );
    
    SEND_ALL = new Crestron.Logos.SplusObjects.DigitalInput( SEND_ALL__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_ALL__DigitalInput__, SEND_ALL );
    
    ON_ = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        ON_[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ON___DigitalInput__ + i, ON___DigitalInput__, this );
        m_DigitalInputList.Add( ON___DigitalInput__ + i, ON_[i+1] );
    }
    
    OFF_ = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        OFF_[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( OFF___DigitalInput__ + i, OFF___DigitalInput__, this );
        m_DigitalInputList.Add( OFF___DigitalInput__ + i, OFF_[i+1] );
    }
    
    ON_FB = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        ON_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ON_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ON_FB__DigitalOutput__ + i, ON_FB[i+1] );
    }
    
    OFF_FB = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        OFF_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OFF_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( OFF_FB__DigitalOutput__ + i, OFF_FB[i+1] );
    }
    
    TO_PROCESSOR = new Crestron.Logos.SplusObjects.StringOutput( TO_PROCESSOR__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_PROCESSOR__AnalogSerialOutput__, TO_PROCESSOR );
    
    FROM_PROCESSOR = new Crestron.Logos.SplusObjects.BufferInput( FROM_PROCESSOR__AnalogSerialInput__, 1200, this );
    m_StringInputList.Add( FROM_PROCESSOR__AnalogSerialInput__, FROM_PROCESSOR );
    
    UNIT_ID = new UShortParameter( UNIT_ID__Parameter__, this );
    m_ParameterList.Add( UNIT_ID__Parameter__, UNIT_ID );
    
    START_ADDRESS = new UShortParameter( START_ADDRESS__Parameter__, this );
    m_ParameterList.Add( START_ADDRESS__Parameter__, START_ADDRESS );
    
    COUNT_COIL = new UShortParameter( COUNT_COIL__Parameter__, this );
    m_ParameterList.Add( COUNT_COIL__Parameter__, COUNT_COIL );
    
    SEND_REACTION = new UShortParameter( SEND_REACTION__Parameter__, this );
    m_ParameterList.Add( SEND_REACTION__Parameter__, SEND_REACTION );
    
    
    POLL_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ALL_OnPush_0, false ) );
    SEND_ALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_ALL_OnPush_1, false ) );
    for( uint i = 0; i < 100; i++ )
        ON_[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ON__OnPush_2, false ) );
        
    for( uint i = 0; i < 100; i++ )
        OFF_[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( OFF__OnPush_3, false ) );
        
    FROM_PROCESSOR.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_PROCESSOR_OnChange_4, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MODBUS_TCP_READ_AND_WRITE_COILS_V1_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint POLL_ALL__DigitalInput__ = 0;
const uint SEND_ALL__DigitalInput__ = 1;
const uint ON___DigitalInput__ = 2;
const uint OFF___DigitalInput__ = 102;
const uint FROM_PROCESSOR__AnalogSerialInput__ = 0;
const uint ON_FB__DigitalOutput__ = 0;
const uint OFF_FB__DigitalOutput__ = 100;
const uint TO_PROCESSOR__AnalogSerialOutput__ = 0;
const uint UNIT_ID__Parameter__ = 10;
const uint START_ADDRESS__Parameter__ = 11;
const uint COUNT_COIL__Parameter__ = 12;
const uint SEND_REACTION__Parameter__ = 13;

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
