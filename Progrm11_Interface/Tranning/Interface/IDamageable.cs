using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Tranning;

namespace Progrm11_Interface.Tranning.Interface
{
	public interface IDamageable
	{
		public void TakeDamage(Skill skill);

		public Skill GiveDamage(SkillButton btn);
	}
}


