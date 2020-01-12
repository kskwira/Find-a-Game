using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Find_a_Game.Models
{
    public enum Platforma
    {
        Nintendo,
        [Display(Name = "Nintendo Switch")]
        Nintendo_Switch,
        [Display(Name = "Nintendo Wii")]
        Nintendo_Wii,
        [Display(Name = "Nintendo Wii U")]
        Nintendo_Wii_U,
        PC,
        PS1,
        PS2,
        PS3,
        PS4,
        Xbox,
        [Display(Name = "Xbox 360")]
        Xbox_360,
        [Display(Name = "Xbox One")]
        Xbox_One
    }
}