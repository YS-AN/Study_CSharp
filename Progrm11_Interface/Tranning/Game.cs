using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;
using System.Threading.Channels;
using Progrm11_Interface.Tranning.ChampionObject;

namespace Progrm11_Interface.Tranning
{
    internal class Game
	{
        public void PlayGame()
        {
			Champion Garen = new Champion("가렌", 690, 690, 66);
			Champion Mundo = new Champion("문도박사", 613, 613, 61);
            ChampionWithMana Caitlyn = new ChampionWithMana("케이틀린", 580, 580, 60, 315, 315, 20);
			ChampionWithMana Seraphine = new ChampionWithMana("세라핀", 570, 570, 55, 440, 440, 15);

            Minion minion1 = new Minion(296, 24);
			Minion minion2 = new Minion(296, 24);
			Minion minion3 = new Minion(296, 24);
			Minion minion4 = new Minion(296, 24);
			Minion minion5 = new Minion(296, 24);

			Skill skill; 

			Garen.AddSkill(new Skill("심판", SkillButton.W, 9, 72));
			Mundo.AddSkill(new Skill("오염된 뼈톱", SkillButton.Q, 4, 80));
			Caitlyn.AddSkill(new Skill("필트오버피스메이커", SkillButton.Q, 10, 90));
			Seraphine.AddSkill(new Skill("비트발사", SkillButton.E, 10, 75));

			Seraphine.TakeDamage(Garen.GiveDamage(SkillButton.W));
			Mundo.TakeDamage(Seraphine.GiveDamage(SkillButton.E));

			for (int i=0; i<10; i++)
			{
				Seraphine.TakeDamage(minion1.GiveDamage(SkillButton.None));
				Seraphine.TakeDamage(minion2.GiveDamage(SkillButton.None));
				Seraphine.TakeDamage(minion3.GiveDamage(SkillButton.None));
				Seraphine.TakeDamage(minion4.GiveDamage(SkillButton.None));
				Seraphine.TakeDamage(minion5.GiveDamage(SkillButton.None));
			}

			Seraphine.TakeDamage(Mundo.GiveDamage(SkillButton.Q));
		}
    }
}