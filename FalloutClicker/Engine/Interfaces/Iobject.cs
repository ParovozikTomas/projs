﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutClicker
{
    interface Iobjekt
    {
        void add(player player, int times);
        void setAmount(player player, int a);
        string dprice(int times);
        double Dprice(int times);
    }
}
