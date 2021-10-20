using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Game.Handlers
{
    public class Error
    {
        public ErrorCode errorcode;

        public Error(ErrorCode errorcode) {
            this.errorcode = errorcode;
        }

        public enum ErrorCode {
            PlayerAdded = 0,
            PlayerAlreadyAdded = 1,
        }
    }
}
