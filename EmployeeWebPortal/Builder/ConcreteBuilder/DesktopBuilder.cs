﻿using EmployeeWebPortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Builder.ConcreteBuilder
{
    public class DesktopBuilder : ISystemBuilder
    {
        ComputerSystem desktop = new ComputerSystem();  
        public ISystemBuilder AddDrive(string size)
        {
            desktop.HDDSize = size;
            return this;
        }

        public ISystemBuilder AddKeyboard(string type)
        {
            desktop.Keyboard = type;
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            desktop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            desktop.Mouse= type;
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            return this;
        }

        public ComputerSystem GetSystem()
        {
            return desktop;
        }
    }
}