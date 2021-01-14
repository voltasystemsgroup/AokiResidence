namespace HiveLabs.SP;
        // class declarations
         class SPlusAccess;
     class SPlusAccess 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace HiveLabs.DataSelector;
        // class declarations
         class DataSelector;
           class GetAnalogArray;
           class SetAnalogArray;
     class DataSelector 
    {
        // class delegates
        delegate INTEGER_FUNCTION GetAnalogArray ( INTEGER index );
        delegate FUNCTION SetAnalogArray ( INTEGER index , INTEGER value );

        // class events

        // class functions
        FUNCTION DataSelectorMain ( INTEGER maxIO , INTEGER maxItems );
        FUNCTION ChangeInput ( INTEGER inputIndex , INTEGER dataIndex );
        FUNCTION ChangeData ( INTEGER dataIndex );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty GetAnalogArray _Input;
        DelegateProperty SetAnalogArray _Output;
    };

