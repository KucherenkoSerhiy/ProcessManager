﻿namespace ProcessManager.Process.Application.Process.AppServices
{
    using System.Collections.Generic;
    using Models;

    public interface IGetProcessesAppService
    {
        IEnumerable<ProcessDto> Get();
    }
}