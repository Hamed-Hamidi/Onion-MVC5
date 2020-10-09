using System;
using System.Collections.Generic;
using Onion.Data.Site;

namespace Onion.Service.Interfaces
{
    public interface ISliderService : IDisposable
    {
        void InsertSlider(Slider slider);
        List<Slider> GetAllSliders();
        Slider GetSliderById(int sliderId);
        List<Slider> GetActivatedSliders();
        void EditSlider(Slider slider);
    }
}