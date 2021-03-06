﻿using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface ITestStatusRepository
    {
       IEnumerable<TestStatus> GetStatuses();
    }
}
