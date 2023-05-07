using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm08_Class
{
	/// <summary>
	/// 클래스
	/// </summary>
	class UserClass
	{
		public void StudyClass()
		{
			Student01 std = new Student01(); //new라는 키워드를 통해 클래스 인스턴스를 생성함.

			std.Name = "Kim"; //인스턴스 변수 접근 시 점을 사용함
			std.Math = 90;
			std.English = 86;

			std.GetAverage();  //인스턴스 메소드 접근 시 점을 사용함.
		}
	}

	class Student01
	{
		public string Name;
		public int Math;
		public int English;

		public Student01() { } //기본 생성자 : 생성자 없으면 자동생성, 있으면 안 만들어짐


		public Student01(string name) //생성자 오버로딩 1
		{
			Name = name;
		}

		public Student01(string name, int math, int eng) //생성자 오버로딩 2 
		{
			Name = name;
			Math = math;
			English = eng;
		}

		public float GetAverage()
		{
			return (Math + English) / 2f;
		}
	}
}
