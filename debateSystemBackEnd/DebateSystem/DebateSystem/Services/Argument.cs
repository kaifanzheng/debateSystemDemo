using System;
namespace DebateSystem.Services
{
    public static class Argument
    {
        public static T NotNull<T>(T argument, string argumentName) where T : class
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return argument;
        }
    }
}