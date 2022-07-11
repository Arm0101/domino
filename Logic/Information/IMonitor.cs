﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IMonitor : IObserver<Info>
    {
        public void Unsubscribe();

        public void Subscribe(InfoHandler provider);
      
    }
}