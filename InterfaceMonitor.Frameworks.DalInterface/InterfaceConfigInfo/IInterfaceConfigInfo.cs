﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    public interface IInterfaceConfigInfo
    {
        void SaveInterfaceConfigInfo(InterfaceConfigInfo entity);
    }
}
