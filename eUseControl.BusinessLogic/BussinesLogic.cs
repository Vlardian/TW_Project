﻿using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession getSessionBL()
        {
            return new SessionBL();
        }

        public IProduct getProductBL()
        {
            return new ProductBL();
        }
    }
}
