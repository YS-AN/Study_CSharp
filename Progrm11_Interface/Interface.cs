using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface
{
	internal class StudyInterface
	{
		class InterfaceInheritance : IInterfaceBasic1, IInterfaceBasic2
		{
			//인터페이스 내용을 반드시 구현해줘야함.
			public void BasicFunc1()
			{
				//todo.BasicFunc1 내용 구현
			}

			public void BasicFunc2()
			{
				//todo.BasicFunc2 내용 구현
			}

			public void BasicFunc3()
			{
				//todo.BasicFunc3 내용 구현
			}

			public void BasicFunc4()
			{
				//todo.BasicFunc4 내용 구현
			}
		}
	}
}
