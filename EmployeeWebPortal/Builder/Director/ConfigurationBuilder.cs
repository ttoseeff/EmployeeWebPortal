using EmployeeWebPortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Builder.Director
{
    public class ConfigurationBuilder
    {
        public void BuildSystem(ISystemBuilder systemBuilder, NameValueCollection collection)
        {
            systemBuilder.AddDrive(collection["HDDSize"])
                .AddMemory(collection["RAM"])
                .AddKeyboard(collection["Keyboard"])
                .AddMouse(collection["Mouse"])
                .AddTouchScreen(collection["TouchScreen"]);
        }
    }
}