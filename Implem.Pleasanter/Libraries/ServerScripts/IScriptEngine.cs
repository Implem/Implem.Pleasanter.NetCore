﻿using System;
namespace Implem.Pleasanter.Models
{
    public interface IScriptEngine : IDisposable
    {
        Func<bool> ContinuationCallback { set; }
        void AddHostObject(string itemName, object target);
        void Execute(string code);
    }
}
