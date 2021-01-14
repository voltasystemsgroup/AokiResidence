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

namespace CrestronModule_SERIAL_PROTOCOL
{
    public class CrestronModuleClass_SERIAL_PROTOCOL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.StringInput PATH__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> COMMANDRX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> COMMANDTX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ROUTETOLOADS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ROUTETOSCENES;
        CrestronString STOREDCOMMANDSTRING;
        CrestronString G_LOADS_FILE__DOLLAR__;
        CrestronString G_ROOM_FILE__DOLLAR__;
        CrestronString G_SCENE_FILE__DOLLAR__;
        CrestronString G_AREA_FILE__DOLLAR__;
        ushort G_COMMAND_HANDLER = 0;
        ushort G_CURRENTSCENECOUNT = 0;
        private void SENDRESPONSE (  SplusExecutionContext __context__, ushort INDEX , ushort DATATYPE , CrestronString RESPONSE ) 
            { 
            
            __context__.SourceCodeLine = 141;
            COMMANDTX__DOLLAR__ [ INDEX]  .UpdateValue ( "/" + Functions.Chr (  (int) ( (Byte( STOREDCOMMANDSTRING , (int)( 2 ) ) | 128) ) ) + Functions.Chr (  (int) ( Byte( STOREDCOMMANDSTRING , (int)( 3 ) ) ) ) + Functions.Chr (  (int) ( DATATYPE ) ) + RESPONSE + "\\"  ) ; 
            
            }
            
        private void SENDSCENELOAD (  SplusExecutionContext __context__, ushort INDEX ) 
            { 
            
            __context__.SourceCodeLine = 146;
            STOREDCOMMANDSTRING  .UpdateValue ( "/" + Functions.Chr (  (int) ( 81 ) ) + Functions.Chr (  (int) ( 0 ) ) + Functions.Chr (  (int) ( 52 ) ) + Functions.Chr (  (int) ( 81 ) ) + "\\"  ) ; 
            __context__.SourceCodeLine = 147;
            MakeString ( ROUTETOSCENES [ INDEX] , "001{0}", STOREDCOMMANDSTRING ) ; 
            
            }
            
        private ushort COMMANDHANDLER (  SplusExecutionContext __context__, ushort INDEX ) 
            { 
            ushort ROUTINGID = 0;
            ushort ROOMNUM = 0;
            ushort AREANUM = 0;
            
            ushort CMD = 0;
            ushort TEMP = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 155;
            
            __context__.SourceCodeLine = 159;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( STOREDCOMMANDSTRING ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 160;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 162;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( STOREDCOMMANDSTRING , (int)( 1 ) ) != Byte( "/" , (int)( 1 ) )))  ) ) 
                { 
                __context__.SourceCodeLine = 164;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) > 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 166;
                    TEMP = (ushort) ( Functions.Atoi( Functions.Mid( STOREDCOMMANDSTRING , (int)( 5 ) , (int)( 4 ) ) ) ) ; 
                    __context__.SourceCodeLine = 167;
                    MakeString ( TEMPSTRING , "{0:d}{1}{2}{3}{4}", (short)TEMP, "," , "-1" , "," , "Framing Error" ) ; 
                    __context__.SourceCodeLine = 168;
                    SENDRESPONSE (  __context__ , (ushort)( INDEX ), (ushort)( 255 ), TEMPSTRING) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 172;
                    TEMPSTRING  .UpdateValue ( "-1" + "," + "Framing Error"  ) ; 
                    __context__.SourceCodeLine = 173;
                    SENDRESPONSE (  __context__ , (ushort)( INDEX ), (ushort)( 255 ), TEMPSTRING) ; 
                    } 
                
                __context__.SourceCodeLine = 175;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 177;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) < 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 179;
                TEMPSTRING  .UpdateValue ( "-1" + "," + "Invalid Command"  ) ; 
                __context__.SourceCodeLine = 180;
                SENDRESPONSE (  __context__ , (ushort)( INDEX ), (ushort)( 255 ), TEMPSTRING) ; 
                __context__.SourceCodeLine = 181;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 184;
            switch ((int)Byte( STOREDCOMMANDSTRING , (int)( 2 ) ))
            
                { 
                case 81 : 
                
                    { 
                    __context__.SourceCodeLine = 188;
                    
                    __context__.SourceCodeLine = 192;
                    G_CURRENTSCENECOUNT = (ushort) ( (G_CURRENTSCENECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 193;
                    ROUTINGID = (ushort) ( G_CURRENTSCENECOUNT ) ; 
                    __context__.SourceCodeLine = 194;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IsSignalDefined( ROUTETOSCENES[ ROUTINGID ] ) != 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 195;
                        SENDSCENELOAD (  __context__ , (ushort)( ROUTINGID )) ; 
                        }
                    
                    __context__.SourceCodeLine = 196;
                    break ; 
                    } 
                
                break;
                } 
                
            
            
            return 0; // default return value (none specified in module)
            }
            
        object COMMANDRX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort INDEX = 0;
                
                
                __context__.SourceCodeLine = 204;
                INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 205;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( COMMANDRX__DOLLAR__[ INDEX ] ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 207;
                    while ( Functions.TestForTrue  ( ( G_COMMAND_HANDLER)  ) ) 
                        {
                        __context__.SourceCodeLine = 208;
                        Functions.ProcessLogic ( ) ; 
                        __context__.SourceCodeLine = 207;
                        }
                    
                    __context__.SourceCodeLine = 210;
                    G_COMMAND_HANDLER = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 211;
                    STOREDCOMMANDSTRING  .UpdateValue ( Functions.Remove ( "\\" , COMMANDRX__DOLLAR__ [ INDEX ] , 1)  ) ; 
                    __context__.SourceCodeLine = 212;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STOREDCOMMANDSTRING ) > 0 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 213;
                        COMMANDHANDLER (  __context__ , (ushort)( INDEX )) ; 
                        }
                    
                    __context__.SourceCodeLine = 214;
                    G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 205;
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
            
            __context__.SourceCodeLine = 220;
            G_COMMAND_HANDLER = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 221;
            G_CURRENTSCENECOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 222;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 223;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IsSignalDefined( ROUTETOSCENES[ 1 ] ) != 0))  ) ) 
                {
                __context__.SourceCodeLine = 224;
                SENDSCENELOAD (  __context__ , (ushort)( 1 )) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        STOREDCOMMANDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        G_LOADS_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
        G_ROOM_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
        G_SCENE_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
        G_AREA_FILE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 96, this );
        
        PATH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( PATH__DOLLAR____AnalogSerialInput__, 64, this );
        m_StringInputList.Add( PATH__DOLLAR____AnalogSerialInput__, PATH__DOLLAR__ );
        
        COMMANDTX__DOLLAR__ = new InOutArray<StringOutput>( 10, this );
        for( uint i = 0; i < 10; i++ )
        {
            COMMANDTX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( COMMANDTX__DOLLAR____AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( COMMANDTX__DOLLAR____AnalogSerialOutput__ + i, COMMANDTX__DOLLAR__[i+1] );
        }
        
        ROUTETOLOADS = new InOutArray<StringOutput>( 500, this );
        for( uint i = 0; i < 500; i++ )
        {
            ROUTETOLOADS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ROUTETOLOADS__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( ROUTETOLOADS__AnalogSerialOutput__ + i, ROUTETOLOADS[i+1] );
        }
        
        ROUTETOSCENES = new InOutArray<StringOutput>( 500, this );
        for( uint i = 0; i < 500; i++ )
        {
            ROUTETOSCENES[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ROUTETOSCENES__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( ROUTETOSCENES__AnalogSerialOutput__ + i, ROUTETOSCENES[i+1] );
        }
        
        COMMANDRX__DOLLAR__ = new InOutArray<BufferInput>( 10, this );
        for( uint i = 0; i < 10; i++ )
        {
            COMMANDRX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.BufferInput( COMMANDRX__DOLLAR____AnalogSerialInput__ + i, COMMANDRX__DOLLAR____AnalogSerialInput__, 768, this );
            m_StringInputList.Add( COMMANDRX__DOLLAR____AnalogSerialInput__ + i, COMMANDRX__DOLLAR__[i+1] );
        }
        
        
        for( uint i = 0; i < 10; i++ )
            COMMANDRX__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( COMMANDRX__DOLLAR___OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_SERIAL_PROTOCOL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint PATH__DOLLAR____AnalogSerialInput__ = 0;
    const uint COMMANDRX__DOLLAR____AnalogSerialInput__ = 1;
    const uint COMMANDTX__DOLLAR____AnalogSerialOutput__ = 0;
    const uint ROUTETOLOADS__AnalogSerialOutput__ = 10;
    const uint ROUTETOSCENES__AnalogSerialOutput__ = 510;
    
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
