using GanzenBoardGame.Application.Modals.Enums;
using GanzenBoardGame.Application.Modals.Locations;
using GanzenBoardGame.SharedKernal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GanzenBoardGame.Application.Modals
{
    public class Pion : IEquatable<Pion>
    {
        public int Id;
        public PionType PionType;
        public Kleuren Kleur;

        public Location Locatie;

        public bool Equals(Pion other)
        {
            if (other is null)
                return false;

            return this.Id == other.Id && this.PionType == other.PionType && this.Kleur == other.Kleur;
        }

        public override bool Equals(object obj) => Equals(obj as Pion);
        public override int GetHashCode() => (Id, Kleur, PionType).GetHashCode();

        public override string ToString()
        {
            return $"Pion: id = {Id}  type = {PionType} kleur = {Kleur}";
        }

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
