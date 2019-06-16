namespace PhotoLocator
{
    public class RenameResult
    {
        internal RenameResult(RenameResultType result)
        {
            Result = result;
        }

        internal RenameResult(RenameResultType result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }

        public RenameResultType Result { get; }

        public string ErrorMessage { get; }

        public static RenameResult Success()
        {
            return new RenameResult(RenameResultType.Renamed);
        }

        public static RenameResult NoChange()
        {
            return new RenameResult(RenameResultType.NoChange);
        }

        public static RenameResult Error(string message)
        {
            return new RenameResult(RenameResultType.Error, message);
        }
    }
}
