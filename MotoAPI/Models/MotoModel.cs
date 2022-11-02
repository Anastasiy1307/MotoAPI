using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotoAPI.Entities;

namespace MotoAPI.Models
{
    public class MotoModel
    {

        public MotoModel(moto Moto)
        {
            ID = Moto.ID;
            Name = Moto.Name;
            Speed = Moto.Speed;           
            Power = Moto.Power;
            Image = Moto.Image;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Power { get; set; }
        public string Image { get; set; }
    }
}