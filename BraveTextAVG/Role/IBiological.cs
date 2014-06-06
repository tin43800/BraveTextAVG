using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveTextAVG
{
    interface IBiological
    {
        int Hp { get; set; }
        int TmpHp { get; }
        int MaxHp { get; }
        int Attack_Damage { get; }
        int Skill_Damage { get; }
        int Money { get; set; }
    }
}
