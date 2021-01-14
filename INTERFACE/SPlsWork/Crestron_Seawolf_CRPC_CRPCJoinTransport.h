namespace Crestron.Seawolf.CRPC;
        // class declarations
         class JoinTransportServerBase;
         class JoinTransportClientBase;
     class JoinTransportServerBase 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION AddFilter ( STRING name );
        FUNCTION RemoveFilter ( STRING name );
        FUNCTION CloseClientTransports ();
        FUNCTION CloseClientTransport ( STRING tag );
        FUNCTION OnJoinData ( STRING pkt );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static SIGNED_LONG_INTEGER ENCODING;

        // class properties
        STRING Type[];
        LONG_INTEGER IpId;
    };

