﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public interface INavigatorViewModel
    {
        void NavigateTo(EPageViewControl viewType);
        void NavigateTo(IPageViewModel viewType);
    }
}
