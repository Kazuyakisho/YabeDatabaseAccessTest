using BacnetLibrary.BACnetBase.BACnetEnum;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetError
    {
        public BacnetErrorClasses error_class;
        public BacnetErrorCodes error_code;
        public BacnetError(BacnetErrorClasses error_class, BacnetErrorCodes error_code)
        {
            this.error_class = error_class;
            this.error_code = error_code;
        }
        public BacnetError(uint error_class, uint error_code)
        {
            this.error_class = (BacnetErrorClasses)error_class;
            this.error_code = (BacnetErrorCodes)error_code;
        }
        public override string ToString()
        {
            return error_class + ": " + error_code;
        }
    }

}
