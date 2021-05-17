using GanzenBord2.Models.Enums;
using GanzenBord2.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class Pion
    {
        public int Id;
        public PionType PionType;
        public Kleuren Kleur;

        public static List<Pion> mogelijkePionnen = new List<Pion>()
        {
            new Pion(){ 
                Id = 1,
                PionType = PionType.Brandganzen, 
                Kleur = Kleuren.GEEL 
            },
            new Pion(){
                Id = 2,
                PionType = PionType.Brandganzen,
                Kleur = Kleuren.BLAUW
            },
            new Pion(){
                Id = 3,
                PionType = PionType.Brandganzen,
                Kleur = Kleuren.GROEN
            },
            new Pion(){
                Id = 4,
                PionType = PionType.Brandganzen,
                Kleur = Kleuren.PAARS
            },
            new Pion(){
                Id = 5,
                PionType = PionType.Canadaganzen,
                Kleur = Kleuren.GEEL
            },
            new Pion(){
                Id = 6,
                PionType = PionType.Canadaganzen,
                Kleur = Kleuren.BLAUW
            },
            new Pion(){
                Id = 7,
                PionType = PionType.Canadaganzen,
                Kleur = Kleuren.GROEN
            },
            new Pion(){
                Id = 8,
                PionType = PionType.Canadaganzen,
                Kleur = Kleuren.PAARS
            }
        };
    }
}
