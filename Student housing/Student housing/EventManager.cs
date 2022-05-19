﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class EventManager
    {
        private List<Events> events = new List<Events>();

        public void AddEvent(Events newEvent)
        {
            events.Add(newEvent);
        }
        public void RemoveEvent(int index)
        {
            events.RemoveAt(index);
        }
        public Events[] GetEvents()
        {
            return events.ToArray();
        }
    }
}
