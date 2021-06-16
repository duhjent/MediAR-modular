﻿using System;
using System.Collections.Generic;

namespace MediAR.Core.Domain
{
    class InvalidCommandException : Exception
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
